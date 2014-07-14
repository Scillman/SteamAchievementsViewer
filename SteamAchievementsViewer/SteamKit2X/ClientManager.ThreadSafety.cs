using System;
using System.Windows.Forms;

/* Thread Safety
 *   This file is to ensure we can invoke events on the parent thread. (control)
 */

namespace SteamKit2X
{
    partial class ClientManager
    {
        /// <summary>
        /// The parent of the manager.
        /// </summary>
        private Control parent;

        /// <summary>
        /// Initialize thread safety fields.
        /// </summary>
        private void InitializeThreadSafety()
        {

        }

        /// <summary>
        /// Invoke a method on the parent. (UI Thread)
        /// </summary>
        /// <param name="method">The method that has to be executed on the parent thread.</param>
        private void Invoke(Delegate method)
        {
            parent.Invoke(method);
        }
    }
}
