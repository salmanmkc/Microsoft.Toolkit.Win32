// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.Windows.Threading;

namespace Microsoft.Toolkit.Wpf.UI.Controls
{
    /// <summary>
    /// Provides additional functionality to the <see cref="Dispatcher"/> object.
    /// </summary>
    internal static class DispatcherExtensions
    {
        /// <summary>
        /// Pushes an empty <see cref="DispatcherFrame"/> at <see cref="DispatcherPriority.ContextIdle"/>.
        /// </summary>
        /// <param name="dispatcher">A <see cref="Dispatcher"/> instance.</param>
        /// <param name="priority">The <see cref="DispatcherPriority"/> of the idle frame.</param>
        /// <remarks>
        /// No frame is pushed if the <paramref name="dispatcher"/> is null, <see cref="Dispatcher.HasShutdownStarted"/> is true, or <see cref="Dispatcher.HasShutdownFinished"/> is true.
        /// </remarks>
        [DebuggerStepThrough]
        internal static void DoEvents(this Dispatcher dispatcher, DispatcherPriority priority = DispatcherPriority.ContextIdle)
        {
            object ExitFrame(object arg)
            {
                ((DispatcherFrame)arg).Continue = false;
                return null;
            }

            // Check if we have a valid dispatcher
            if (dispatcher != null
                && !dispatcher.HasShutdownStarted
                && !dispatcher.HasShutdownFinished)
            {
                // Set the priority to ContextIdle to force the queue to flush higher priority events
                var frame = new DispatcherFrame();
                dispatcher.BeginInvoke(
                    priority,
                    new DispatcherOperationCallback(ExitFrame),
                    frame);
                Dispatcher.PushFrame(frame);
            }
        }
    }
}
