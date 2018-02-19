using System;
using System.Collections.Generic;
using System.Text;
using EEApi.JSONWrapper;

namespace EEApi.Internal {
	internal static class DeNuller {
		public static Build RemoveNulls(Build build) {
			var modify = build;

			if (modify == null)
				modify = new Build();

			if (modify.BuildDate == null)
				modify.BuildDate = DateTime.MinValue;

			if (modify.Error == null)
				modify.Error = new IsError(true, "DENULLER");

			if (modify.Error.Error == null)
				modify.Error.Error = "DENULLER";

			if (modify.HostName == null)
				modify.HostName = "";

			if (modify.Time == null)
				modify.Time = DateTime.MinValue;

			if (modify.UpTime == null)
				modify.UpTime = TimeSpan.MinValue;

			return modify;
		}

		public static Online RemoveNulls(Online online) {
			var modify = online;

			if (modify == null)
				modify = new Online();

			if (modify.Error == null)
				modify.Error = new IsError(true, "DENULLER");

			if (modify.Error.Error == null)
				modify.Error.Error = "DENULLER";

			if (modify.PlayersOnline == null)
				modify.PlayersOnline = new OnlinePlayer[0];

			for (int i = 0; i < modify.PlayersOnline.Length; i++) {
				if (modify.PlayersOnline[i] == null)
					modify.PlayersOnline[i] = new OnlinePlayer("", "");

				if (modify.PlayersOnline[i].Error == null)
					modify.PlayersOnline[i].Error = new IsError(true, "DENULLER");

				if (modify.PlayersOnline[i].Error.Error == null)
					modify.PlayersOnline[i].Error.Error = "DENULLER";

				if (modify.PlayersOnline[i].UserId == null)
					modify.PlayersOnline[i].UserId = "";

				if (modify.PlayersOnline[i].Username == null)
					modify.PlayersOnline[i].Username = "";
			}

			return modify;
		}

		public static Game RemoveNulls(Game game) {
			var modify = game;

			if (modify == null)
				modify = new Game();

			if (modify.Error == null)
				modify.Error = new IsError(true, "DENULLER");

			if (modify.Error.Error == null)
				modify.Error.Error = "DENULLER";

			if (modify.Version == null)
				modify.Version = 227; //compiled constant date //TODO: compiled constants class

			return modify;
		}

		public static Player RemoveNulls(Player player) {
			var modify = player;

			if (modify == null)
				modify = new Player();

			if (modify.Banned == null)
				modify.Banned = false;

			if (modify.CurrentEnergy == null)
				modify.CurrentEnergy = 200; //compiled constant

			if (modify.Error == null)
				modify.Error = new IsError(true, "DENULLER");

			if (modify.Error.Error == null)
				modify.Error.Error = "DENULLER";

			if (modify.Gems == null)
				modify.Gems = 0; //compiled constant

			if (modify.HasBeta == null)
				modify.HasBeta = false;

			if (modify.Id == null)
				modify.Id = "";

			if (modify.IsAdministrator == null)
				modify.IsAdministrator = false;

			if (modify.IsGold == null)
				modify.IsGold = false;

			if (modify.IsModerator == null)
				modify.IsModerator = false;

			if (modify.LastLogin == null)
				modify.LastLogin = DateTime.MinValue;

			if (modify.LastMagicCoin == null)
				modify.LastMagicCoin = DateTime.MinValue;

			if (modify.LoginStreak == null)
				modify.LoginStreak = 0;

			if (modify.MaximumEnergy == null)
				modify.MaximumEnergy = 200;

			if (modify.Name == null)
				modify.Name = "";

			if (modify.RegistrationDate == null)
				modify.RegistrationDate = DateTime.MinValue;

			if (modify.Smiley == null)
				modify.Smiley = 0;

			if (modify.TempBanned == null)
				modify.TempBanned = false;

			if (modify.Timezone == null)
				modify.Timezone = 0;

			if (modify.TotalItems == null)
				modify.TotalItems = 0;

			if (modify.Visible == null)
				modify.Visible = true;

			/*if (modify.Worlds == null) //worlds is purely for JSON parsing reasons.
				modify.Worlds = new Dictionary<string, string>();

			foreach (var i in modify.Worlds.Keys)
				if (modify.Worlds[i] == null)
					modify.Worlds[i] = "";*/ 

			if (modify.WorldsHave == null)
				modify.WorldsHave = new SimpleWorld[0];

			for (int i = 0; i < modify.WorldsHave.Length; i++) {
				if (modify.WorldsHave[i] == null)
					modify.WorldsHave[i] = new SimpleWorld("", "");

				if (modify.WorldsHave[i].Error == null)
					modify.WorldsHave[i].Error = new IsError(true, "DENULLER");

				if (modify.WorldsHave[i].Error.Error == null)
					modify.WorldsHave[i].Error.Error = "DENULLER";

				if (modify.WorldsHave[i].WorldId == null)
					modify.WorldsHave[i].WorldId = "";

				if (modify.WorldsHave[i].WorldName == null)
					modify.WorldsHave[i].WorldName = "";
			}

			return modify;
		}

