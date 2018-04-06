using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.ServiceModel;
using Project.Communication.Enums;

namespace Project.Communication.Module
{
    public partial class Form1 : Form, IObserver
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Project.Communication.Module.StaticServerTalker.Attach(this);

                // Startup TesterObject and connect to WCF.
                IClassLService iClassLService = new ClassService();
                Program.MessageServiceHost = new ServiceHost(iClassLService);
                Program.MessageServiceHost.Open();

                MessageBox.Show("test");
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region IObserver
        public void Notify(string text)
        {

        }
        public void NotifyContent(string text)
        {

        }
        public void OnExitDelegate(Delegate thisOne)
        {

        }
        public string GetCurrentCultureString(string whichStr)
        {
            return null;
        }
        public ReturnValues LogInValueProp
        {
            set
            {

            }
        }
        public void BladeEvent(object[] BladeEventArgsObject)
        {

        }
        public event ObjObjDelegate SendToTesterObjectEvent;
        #endregion

    }
}
