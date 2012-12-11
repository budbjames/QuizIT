//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
////using Microsoft.Practices.Prism.UnityExtensions;
//using System.Windows;
//using Microsoft.Practices.ServiceLocation;
//using Microsoft.Practices.Prism.Logging;
//using Presentation.QuizIt.Modules;
//using Microsoft.Practices.Prism.Modularity;
//using Infrastructure;
//using Domain.QuizIt;
//using Microsoft.Practices.Unity;

//namespace Presentation.QuizIt
//{
//    /// <summary>
//    /// Prism Unity bootstrapper implementation.  Prepares the IoC container
//    /// and initializes all of the modules.
//    /// </summary>
//    public class QuizItBootstrapper //: UnityBootstrapper
//    {
//        private readonly ILoggerFacade callbackLogger;
        
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        protected override DependencyObject CreateShell()
//        {
//            return ServiceLocator.Current.GetInstance<MainWindow>();
//        }

//        /// <summary>
//        /// Initializes the shell.
//        /// </summary>
//        /// <remarks>
//        /// The base implemention ensures the shell is composed in the container.
//        /// </remarks>
//        protected override void InitializeShell()
//        {
//            base.InitializeShell();

//            Application.Current.MainWindow = (Window)this.Shell;
//            Application.Current.MainWindow.Show();
//        }

//        /// <summary>
//        /// Create the <see cref="ILoggerFacade"/> used by the bootstrapper.
//        /// </summary>
//        /// <returns></returns>
//        /// <remarks>
//        /// The base implementation returns a new TextLogger.
//        /// </remarks>
//        protected override ILoggerFacade CreateLogger()
//        {
//            // Because the Shell is displayed after most of the interesting boostrapper work has been performed,
//            // this quickstart uses a special logger class to hold on to early log entries and display them 
//            // after the UI is visible.
//            return this.callbackLogger;
//        }

//        /// <summary>
//        /// Configures the <see cref="IUnityContainer"/>. May be overwritten in a derived class to add specific
//        /// type mappings required by the application.
//        /// </summary>
//        protected override void ConfigureContainer()
//        {
//            base.ConfigureContainer();

//            this.Container = new UnityContainer();
            
//            var loggerFacade = new TextLogger();

//            this.Container.RegisterInstance<ILoggerFacade>(loggerFacade);
//        }

//        /// <summary>
//        /// Returns the module catalog that will be used to initialize the modules.
//        /// </summary>
//        /// <returns>
//        /// An instance of <see cref="IModuleCatalog"/> that will be used to initialize the modules.
//        /// </returns>
//        /// <remarks>
//        /// When using the default initialization behavior, this method must be overwritten by a derived class.
//        /// </remarks>
//        protected override IModuleCatalog CreateModuleCatalog()
//        {
//            return new ModuleCatalog();
//        }

//        protected override void ConfigureModuleCatalog()
//        {
//            var moduleInfos = new List<ModuleInfo>();

//            Type infrastructureModule = typeof(InfrastructureModule);
//            var infrastructureModuleInfo = new ModuleInfo(infrastructureModule.Name, infrastructureModule.AssemblyQualifiedName);

//            Type domainModule = typeof(DomainModule);
//            var domainModuleInfo = new ModuleInfo(domainModule.Name, domainModule.AssemblyQualifiedName);
//            domainModuleInfo.DependsOn.Add(infrastructureModule.Name);


//            Type quizitPresentationModule = typeof(PresentationModule);
//            var presentationModuleInfo = new ModuleInfo(quizitPresentationModule.Name, quizitPresentationModule.AssemblyQualifiedName);
//            presentationModuleInfo.DependsOn.Add(domainModule.Name);

//            this.ModuleCatalog.AddModule(presentationModuleInfo);

//        }
//    }
//}
