﻿using MelonLoader;
using static Davipresence.DavigoDataGrabber;
using System;
using System.Threading;

namespace Davipresence
{
    class Presence : MelonMod
    {
        private const string clientID = "841783425161887795";
        public static string currentMapID;
        static Discord.Discord discord;

        private static bool matchControllerExists = false;

        private static int playerCount = 0;

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
                if(GetCurrentScene() == "MenuClosedAlpha")
                {
                    matchControllerExists = false;
                }
            }
        }

        public override void OnApplicationQuit()
        { discord.Dispose(); }

        public static void DoDiscord()
        {
            discord = new Discord.Discord(Int64.Parse(clientID), (UInt64)Discord.CreateFlags.Default);
            Thread.Sleep(3000);
            // MelonLogger.Msg("Discord should be running");
            UpdateActivity();

            // Do callback thing to update the status. 

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
                // MelonLogger.Msg("In menus, Updating!");
                activity.State = "In menus";
                activity.Assets.LargeImage = "davimenu";
                activity.Assets.LargeText = "In menus";
            }
            else
            {
                DaviMap currentMap = GetDaviMap(GetCurrentScene());
                activity.State = "In game";
                activity.Details = currentMap.DisplayName + " (" + playerCount.ToString() + " of 4)";
                activity.Assets.LargeImage = currentMap.AssetKey;
                activity.Assets.LargeText = currentMap.DisplayName;
            }


            // MelonLogger.Msg("Yea im gaming dont worry - UpdateActivity");

            // the displaying part
            var activityManager = discord.GetActivityManager();
            

            activityManager.UpdateActivity(activity, result =>
            {
                // MelonLogger.Msg("Update Activity: {0}!", result);
            });
        }


        public override void OnUpdate()
        {
            if(GetCurrentScene() != "Main" && !matchControllerExists)
            {
                MatchController matchController = UnityEngine.Object.FindObjectOfType<MatchController>();
                if (matchController != null)
                {
                    playerCount = matchController.match.WarriorCount;
                    currentMapID = matchController.match.Map.identifier;
                    matchControllerExists = true;
                }
            }
        }
    }
}
