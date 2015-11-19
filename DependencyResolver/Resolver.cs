using BLL.Interface.Services;
using BLL.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyResolver
{
    public static class Resolver
    {
        public static void ConfigureteResolver(this IKernel kernel)
        {
            kernel.Bind<ITestListService>().To<TestListService>();
        }
    }
}
