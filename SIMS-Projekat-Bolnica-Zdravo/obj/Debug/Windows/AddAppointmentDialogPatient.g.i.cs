﻿#pragma checksum "..\..\..\Windows\AddAppointmentDialogPatient.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "05ABE14C005E45FB432CD2E37C2C0CC6EEE58AE46E695723157A7D4A9EA4B4EA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SIMS_Projekat_Bolnica_Zdravo.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SIMS_Projekat_Bolnica_Zdravo.Windows {
    
    
    /// <summary>
    /// AddAppointmentDialogPatient
    /// </summary>
    public partial class AddAppointmentDialogPatient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\Windows\AddAppointmentDialogPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox doctorsCB;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Windows\AddAppointmentDialogPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Hours;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Windows\AddAppointmentDialogPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliderHours;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Windows\AddAppointmentDialogPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Minutes;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Windows\AddAppointmentDialogPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliderMinutes;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Windows\AddAppointmentDialogPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Date;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Windows\AddAppointmentDialogPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox desc;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SIMS-Projekat-Bolnica-Zdravo;component/windows/addappointmentdialogpatient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AddAppointmentDialogPatient.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 25 "..\..\..\Windows\AddAppointmentDialogPatient.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Show_Notes);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 26 "..\..\..\Windows\AddAppointmentDialogPatient.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Show_Home);
            
            #line default
            #line hidden
            return;
            case 3:
            this.doctorsCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Hours = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.sliderHours = ((System.Windows.Controls.Slider)(target));
            return;
            case 6:
            this.Minutes = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.sliderMinutes = ((System.Windows.Controls.Slider)(target));
            return;
            case 8:
            this.Date = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            
            #line 57 "..\..\..\Windows\AddAppointmentDialogPatient.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Pick_Date);
            
            #line default
            #line hidden
            return;
            case 10:
            this.desc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            
            #line 61 "..\..\..\Windows\AddAppointmentDialogPatient.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Add_Appointment);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 62 "..\..\..\Windows\AddAppointmentDialogPatient.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Confirm_Add_appointment);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

