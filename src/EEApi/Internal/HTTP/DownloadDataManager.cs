using EEApi.JSONWrapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi.Internal.HTTP {
	internal static class DownloadDataManager {

		/// <summary>
		/// Get the build version and info of the API.
		/// </summary>
		/// <returns>A BuildWrapper</returns>
		public static Build GetBuild() {
			return HTTPRequestManager.GetBuild(HTTPGet.GetBuild());
		}

		/// <summary>
		/// Get the list of friends the EEAPI bot has.
		/// </summary>
		/// <returns>A FriendsWrapper</returns>
		public static Friends GetFriends() {
			return HTTPRequestManager.GetFriends(HTTPGet.GetFriends());
		}

		/// <summary>
		/// Turn's the API's /game into a GameWrapper
		/// </summary>
		/// <returns>A GameWrapper</returns>
		public static Game GetGame() {
			return HTTPRequestManager.GetGame(HTTPGet.GetGame());
		}

		/// <summary>
		/// Turn's the API's /lobby into a LobbyWrapper
		/// </summary>
		/// <returns>A LobbyWrapper</returns>
		public static Lobby GetLobby() {
			return HTTPRequestManager.GetLobby(HTTPGet.GetLobby());
		}
		
		/// <summary>
		/// Turn's the API's /online into an OnlineWrapper
		/// </summary>
		/// <returns>An OnlineWrapper</returns>
		public static Online GetOnline() {
			return HTTPRequestManager.GetOnline(HTTPGet.GetOnline());
		}
		
		/// <summary>
		/// Turn's the API's /player/x?type=name into a PlayerWrapper
		/// </summary>
		/// <param name="Username">The username of the player</param>
		/// <returns>A PlayerWrapper</returns>
		public static Player GetPlayerByUsername(string Username) {
			return HTTPRequestManager.GetPlayer(HTTPGet.GetPlayerByUsername(Username));
		}
		
		/// <summary>
		/// Turn's the API's /player/x?type=id into a PlayerWrapper
		/// </summary>
		/// <param name="UserID">The UserID of the player.</param>
		/// <returns>A PlayerWrapper</returns>
		public static Player GetPlayerByUserID(string UserID) {
			return HTTPRequestManager.GetPlayer(HTTPGet.GetPlayerByUserID(UserID));
		}
		
		/// <summary>
		/// Turn's the API's /lobby into a RoomWrapper[]
		/// </summary>
		/// <returns>A RoomWrapper[]</returns>
		public static RoomWrapper[] GetRooms() {
			return HTTPRequestManager.GetRooms(HTTPGet.GetLobby());
		}
		
		/// <summary>
		/// TWurn's the API's /world/x into a WorldWrapper
		/// </summary>
		/// <param name="WorldID">The World ID of the world.</param>
		/// <returns>A WorldWrapper</returns>
		public static World GetWorld(string WorldID) {
			return HTTPRequestManager.GetWorld(HTTPGet.GetWorld(WorldID));
		}
	}
}
