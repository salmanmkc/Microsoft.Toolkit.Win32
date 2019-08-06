// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows;
#if WPF
using System.Windows.Data;
#endif
using System.Windows.Forms;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;

namespace Microsoft.Toolkit.Forms.UI.Controls
{
    internal abstract class WebBaseCompatibilityAdapter :
#if WPF
        DependencyObject, 
#endif
        IWebViewCompatibleAdapter
    {
        protected WebBaseCompatibilityAdapter()
        {
#pragma warning disable CA2214 // Do not call overridable methods in constructors
            Initialize();
#pragma warning restore CA2214 // Do not call overridable methods in constructors
        }

#if WPF
        public static DependencyProperty SourceProperty { get; } = DependencyProperty.Register(nameof(Source), typeof(Uri), typeof(WebBaseCompatibilityAdapter));
#endif

        public abstract Control View { get; }

        public abstract Uri Source { get; set; }

        public abstract bool CanGoBack { get; }

        public abstract bool CanGoForward { get; }

        public abstract event EventHandler<WebViewControlNavigationStartingEventArgs> NavigationStarting;

        public abstract event EventHandler<WebViewControlContentLoadingEventArgs> ContentLoading;

        public abstract event EventHandler<WebViewControlNavigationCompletedEventArgs> NavigationCompleted;

        public abstract bool GoBack();

        public abstract bool GoForward();

        public abstract string InvokeScript(string scriptName);

        public abstract void Navigate(Uri url);

        public abstract void Navigate(string url);

        public abstract void NavigateToString(string text);

        public abstract void Refresh();

        public abstract void Stop();

        protected abstract void Initialize();
    }
}
