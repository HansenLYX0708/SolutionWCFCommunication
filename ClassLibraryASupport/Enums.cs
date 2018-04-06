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

    [Flags]
    public enum ReturnValues
    {
        // Access bits (upper bit not set)
        operatorBit = 0x01,
        editSeqBit = 0x02,
        editOcrBit = 0x04,
        editBinBit = 0x08,
        editGradeBit = 0x10,
        editDispositionBit = 0x20,
        editTrayDispoBit = 0x40,
        editTestNamesDbBit = 0x80,
        editBladeLocationDbBit = 0x100,
        automationBit = 0x200,
        bladeAccessBit = 0x400,
        serverAccessBit = 0x800,
        passwordAdminBit = 0x1000,
        engineerBit = 0x2000,
        changedVal = 0x4000,
        editTestCountBit = 0x8000,
        OverrideLockBit = 0x10000,
        EditCategoryBit = 0x20000,
        ClearSpoRpoBit = 0x40000,
        RetryDispoBit = 0x80000,
        SuperMoveBit = 0x100000,
        SliderSetup = 0x200000,
        GraniteQuartz = 0x400000,

        // Errors (upper bit set)
        errorBit = 0x40000000,
        fileBad = 0x60000000,
        fileMissing = 0x50000000,
        passwordBad = 0x48000000,
        userIdBad = 0x44000000,
        locked = 0x42000000,
        tooManyAttempts = 0x41000000,
        connectionBad = 0x40800000,
        noChange = 0x40400000,
        cancel = 0x40200000,
        notAdmin = 0x40100000
        // Sorry sometimes this one is signed int and sometimes unsigned int.  Don't use upper bit.
    }
}
