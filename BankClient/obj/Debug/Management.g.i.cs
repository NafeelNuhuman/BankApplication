﻿#pragma checksum "..\..\Management.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DB03E8FB192481E02098EB53F2EF9C31A99A6D53F9C887AFEA0C04E9DAAFB0E2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BankClient;
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


namespace BankClient {
    
    
    /// <summary>
    /// Management
    /// </summary>
    public partial class Management : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 61 "..\..\Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView transList;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShowTrans;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnProcessAll;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogOut;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView usersList;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShowUsers;
        
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
            System.Uri resourceLocater = new System.Uri("/BankClient;component/management.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Management.xaml"
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
            this.transList = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.btnShowTrans = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\Management.xaml"
            this.btnShowTrans.Click += new System.Windows.RoutedEventHandler(this.btnShowTrans_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnProcessAll = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\Management.xaml"
            this.btnProcessAll.Click += new System.Windows.RoutedEventHandler(this.btnProcessAll_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnLogOut = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\Management.xaml"
            this.btnLogOut.Click += new System.Windows.RoutedEventHandler(this.btnLogOut_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.usersList = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.btnShowUsers = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\Management.xaml"
            this.btnShowUsers.Click += new System.Windows.RoutedEventHandler(this.btnShowUsers_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

