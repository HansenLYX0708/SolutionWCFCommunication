using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.Composition;
using System.ServiceModel;
using System.ServiceModel.Description;
using Project.Communication.IService;

namespace Project.Communication.Module
{
    [Export(typeof(Project.Communication.Module.IClassLService)),
        PartCreationPolicy(CreationPolicy.Any),
        ExportMetadata("Name", "FactBladeRunner")]
    [ServiceBehavior(UseSynchronizationContext = false,
        ConcurrencyMode = ConcurrencyMode.Reentrant,
        InstanceContextMode = InstanceContextMode.Single)]
    [ErrorHandlerAttribute]
    public class ClassService : IClassLService, IServiceBehavior, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            //throw new NotImplementedException();
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            //throw new NotImplementedException();
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            //throw new NotImplementedException();
        }

                /// <summary>
        /// Constructor
        /// </summary>
        [ImportingConstructor]
        public ClassService()
        {

        }

        public void Func1()
        {
            
        }
        public void Func2()
        {

        }
        public void Func3()
        {

        }
        public void Func4()
        {

        }
    }
}
