using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat_Bolnica_Zdravo.CrudModel
{
    class TimePatient
    {
            public int hour
            {
                set;
                get;
            }
            public DoctorCrAppDTO doctor
            {
                get;
                set;
            }
            public DateTime date
            {
                get;
                set;
            }
            public int minute
            {
                set;
                get;

            }
            public string time
            {
                set;
                get;
            }

            public int ID
            {
                get; set;
            }

            public TimePatient(int hour, int minute, int ID)
            {
                this.time = "";
                this.hour = hour;
                this.minute = minute;
                if (hour < 10 && minute < 10) this.time += "0" + hour + ":" + "0" + minute;
                else if (hour >= 10 && minute < 10) this.time += hour + ":" + "00";
                else if (hour < 10 && minute > 10) this.time += "0" + hour + ":" + minute;
                else this.time += hour + ":" + minute;
                this.ID = ID;
            }

    }
}
