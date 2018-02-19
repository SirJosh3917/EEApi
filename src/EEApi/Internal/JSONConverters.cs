using EEApi.JSONWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi.Internal {
	internal static class JSONConverters {
		public static Player GetFrom(PlayerJSON pjson) {
			Player playerNew = new Player();

			playerNew.Banned = pjson.Banned;
			playerNew.CurrentEnergy = pjson.CurrentEnergy;
			playerNew.Error = pjson.Error;
			playerNew.Gems = pjson.Gems;
			playerNew.HasBeta = pjson.HasBeta;
			playerNew.Id = pjson.Id;
			playerNew.IsAdministrator = pjson.IsAdministrator;
			playerNew.IsGold = pjson.IsGold;
			playerNew.IsModerator = pjson.IsModerator;
			playerNew.LastLogin = pjson.LastLogin;
			playerNew.LastMagicCoin = pjson.LastMagicCoin;
			playerNew.LoginStreak = pjson.LoginStreak;
			playerNew.MaximumEnergy = pjson.MaximumEnergy;
			playerNew.Name = pjson.Name;
			playerNew.RegistrationDate = pjson.RegistrationDate;
			playerNew.Smiley = pjson.Smiley;
			playerNew.TempBanned = pjson.TempBanned;
			playerNew.Timezone = pjson.Timezone;
			playerNew.TotalItems = pjson.TotalItems;
			playerNew.Visible = pjson.Visible;

			if (pjson.Worlds != null) {
				List<SimpleWorld> worlds = new List<SimpleWorld>();

				foreach (var i in pjson.Worlds.Keys) {
					if (i != null) {
						string val;

						if (pjson.Worlds.TryGetValue(i, out val)) {
							worlds.Add(new SimpleWorld(i, val));
						}
					}
				}

				playerNew.WorldsHave = worlds.ToArray();
			} else
				playerNew.WorldsHave = null;

			return playerNew;
		}
	}
}
