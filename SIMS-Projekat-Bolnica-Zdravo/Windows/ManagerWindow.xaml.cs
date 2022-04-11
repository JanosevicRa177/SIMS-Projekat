using CrudModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
        public static Manager loggedManager
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

        }

        private void deleteRoom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
