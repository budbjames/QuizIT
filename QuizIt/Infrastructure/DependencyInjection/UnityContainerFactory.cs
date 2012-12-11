using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using Microsoft.Practices.Unity;

namespace Infrastructure.DependencyInjection
{
    /// <summary>
    /// This class allows only one reference to the unity container.
    /// This will assure that any instances that are registered with the container
    /// will be available for use anywhere in the application.
    /// </summary>
    public static class UnityContainerFactory
    {
        private static IUnityContainer unityContainer;


        public static IUnityContainer GetUnityContainer()
        {
            PrepareContainerInstance();
            return unityContainer;
        }


        private static void PrepareContainerInstance()
        {
            if (unityContainer == null)
            {
                unityContainer = new UnityContainer();
            }
        }
    }
}
