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

namespace SIMS_Projekat_Bolnica_Zdravo.DoctorWindows
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {

        public static Window win
        {
            set;get;
        }
        public DialogWindow(string description,string firstOption,string secondOption,Window wi)
        {
            win = wi;
            InitializeComponent();
            desc.Text = description;
            this.firstOption.Content = firstOption;
            this.secondOption.Content = secondOption;
        }

        private void firstOption_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void secondOption_Click(object sender, RoutedEventArgs e)
        {
            if(win != null)
            win.Close();
            this.Close();
        }
    }
}
