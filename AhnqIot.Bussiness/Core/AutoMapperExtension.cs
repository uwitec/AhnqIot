#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Bussiness
// FILENAME   ： AutoMapperExtension.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-18 11:07
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
/*
using AutoMapper;
using AutoMapper.QueryableExtensions;
*/

#endregion

namespace AhnqIot.Bussiness.Core
{
    public static class LambdaExpressionExtensions
    {
        private static Expression Parser(ParameterExpression parameter, Expression expression)
        {
            if (expression == null) return null;
            switch (expression.NodeType)
            {
                //一元运算符
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.ArrayLength:
                case ExpressionType.Quote:
                case ExpressionType.TypeAs:
                    {
                        var unary = expression as UnaryExpression;
                        var exp = Parser(parameter, unary.Operand);
                        return Expression.MakeUnary(expression.NodeType, exp, unary.Type, unary.Method);
                    }
                //二元运算符
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Divide:
                case ExpressionType.Modulo:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.Coalesce:
                case ExpressionType.ArrayIndex:
                case ExpressionType.RightShift:
                case ExpressionType.LeftShift:
                case ExpressionType.ExclusiveOr:
                    {
                        var binary = expression as BinaryExpression;
                        var left = Parser(parameter, binary.Left);
                        var right = Parser(parameter, binary.Right);
                        var conversion = Parser(parameter, binary.Conversion);
                        if (binary.NodeType == ExpressionType.Coalesce && binary.Conversion != null)
                        {
                            return Expression.Coalesce(left, right, conversion as LambdaExpression);
                        }
                        else
                        {
                            return Expression.MakeBinary(expression.NodeType, left, right, binary.IsLiftedToNull, binary.Method);
                        }
                    }
                //其他
                case ExpressionType.Call:
                    {
                        var call = expression as MethodCallExpression;
                        List<Expression> arguments = new List<Expression>();
                        foreach (var argument in call.Arguments)
                        {
                            arguments.Add(Parser(parameter, argument));
                        }
                        var instance = Parser(parameter, call.Object);
                        call = Expression.Call(instance, call.Method, arguments);
                        return call;
                    }
                case ExpressionType.Lambda:
                    {
                        var Lambda = expression as LambdaExpression;
                        return Parser(parameter, Lambda.Body);
                    }
                case ExpressionType.MemberAccess:
                    {
                        var memberAccess = expression as MemberExpression;
                        if (memberAccess.Expression == null)
                        {
                            memberAccess = Expression.MakeMemberAccess(null, memberAccess.Member);
                        }
                        else
                        {
                            var exp = Parser(parameter, memberAccess.Expression);
                            var member = exp.Type.GetMember(memberAccess.Member.Name).FirstOrDefault();
                            memberAccess = Expression.MakeMemberAccess(exp, member);
                        }
                        return memberAccess;
                    }
                case ExpressionType.Parameter:
                    return parameter;
                case ExpressionType.Constant:
                    return expression;
                case ExpressionType.TypeIs:
                    {
                        var typeis = expression as TypeBinaryExpression;
                        var exp = Parser(parameter, typeis.Expression);
                        return Expression.TypeIs(exp, typeis.TypeOperand);
                    }
                default:
                    throw new Exception(string.Format("Unhandled expression type: '{0}'", expression.NodeType));
            }
        }
        public static Expression<Func<TToProperty, bool>> MapExpression<TInput, TToProperty>(this Expression<Func<TInput, bool>> expression)
        {
            var p = Expression.Parameter(typeof(TToProperty), "p");
            var x = Parser(p, expression);
            return Expression.Lambda<Func<TToProperty, bool>>(x, p);
        }
    }
    
    /*
    public static class FunctionCompositionExtensions
    {
        private static readonly ConcurrentDictionary<Tuple<Type, Type>, Tuple<MethodInfo, Expression>> Dictionary =
            new ConcurrentDictionary<Tuple<Type, Type>, Tuple<MethodInfo, Expression>>();

        private static readonly MethodInfo Method = typeof(FunctionCompositionExtensions).GetMethod("Compose",
            BindingFlags.NonPublic | BindingFlags.Static);

        public static Expression<Func<TDestination, bool>> MapExpression<TSource, TDestination>(
            this Expression<Func<TSource, bool>> selector)
        {
            var bulidMethod = Dictionary.GetOrAdd(new Tuple<Type, Type>(typeof(TSource), typeof(TDestination)), _ =>
          {
              var expression = Mapper.Engine.CreateMapExpression<TDestination, TSource>();
              return new Tuple<MethodInfo, Expression>(
                  Method.MakeGenericMethod(typeof(TDestination), typeof(bool), typeof(TSource)), expression);
          });
            return
                bulidMethod.Item1.Invoke(null, new object[] { selector, bulidMethod.Item2 }) as
                    Expression<Func<TDestination, bool>>;
        }

        //void MapFrom<TMember>(Expression<Func<TSource, TMember>> sourceMember);
        public static Expression<Func<TDestination, TResult>> Compose<TSource, TDestination, TResult>(this Expression<Func<TSource, TResult>> outer,
            Expression<Func<TSource, TDestination>> inner)
        {
            var exp = ParameterReplacer.Replace(outer.Body, outer.Parameters[0], inner.Body);
            return Expression.Lambda<Func<TDestination, TResult>>(exp, inner.Parameters[0]);
        }

        public static Expression<Predicate<TDestination>> ComposePredicate<TSource, TDestination>(this Expression<Predicate<TSource>> outer,
            Expression<Func<TDestination, TSource>> inner)
        {
            return Expression.Lambda<Predicate<TDestination>>(
                ParameterReplacer.Replace(outer.Body, outer.Parameters[0], inner.Body),
                inner.Parameters[0]);
        }
    }

    class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;
        private readonly Expression _replacement;

        private ParameterReplacer(ParameterExpression parameter, Expression replacement)
        {
            _parameter = parameter;
            _replacement = replacement;
        }

        public static Expression Replace(Expression expression, ParameterExpression parameter, Expression replacement)
        {
            return new ParameterReplacer(parameter, replacement).Visit(expression);
        }

        protected override Expression VisitParameter(ParameterExpression parameter)
        {
            if (parameter == _parameter)
            {
                return _replacement;
            }
            return base.VisitParameter(parameter);
        }
    }*/
}