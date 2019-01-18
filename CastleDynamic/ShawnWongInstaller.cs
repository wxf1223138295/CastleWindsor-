using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CastleDynamic.Common;

namespace CastleDynamic
{
    //安装器1
    internal class ShawnWongInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //注册组件
            container.Register(
                Component.For<IShopping,Shopping>().
                    ImplementedBy<Shopping>().LifestyleTransient()
            );
        }
    }
}
