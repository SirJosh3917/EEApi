using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

//ee-api.lrussell.net/lobby

namespace EEApi.JSONWrapper {

	/// <summary>
	/// Assistant class in helping with the lobby room data.
	/// A class for the lobby, retreivable by /lobby
	/// 
	/// A RoomWrapper differs from a WorldWrapper, because a WorldWrapper is used to get static, saved information from the world, such as the Type of the world, or the Width and Height.
	/// A RoomWrapper however, is used to retrieve the live status of the world, e.g. the amount of players in it and such.
	/// </summary>
	public class RoomWrapper : Wrapper {
		internal RoomWrapper() { }

		#region properties
		/// <summary>
		/// The name of the room
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The world ID of the room
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// The description of the world, set by the owner.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// The amount of online players in the world.
		/// </summary>
		public int? Online { get; set; }

		/// <summary>
		/// The amount of favorites given to the world.
		/// </summary>
		public int? Favorites { get; set; }

		/// <summary>
		/// The amount of likes given to the world.
		/// </summary>
		public int? Likes { get; set; }

		/// <summary>
		/// If you need a key to edit
		/// </summary>
		public bool? NeedsKey { get; set; }

		/// <summary>
		/// If it is owned by an owner, who is it? ( Blank if there is no owner, e.g. open world )
		/// </summary>
		public string Owned { get; set; }

		/// <summary>
		/// Is it in the featured list of the worlds?
		/// </summary>
		public bool? IsFeatured { get; set; }

		/// <summary>
		/// Is it a campaign world?
		/// </summary>
		public bool? IsCampaign { get; set; }

		/// <summary>
		/// If you can preview it in the lobby
		/// </summary>
		public bool? LobbyPreviewEnabled { get; set; }
		#endregion
	}
}
