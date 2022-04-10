// File:    Meeting.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:13:45 PM
// Purpose: Definition of Class Meeting

using System;
using System.Collections.Generic;

namespace CrudModel
{
   public class Meeting
   {
      public DateTime timeBegin
        {
            set;
            get;
        }
        public int duration
        {
            set;
            get;
        }
        public int meetingID
        {
            set;
            get;
        }

        public Room room;
      public List<Doctor> requiredToCome
        {
            set;
            get;
        }

        /// <summary>
        /// Property for Doctor
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public List<Doctor> RequiredToCome
        {
         get
         {
            return requiredToCome;
         }
         set
         {
            this.requiredToCome  = value;
         }
      }
      public Doctor invitedDoctor;
      
      /// <summary>
      /// Property for Doctor
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
        public List<Doctor> invitedDoctors
      {
         get
         {
            return invitedDoctors;
         }
         set
         {
            this.invitedDoctors = value;
         }
      }
        public Secretary secretary
        {
            set;
            get;
        }

        /// <summary>
        /// Property for Secretary
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Secretary Secretary
      {
         get
         {
            return secretary;
         }
         set
         {
            if (this.secretary == null || !this.secretary.Equals(value))
            {
               if (this.secretary != null)
               {
                  Secretary oldSecretary = this.secretary;
                  this.secretary = null;
                  oldSecretary.RemoveMeeting(this);
               }
               if (value != null)
               {
                  this.secretary = value;
                  this.secretary.AddMeeting(this);
               }
            }
         }
      }
   
   }
}