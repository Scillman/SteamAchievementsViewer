using SteamKit2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateMachineAuthCallback = SteamKit2.SteamUser.UpdateMachineAuthCallback;

namespace SteamKit2X
{
    partial class SteamClient
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
        /// Initialize all the authentication related variables.
        /// </summary>
        private void InitializeAuthentication()
        {

        }

        /// <summary>
        /// Read the sentry hash from file.
        /// </summary>
        private async void ReadHash()
        {
            // There must be a path to the sentry file first.
            if (sentryFile != null)
            {
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

        private void OnMachineAuth(UpdateMachineAuthCallback callback)
        {
            Debug.WriteLine("Updating sentryfile...");
            sentryFile = callback.FileName;

            var hash = CryptoHelper.SHAHash(callback.Data);
            File.WriteAllBytes(sentryFile, callback.Data);

            SteamUser.SendMachineAuthResponse(new SteamUser.MachineAuthDetails
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
