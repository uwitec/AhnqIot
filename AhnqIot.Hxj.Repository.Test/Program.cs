using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhnqIot.Infrastructure.DI;
using Autofac;

namespace AhnqIot.Hxj.Repository.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            AhnqIotContainer.Builder = builder;
            RepositoryBootStraper.Start();


            Console.ReadLine();
        }
    }
}
