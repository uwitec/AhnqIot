using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Hxj.Repository.Base;
using AhnqIot.Hxj.Repository.Helper;
using Dos.ORM;

namespace AhnqIot.Hxj.Repository.AhnqIot
{
    public class AhnqIotRepository<T> : RepositoryBase<T>, IAhnqIotRepository<T>
         where T : Entity
    {

        public override void Delete(string id)
        {
            base.Delete(id);
        }
    }
}
