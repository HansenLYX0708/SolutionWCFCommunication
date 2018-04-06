using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security;
using System.ServiceModel;

namespace Project.Communication.Module
{
    [ServiceContract(Name = "ClassLServiceContract",
        Namespace = "Project.Communication.Module",
        CallbackContract = typeof(IClassLServiceCallback))]
    public interface IClassLService
    {
        [OperationContract]
        [FaultContract(typeof(Faults.FaultDetailReceiver))]
        [FaultContract(typeof(Faults.FaultDetailSender))]
        void Func1();


        [OperationContract]
        [FaultContract(typeof(Faults.FaultDetailReceiver))]
        [FaultContract(typeof(Faults.FaultDetailSender))]
        void Func2();

        [OperationContract]
        [FaultContract(typeof(Faults.FaultDetailReceiver))]
        [FaultContract(typeof(Faults.FaultDetailSender))]
        void Func3();

        [OperationContract]
        [FaultContract(typeof(Faults.FaultDetailReceiver))]
        [FaultContract(typeof(Faults.FaultDetailSender))]
        void Func4();
    }
    // These event handlers are used inside of Jade and BladeRunner.
    public delegate void EventHandlerStatus(object sender, EventArgsStatus e);
    public delegate void EventHandlerComplete(object sender, EventArgsCompleted e);
    public delegate void EventHandlerStarted(object sender, EventArgsStarted e);

    // The following event handler is used to send all events across the wire.
    // Actually we no longer do .NET remoting events.  Instead we use a WCF callback.
    // Blade runner wraps this in a callback.
    public delegate void EventHandlerBlade(object sender, EventArgsBlade e);
}
