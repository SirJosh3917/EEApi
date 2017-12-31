using System;
using System.Collections.Generic;
using System.Text;

//http://ee-api.lrussell.net/online

namespace EEApi.JSONWrapper {

	/// <summary>
	/// A class for the online players, retreivable by /online.
	/// </summary>
	public class OnlineWrapper : OnlineWrapperJSON {
		internal OnlineWrapper() { }

		/// <summary>
		/// A dictionary<string, string> representing each player UserID, and then their EE name.
		/// </summary>
		public OnlinePlayer[] PlayersOnline { get; set; }
	}

	/// <summary>
	/// The form of the class to deserialze to JSON first, then convert to a more user friendly approach.
	/// </summary>
	public class OnlineWrapperJSON : Wrapper {
		internal OnlineWrapperJSON() { }

		/// <summary>
		/// Convert the OnlineWrapperJSON into a more consistent method of an array (found in LobbyWrapper)
		/// </summary>
		/// <returns></returns>
		public OnlineWrapper Convert() { //Convert a Dictionart<string, string> to an Array[] which contains both string properties.
			OnlineWrapper create = new OnlineWrapper();

			create.PlayersOnline = new OnlinePlayer[Players.Count];

			// I can't believe I have to manually do a for loop with a foreach loop, but dictionaries don't allow an easy way to do this.
			int i = 0;
			foreach (var j in Players.Keys) {
				create.PlayersOnline[i] = new OnlinePlayer(j, Players[j]);
				i++;
			}

			return create;
		}

		#region properties
		/// <summary>
		/// A dictionary<string, string> representing each player's UserId, and then their EE name.
		/// </summary>
		internal Dictionary<string, string> Players { get; set; }
		#endregion
	}
}
