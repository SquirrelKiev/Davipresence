using System;
using MelonLoader;

namespace Davipresence
{
    public class DP : MelonMod
    {
        private static Discord.Discord discord;
        private const long clientId = 841783425161887795;

        private static Discord.Activity activity;

        public override void OnApplicationStart()
        {
            discord = new Discord.Discord(clientId, (UInt64)Discord.CreateFlags.Default);
            SetActivity();
        }

        public override void OnUpdate()
        {
            discord.RunCallbacks();
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
                State = "In Play Mode",
                Details = "Playing the Trumpet!",
                Timestamps =
                  {
                      Start = 5,
                  },
                /*Assets =
                  {
                      LargeImage = "foo largeImageKey", // Larger Image Asset Key
                      LargeText = "foo largeImageText", // Large Image Tooltip
                      SmallImage = "foo smallImageKey", // Small Image Asset Key
                      SmallText = "foo smallImageText", // Small Image Tooltip
                  },*/
            };

            activityManager.UpdateActivity(activity, (result) =>
            {
                if (result == Discord.Result.Ok)
                {
                    MelonLogger.Msg("Success!");
                }
                else
                {
                    MelonLogger.Error("Failed");
                }
            });
        }

        
    }
}
