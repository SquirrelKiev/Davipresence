using System;
using MelonLoader;
using UnityEngine;

namespace Davipresence
{
    public class DP : MelonMod
    {
        private static Discord.Discord discord;
        private const long clientId = 841783425161887795;

        private static Discord.Activity activity;
        private static MatchController matchController = null;

        private static string currentSceneName;

        public override void OnApplicationStart()
        {
            discord = new Discord.Discord(clientId, (UInt64)Discord.CreateFlags.NoRequireDiscord);
        }

        public override void OnUpdate()
        {
            GetMatchController();
            discord.RunCallbacks();
        }
        
        public override void OnSceneWasLoaded(int buildIndex,string sceneName)
        {
            currentSceneName = sceneName;
            if(matchController != null)
            {
                MelonLogger.Msg(matchController.match.Map.identifier);
            }

            SetActivity();
        }

        public override void OnApplicationQuit()
        {
            discord.Dispose();
        }


        private static void SetActivity()
        {
            Discord.ActivityManager activityManager = discord.GetActivityManager();

            activity = new Discord.Activity
            {
                Timestamps =
                {
                    Start = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds(),
                },
            };

            switch(currentSceneName)
            {
                case "Main":
                    return;
                case "Menu":
                    activity.State = "In menus";
                    activity.Assets.LargeImage = "davimenu";
                    activity.Assets.LargeText = "In menus";
                    break;
                default:
                    activity.State = "In game";
                    activity.Details = currentSceneName + " (" + matchController.match.WarriorCount + " of 4)";
                    break;
            }
            

            activityManager.UpdateActivity(activity, (result) =>
            {
                #if DEBUG
                if (result == Discord.Result.Ok)
                {
                    MelonLogger.Msg("Success!");
                }
                else
                {
                    MelonLogger.Error("Failed");
                }
                #endif
            });
        }

        private void GetMatchController()
        {
            if (currentSceneName != "Main" && matchController == null)
            {
                matchController = UnityEngine.Object.FindObjectOfType<MatchController>();
            }
        }
    }
}
