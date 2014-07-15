using SteamKit2;
using System.Diagnostics;
using System.IO;
using UpdateMachineAuthCallback = SteamKit2.SteamUser.UpdateMachineAuthCallback;

/* SENTRY FILE
 *   This file handles the Steam sentry file.
 */
namespace SteamKit2X.Managing // TODO: Look for a proper (persistent location) sample.
{
    partial class SteamManager
    {
        /// <summary>
        /// The buffer containing the sentry file.
        /// </summary>
        private byte[] buffer;

        /// <summary>
        /// The path to the sentry file.
        /// </summary>
        private string sentryFile;

        /// <summary>
        /// Read the sentry hash from file. (asynchronously)
        /// </summary>
        private async void ReadHash()
        {
            // There must be a path to the sentry file first.
            if (!string.IsNullOrWhiteSpace(sentryFile))
            {
                // Ensure the file exists prior to reading it.
                if (File.Exists(sentryFile))
                {
                    // Read the file.
                    using (var stream = new FileStream(sentryFile, FileMode.Open, FileAccess.Read))
                    {
                        buffer = new byte[stream.Length];
                        await stream.ReadAsync(buffer, 0x00, buffer.Length);
                    }
                }
            }
        }

        /// <summary>
        /// Get the sentry hash.
        /// </summary>
        /// <returns>The hash in a byte array.</returns>
        private byte[] GetSentryHash()
        {
            ReadHash();
            return buffer;
        }

        /// <summary>
        /// Called when the machine's authentication data has to be updated.
        /// </summary>
        /// <param name="callback"></param>
        protected override void OnUpdateMachineAuth(UpdateMachineAuthCallback callback)
        {
            System.Diagnostics.Debug.WriteLine("OnMachineAuth");

            Debug.WriteLine("Updating sentryfile...");
            sentryFile = callback.FileName; // TODO: Persistent stentryfile location.

            var hash = CryptoHelper.SHAHash(callback.Data);
            File.WriteAllBytes(sentryFile, callback.Data);

            steamUser.SendMachineAuthResponse(new SteamUser.MachineAuthDetails
            {
                FileName = callback.FileName,

                BytesWritten = callback.BytesToWrite,
                FileSize = callback.Data.Length,
                Offset = callback.Offset,

                Result = EResult.OK,
                LastError = 0,

                OneTimePassword = callback.OneTimePassword,

                SentryFileHash = hash
            });

            Debug.WriteLine("Done writing sentryfile!");
        }
    }
}
