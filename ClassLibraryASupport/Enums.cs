using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Communication.Enums
{
    // This matches the event Type
    public enum ETHostToServiceEnums
    {
        Abort,
        CopyFileOnBlade,
        ClearStats,
        hgst_get_servo,
        hgst_get_neutral,
        hgst_set_neutral,
        hgst_move_servo,
        hgst_usb_reset,
        hgst_set_save_servo,
        GetDataViaEvent,
        SetCounts,
        SaveCounts,
        SetIntegers,
        SetMemsCloseSensorType,
        SetMemsOpenSensorType,
        SetMemsType,
        SetStrings,
        GetStrings,
        TclCommand,
        TclInput,
        ZeroCounts,
    }
}
