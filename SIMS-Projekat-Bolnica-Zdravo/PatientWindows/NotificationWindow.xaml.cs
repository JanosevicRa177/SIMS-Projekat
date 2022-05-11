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
using System.Windows.Threading;

namespace SIMS_Projekat_Bolnica_Zdravo.PatientWindows
{
    /// <summary>
    /// Interaction logic for NotificationWindow.xaml
    /// </summary>
    public partial class NotificationWindow : Window
    {
        public String notificationTitle { get; set; }
        public String notificationContent { get; set; }
        public NotificationWindow(string notificationTitle, string notificationContent)
        {
            this.notificationContent = notificationContent;
            this.notificationTitle = notificationTitle;
            this.Top = 140;
            this.Left = 559;
            this.DataContext = this;
            InitializeComponent();
            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
            }));
        }

    }
}
