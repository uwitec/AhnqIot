//#region Code File Comment
//// SOLUTION   ： 安徽农业气象物联网V3
//// PROJECT    ： ahnqiot.Ef.Test
//// FILENAME   ： TestUnit.cs
//// AUTHOR     ： soft-cq
//// CREATE TIME： 2016-01-13 21:47
//// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015
//#endregion

//using System;
//using Microsoft.Practices.Unity;

//namespace ahnqiot.Ef.Test
//{
//    public class TestUnit
//    {
//        public void Test()
//        {
//            IUnityContainer container = new UnityContainer();
//            container.RegisterType(typeof(I_0<A>), typeof(A), "A");
//            //container.RegisterType(typeof(I_0<B>), typeof(B));
//            container.RegisterType(typeof(I_0<>).MakeGenericType(typeof(B)), typeof(B));

//            var ta = container.Resolve(typeof(I_0<A>), "A");
//            var tb = container.Resolve(typeof(I_0<B>));

//            container.RegisterType<C>();
//            var tc = container.Resolve<C>();
//            Console.WriteLine(tc.ToString());
//        }
//    }

//    public interface I_0<T> where T : class { }

//    public interface I_1<T> : I_0<T> where T : class { } 

//    public class c_0
//    {
//    }

//    public class A : I_1<c_0>
//    {

//    }

//    public class B : I_1<c_0>
//    {

//    }

//    public class C
//    {
//        [Dependency]
//        public A ac { get; set; }

//        [Dependency]
//        public B bc { get; set; }

//        public override string ToString()
//        {
//            return string.Format("A:{0},B:{1}", nameof(ac), nameof(bc));
//        }
//    }
//}