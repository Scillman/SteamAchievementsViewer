using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SteamKit2X.Managing
{
    /// <summary>
    /// The <see cref="SteamKit2X.Managing.SteamManager"/> is resposible for most interaction.
    /// </summary>
    public partial class SteamManager : ManagerBase
    {
        /// <summary>
        /// The parent control.
        /// </summary>
        private Control parent;

        /// <summary>
        /// Creates a new instance of the <see cref="SteamKit2X.Managing.SteamManager"/>.
        /// </summary>
        public SteamManager(Control control)
        {
            // Ensure the control is actually set, otherwise the events will not work.
            Debug.Assert(control != null, "The input control may not be null.");
            this.parent = control;

            // Start initializing.
            InitializeUser();
            InitializeFriends();
        }

        /// <summary>
        /// Invoke the event on the thread of the parent control.
        /// </summary>
        /// <param name="method">The method that has to be invoked.</param>
        private void InvokeEvent(Delegate method)
        {
            // Ensure method is not null.
            if (method != null)
                parent.Invoke(method, EventArgs.Empty);
        }
    }
}
