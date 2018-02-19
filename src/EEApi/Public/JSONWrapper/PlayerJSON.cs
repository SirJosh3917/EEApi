using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

//http://ee-api.lrussell.net/player/

namespace EEApi.JSONWrapper {
	/// <summary>
	/// A class for retreiving the data in a Player's PlayerObject. Retrievable by /player/
	/// </summary>
	internal class PlayerJSON : Wrapper {
		internal PlayerJSON() { }

		#region properties
		/// <summary>
		/// The name of the player
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The ID of the player
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// The maximum amount of energy the player can have at any moment
		/// </summary>
		public int? MaximumEnergy { get; set; }

		/// <summary>
		/// The amount of energy the player has currently
		/// </summary>
		public int? CurrentEnergy { get; set; }

		/// <summary>
		/// The amount of gems the player currently has
		/// </summary>
		public int? Gems { get; set; }

		/// <summary>
		/// The last time the player has logged into EE
		/// </summary>
		public DateTime? LastLogin { get; set; }

		/// <summary>
		/// The last time the player has collected a magic coin
		/// </summary>
		public DateTime? LastMagicCoin { get; set; }

		/// <summary>
		/// When the user registered their account
		/// </summary>
		public DateTime? RegistrationDate { get; set; }

		/// <summary>
		/// How many days the user has logged in a row
		/// </summary>
		public int? LoginStreak { get; set; }

		/// <summary>
		/// The total amount of items that player has bought
		/// </summary>
		public int? TotalItems { get; set; }

		/// <summary>
		/// The smiley the player was last seen wearing, or is currently wearing.
		/// </summary>
		public int? Smiley { get; set; }

		/// <summary>
		/// The timzone the player is in in integer form.
		/// </summary>
		public int? Timezone { get; set; }

		/// <summary>
		/// If the player's profile is visible
		/// </summary>
		public bool? Visible { get; set; }

		/// <summary>
		/// If the player is permanently banned 
		/// </summary>
		public bool? Banned { get; set; }

		/// <summary>
		/// If the player is temporarily banned
		/// </summary>
		public bool? TempBanned { get; set; }

		/// <summary>
		/// If the player has beta
		/// </summary>
		public bool? HasBeta { get; set; }

		/// <summary>
		/// If the player is a gold member
		/// </summary>
		public bool? IsGold { get; set; }

		/// <summary>
		/// If the player is a moderator
		/// </summary>
		public bool? IsModerator { get; set; }

		/// <summary>
		/// if the player is an administrator
		/// </summary>
		public bool? IsAdministrator { get; set; }

		/// <summary>
		/// The worlds in JSON form
		/// </summary>
		public Dictionary<string, string> Worlds { get; set; }
		#endregion
	}
}
