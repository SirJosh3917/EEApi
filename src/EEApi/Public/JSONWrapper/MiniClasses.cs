using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi.JSONWrapper {
	/// <summary>
	/// The class for storing a world by it's ID and Name.
	/// </summary>
	public class SimpleWorld : Wrapper {
		public SimpleWorld(string _WorldId, string _WorldName) {
			this.WorldId = _WorldId;
			this.WorldName = _WorldName;
		}

		/// <summary>
		/// The WorldId of the world.
		/// </summary>
		public string WorldId { get; set; }

		/// <summary>
		/// The name of the world in question.
		/// </summary>
		public string WorldName { get; set; }
	}

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