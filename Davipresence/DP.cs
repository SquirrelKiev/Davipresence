using System;
using MelonLoader;

namespace Davipresence
{
    public class DP : MelonMod
    {
        private static Discord.Discord discord;
        private const long clientId = 841783425161887795;

        private static Discord.Activity activity;
        public static MatchController matchController = null;
        public static Govidad.Room govidadMatchController = null;

        public static string currentSceneName;

        public override void OnApplicationStart()
        {
            discord = new Discord.Discord(clientId, (UInt64)Discord.CreateFlags.NoRequireDiscord);
            DavimapsImport.Davimaps = DavimapsImport.GetDaviMaps();
        }

        public override void OnUpdate()
        {
            GetMatchController();
            discord.RunCallbacks();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            currentSceneName = sceneName;

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
                    Start = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()
                },
            };

            switch (currentSceneName)
            {
                case "Main":
                    return;
                case "Menu":
                    activity.State = "In menus";
                    activity.Assets.LargeImage = "davimenu";
                    activity.Assets.LargeText = "In menus";
                    break;
                default:
                    if(govidadMatchController != null)
                    {
                        Davimap davimap = DavimapsImport.GetDavimap(currentSceneName, currentSceneName);

                        activity.State = "In online";
                        // activity.Details = davimap.displayName + " (" + govidadMatchController.warriorControllers.Count + " of 4)";
                        activity.Details = davimap.displayName;
                        activity.Assets.LargeImage = davimap.assetKey;
                        activity.Assets.LargeText = davimap.displayName;
                        break;
                    }
                    else if (matchController != null)
                    {
                        Davimap davimap = DavimapsImport.GetDavimap(currentSceneName, matchController.match.Map.identifier);

                        switch (matchController.match.Mode.gameType)
                        {
                            case GameType.TargetPractice:
                                activity.State = "In Target Smash";
                                activity.Details = davimap.displayName;
                                activity.Assets.LargeImage = davimap.assetKey;
                                activity.Assets.LargeText = davimap.displayName;
                                break;
                            case GameType.Tutorial:
                                activity.State = "In tutorial";
                                activity.Assets.LargeImage = davimap.assetKey;
                                activity.Assets.LargeText = davimap.displayName;
                                break;
                            default:
                                activity.State = "In game";
                                activity.Details = davimap.displayName + " (" + matchController.match.WarriorCount + " of 4)";
                                activity.Assets.LargeImage = davimap.assetKey;
                                activity.Assets.LargeText = davimap.displayName;
                                break;
                        }
                        break;
                    }
                    MelonLogger.Warning("No match controllers found!");
                    break;
            }


            activityManager.UpdateActivity(activity, (result) =>
                {
#if DEBUG
                    if (result == Discord.Result.Ok)
                    {
                        MelonLogger.Msg("Discord status applied!");
                        MelonLogger.Msg("Scene Name: " + currentSceneName);
                        if (matchController != null)
                        {
                            MelonLogger.Msg("Game type: " + matchController.match.Mode.gameType);
                            MelonLogger.Msg("Map ID: " + matchController.match.Map.identifier);
                        }
                    }
                    else
                    {
                        MelonLogger.Error("Failed: " + result.ToString());
                    }
#endif
                });
        }

        private void GetMatchController()
        {
            if (currentSceneName != "Main" && matchController == null || govidadMatchController == null)
            {
                matchController = UnityEngine.Object.FindObjectOfType<MatchController>();
                if(matchController == null)
                {
                    govidadMatchController = UnityEngine.Object.FindObjectOfType<Govidad.Room>();
                }
            }
        }
    }
}
