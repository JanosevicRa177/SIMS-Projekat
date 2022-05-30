using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CrudModel;
using MVVM;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.PatientWindows;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows.PatientWindows.ViewModel
{
    class AccountViewModel : BindableBase
    {
        private PatientController PC = new PatientController();
        public MyICommand ConfirmCommand { get; set; }
        public MyICommand ReverseCommand { get; set; }
        Patient LoggedPatient
        {
            get;
            set;
        }
        String oldName
        {
            get;
            set;
        }
        public string Name
        {
            get { return LoggedPatient.name; }
            set
            {
                if (value != LoggedPatient.name)
                {
                    LoggedPatient.name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        String oldSurname
        {
            get;
            set;
        }
        public string Surname
        {
            get { return LoggedPatient.surname; }
            set
            {
                if (value != LoggedPatient.surname)
                {
                    LoggedPatient.surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }
        String oldCountry
        {
            get;
            set;
        }
        public string Country
        {
            get { return LoggedPatient.address.country; }
            set
            {
                if (value != LoggedPatient.address.country)
                {
                    LoggedPatient.address.country = value;
                    OnPropertyChanged("Country");
                }
            }
        }
        String oldCity
        {
            get;
            set;
        }
        public string City
        {
            get { return LoggedPatient.address.city; }
            set
            {
                if (value != LoggedPatient.address.city)
                {
                    LoggedPatient.address.city = value;
                    OnPropertyChanged("City");
                }
            }
        }
        String oldAddressNumber
        {
            get;
            set;
        }
        public string AddressNumber
        {
            get { return LoggedPatient.address.number; }
            set
            {
                if (value != LoggedPatient.address.number)
                {
                    LoggedPatient.address.number = value;
                    OnPropertyChanged("AddressNumber");
                }
            }
        }
        String oldAddress
        {
            get;
            set;
        }
        public string Address
        {
            get { return LoggedPatient.address.street; }
            set
            {
                if (value != LoggedPatient.address.street)
                {
                    LoggedPatient.address.street = value;
                    OnPropertyChanged("Address");
                }
            }
        }
        String oldPhoneNumber
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get { return LoggedPatient.mobilePhone; }
            set
            {
                if (value != LoggedPatient.mobilePhone)
                {
                    LoggedPatient.mobilePhone = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }
        String oldMail
        {
            get;
            set;
        }
        public string Mail
        {
            get { return LoggedPatient.mail; }
            set
            {
                if (value != LoggedPatient.mail)
                {
                    LoggedPatient.mail = value;
                    OnPropertyChanged("Mail");
                }
            }
        }

        public String gender { get; set; }

        public AccountViewModel()
        {
            LoggedPatient = PC.GetPatientByID(PatientWindow.LoggedPatient.id);
            ReverseCommand = new MyICommand(OnReverse);
            ConfirmCommand = new MyICommand(OnConfirm);
            if (LoggedPatient.gender == Gender.male)
            {
                gender = "M";
            }
            else
            {
                gender = "Ž";

            }

            oldName = LoggedPatient.name;
            oldSurname = LoggedPatient.surname;
            oldCountry = LoggedPatient.address.country;
            oldAddressNumber = LoggedPatient.address.number;
            oldCity = LoggedPatient.address.city;
            oldPhoneNumber = LoggedPatient.mobilePhone;
            oldAddress = LoggedPatient.address.street;
            oldMail = LoggedPatient.mail;

        }
        private void OnReverse()
        {
            Name = oldName;
            Surname = oldSurname;
            Mail = oldMail;
            PhoneNumber = oldPhoneNumber;
            Country = oldCountry;
            Address = oldAddress;
            City = oldCity;
            AddressNumber = oldAddressNumber;
        }
        private void OnConfirm()
        {
            PC.UpdatePatient(LoggedPatient);
            PatientWindow.LoggedPatient.name = Name;
            PatientWindow.LoggedPatient.surname = Surname;
            oldName = LoggedPatient.name;
            oldSurname = LoggedPatient.surname;
            oldCountry = LoggedPatient.address.country;
            oldAddressNumber = LoggedPatient.address.number;
            oldCity = LoggedPatient.address.city;
            oldPhoneNumber = LoggedPatient.mobilePhone;
            oldAddress = LoggedPatient.address.street;

            InformationDialog informationDialog = new InformationDialog("Uspešno ste ažurirali vaše podatke!");
            informationDialog.Top = 50 + 270;
            informationDialog.Left = 555 + 25;
            informationDialog.Activate();
            informationDialog.Topmost = true;
            informationDialog.ShowDialog();
        }
    }
}