		public static World RemoveNulls(World world) {
			var modify = world;

			if (modify == null)
				modify = new World();

			if (modify.BackgroundColor == null)
				modify.BackgroundColor = 0;

			if (modify.Crew == null)
				modify.Crew = "";

			if (modify.CurseLimit == null)
				modify.CurseLimit = 0;

			if (modify.Error == null)
				modify.Error = new IsError(true, "DENULLER");

			if (modify.Error.Error == null)
				modify.Error.Error = "DENULLER";

			if (modify.Favorites == null)
				modify.Favorites = 0;

			if (modify.Height == null)
				modify.Height = 200;

			if (modify.Width == null)
				modify.Width = 200;

			if (modify.WorldDescription == null)
				modify.WorldDescription = "";

			if (modify.ZombieLimit == null)
				modify.ZombieLimit = 0;

			return modify;
		}

		public static Lobby RemoveNulls(Lobby lobby) {
			var modify = lobby;

			if (modify == null)
				modify = new Lobby();

			if (modify.Error == null)
				modify.Error = new IsError(true, "DENULLER");

			if (modify.Error.Error == null)
				modify.Error.Error = "DENULLER";

			if (modify.Rooms == null)
				modify.Rooms = new RoomWrapper[0];

			for (int i = 0; i < modify.Rooms.Length; i++) {
				if (modify.Rooms[i] == null)
					modify.Rooms[i] = new RoomWrapper();

				if (modify.Rooms[i].Description == null)
					modify.Rooms[i].Description = "";

				if (modify.Rooms[i].Error == null)
					modify.Rooms[i].Error = new IsError(true, "DENULLER");

				if (modify.Rooms[i].Error.Error == null)
					modify.Rooms[i].Error.Error = "DENULLER";

				if (modify.Rooms[i].Favorites == null)
					modify.Rooms[i].Favorites = 0;

				if (modify.Rooms[i].Id == null)
					modify.Rooms[i].Id = "";

				if (modify.Rooms[i].IsCampaign == null)
					modify.Rooms[i].IsCampaign = false;

				if (modify.Rooms[i].IsFeatured == null)
					modify.Rooms[i].IsFeatured = false;

				if (modify.Rooms[i].Likes == null)
					modify.Rooms[i].Likes = 0;

				if (modify.Rooms[i].LobbyPreviewEnabled == null)
					modify.Rooms[i].LobbyPreviewEnabled = true;

				if (modify.Rooms[i].Name == null)
					modify.Rooms[i].Name = "";

				if (modify.Rooms[i].NeedsKey == null)
					modify.Rooms[i].NeedsKey = true;

				if (modify.Rooms[i].Online == null)
					modify.Rooms[i].Online = 0;

				if (modify.Rooms[i].Owned == null)
					modify.Rooms[i].Owned = "";

			}
			return modify;
		}

		public static Friends RemoveNulls(Friends friends) {
			var modify = friends;

			if (modify == null)
				modify = new Friends();

			if (modify.Error == null)
				modify.Error = new IsError(true, "DENULLER");

			if (modify.Error.Error == null)
				modify.Error.Error = "DENULLER";

			if (modify.FriendsList == null)
				modify.FriendsList = new FriendWrapper[0];

			for (int i = 0; i < modify.FriendsList.Length; i++) {
				if (modify.FriendsList[i] == null)
					modify.FriendsList[i] = new FriendWrapper();

				if (modify.FriendsList[i].Error == null)
					modify.FriendsList[i].Error = new IsError(true, "DENULLER");

				if (modify.FriendsList[i].Error.Error == null)
					modify.FriendsList[i].Error.Error = "DENULLER";

				if (modify.FriendsList[i].GoldBorder == null)
					modify.FriendsList[i].GoldBorder = false;

				if (modify.FriendsList[i].IsOnline == null)
					modify.FriendsList[i].IsOnline = false;

				if (modify.FriendsList[i].LastLogin == null)
					modify.FriendsList[i].LastLogin = DateTime.MinValue;

				if (modify.FriendsList[i].Name == null)
					modify.FriendsList[i].Name = "";

				if (modify.FriendsList[i].Smiley == null)
					modify.FriendsList[i].Smiley = 0;

				if (modify.FriendsList[i].WorldId == null)
					modify.FriendsList[i].WorldId = "";

				if (modify.FriendsList[i].WorldName == null)
					modify.FriendsList[i].WorldName = "";
			}

			return modify;
		}

	}
}