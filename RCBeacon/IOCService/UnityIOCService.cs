﻿
using Microsoft.Practices.Unity;
using PersistanceService;
using WebService;

namespace IOCService
{
    public class UnityIOCService
    {
        public static UnityContainer Container { get; private set; }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>(new ResolverOverride[0]);
        }

        public static void Initialize(UnityContainer container = null)
        {
            Container = container ?? new UnityContainer();

            Container
                .RegisterType<IWebService, AuthWebService>()
                .RegisterType<IPersistanceService, AkavachePersistanceService>();
        }

    }
}