using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.DataProcess.Service.Core
{
  public  class SqlHelper
    {
        private  String _SchemaSql = "";
        private const bool IsSQL2005 = false;
        /// <summary>
        /// 获取所有表名
        /// </summary>
        private readonly string _GetTableNames = "Select Name FROM SysObjects Where XType='U' and left(Name,1)='M' and left(name,2)<>'MH' and LEN(name)=6 orDER BY Name";
        /// <summary>
        /// 获取数据库所有表名
        /// </summary>
        public virtual String GetTableNames => _GetTableNames;

        /// <summary>
        /// 获取表中所有字段
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static String GetTableMember(string tableName)
        {
            return "SELECT Name FROM SysColumns WHERE id=Object_Id('" + tableName + "')";
        }
        private readonly String _DescriptionSql2000 = "select b.name n, a.value v from sysproperties a inner join sysobjects b on a.id=b.id where a.smallid=0";
        private readonly String _DescriptionSql2005 = "select b.name n, a.value v from sys.extended_properties a inner join sysobjects b on a.major_id=b.id and a.minor_id=0 and a.name = 'MS_Description'";
        /// <summary>取表说明SQL</summary>
        public virtual String DescriptionSql { get { return IsSQL2005 ? _DescriptionSql2005 : _DescriptionSql2000; } }
        /// <summary>构架SQL</summary>
        public virtual String SchemaSql
        {
            get
            {
                if (String.IsNullOrEmpty(_SchemaSql))
                {
                    var sb = new StringBuilder();
                    sb.Append("SELECT ");
                    sb.Append("表名=d.name,");
                    sb.Append("字段序号=a.colorder,");
                    sb.Append("字段名=a.name,");
                    sb.Append("标识=case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then Convert(Bit,1) else Convert(Bit,0) end,");
                    sb.Append("主键=case when exists(SELECT 1 FROM sysobjects where xtype='PK' and name in (");
                    sb.Append("SELECT name FROM sysindexes WHERE id = a.id AND indid in(");
                    sb.Append("SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid");
                    sb.Append("))) then Convert(Bit,1) else Convert(Bit,0) end,");
                    sb.Append("类型=b.name,");
                    sb.Append("占用字节数=a.length,");
                    sb.Append("长度=COLUMNPROPERTY(a.id,a.name,'PRECISION'),");
                    sb.Append("小数位数=isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0),");
                    sb.Append("允许空=case when a.isnullable=1 then Convert(Bit,1)else Convert(Bit,0) end,");
                    sb.Append("默认值=isnull(e.text,''),");
                    sb.Append("字段说明=isnull(g.[value],'')");
                    sb.Append("FROM syscolumns a ");
                    sb.Append("left join systypes b on a.xtype=b.xusertype ");
                    sb.Append("inner join sysobjects d on a.id=d.id  and d.xtype='U' ");
                    sb.Append("left join syscomments e on a.cdefault=e.id ");
                    if (IsSQL2005)
                    {
                        sb.Append("left join sys.extended_properties g on a.id=g.major_id and a.colid=g.minor_id and g.name = 'MS_Description'  ");
                    }
                    else
                    {
                        sb.Append("left join sysproperties g on a.id=g.id and a.colid=g.smallid  ");
                    }
                    sb.Append("order by a.id,a.colorder");
                    _SchemaSql = sb.ToString();
                }
                return _SchemaSql;
            }
        }

        //private static String _IndexSql;
        //public static String IndexSql
        //{
        //    get
        //    {
        //        if (_IndexSql == null)
        //        {
        //            if (IsSQL2005)
        //                _IndexSql = "select ind.* from sys.indexes ind inner join sys.objects obj on ind.object_id = obj.object_id where obj.type='u'";
        //            else
        //                _IndexSql = "select IndexProperty(obj.id, ind.name,'IsUnique') as is_unique, ObjectProperty(object_id(ind.name),'IsPrimaryKey') as is_primary_key,ind.* from sysindexes ind inner join sysobjects obj on ind.id = obj.id where obj.type='u'";
        //        }
        //        return _IndexSql;
        //    }
        //}

  
    }
}
