using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using PlayerIOClient;
using EEApi;

namespace EEApiBot {
	class Program {
		static void Main(string[] args) {
			var game = Get.Game();
			int ver = 227;

			if(game.Error.ErrorOccurred == false)
				ver = (game.Version == null ? ver : (int)game.Version);

			/*var client = PlayerIO.QuickConnect.SimpleConnect("everybody-edits-su9rn58o40itdbnw69plyw", "", "", null);
			var con = client.Multiplayer.CreateJoinRoom("", "Everybodyedits" + ver, true, null, null);

			con.OnMessage += con_OnMessage;
			con.Send("init");*/

			var world = Get.World("PWNdrYZCd0cEI");

			Console.ReadLine();
		}

		static Dictionary<int, EEApi.JSONWrapper.Player> Players = new Dictionary<int, EEApi.JSONWrapper.Player>();

		static void con_OnMessage(object sender, Message e) {
			var con = (Connection)sender;
			switch (e.Type) {
				case "init": {
					con.Send("init2");
				} break;

				case "add": {
					Players[e.GetInt(0)] = Get.PlayerByUsername(e.GetString(1));
				} break;

				case "say": {
					if (e.GetString(1) == "!info") {
						EEApi.JSONWrapper.Player player;

						if (Players.TryGetValue(e.GetInt(0), out player)) {
							Pm(player, con, "Banned: " + player.Banned);
							Pm(player, con, "CurrentEnergy: " + player.CurrentEnergy);
							Pm(player, con, "Gems: " + player.Gems);
							Pm(player, con, "HasBeta: " + player.HasBeta);
							Pm(player, con, "Id: " + player.Id);
							Pm(player, con, "IsAdministrator: " + player.IsAdministrator);
							Pm(player, con, "IsGold: " + player.IsGold);
							Pm(player, con, "IsModerator: " + player.IsModerator);
							Pm(player, con, "LastLogin: " + player.LastLogin);
							Pm(player, con, "LastMagicCoin: " + player.LastMagicCoin);
							Pm(player, con, "LoginStreak: " + player.LoginStreak);
							Pm(player, con, "MaximumEnergy: " + player.MaximumEnergy);
							Pm(player, con, "Name: " + player.Name);
							Pm(player, con, "RegistrationDate: " + player.RegistrationDate);
							Pm(player, con, "Smiley: " + player.Smiley);
							Pm(player, con, "TempBanned: " + player.TempBanned);
							Pm(player, con, "Timezon: " + player.Timezone);
							Pm(player, con, "TotalItems: " + player.TotalItems);
							Pm(player, con, "Visible: " + player.Visible);
							Pm(player, con, "WorldsHave: " + player.WorldsHave);
						}
					}
				} break;
			}
		}

		static void Pm(EEApi.JSONWrapper.Player p, Connection con, string msg) {
			con.Send("say", "/pm " + p.Name + " " + msg);
			System.Threading.Thread.Sleep(750);
		}
	}
}
