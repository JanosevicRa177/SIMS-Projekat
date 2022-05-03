
using ConsoleApp.serialization;
using System;

namespace CrudModel
{
   public class AppointmentNotification : Serializable
    {
      private static int ids = -1;
      public String title
        {
            get;
            set;
        }
      public String content
        {
            get;
            set;
        }
        public DateTime deleteDate
        {
            get;
            set;
        }
        public Boolean viewed
        {
            get;
            set;
        }
        public static int getids()
        {
            return ids;
        }
        public static void setids(int set)
        {
            ids = set;
        }
        public int userID
        {
            get;
            set;
        }
        public int notificationID
        {
            get;
            set;
        }
        public AppointmentNotification()
        {
        }
        public AppointmentNotification(string title, string content, DateTime deleteDate, bool viewed,int userID)
        {
            this.title = title;
            this.content = content;
            this.deleteDate = deleteDate;
            this.viewed = viewed;
            this.userID = userID;
            this.notificationID = ++ids;
        }

        public string[] toCSV()
        {
            if (viewed)
            {
                string[] csvValues =
                {
                    title,
                    content,
                    deleteDate.Day.ToString(),
                    deleteDate.Month.ToString(),
                    deleteDate.Year.ToString(),
                    "1",
                    notificationID.ToString(),
                    userID.ToString()
                };
                return csvValues;
            }
            else 
            {
                string[] csvValues =
                {
                    title,
                    content,
                    deleteDate.Day.ToString(),
                    deleteDate.Month.ToString(),
                    deleteDate.Year.ToString(),
                    "0",
                    notificationID.ToString(),
                    userID.ToString()
                };
                return csvValues;
            }
        }

        public void fromCSV(string[] values)
        {
            this.title = values[0];
            this.content = values[1];
            this.deleteDate = new DateTime(int.Parse(values[4]), int.Parse(values[3]), int.Parse(values[2]));
            if (int.Parse(values[5]) == 1)
            {
                this.viewed = true;
            }
            else 
            {
                this.viewed = false;
            }
            this.notificationID = int.Parse(values[6]);
            this.userID = int.Parse(values[7]);

        }
    }
}