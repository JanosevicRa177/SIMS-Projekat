using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows.DoctorWindows.DoctorWindows.ViewModel
{
    class EmergencyViewModel : BindableBase
    {
        public int hour
        {
            set;
            get;
        }
        public int minute
        {
            set;
            get;
        }


        public EmergencyViewModel(int patid)
        {
            this.hour = DateTime.Now.Hour;
            this.minute = DateTime.Now.Minute;
        }
    }
}
