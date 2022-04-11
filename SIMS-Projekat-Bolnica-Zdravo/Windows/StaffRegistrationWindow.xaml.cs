using CrudModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;


namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    /// <summary>
    /// Interaction logic for StaffRegistrationWindow.xaml
    /// </summary>
    public partial class StaffRegistrationWindow : Window
    {
       

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private String _test1;
        private String _test2;
        private String _test3;
        private String _test4;
        private String _test5;
        private String _test6;
        private String _test7;
        private String _test8;
        int br = 0;

        public String Test7
        {
            get
            {
                return _test7;
            }
            set
            {
                if (value != _test7)
                {
                    
                        _test7 = value;
                        OnPropertyChanged("Test7");
                    
                   }
            }
        }
        public String Test8
        {
            get
            {
                return _test8;
            }
            set
            {
                if (value != _test8)
                {
                    _test8 = value;
                    OnPropertyChanged("Test8");
                }
            }
        }
        public String Test6
        {
            get
            {
                return _test6;
            }
            set
            {
                if (value != _test6)
                {
                    _test6 = value;
                    OnPropertyChanged("Test6");
                }
            }
        }
        public String Test1
        {
            get
            {
                return _test1;
            }
            set
            {
                if (value != _test1)
                {
                    
                        _test1 = value;
                        OnPropertyChanged("Test1");
                    
                }
            }
        }
        public String Test3
        {
            get
            {
                return _test3;
            }
            set
            {
                if (value != _test3)
                {
                    _test3 = value;
                    OnPropertyChanged("Test3");
                }
            }
        }
        public String Test4
        {
            get
            {
                return _test4;
            }
            set
            {
                if (value != _test4)
                {
                    _test4 = value;
                    OnPropertyChanged("Test4");
                }
            }
        }
        public String Test5
        {
            get
            {
                return _test5;
            }
            set
            {
                if (value != _test5)
                {
                    _test5 = value;
                    OnPropertyChanged("Test5");
                }
            }
        }
        public String Test2
        {
            get
            {
                return _test2;
            }
            set
            {
                if (value != _test2)
                {
                    _test2 = value;
                    OnPropertyChanged("Test2");
                }
            }
        }


       
        public static int staffID = 0;


        

        public StaffRegistrationWindow()
        {

            InitializeComponent();
            this.DataContext = new
            {
                docs = new DoctorFileStorage(),
                man = new ManagerFileStorage(),
                sec = new SecretaryFileStorage(),
                This = this
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (licenceComboBox.Text.Equals("Doctor"))
            {
                int tmp = 0;
                if ((nameTextBox.Text != "") && (surnameTextBox.Text != "") && (emailTextBox.Text != "") && (passwordTextBox.Text != "") && (countryComboBox.Text != "") && (cityTextBox.Text != "") && (addressTextBox.Text != "") && (phoneTextBox1.Text != "") && (numberTextBox.Text != "") && (specializationTextBox.Text != "") && (licenceComboBox.Text != ""))
                {

                    if (DoctorFileStorage.doctorList.Count == 0)
                    {
                        DoctorFileStorage.doctorList.Add(new Doctor(staffID, nameTextBox.Text, surnameTextBox.Text, emailTextBox.Text, passwordTextBox.Text, new Address(countryComboBox.Text, cityTextBox.Text, addressTextBox.Text, numberTextBox.Text), phoneTextBox1.Text, new Specialization(specializationTextBox.Text), licenceComboBox.Text));
                        MessageBox.Show("User " + nameTextBox.Text + " " + surnameTextBox.Text + " has been added!");

                        nameTextBox.Text = surnameTextBox.Text = emailTextBox.Text = passwordTextBox.Text = countryComboBox.Text = cityTextBox.Text = addressTextBox.Text = phoneTextBox1.Text = specializationTextBox.Text = licenceComboBox.Text = numberTextBox.Text = "";
      
                        staffID++;
                    }
                    else if (DoctorFileStorage.doctorList.Count != 0)
                    {
                        foreach (Doctor d in DoctorFileStorage.doctorList)
                        {
                            if (d.mail.Equals(emailTextBox.Text))
                            {
                                MessageBox.Show("There is user with this email!");
                                tmp = 1;
                                break;
                            }
                        }
                        if (tmp == 0)
                        {
                            DoctorFileStorage.doctorList.Add(new Doctor(staffID, nameTextBox.Text, surnameTextBox.Text, emailTextBox.Text, passwordTextBox.Text, new Address(countryComboBox.Text, cityTextBox.Text, addressTextBox.Text, numberTextBox.Text), phoneTextBox1.Text, new Specialization(specializationTextBox.Text), licenceComboBox.Text));
                            MessageBox.Show("User " + nameTextBox.Text + " " + surnameTextBox.Text + " has been added!");

                            nameTextBox.Text = surnameTextBox.Text = numberTextBox.Text = emailTextBox.Text = passwordTextBox.Text = countryComboBox.Text = cityTextBox.Text = addressTextBox.Text = phoneTextBox1.Text = specializationTextBox.Text = licenceComboBox.Text = "";
                            staffID++;
                        }


                    }

                }
                else
                    MessageBox.Show("You must fill all inputs!");

            }
            else if (licenceComboBox.Text.Equals("Manager"))
            {
                int tmp = 0;
                if ((nameTextBox.Text != "") && (numberTextBox.Text != "") && (surnameTextBox.Text != "") && (emailTextBox.Text != "") && (passwordTextBox.Text != "") && (countryComboBox.Text != "") && (cityTextBox.Text != "") && (addressTextBox.Text != "") && (phoneTextBox1.Text != "") && (specializationTextBox.Text != "") && (licenceComboBox.Text != ""))
                {
                    if (ManagerFileStorage.managerList.Count == 0)
                    {
                        ManagerFileStorage.managerList.Add(new Manager(staffID, nameTextBox.Text, surnameTextBox.Text, emailTextBox.Text, passwordTextBox.Text, new Address(countryComboBox.Text, cityTextBox.Text, addressTextBox.Text, numberTextBox.Text), phoneTextBox1.Text,licenceComboBox.Text));
                        MessageBox.Show("User " + nameTextBox.Text + " " + surnameTextBox.Text + " has been added!");

                        nameTextBox.Text = surnameTextBox.Text = numberTextBox.Text = emailTextBox.Text = passwordTextBox.Text = countryComboBox.Text = cityTextBox.Text = addressTextBox.Text = phoneTextBox1.Text = numberTextBox.Text = specializationTextBox.Text = licenceComboBox.Text = "";
                        staffID++;
                    }
                    else if (ManagerFileStorage.managerList.Count != 0)
                    {
                        foreach (Manager d in ManagerFileStorage.managerList)
                        {
                            if (d.mail.Equals(emailTextBox.Text))
                            {

                                MessageBox.Show("There is user with this email!");
                                tmp = 1;
                                break;
                            }
                        }
                        if (tmp == 0)
                        {
                            ManagerFileStorage.managerList.Add(new Manager(staffID, nameTextBox.Text, surnameTextBox.Text, emailTextBox.Text, passwordTextBox.Text, new Address(countryComboBox.Text, cityTextBox.Text, addressTextBox.Text, numberTextBox.Text), phoneTextBox1.Text, licenceComboBox.Text));
                            MessageBox.Show("User " + nameTextBox.Text + " " + surnameTextBox.Text + " has been added!");

                            nameTextBox.Text = surnameTextBox.Text = emailTextBox.Text = passwordTextBox.Text = countryComboBox.Text = cityTextBox.Text = addressTextBox.Text = phoneTextBox1.Text = specializationTextBox.Text = numberTextBox.Text = licenceComboBox.Text = "";
                            staffID++;
                        }


                    }

                }
                else
                    MessageBox.Show("You must fill all inputs!");

            }
            else if (licenceComboBox.Text.Equals("Secretary"))
            {
                int tmp = 0;
                if ((nameTextBox.Text != "") && (numberTextBox.Text != "") && (surnameTextBox.Text != "") && (emailTextBox.Text != "") && (passwordTextBox.Text != "") && (countryComboBox.Text != "") && (cityTextBox.Text != "") && (addressTextBox.Text != "") && (phoneTextBox1.Text != "") && (specializationTextBox.Text != "") && (licenceComboBox.Text != ""))
                {
                    if (SecretaryFileStorage.secretaryList.Count == 0)
                    {
                        SecretaryFileStorage.secretaryList.Add(new CrudModel.Secretary(nameTextBox.Text, surnameTextBox.Text, emailTextBox.Text, passwordTextBox.Text, new Address(countryComboBox.Text, cityTextBox.Text, addressTextBox.Text, numberTextBox.Text), phoneTextBox1.Text, licenceComboBox.Text));
                        MessageBox.Show("User " + nameTextBox.Text + " " + surnameTextBox.Text + " has been added!");

                        nameTextBox.Text = surnameTextBox.Text = numberTextBox.Text = emailTextBox.Text = passwordTextBox.Text = countryComboBox.Text = cityTextBox.Text = addressTextBox.Text = phoneTextBox1.Text = numberTextBox.Text = specializationTextBox.Text = licenceComboBox.Text = "";
                        staffID++;
                    }
                    else if (SecretaryFileStorage.secretaryList.Count != 0)
                    {
                        foreach (CrudModel.Secretary d in SecretaryFileStorage.secretaryList)
                        {
                            if (d.mail.Equals(emailTextBox.Text))
                            {

                                MessageBox.Show("There is user with this email!");
                                tmp = 1;
                                break;
                            }
                        }
                        if (tmp == 0)
                        {
                            SecretaryFileStorage.secretaryList.Add(new CrudModel.Secretary(nameTextBox.Text, surnameTextBox.Text, emailTextBox.Text, passwordTextBox.Text, new Address(countryComboBox.Text, cityTextBox.Text, addressTextBox.Text, numberTextBox.Text), phoneTextBox1.Text, licenceComboBox.Text));
                            MessageBox.Show("User " + nameTextBox.Text + " " + surnameTextBox.Text + " has been added!");

                            nameTextBox.Text = surnameTextBox.Text = emailTextBox.Text = passwordTextBox.Text = countryComboBox.Text = cityTextBox.Text = addressTextBox.Text = phoneTextBox1.Text = specializationTextBox.Text = numberTextBox.Text = licenceComboBox.Text = "";
                            staffID++;
                        }


                    }

                }
                else
                    MessageBox.Show("You must fill all inputs!");

            }
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Doctor)UserGrid.SelectedItem != null)
                DoctorFileStorage.doctorList.Remove((Doctor)UserGrid.SelectedItem);
            if ((Manager)managerGrid.SelectedItem != null)
                ManagerFileStorage.managerList.Remove((Manager)managerGrid.SelectedItem);
            if ((Secretary)secretaryGrid.SelectedItem != null)
                SecretaryFileStorage.secretaryList.Remove((CrudModel.Secretary)secretaryGrid.SelectedItem);
            licenceComboBox.IsEnabled = true;
            nameTextBox.Text = surnameTextBox.Text = numberTextBox.Text = emailTextBox.Text = passwordTextBox.Text = countryComboBox.Text = cityTextBox.Text = addressTextBox.Text = phoneTextBox1.Text = specializationTextBox.Text = licenceComboBox.Text = "";
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            licenceComboBox.IsEnabled = true;
            if (licenceComboBox.Text.Equals("Doctor"))
            {
                int tmp = 0;
                Doctor doct = (Doctor)UserGrid.SelectedItem;
                if ((nameTextBox.Text != "") && (surnameTextBox.Text != "") && (emailTextBox.Text != "") && (passwordTextBox.Text != "") && (countryComboBox.Text != "") && (cityTextBox.Text != "") && (addressTextBox.Text != "") && (numberTextBox.Text != "") && (phoneTextBox1.Text != "") && (specializationTextBox.Text != "") && (licenceComboBox.Text != ""))
                {
                    foreach (Doctor d2 in DoctorFileStorage.doctorList)
                    {
                        if ((d2.mail.Equals(emailTextBox.Text)) && (doct.userID != d2.userID))
                        {
                            MessageBox.Show("There is user with this email!");
                            tmp = 1;
                            break;
                        }
                    }
                    if (tmp == 0)
                    {
                        foreach (Doctor d in DoctorFileStorage.doctorList)
                        {


                            if (doct.userID == d.userID)
                            {

                                d.name = nameTextBox.Text;
                                d.surname = surnameTextBox.Text;
                                d.mail = emailTextBox.Text;
                                d.password = passwordTextBox.Text;
                                d.address.country = countryComboBox.Text;
                                d.address.city = cityTextBox.Text;
                                d.address.street = addressTextBox.Text;
                                d.mobilePhone = phoneTextBox1.Text;
                                d.specialization.specialization = specializationTextBox.Text;
                          
                                d.position = licenceComboBox.Text;
                                d.address.number = numberTextBox.Text;

                            }
                        }
                        nameTextBox.Text = surnameTextBox.Text = numberTextBox.Text = emailTextBox.Text = passwordTextBox.Text = countryComboBox.Text = cityTextBox.Text = addressTextBox.Text = phoneTextBox1.Text = specializationTextBox.Text = licenceComboBox.Text = "";

                    }


                }
                else
                    MessageBox.Show("You must fill all inputs!");
            }
            else if (licenceComboBox.Text.Equals("Manager"))
            {
                int tmp = 0;
                Manager doct = (Manager)managerGrid.SelectedItem;
                if ((nameTextBox.Text != "") && (surnameTextBox.Text != "") && (numberTextBox.Text != "") && (emailTextBox.Text != "") && (passwordTextBox.Text != "") && (countryComboBox.Text != "") && (cityTextBox.Text != "") && (addressTextBox.Text != "") && (phoneTextBox1.Text != "") && (specializationTextBox.Text != "") && (licenceComboBox.Text != ""))
                {
                    foreach (Manager d2 in ManagerFileStorage.managerList)
                    {
                        if ((d2.mail.Equals(emailTextBox.Text)) && (doct.userID != d2.userID))
                        {
                            MessageBox.Show("There is user with this email!");
                            tmp = 1;
                            break;
                        }
                    }
                    if (tmp == 0)
                    {
                        foreach (Manager d in ManagerFileStorage.managerList)
                        {


                            if (doct.userID == d.userID)
                            {

                                d.name = nameTextBox.Text;
                                d.surname = surnameTextBox.Text;
                                d.mail = emailTextBox.Text;
                                d.password = passwordTextBox.Text;
                                d.address.country = countryComboBox.Text;
                                d.address.city = cityTextBox.Text;
                                d.address.street = addressTextBox.Text;
                                d.mobilePhone = phoneTextBox1.Text;
                                d.address.number = numberTextBox.Text;



                            }
                        }
                        nameTextBox.Text = surnameTextBox.Text = numberTextBox.Text = emailTextBox.Text = passwordTextBox.Text = countryComboBox.Text = cityTextBox.Text = addressTextBox.Text = phoneTextBox1.Text = specializationTextBox.Text = licenceComboBox.Text = "";

                    }


                }
                else
                    MessageBox.Show("You must fill all inputs!");
            }
            else if (licenceComboBox.Text.Equals("Secretary"))
            {
                int tmp = 0;
                CrudModel.Secretary doct = (CrudModel.Secretary)secretaryGrid.SelectedItem;
                if ((nameTextBox.Text != "") && (surnameTextBox.Text != "") && (numberTextBox.Text != "") && (emailTextBox.Text != "") && (passwordTextBox.Text != "") && (countryComboBox.Text != "") && (cityTextBox.Text != "") && (addressTextBox.Text != "") && (phoneTextBox1.Text != "") && (specializationTextBox.Text != "") && (licenceComboBox.Text != ""))
                {
                    foreach (CrudModel.Secretary d2 in SecretaryFileStorage.secretaryList)
                    {
                        if ((d2.mail.Equals(emailTextBox.Text)) && (doct.userID != d2.userID))
                        {
                            MessageBox.Show("There is user with this email!");
                            tmp = 1;
                            break;
                        }
                    }
                    if (tmp == 0)
                    {
                        foreach (CrudModel.Secretary d in SecretaryFileStorage.secretaryList)
                        {


                            if (doct.userID == d.userID)
                            {

                                d.name = nameTextBox.Text;
                                d.surname = surnameTextBox.Text;
                                d.mail = emailTextBox.Text;
                                d.password = passwordTextBox.Text;
                                d.address.country = countryComboBox.Text;
                                d.address.city = cityTextBox.Text;
                                d.address.street = addressTextBox.Text;
                                d.mobilePhone = phoneTextBox1.Text;
                                d.address.number = numberTextBox.Text;



                            }
                        }
                        nameTextBox.Text = surnameTextBox.Text = numberTextBox.Text = emailTextBox.Text = passwordTextBox.Text = countryComboBox.Text = cityTextBox.Text = addressTextBox.Text = phoneTextBox1.Text = specializationTextBox.Text = licenceComboBox.Text = "";

                    }


                }
                else
                    MessageBox.Show("You must fill all inputs!");
            }
            UserGrid.Items.Refresh();
            secretaryGrid.Items.Refresh();
            managerGrid.Items.Refresh();
            licenceComboBox.IsEnabled = true;

        }

        private void UserGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Doctor doct = (Doctor)UserGrid.SelectedItem;
            if (doct != null)
            {
                nameTextBox.Text = doct.name;
                surnameTextBox.Text = doct.surname;
                emailTextBox.Text = doct.mail;
                passwordTextBox.Text = doct.password;
                countryComboBox.Text = doct.address.country;
                cityTextBox.Text = doct.address.city;
                addressTextBox.Text = doct.address.street;
                phoneTextBox1.Text = doct.mobilePhone;
                specializationTextBox.Text = doct.specialization.specialization;
                licenceComboBox.Text = doct.position;
                numberTextBox.Text = doct.address.number;
            }
            licenceComboBox.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            countryComboBox.Items.Add("Azerbaijan");
            countryComboBox.Items.Add("Serbia");
            licenceComboBox.Items.Add("Doctor");
            licenceComboBox.Items.Add("Manager");
            licenceComboBox.Items.Add("Secretary");
            foreach(Specialization s in SpecializationFileStorage.specializationList)
            {
                specializationTextBox.Items.Add(s.specialization);
            }

        }

        private void managerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager doct = (Manager)managerGrid.SelectedItem;
            if (doct != null)
            {
                nameTextBox.Text = doct.name;
                surnameTextBox.Text = doct.surname;
                emailTextBox.Text = doct.mail;
                passwordTextBox.Text = doct.password;
                countryComboBox.Text = doct.address.country;
                cityTextBox.Text = doct.address.city;
                addressTextBox.Text = doct.address.street;
                phoneTextBox1.Text = doct.mobilePhone;
                licenceComboBox.Text = doct.position;
                numberTextBox.Text = doct.address.number;
            }
            licenceComboBox.IsEnabled = false;
        }

        private void UserGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            managerGrid.SelectedItem = null;
            secretaryGrid.SelectedItem = null;
        }

        private void managerGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            UserGrid.SelectedItem = null;
            secretaryGrid.SelectedItem = null;
        }

        private void secretaryGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CrudModel.Secretary doct = (CrudModel.Secretary)secretaryGrid.SelectedItem;
            if (doct != null)
            {
                nameTextBox.Text = doct.name;
                surnameTextBox.Text = doct.surname;
                emailTextBox.Text = doct.mail;
                passwordTextBox.Text = doct.password;
                countryComboBox.Text = doct.address.country;
                cityTextBox.Text = doct.address.city;
                addressTextBox.Text = doct.address.street;
                phoneTextBox1.Text = doct.mobilePhone;
                licenceComboBox.Text = doct.position;
                numberTextBox.Text = doct.address.number;
            }
            licenceComboBox.IsEnabled = false;
        }

        private void secretaryGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            UserGrid.SelectedItem = null;
            managerGrid.SelectedItem = null;
        }

        private void position_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(licenceComboBox.Text.Equals("Manager") || licenceComboBox.Text.Equals("Secretary"))
            {
                specializationTextBox.IsEnabled = false;
                specializationTextBox.Text = "";
            }
            else
            {
                specializationTextBox.IsEnabled = true;
            }
        }
    }
}
