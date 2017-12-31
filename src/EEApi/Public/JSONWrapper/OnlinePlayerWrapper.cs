using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi.JSONWrapper {

	/// <summary>
	/// A class for the online players
	/// </summary>
	public class OnlinePlayer : Wrapper {
		public OnlinePlayer(string _UserId, string _Username) {
			this.UserId = _UserId;
			this.Username = _Username;
		}

		/// <summary>
		/// The UserID of the user. e.g simple1376194136189x3
		/// </summary>
		public string UserId { get; set; }

		/// <summary>
		/// The Username of the user. e.g. lrussell887
		/// </summary>
		public string Username { get; set; }
	}
}
