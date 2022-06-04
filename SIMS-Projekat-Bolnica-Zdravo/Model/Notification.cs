using System;
using ConsoleApp.serialization;
using CrudModel;

namespace SIMS_Projekat_Bolnica_Zdravo.Model
{
   public class Notification : Serializable
    {
      private static int ids = -1;
      public String Title
        {
            get;
            set;
        }
      public String Content
        {
            get;
            set;
        }
        public DateTime DeleteDate
        {
            get;
            set;
        }
        public Boolean Viewed
        {
            get;
            set;
        }
        public static int Getids()
        {
            return ids;
        }
        public static void Setids(int set)
        {
            ids = set;
        }
        public int UserID
        {
            get;
            set;
        }
        public int NotificationID
        {
            get;
            set;
        }

        public NotificationType notificationType
        {
            get;
            set;
        }
        public Notification()
        {
        }
        public Notification(string title, string content, DateTime deleteDate, bool viewed,int userID)
        {
            this.Title = title;
            this.Content = content;
            this.DeleteDate = deleteDate;
            this.Viewed = viewed;
            this.UserID = userID;
            this.NotificationID = ++ids;
            notificationType = NotificationType.appointment;
        }

        public string[] toCSV()
        {
            if (notificationType == NotificationType.appointment)
            {
                if (Viewed)
                {
                    string[] csvValues =
                    {
                        Title,
                        Content,
                        DeleteDate.Day.ToString(),
                        DeleteDate.Month.ToString(),
                        DeleteDate.Year.ToString(),
                        "1",
                        NotificationID.ToString(),
                        UserID.ToString(),
                        "appointment"
                    };
                    return csvValues;
                }
                else
                {
                    string[] csvValues =
                    {
                        Title,
                        Content,
                        DeleteDate.Day.ToString(),
                        DeleteDate.Month.ToString(),
                        DeleteDate.Year.ToString(),
                        "0",
                        NotificationID.ToString(),
                        UserID.ToString(),
                        "appointment"
                    };
                    return csvValues;
                }
            }
            else
            {
                string[] csvValues =
                {
                    Title,
                    Content,
                    DeleteDate.Day.ToString(),
                    DeleteDate.Month.ToString(),
                    DeleteDate.Year.ToString(),
                    DeleteDate.Hour.ToString(),
                    "0",
                    NotificationID.ToString(),
                    UserID.ToString(),
                    "note"
                };
                return csvValues;
            }
        }

        public void fromCSV(string[] values)
        {
            this.Title = values[0];
            this.Content = values[1];
            this.DeleteDate = new DateTime(int.Parse(values[4]), int.Parse(values[3]), int.Parse(values[2]));
            if (int.Parse(values[5]) == 1)
            {
                this.Viewed = true;
            }
            else 
            {
                this.Viewed = false;
            }
            this.NotificationID = int.Parse(values[6]);
            this.UserID = int.Parse(values[7]);
            if (values[8].Equals("note"))
            {
                this.notificationType = NotificationType.note;
            }
            else
            {
                this.notificationType = NotificationType.appointment;
            }
        }
    }
}