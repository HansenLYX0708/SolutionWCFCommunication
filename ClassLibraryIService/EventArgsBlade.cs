// ****************************************************************
// BladeEventArgs.cs 
// This is the argunment struc that is passed with most of our events.
// Hitachi Parametrics tester
// Copyright 2009, Hitachi Global Storage Technologies
// written by Akishi Murata
//
// 2018-4-4 16:07:50
// modifity by Hansen
// ****************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Communication.IService
{
    public class EventTypeBlade
    {
        // Revision=1
        public const int None = 0;
        public const int TestStarted = 5;
        public const int TestCompleted = 6;
        public const int SequenceStarted = 7;
        public const int SequenceAborting = 8;
        public const int SequenceCompleted = 9;
        public const int SequenceUpdate = 10;
        public const int ProgramClosing = 12;
        public const int Bunny = 13;
        public const int Status = 14;

        /// <summary>
        /// Parse int value to string name.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        static public bool TryParse(int value, out string name)
        {
            try
            {
                name = Parse(value);
                return true;
            }
            catch
            {
                name = "";
            }
            return false;
    }

        /// <summary>
        /// Parse int value to string name of event type.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static public string Parse(int value)
        { 
            string name;
            switch (value)
            {
                case 0:
                    name = "None";
                    break;
                case TestStarted:
                    name = "TestStarted";
                    break;
                case TestCompleted:
                    name = "TestCompleted";
                    break;
                case SequenceStarted:
                    name = "SequenceStarted";
                    break;
                case SequenceAborting:
                    name = "SequenceAborting";
                    break;
                case SequenceCompleted:
                    name = "SequenceCompleted";
                    break;
                case SequenceUpdate:
                    name = "SequenceUpdate";
                    break;
                case ProgramClosing:
                    name = "BladeEventType";
                    break;
                case Bunny:
                    name = "Bunny";
                    break;
                case Status:
                    name = "Status";
                    break;
                default:
                    throw new ArgumentException("Cannot parse input to BladeEventType.");
                    //break;
            } // end switch

            return name;
        } // end TryParse
     
    } // end class

    /// <summary>
    /// Summary description for BladeEventArgs.
    /// This Event Has parameters from all event types returned by BladeRunner.
    /// if int eType == 0 then this is an output from the remote tcl program.
    /// </summary>
    [Serializable]
    public class EventArgsBlade : EventArgs
    {
        /// <summary>
        /// Constructor with all parameters. 
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="iType"></param>
        public EventArgsBlade(int _EventType, int _Int1, int _ConsecutiveCount, int _Int3, string _Str1, string _Str2, bool _Bool1)
        {
            Revision = 2;
            EventType = _EventType;

            Int1 = _Int1;
            m_ConsecutiveCount = _ConsecutiveCount;
            Int3 = _Int3;
            Str1 = _Str1;
            Str2 = _Str2;
            Bool1 = _Bool1;
        }

        public EventArgsBlade()
        {
            Revision = 2;
            EventType = EventTypeBlade.None;

            Int1 = 0;
            m_ConsecutiveCount = 0;
            Int3 = 0;
            Str1 = "";
            Str2 = "";
            Bool1 = false;
        }

        public int Revision;
        public int EventType;
        
        //BladeEventArgs               //StatusEvent   StartedEvent  CompletedEvent
        protected int Int1;                //iType,    iStartTest,   testNumber
        protected int m_ConsecutiveCount;  //consec     consec       consec
        protected int Int3;                //                        testcount
        protected string Str1;             //Text,     SeqName,      Text 
        protected string Str2;             //          GradeName,     
        protected bool Bool1;              //                        Fail

        public string Text
        {
            get
            {
                return Str1;
            }
            set
            {
                Str1 = value;
            }
        }

        public int iType
        {
            get
            {
                return Int1;
            }
            set
            {
                Int1 = value;
            }
        }

        public int Consecutive
        {
            get
            {
                return m_ConsecutiveCount;
            }
            set
            {
                m_ConsecutiveCount = value;
            }
        }

        public EventArgsBladeCompleted ToCompletedEventBladeArgs()
        {
            return new EventArgsBladeCompleted(EventType, Int1, m_ConsecutiveCount, Int3, Str1, Str2, Bool1);
        }

        public EventArgsBladeStatus ToStatusEventBladeArgs()
        {
            return new EventArgsBladeStatus(EventType, Int1, m_ConsecutiveCount, Int3, Str1, Str2, Bool1);
        }

        public EventArgsBladeSequenceStarted ToSequenceStartedBladeEventArgs()
        {
            return new EventArgsBladeSequenceStarted(EventType, Int1, m_ConsecutiveCount, Int3, Str1, Str2, Bool1);
        }
    }



    [Serializable]
    public class EventArgsBladeCompleted : EventArgsBlade
    {
        /// <summary>
        /// Constructor with BladeEventArgs parameters.
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="iTestNum"></param>
        /// <param name="iTestCount"></param>
        public EventArgsBladeCompleted(int _EventType, int _Int1, int _Int2, int _Int3, string _Str1, string _Str2, bool _Bool1) :
            base(_EventType, _Int1, _Int2, _Int3, _Str1, _Str2, _Bool1)
        {
        }

        /// <summary>
        /// Constructor with StatusEventArgs
        /// </summary>
        /// <param name="_EventType"></param>
        /// <param name="e"></param>
        public EventArgsBladeCompleted(int _EventType, EventArgsCompleted e) :
            base(_EventType, e.testNum, e.ConsecutiveCount, e.testCount, e.Text, "", e.fail)
        {
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EventArgsBladeCompleted(int _EventType) : base()
        {
            EventType = _EventType;
        }

        private EventArgsBladeCompleted() { }

        //BladeEventArgs               CompletedEvent
        //public int Int1;             testNumber
        //public int Int2;             testcount
        //public string Str1;          Text 
        //public string Str2;          _     
        //public bool Bool1;           Fail

        public EventArgsCompleted EventArgsToCompleted()
        {
            return new EventArgsCompleted(Str1, Int1, Int3, m_ConsecutiveCount, Bool1);
        }

        public EventArgsBlade EventArgsToBlade()
        {
            return new EventArgsBlade(this.EventType, this.Int1, this.m_ConsecutiveCount, this.Int3, this.Str1, this.Str2, this.Bool1);
        }

    } // end class


    [Serializable]
    public class EventArgsBladeSequenceStarted : EventArgsBlade
    {
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="iTestNum"></param>
        /// <param name="iTestCount"></param>
        public EventArgsBladeSequenceStarted(int _EventType, int _Int1, int _Int2, int _Int3, string _Str1, string _Str2, bool _Bool1) :
            base(_EventType, _Int1, _Int2, _Int3, _Str1, _Str2, _Bool1)
        {
        }
      
        
        public EventArgsBladeSequenceStarted(int _EventType, EventArgsStarted e) :
            base(_EventType, e.iStartTest, e.iConsecutive, 0, e.seqName, e.gradeName, false)
        {
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EventArgsBladeSequenceStarted(int _EventType)
            : base()
        {
            EventType = _EventType;
        }

        private EventArgsBladeSequenceStarted() { }

        //BladeEventArgs                StartedEvent  
        //public int Int1;              iStartTest
        //public int Int2;              -
        //public string Str1;           SeqName 
        //public string Str2;           GradeName     
        //public bool Bool1;            -

        public EventArgsStarted EventArgsToStarted()
        {
            return new EventArgsStarted(Str1, Str2, Int1, m_ConsecutiveCount);
        }

        public EventArgsBlade EventArgsToBlade()
        {
            return new EventArgsBlade(this.EventType, this.Int1, this.m_ConsecutiveCount, this.Int3, this.Str1, this.Str2, this.Bool1);
        }

    } // end class

    [Serializable]
    public class EventArgsBladeStatus : EventArgsBlade
    {
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="iTestNum"></param>
        /// <param name="iTestCount"></param>
        public EventArgsBladeStatus(int _EventType, int _Int1, int _Int2, int _Int3, string _Str1, string _Str2, bool _Bool1) :
            base(_EventType, _Int1, _Int2, _Int3, _Str1, _Str2, _Bool1)
        {
        }


        public EventArgsBladeStatus(int _EventType, EventArgsStatus e) :
            base(_EventType, e.EventType, e.ConsecutiveCount, 0, e.Text, "", false)
        {
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EventArgsBladeStatus(int _EventType)
            : base()
        {
            EventType = _EventType;
        }

        private EventArgsBladeStatus() { }

        //BladeEventArgs                StatusEvent   
        //public int Int1;                //iType,    
        //public int Int2;                //consecutive         
        //public string Str1;             //Text,     
        //public string Str2;             //              
        //public bool Bool1;              //             


        public EventArgsStatus EventArgsToStatus()
        {
            return new EventArgsStatus(Str1, Int1, m_ConsecutiveCount);  // Text, EventType, Consecutive
        }

        public EventArgsBlade EventArgsToBlade()
        {
            return new EventArgsBlade(this.EventType, this.Int1, this.m_ConsecutiveCount, this.Int3, this.Str1, this.Str2, this.Bool1);
        }

    } // end class



} // end namespace