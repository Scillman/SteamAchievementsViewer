﻿using SteamAchievementsViewer.Steam;
using SteamKit2;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectedCallback = SteamKit2.SteamClient.ConnectedCallback;
using DisconnectedCallback = SteamKit2.SteamClient.DisconnectedCallback;
using LoggedOffCallback = SteamKit2.SteamUser.LoggedOffCallback;
using LoggedOnCallback = SteamKit2.SteamUser.LoggedOnCallback;
using UpdateMachineAuthCallback = SteamKit2.SteamUser.UpdateMachineAuthCallback;

namespace SteamAchievementsViewer
{
    public partial class LoginForm : SteamAchievementsViewer.Steam.GUI.SteamGUI
    {
        public bool IsRunning { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            RegisterCallbacks();
            IsRunning = false;
        }

        private void RegisterCallbacks()
        {
            // Get the callback manager.
            var manager = Manager.CallbackManager;

            // Steam server(s) connection(s).
            new Callback<ConnectedCallback>(OnConnected, manager);
            new Callback<DisconnectedCallback>(OnDisconnected, manager);

            // Steam user information.
            new Callback<LoggedOnCallback>(OnLoggedOn, manager);
            new Callback<LoggedOffCallback>(OnLoggedOff, manager);

            // Authentication
            new Callback<UpdateMachineAuthCallback>(OnMachineAuth, manager);
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            IsRunning = false;
            Application.Exit();
        }

        private async void Login()
        {
            // Do not run when it is already running.
            if (IsRunning)
                return;

            // Set the state to running.
            IsRunning = true;

            // Let the client connect to the server.
            Manager.SteamClient.Connect();

            // Keep getting the callbacks.
            while (IsRunning)
                await Task.Run(() => Manager.CallbackManager.RunWaitCallbacks(TimeSpan.FromSeconds(1)));
        }

        private void OnConnected(ConnectedCallback callback)
        {
            // We could not connection to Steam.
            if (callback.Result != EResult.OK)
            {
                IsRunning = false;
                Debug.WriteLine("Could not connect to the Steam servers.");
            }
            else
            {
                Debug.WriteLine("Successfully connected to the Steam server(s).");
                
                /**
                 * Sentry hash
                 */
                byte[] hash = null;
                if (File.Exists("sentry.bin"))
                {
                    // If the sentry file was saved.
                    var file = File.ReadAllBytes("sentry.bin");
                    hash = CryptoHelper.SHAHash(file);
                }

                /**
                 * Logon
                 */
                Manager.SteamUser.LogOn(new SteamUser.LogOnDetails
                {
                    // User credentials
                    Username = username.Text,
                    Password = password.Text,

                    // Steam Guard Code
                    AuthCode = steamGuardCode.Enabled ? steamGuardCode.Text : null,

                    SentryFileHash = hash
                });
            }
        }

        private void OnDisconnected(DisconnectedCallback callback)
        {
            IsRunning = false;
            Debug.WriteLine("Disconnected from the Steam server(s) successfully.");
        }

        private void OnLoggedOn(LoggedOnCallback callback)
        {
            if (callback.Result == EResult.AccountLogonDenied)
            {
                // Stop waiting for callbacks till the user entered the Steam Guard Code.
                //IsRunning = false;

                // Enable the Steam Guard Code text box.
                steamGuardCode.SetEnabled(true);
            }
            else if (callback.Result != EResult.OK)
            {
                IsRunning = false;
            }
            else
            {
                Debug.WriteLine("Successfully logged on!");
            }
        }

        private void OnLoggedOff(LoggedOffCallback callback)
        {
            Debug.WriteLine("Logged off of Steam.");
        }

        private void OnMachineAuth(UpdateMachineAuthCallback callback)
        {
            Debug.WriteLine("Updating sentryfile...");

            var hash = CryptoHelper.SHAHash(callback.Data);

            File.WriteAllBytes("sentry.bin", callback.Data);

            Manager.SteamUser.SendMachineAuthResponse(new SteamUser.MachineAuthDetails
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
