﻿#pragma checksum "..\..\SandBox.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "43C6F0E54A8073D3C9BE846957AD4881"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PlayGround.Engine.Controls;
using PlayGround.Engine.Emitters;
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


namespace PlayGround {
    
    
    /// <summary>
    /// SandBox
    /// </summary>
    public partial class SandBox : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\SandBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PlayGround.Engine.Controls.ParticleSystem FireParticleSystem;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\SandBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PlayGround.Engine.Controls.ParticleSystem GooParticleSystem;
        
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
            System.Uri resourceLocater = new System.Uri("/SandBox;component/sandbox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SandBox.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.FireParticleSystem = ((PlayGround.Engine.Controls.ParticleSystem)(target));
            return;
            case 2:
            
            #line 38 "..\..\SandBox.xaml"
            ((System.Windows.Controls.Button)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.MyButtonMouseEnter);
            
            #line default
            #line hidden
            
            #line 38 "..\..\SandBox.xaml"
            ((System.Windows.Controls.Button)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.MyButtonMouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GooParticleSystem = ((PlayGround.Engine.Controls.ParticleSystem)(target));
            return;
            case 4:
            
            #line 67 "..\..\SandBox.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MyButtonClicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
