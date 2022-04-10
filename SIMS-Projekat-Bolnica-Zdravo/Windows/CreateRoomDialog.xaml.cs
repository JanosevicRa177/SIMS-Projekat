using CrudModel;
using System;
using System.Collections.Generic;
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
    public partial class CreateRoomDialog : Window
    {
        public CreateRoomDialog()
        {
            InitializeComponent();
            this.DataContext = new RoomFileStorage();
        }

        private void createRoom_Click(object sender, RoutedEventArgs e)
        {
            Room room = new Room(inputID.Text, inputPurpose.Text, int.Parse(inputFloor.Text));
            RoomFileStorage.roomList.Add(room);
            ManagerWindow.loggedManager.AddRoom(room);
            this.Close();
        }
    }
}
