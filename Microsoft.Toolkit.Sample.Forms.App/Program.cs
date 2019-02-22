// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows.Forms;

namespace Microsoft.Toolkit.Win32.Samples.WinForms.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (new UI.XamlHost.XamlApplication()
            {
                RequestedTheme = Windows.UI.Xaml.ApplicationTheme.Dark,
            })
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                Application.Run(new Form1());
            }
        }
    }
}
