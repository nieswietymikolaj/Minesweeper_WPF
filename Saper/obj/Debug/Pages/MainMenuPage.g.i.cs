﻿#pragma checksum "..\..\..\Pages\MainMenuPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "703D5BE263908256A870E481FA79A3CE74854771BA74947A5E2BECD3FFC0AD3D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Saper.Pages;
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


namespace Saper.Pages {
    
    
    /// <summary>
    /// MainMenuPage
    /// </summary>
    public partial class MainMenuPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\Pages\MainMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PictureLeft;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Pages\MainMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PictureRigth;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\MainMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GameButton;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Pages\MainMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SettingsButton;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Pages\MainMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResultsButton;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\Pages\MainMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InformationsButton;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\Pages\MainMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Saper;component/pages/mainmenupage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\MainMenuPage.xaml"
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
            this.PictureLeft = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.PictureRigth = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.GameButton = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\Pages\MainMenuPage.xaml"
            this.GameButton.Click += new System.Windows.RoutedEventHandler(this.GameButton_Click);
            
            #line default
            #line hidden
            
            #line 70 "..\..\..\Pages\MainMenuPage.xaml"
            this.GameButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Game_MouseEnter);
            
            #line default
            #line hidden
            
            #line 71 "..\..\..\Pages\MainMenuPage.xaml"
            this.GameButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SettingsButton = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\Pages\MainMenuPage.xaml"
            this.SettingsButton.Click += new System.Windows.RoutedEventHandler(this.SettingsButton_Click);
            
            #line default
            #line hidden
            
            #line 84 "..\..\..\Pages\MainMenuPage.xaml"
            this.SettingsButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Settings_MouseEnter);
            
            #line default
            #line hidden
            
            #line 85 "..\..\..\Pages\MainMenuPage.xaml"
            this.SettingsButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ResultsButton = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\..\Pages\MainMenuPage.xaml"
            this.ResultsButton.Click += new System.Windows.RoutedEventHandler(this.ResultsButton_Click);
            
            #line default
            #line hidden
            
            #line 98 "..\..\..\Pages\MainMenuPage.xaml"
            this.ResultsButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Results_MouseEnter);
            
            #line default
            #line hidden
            
            #line 99 "..\..\..\Pages\MainMenuPage.xaml"
            this.ResultsButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            this.InformationsButton = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\..\Pages\MainMenuPage.xaml"
            this.InformationsButton.Click += new System.Windows.RoutedEventHandler(this.InformationButton_Click);
            
            #line default
            #line hidden
            
            #line 112 "..\..\..\Pages\MainMenuPage.xaml"
            this.InformationsButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Informations_MouseEnter);
            
            #line default
            #line hidden
            
            #line 113 "..\..\..\Pages\MainMenuPage.xaml"
            this.InformationsButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ExitButton = ((System.Windows.Controls.Button)(target));
            
            #line 123 "..\..\..\Pages\MainMenuPage.xaml"
            this.ExitButton.Click += new System.Windows.RoutedEventHandler(this.ExitButton_Click);
            
            #line default
            #line hidden
            
            #line 127 "..\..\..\Pages\MainMenuPage.xaml"
            this.ExitButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Exit_MouseEnter);
            
            #line default
            #line hidden
            
            #line 128 "..\..\..\Pages\MainMenuPage.xaml"
            this.ExitButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

