using EEApi;
using EEApi.Internal.HTTP;
using EEApi.JSONWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi {
	public static class Get {

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static bool? WrapperUpToDate(out IsError error) {
			error = null;
			var build = Build();

			if(build.Error.ErrorOccurred) {
				error = build.Error;
				return false;
			} else return build.BuildDate == new DateTime(2017, 12, 29);
		}

		/// <summary>
		/// The amount of API Requests sent to the API so far.
		/// </summary>
		public static int APIRequestsMade { get { return HTTPGet.APIRequestsMade; } }

		/// <summary>
		/// Get the build info of the API - identicle to /
		/// </summary>
		/// <returns></returns>
		public static Build Build() {
			var build = DownloadDataManager.GetBuild();

			if (build == null) return null;

			return new Build(build);
		}

		/// <summary>
		/// Get the people online - identicle to /online
		/// </summary>
		/// <returns></returns>
		public static Online Online() {
			var online = DownloadDataManager.GetOnline();

			if (online == null)
				return null;

			return new Online(online);
		}

		/// <summary>
		/// Get the information about the game - identicle to /game
		/// </summary>
		/// <returns></returns>
		public static Game Game() {
			var game = DownloadDataManager.GetGame();

			if (game == null) return null;

			return new Game(game);
		}

		/// <summary>
		/// Get the information about a player by their username - identicle to /player/x?type=name
		/// </summary>
		/// <param name="Username">The username of the player</param>
		/// <returns></returns>
		public static Player PlayerByUsername(string Username) {
			var player = DownloadDataManager.GetPlayerByUsername(Username);

			if (player == null) return null;

			return new Player(player);
		}

		/// <summary>
		/// Get the information about a player by their Userid - identicle to /player/x?type=id
		/// </summary>
		/// <param name="UserID">The UserID of the player</param>
		/// <returns></returns>
		public static Player PlayerByUserID(string UserID) {
			var player = DownloadDataManager.GetPlayerByUserID(UserID);

			if (player == null) return null;

			return new Player(player);
		}

		/// <summary>
		/// Get the information about a world based on the world's id - identicle to /world/x
		/// </summary>
		/// <param name="WorldID">The ID of the world</param>
		/// <returns></returns>
		public static World World(string WorldID) {
			var world = DownloadDataManager.GetWorld(WorldID);

			if (world == null)
				return null;

			return new World(world);
		}

		/// <summary>
		/// Get the rooms online in the lobby, 
		/// </summary>
		/// <returns></returns>
		public static Lobby Lobby() {
			var lobby = DownloadDataManager.GetLobby();

			if (lobby == null) return null;

			return new Lobby(lobby);
		}

		/// <summary>
		/// Get the people who are friends with EEApi
		/// </summary>
		/// <returns></returns>
		public static Friends Friends() {

			//get friends
			var pls = EEApi.Internal.HTTP.DownloadDataManager.GetFriends();

			if (pls == null) return null;

			return new Friends(pls);
		}
	}
}
