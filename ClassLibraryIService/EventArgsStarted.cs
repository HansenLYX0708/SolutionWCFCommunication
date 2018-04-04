// ****************************************************************
// StartedEventArgs.cs 
// This is the argunment struc that is passed with the test started event.
//
// Hitachi Parametrics tester
// Copyright 2008
// Robert L. Kimball  Aug 29 ,2008
// ****************************************************************
using System;

namespace Project.Communication.IService
{
   /// <summary>
   /// Summary description for StartedEventArgs.
   /// This EventArgs type returns a string and two integers.
   /// </summary>
   [Serializable]
   public class EventArgsStarted : EventArgs
   {
      /// <summary>
      /// Constructor with parameters.
      /// </summary>
      /// <param name="strText"></param>
      /// <param name="iTestNum"></param>
      /// <param name="iTestCount"></param>
      public EventArgsStarted(string strSequence, string strGrade, int startTest, int Consecutive)
      {
         seqName = strSequence;
         gradeName = strGrade;
         iStartTest = startTest;
         iConsecutive = Consecutive;
      }
      /// <summary>
      /// Default constructor.
      /// </summary>
      public EventArgsStarted()
      {
         seqName = "";
         gradeName = "";
         iStartTest = 0;
         iConsecutive = 0;
      }

      public string  seqName;
      public string gradeName;
      public int iStartTest;
      public int iConsecutive;

   } // end class
} // end namespace
