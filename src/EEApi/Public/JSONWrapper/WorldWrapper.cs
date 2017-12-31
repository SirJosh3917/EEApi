using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

//http://ee-api.lrussell.net/world/

namespace EEApi.JSONWrapper {

	/// <summary>
	/// A class for retreiving the data associated with a world, retreivable by /world/
	/// A WorldWrapper differs from a RoomWrapper, because a RoomWrapper is used to retrieve the live status of the world, e.g. the amount of players in it and such.
	/// A WorldWrapper however, is used to get static, saved information from the world, such as the Type of the world, or the Width and Height.
	/// </summary>
	public class WorldWrapper : Wrapper {
		internal WorldWrapper() { }

		#region properties
		/// <summary>
		/// The Id of the world
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// The name of the world set by the owner
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The owner of the world
		/// </summary>
		public string Owner { get; set; }

		/// <summary>
		/// The description of the world set by the owner
		/// </summary>
		public string WorldDescription { get; set; }

		/// <summary>
		/// The background color of the world
		/// </summary>
		public string BackgroundColor { get; set; }

		/// <summary>
		/// Is it in the featured list/tab of EE?
		/// </summary>
		public bool? IsFeatured { get; set; }

		/// <summary>
		/// How wide is it, in blocks
		/// </summary>
		public int? Width { get; set; }

		/// <summary>
		/// How high is it, in blocks
		/// </summary>
		public int? Height { get; set; }

		/// <summary>
		/// What type of world is it? ( e.g. Small, Medium, Large, Huge, Wide, e.t.c )
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// If it is hidden from the lobby
		/// </summary>
		public bool? HideLobby { get; set; }

		/// <summary>
		/// If it is visible in the player's profile
		/// </summary>
		public bool? Visible { get; set; }

		/// <summary>
		/// How many plays it has
		/// </summary>
		public int? Plays { get; set; }

		/// <summary>
		/// How many likes it has
		/// </summary>
		public int? Likes { get; set; }

		/// <summary>
		/// How many favorites it has
		/// </summary>
		public int? Favorites { get; set; }

		/// <summary>
		/// The crew that it belongs to
		/// </summary>
		public string Crew { get; set; }

		/// <summary>
		/// The status of the world, related to crew: WIP? OPEN? RELEASED?
		/// </summary>
		public string Status { get; set; }

		/// <summary>
		/// The maximum amount of zombies allowed
		/// </summary>
		public int? ZombieLimit { get; set; }

		/// <summary>
		/// The maximum amount of curses allowed
		/// </summary>
		public int? CurseLimit { get; set; }
		#endregion
	}
}