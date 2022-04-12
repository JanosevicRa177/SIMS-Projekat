using CrudModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    public partial class CreateRoomDialog : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string test;
        public string Test
        {
            get
            {
                return test;
            }
            set
            {
                if (value != test)
                {

                    test = value;
                    OnPropertyChanged("Test");

                }
            }
        }
        public CreateRoomDialog()
        {
            InitializeComponent();
            this.DataContext = new RoomFileStorage();
        }

        private void createRoom_Click(object sender, RoutedEventArgs e)
        {
            if((inputName.Text != "") && (inputPurpose.Text != "") && (inputFloor.Text != "")) 
            {
                Room room = new Room(inputName.Text, inputPurpose.Text, int.Parse(inputFloor.Text));
                RoomFileStorage.roomList.Add(room);
            }
            else
            {
                MessageBox.Show("You must fill in all the fields!");
            }
           
            this.Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void inputFloor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
