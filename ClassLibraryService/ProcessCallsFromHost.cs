/********************************************************************************
 * Host sends calls to the service via its StaticServerTalker class, this decides 
 * what the call is and calls the function in TesterObject.
 * 
 * Robert L. Kimball
 * Aug 2012
 * 
 * *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Project.Communication.Enums;

namespace Project.Communication.Module
{
    public class ProcessCallsFromHost
    {
        /// <summary>
        /// We do not use this.
        /// </summary>
        private ProcessCallsFromHost()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="owner"></param>
        public ProcessCallsFromHost(ClassService owner)
        {
            testerObject = owner;
        }

        private ClassService testerObject;

        /// <summary>
        /// Gets Blade events from the WCF services.
        /// This decides which callback to call.
        /// This matches the events decision in RemoteConnectLib.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object OnTesterObjectEvent(object[] args)
        {
            ETHostToServiceEnums whichFunction = (ETHostToServiceEnums)args[0];
            object retObj = null;

            switch (whichFunction)
            {
                case ETHostToServiceEnums.Abort:
                    //retObj = testerObject.Abort((string)args[1], (bool)args[2]);
                    break;
                case ETHostToServiceEnums.CopyFileOnBlade:
                    //retObj = testerObject.CopyFileOnBlade((string)args[1], (string)args[2]);
                    break;
                case ETHostToServiceEnums.ClearStats:
                    //testerObject.ClearStats();
                    break;
                case ETHostToServiceEnums.GetDataViaEvent:
                    //testerObject.GetDataViaEvent((string[])args[1]);
                    break;
                case ETHostToServiceEnums.hgst_get_neutral:
                    //testerObject.hgst_get_neutral((int)args[1], (int)args[2]);
                    break;
                case ETHostToServiceEnums.hgst_set_neutral:
                    //testerObject.hgst_set_neutral((int)args[1], (int)args[2], (int)args[3]);
                    break;
                case ETHostToServiceEnums.hgst_get_servo:
                    // void hgst_get_servo(int index, int dev);
                    //testerObject.hgst_get_servo((int)args[1], (int)args[2]);
                    break;
                case ETHostToServiceEnums.hgst_set_save_servo:
                            //public void hgst_set_save_servo(int index, int dev, int type,
                            //  int open_end_pos, int open_max_vel, int open_accel,
                            //  int close_end_pos, int close_max_vel, int close_accel,
                            //  int current_end_pos, int current_max_vel, int current_accel)
                    //testerObject.hgst_set_save_servo((int)args[1], (int)args[2], (int)args[3],
                    //    (int)args[4], (int)args[5], (int)args[6],
                    //    (int)args[7], (int)args[8], (int)args[9],
                    //    (int)args[10], (int)args[11], (int)args[12]);
                    break;
                case ETHostToServiceEnums.hgst_move_servo:
                    //testerObject.hgst_move_servo((int)args[1], (int)args[2], (int)args[3],
                    //    (int)args[4], (int)args[5], (int)args[6]);
                    break;
                case ETHostToServiceEnums.hgst_usb_reset:
                    //testerObject.hgst_usb_reset((int)args[1]);
                    break;
                case ETHostToServiceEnums.SetCounts:
                    //testerObject.SetCounts((string)args[1]);
                    break;
                case ETHostToServiceEnums.SaveCounts:
                    //testerObject.SaveCounts();
                    break;
                case ETHostToServiceEnums.SetIntegers:
                    //testerObject.SetIntegers((string)args[1], (string[])args[2], (int[])args[3]);
                    break;
                case ETHostToServiceEnums.SetMemsCloseSensorType:
                    //testerObject.SetMemsCloseSensorType((BunnyPinMotionSensor)args[1]);
                    break;
                case ETHostToServiceEnums.SetMemsOpenSensorType:
                    //testerObject.SetMemsOpenSensorType((BunnyPinMotionSensor)args[1]);
                    break;
                case ETHostToServiceEnums.SetMemsType:
                    //testerObject.SetMemsType((BunnyPinMotionType)args[1]);
                    break;
                case ETHostToServiceEnums.SetStrings:
                    //testerObject.SetStrings((string)args[1], (string[])args[2], (string[])args[3]);
                    break;
                case ETHostToServiceEnums.GetStrings:
                    //retObj = testerObject.GetStrings((string)args[1], (string[])args[2]);
                    break;
                case ETHostToServiceEnums.TclCommand:
                    //testerObject.TclCommand((string)args[1], (bool)args[2]);
                    break;
                case ETHostToServiceEnums.TclInput:
                    //testerObject.TclInput((string)args[1], (bool)args[2]);
                    break;
                case ETHostToServiceEnums.ZeroCounts:
                    //testerObject.ZeroCounts();
                    break;


            } // end switch

            return retObj;
        }
    } // end class
} // end namespace
