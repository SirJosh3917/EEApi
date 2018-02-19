using EEApi;
using EEApi.Internal;
using EEApi.Internal.HTTP;
using EEApi.JSONWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi {
	public static class Get {
		static Get() { //by default chug mode should be off. chug mode is for lazy developers like me :p
			ChugMode = false;
		}

		/// <summary>
		/// Returns if the wrapper is up to date.
		/// </summary>
		/// <returns></returns>
		public static bool WrapperUpToDate(out IsError error) {
			error = null;
			var build = Build();

			if(build.Error.ErrorOccurred) {
				error = build.Error;
				return false;
			} else return build.BuildDate == new DateTime(2017, 12, 29);
		}

		/// <summary>
		/// Makes the code work like PHP. Your code *should* work fine and normal, everything will just keep chugging along. No reason to check for errors in this mode!
		/// </summary>
		public static bool ChugMode { get; set; }

		public static uint? Timeout { get { return HTTPGet.Timeout; } set { HTTPGet.Timeout = value; } }

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

			if (ChugMode) {
				build = DeNuller.RemoveNulls(build);
			}

			return build;
		}

		/// <summary>
		/// Get the people online - identicle to /online
		/// </summary>
		/// <returns></returns>
		public static Online Online() {
			var online = DownloadDataManager.GetOnline();

			if (ChugMode) {
				online = DeNuller.RemoveNulls(online);
			}

			return online;
		}

		/// <summary>
		/// Get the information about the game - identicle to /game
		/// </summary>
		/// <returns></returns>
		public static Game Game() {
			var game = DownloadDataManager.GetGame();

			if (ChugMode) {
				game = DeNuller.RemoveNulls(game);
			}

			return game;
		}

		/// <summary>
		/// Get the information about a player by their username - identicle to /player/x?type=name
		/// </summary>
		/// <param name="Username">The username of the player</param>
		/// <returns></returns>
		public static Player PlayerByUsername(string Username) {
			var player = DownloadDataManager.GetPlayerByUsername(Username);

			if (ChugMode) {
				player = DeNuller.RemoveNulls(player);
			}

			return player;
		}

		/// <summary>
		/// Get the information about a player by their Userid - identicle to /player/x?type=id
		/// </summary>
		/// <param name="UserID">The UserID of the player</param>
		/// <returns></returns>
		public static Player PlayerByUserID(string UserID) {
			var player = DownloadDataManager.GetPlayerByUserID(UserID);

			if (ChugMode) {
				player = DeNuller.RemoveNulls(player);
			}

			return player;
		}

		/// <summary>
		/// Get the information about a world based on the world's id - identicle to /world/x
		/// </summary>
		/// <param name="WorldID">The ID of the world</param>
		/// <returns></returns>
		public static World World(string WorldID) {
			var world = DownloadDataManager.GetWorld(WorldID);

			if (ChugMode) {
				world = DeNuller.RemoveNulls(world);
			}

			return world;
		}

		/// <summary>
		/// Get the rooms online in the lobby, 
		/// </summary>
		/// <returns></returns>
		public static Lobby Lobby() {
			var lobby = DownloadDataManager.GetLobby();

			if (ChugMode) {
				lobby = DeNuller.RemoveNulls(lobby);
			}

			return lobby;
		}

		/// <summary>
		/// Get the people who are friends with EEApi
		/// </summary>
		/// <returns></returns>
		public static Friends Friends() {
			var friends = EEApi.Internal.HTTP.DownloadDataManager.GetFriends();

			if (ChugMode) {
				friends = DeNuller.RemoveNulls(friends);
			}

			return friends;
		}
	}
}
