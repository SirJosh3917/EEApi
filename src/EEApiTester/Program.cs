using System;
using System.Collections.Generic;
using System.Text;
using EEApi;
using System.Reflection;
using System.Threading;

namespace EEApiTester {
	class Program {
		static bool release = false;

		static void Main(string[] args) {
			//Get.ChugMode = true;

			EEApi.JSONWrapper.IsError err;
			var uptodate = Get.WrapperUpToDate(out err);
			if (!uptodate) {
				Console.WriteLine("API wrapper seems to be out of date. Use at your own risk!");
			} else {
				var build = Get.Build();

				Console.WriteLine(string.Format("API Uptime in days: {0}", build.UpTime.TotalDays));
				Console.WriteLine(string.Format("API Build date: {0}", build.BuildDate.ToLongDateString()));

				var game = Get.Game();

				Console.WriteLine("EE Game Version: {0}", game.Version);

				var findBotFriends = Get.Friends();

				foreach (var i in findBotFriends.FriendsList) {
					if (i.IsOnline == true) {
						Console.WriteLine(string.Format("{0} is in world '{1}' ( {2} )", i.Name, i.WorldName, i.WorldId));
					}
				}

				var lobby = Get.Lobby();

				for(int j = 0; j < lobby.Rooms.Length; j++) { 
					var i = lobby.Rooms[j];

					var world = Get.World(i.Id);
					var owner = Get.PlayerByUserID(world.Owner);

					Console.WriteLine("{0}'s world owner ( {1} ) has beta? {2}", world.Name, owner.Name, owner.HasBeta);
				}
			}

			Console.WriteLine("API Requests: {0}", Get.APIRequestsMade);

			Console.ReadLine();
		}
	}
}
