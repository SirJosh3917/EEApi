using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi.JSONWrapper {
	public class FriendsWrapper : Wrapper {
		internal FriendsWrapper(FriendWrapper[] frnds = null) { this.Friends = frnds; }
		internal FriendsWrapper() { }

		#region properties
		/// <summary>
		/// The friends of the API
		/// </summary>
		public FriendWrapper[] Friends { get; set; }
		#endregion
	}
}
