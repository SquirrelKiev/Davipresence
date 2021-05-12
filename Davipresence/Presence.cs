using MelonLoader;
using static Davipresence.DavigoDataGrabber;
using System;
using System.Threading;

namespace Davipresence
{
    class Presence : MelonMod
    {
        public const string ClientID = "841783425161887795";
        static Discord.Discord discord;

        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Davipresence Loaded.");

            Thread DiscordThread = new Thread(DoDiscord);
            DiscordThread.Start();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if(GetCurrentScene() != "Main")
            {
                UpdateActivity();
            }
        }

        public override void OnApplicationQuit()
        { discord.Dispose(); }

        public static void DoDiscord()
        {
            discord = new Discord.Discord(Int64.Parse(ClientID), (UInt64)Discord.CreateFlags.Default);
            Thread.Sleep(3000);
            MelonLogger.Msg("Discord should be running");
            UpdateActivity();

            // Pump the event look to ensure all callbacks continue to get fired.

            while (true)
            {
                discord.RunCallbacks();
                Thread.Sleep(1000 / 60);
            }
        }

        static void UpdateActivity()
        {
            // So i can do thing
            Discord.Activity activity = new Discord.Activity
            {
                Timestamps = {
                    Start = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()
                }
            };

            // Logic for figuring out what to display
            string CurrentScene = GetCurrentScene();
            if(CurrentScene == "Main") { return; }
            else if ((GetCurrentScene() == "MenuClosedAlpha"))
                {
                MelonLogger.Msg("In menus, Updating!");
                activity.State = "In menus";
                activity.Assets.LargeImage = "unknown";
                activity.Assets.LargeText = "In menus";
            }


            // MelonLogger.Msg("Yea im gaming dont worry - UpdateActivity");

            // the displaying part
            var activityManager = discord.GetActivityManager();
            

            activityManager.UpdateActivity(activity, result =>
            {
                MelonLogger.Msg("Update Activity: {0}!", result);
            });
        }
    }
}
