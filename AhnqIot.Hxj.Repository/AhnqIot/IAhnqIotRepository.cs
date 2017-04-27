using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Hxj.Repository.Base;
using Dos.ORM;

namespace AhnqIot.Hxj.Repository.AhnqIot
{
    public interface IAhnqIotRepository<T> : IRepositoryBase<T> where T : Entity
    {
    }
}
