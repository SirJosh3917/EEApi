using System;
using System.Collections.Generic;
using System.Text;

//http://ee-api.lrussell.net/lobby

namespace EEApi.JSONWrapper {

	/// <summary>
	/// A class for the lobby, retreivable by /lobby
	/// </summary>
	public class Lobby : Wrapper {
		internal Lobby() { }

		#region properties
		private RoomWrapper[] _rooms;

		/// <summary>
		/// Returns an array of the rooms that are online, from order of most online to least online, then A-Z.
		/// </summary>
		public RoomWrapper[] Rooms {
			get {
				return _rooms;
			}
			set {
				_rooms = value; //we need to make the rooms sort by online and name a-z

				if (value != null) {
					//Automatically sort rooms by online when we put in the values
					Array.Sort(_rooms, delegate(RoomWrapper a, RoomWrapper b) {
						if (a == null || b == null ||
							a.Online == null || b.Online == null)
							return 0;
						if (a.Online < b.Online)
							return 1;
						if (a.Online > b.Online)
							return -1;

						//They're the same, organize by world name

						if (a.Name == null || b.Name == null)
							return 0;

						return a.Name.CompareTo(b.Name);
					});
				}
			}
		}
		#endregion
	}
}
