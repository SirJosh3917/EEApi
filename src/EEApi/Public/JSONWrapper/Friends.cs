using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi.JSONWrapper {
	public class Friends : Wrapper {
		internal Friends(FriendWrapper[] frnds = null) { this.FriendsList = frnds; }
		internal Friends() { }

		#region properties
		/// <summary>
		/// The friends of the API
		/// </summary>
		public FriendWrapper[] FriendsList { get; set; }
		#endregion
	}
}
