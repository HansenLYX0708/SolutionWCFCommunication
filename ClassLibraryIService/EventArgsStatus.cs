// ****************************************************************
// StatusEventArgs.cs 
// This is the argunment struc that is passed with most of our events.
//
// Hitachi Parametrics tester
// Copyright 2007
// Robert L. Kimball
// ****************************************************************
using System;

namespace Project.Communication.Module
{
    /// <summary>
    /// Summary description for StatusEventArgs.
    /// This Event returns a string and an integer.
    /// if int eType == 0 then this is an output from the remote tcl program.
    /// </summary>
    [Serializable]
    public class EventArgsStatus : EventArgs
    {
        /// <summary>
        /// Constructor with three parameters. 
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="iType"></param>
        public EventArgsStatus(string strText, int iType, int iConsecutive)
        {
            Text = strText;
            EventType = iType;
            ConsecutiveCount = iConsecutive;
        }

        /// <summary>
        /// Constructor with two parameters. 
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="iType"></param>
        public EventArgsStatus(string strText, int iType)
        {
            Text = strText;
            EventType = iType;
            ConsecutiveCount = -1;
        }

        /// <summary>
        /// Constructor with string parameter.
        /// </summary>
        /// <param name="strText"></param>
        public EventArgsStatus(string strText)
        {
            Text = strText;
            EventType = 0;
            ConsecutiveCount = -1;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EventArgsStatus()
        {
            Text = "";
            EventType = 0;
            ConsecutiveCount = -1;
        }

        public string Text;
        public int EventType;
        public int ConsecutiveCount;
    }
}


