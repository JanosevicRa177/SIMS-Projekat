﻿#pragma checksum "..\..\..\Windows\DoctorsAppointments.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F820BA5C5A45440D4AF2E300CDCC8E4BFB87FB042E3E81F1751E8E1744D90D28"
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
    /// DoctorsAppointments
    /// </summary>
    public partial class DoctorsAppointments : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 14 "..\..\..\Windows\DoctorsAppointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Appointments;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Windows\DoctorsAppointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn patname;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Windows\DoctorsAppointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn patsurname;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Windows\DoctorsAppointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn patid;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Windows\DoctorsAppointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn room;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Windows\DoctorsAppointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn date;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Windows\DoctorsAppointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn time;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Windows\DoctorsAppointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn description;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Windows\DoctorsAppointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn show;
        
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
            System.Uri resourceLocater = new System.Uri("/SIMS-Projekat-Bolnica-Zdravo;component/windows/doctorsappointments.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\DoctorsAppointments.xaml"
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
            this.Appointments = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.patname = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 3:
            this.patsurname = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.patid = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.room = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.date = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.time = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 8:
            this.description = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 9:
            this.show = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 10:
            
            #line 26 "..\..\..\Windows\DoctorsAppointments.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.showButt_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

