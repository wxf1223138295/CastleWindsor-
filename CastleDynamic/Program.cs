using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor.Installer;
using CastleAssemly;
using CastleDynamic.Castle;
using CastleDynamic.Common;

namespace CastleDynamic
{
    class Program
    {
        static void Main(string[] args)
        {          
            //Install
            IocManager.Instance.IocContainer.Install(
                //1.安装器
                new ShawnWongInstaller(),
                //方式二：顾名思义
                //1:反射需要注册的程序集
                FromAssembly.Instance(typeof(IPerson).Assembly)
                //2:按名字
                //3
            );


            //规约注册
            IocManager.Instance.IocContainer.Register(
                Classes.FromAssembly(typeof(IPerson).Assembly)                 
                .Where(p => p.Name.EndsWith("Repository"))
                .WithService.AllInterfaces().LifestyleTransient());


          var r= IocManager.Instance.Resolve<IShopping>().shopshoes(180);

            var t = IocManager.Instance.Resolve<IPerson>().MyName("sss");

            var e = IocManager.Instance.Resolve<IPerson>().yourname("rrr");


            var y = IocManager.Instance.Resolve<ITestRepository>().testConservtion(6);






            //ShoppingInterceptor inte=new ShoppingInterceptor(100);

            //ProxyGenerator getGenerator=new ProxyGenerator();

            //var t = getGenerator.CreateClassProxy<Shopping>(inte);
            //t.shopshoes(120);

            //IocManager.Instance.IocContainer.Register(
            //    Component.For(typeof(IShopping))
            //        .ImplementedBy(typeof(Shopping))

            //);

            //IocManager.Instance.Resolve<IShopping>().shopshoes(180);

            Console.ReadLine();

        }


    }
}
