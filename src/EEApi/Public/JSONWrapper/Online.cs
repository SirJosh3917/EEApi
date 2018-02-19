using System;
using System.Collections.Generic;
using System.Text;

//http://ee-api.lrussell.net/online

namespace EEApi.JSONWrapper {

	/// <summary>
	/// A class for the online players, retreivable by /online.
	/// </summary>
	public class Online : Wrapper {
		internal Online() { }

		/// <summary>
		/// A dictionary<string, string> representing each player UserID, and then their EE name.
		/// </summary>
		public OnlinePlayer[] PlayersOnline { get; set; }
	}
}
