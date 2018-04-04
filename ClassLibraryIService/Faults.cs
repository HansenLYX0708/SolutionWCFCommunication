using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Project.Communication.IService
{
    class Faults
    {
        [DataContract(Namespace = "Project.Communication.IService")]
        public class FaultDetailReceiver
        {

        }

        public class FaultDetailSender
        {

        }
    }
}
