using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.ServiceModel;
using System.Threading;

namespace Project.Communication.Module
{
    static class Program
    {
        //// {7A0258B6-8D8E-454F-892F-D1B9BC119DF0}
        //DEFINE_GUID(<<name>>, 
        //0x7a0258b6, 0x8d8e, 0x454f, 0x89, 0x2f, 0xd1, 0xb9, 0xbc, 0x11, 0x9d, 0xf0);

        private static string instanceStr = "7A0258B6-8D8E-454F-892F-D1B9BC119DF0";
        // Our WCF instance.
        public static ServiceHost MessageServiceHost;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Mutex instanceLock = new Mutex(false, instanceStr);

            if (instanceLock.WaitOne(0, false))
            {
                try
                {
                    int minWorkerThreads;
                    int minIocompleteThreads;
                    ThreadPool.GetMinThreads(out minWorkerThreads, out minIocompleteThreads);
                    if (minWorkerThreads < 50)
                    {
                        ThreadPool.SetMinThreads(50, 50);
                    }
                    int maxWorkerThreads;
                    int maxIocompleteThreads;
                    ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxIocompleteThreads);
                    if (maxWorkerThreads < Constants.MaxWorkerThreadsConst)
                    {
                        ThreadPool.SetMaxThreads(Constants.MaxWorkerThreadsConst, maxIocompleteThreads);
                    }

                    //// Start WCF.
                    //Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
                    //Program.MessageServiceHost = new ServiceHost(typeof(TesterObject));
                    //Program.MessageServiceHost.Open();
                    //Program.MessageStreamHost = new ServiceHost(typeof(TesterObjectStreaming));
                    //Program.MessageStreamHost.Open();

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
                catch
                {

                }
            }
        }
    }
}
