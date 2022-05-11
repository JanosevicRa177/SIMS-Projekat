using SIMS_Projekat_Bolnica_Zdravo.Windows;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SIMS_Projekat_Bolnica_Zdravo.PatientWindows
{
    public partial class MainHamburgerMenu : Window
    {
        public Boolean closed = true;
        private DoubleAnimation anim { get; set; }
        private static PatientWindow patientWindow;
        public MainHamburgerMenu(PatientWindow patientWindow1)
        {
            patientWindow = patientWindow1;
            this.Top = 141;
            this.Left = 559;
            InitializeComponent();
            anim = new DoubleAnimation()
            {
                Duration = TimeSpan.FromSeconds(0),
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseInOut },
            };
            RenderTransform = new ScaleTransform(1, 1, 0, ActualHeight / 2);
            anim.To = 0;
            RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, anim);
            closed = true;
        }
        public void Open_menu() 
        {
            anim = new DoubleAnimation()
            {
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseInOut },
            };
            RenderTransform = new ScaleTransform(1, 1, 0, ActualHeight / 2);
            anim.From = 0;
            RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, anim);
            closed = false;
        }
        public void Close_menu()
        {
            anim = new DoubleAnimation()
            {
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseInOut },
            };
            RenderTransform = new ScaleTransform(1, 1, 0, ActualHeight / 2);
            anim.To = 0;
            RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, anim);
            closed = true;
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            patientWindow.signout();
        }
    }
}
