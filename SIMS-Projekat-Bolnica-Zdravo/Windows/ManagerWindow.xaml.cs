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
    public partial class ManagerWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public static CrudModel.Manager loggedManager
        {
            get;
            set;
        }

        public ManagerWindow()
        {
            InitializeComponent();
            this.DataContext = new RoomFileStorage();
            if (loggedManager == null)
            {
                Manager m = new Manager("Hana", "Smith", new Address("Srbija", "Novi Sad", "Gogoljeva", "11/12"), "password123", "0654321123", "hanasmith@gmail.com");
                ManagerFileStorage.managerList.Add(m);
                loggedManager = m;
            }
        }
        private void createRoom_Click(object sender, RoutedEventArgs e)
        {
            CreateRoomDialog dialog = new CreateRoomDialog();
            dialog.ShowDialog();
            RoomsListGrid.Items.Refresh();
        }

        private void editRoom_Click(object sender, RoutedEventArgs e)
        {
            if ((Room)RoomsListGrid.SelectedItem != null)
            {
                Room r1 = (Room)RoomsListGrid.SelectedItem;
                if ((inputName.Text != "") && (inputPurpose.Text != "") && (inputFloor.Text != "")){
                    foreach (Room r2 in RoomFileStorage.roomList)
                    {
                        if (r1.roomID == r2.roomID)
                        {

                            r2.name = inputName.Text;
                            r2.purpose = inputPurpose.Text;
                            r2.floor = int.Parse(inputFloor.Text);
                        }
                    }
                    inputName.Text = "";
                    inputPurpose.Text = "";
                    inputFloor.Text = "";
                }
            }
                RoomsListGrid.Items.Refresh();
        }

        private void deleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if((Room)RoomsListGrid.SelectedItem != null)
            {
                RoomFileStorage.roomList.Remove((Room)RoomsListGrid.SelectedItem);
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            var dia = new MainWindow();
            dia.Show();
            this.Close();
        }

        private void RoomsListGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room r = (Room)RoomsListGrid.SelectedItem;
            if (r != null)
            {
                inputName.Text = r.name;
                inputPurpose.Text = r.purpose;
                inputFloor.Text = Convert.ToString(r.floor);
            }
        }

        private void inputFloor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
