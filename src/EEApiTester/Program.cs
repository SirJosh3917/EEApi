using System;
using System.Collections.Generic;
using System.Text;
using EEApi;

namespace EEApiTester {
	class Program {
		static void Main(string[] args) {
			EEApi.JSONWrapper.IsError err;
			var uptodate = Get.WrapperUpToDate(out err);
			if (uptodate == null) {
				Console.WriteLine("API seems to be down or having issues...");
				Console.WriteLine(err.Error);
			} else if (uptodate == false) {
				Console.WriteLine("API wrapper seems to be out of date. Use at your own risk!");
			} else {
				var build = Get.Build();

				Console.WriteLine(string.Format("API Uptime in days: {0}", build.UpTime.TotalDays));
				Console.WriteLine(string.Format("API Build date: {0}", build.BuildDate.ToLongDateString()));

				var findBotFriends = Get.Friends();

				foreach (var i in findBotFriends.Friends) {
					if (i.IsOnline == true) {
						Console.WriteLine(string.Format("{0} is in world '{1}' ( {2} )", i.Name, i.WorldName, i.WorldId));
					}
				}
			}

			Console.ReadLine();
		}
	}
}
