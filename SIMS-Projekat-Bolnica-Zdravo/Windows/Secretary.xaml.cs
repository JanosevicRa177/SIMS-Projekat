using System.Windows;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    /// <summary>
    /// Interaction logic for Secretary.xaml
    /// </summary>
    public partial class Secretary : Window
    {
        public Secretary()
        {
           
            InitializeComponent();
           

        }

        
        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            StaffRegistrationWindow srw = new StaffRegistrationWindow();
            srw.Show();
            this.Close();
        }
    }
}
