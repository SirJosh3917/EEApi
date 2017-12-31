using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

//http://ee-api.lrussell.net/friends

namespace EEApi.JSONWrapper {

	/// <summary>
	/// A class for friends of the EEAPI bot, retrievable by /friends
	/// </summary>
	public class FriendWrapper : Wrapper {
		internal FriendWrapper() { }

		#region properties
		/// <summary>
		/// Username of the friend
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Boolean to determine if the friend is online
		/// </summary>
		public bool? IsOnline { get; set; }

		/// <summary>
		/// String of the WorldId that the player is currently in; null if none.
		/// </summary>
		public string WorldId { get; set; }

		/// <summary>
		/// String of the name of the World that the player is currently in; null if none.
		/// </summary>
		public string WorldName { get; set; }

		/// <summary>
		/// Integer representing the smiley they're currently wearing.
		/// </summary>
		public int? Smiley { get; set; }

		/// <summary>
		/// String representing the last time the player logged in.
		/// </summary>
		public string LastLogin { get; set; }

		/// <summary>
		/// Boolean to determine if they have a golden border.
		/// </summary>
		public bool? GoldBorder { get; set; }
		#endregion
	}
}
