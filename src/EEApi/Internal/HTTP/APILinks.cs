using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi.Internal.HTTP {
	internal static class APILinks {
		/// <summary>
		/// Base link of the API. Could change if you decide to replicate the API somehow.
		/// </summary>
		public const string baseLink = "http://ee-api.lrussell.net/";

		/// <summary>
		/// Get the build version and info of the API.
		/// </summary>
		/// <returns>The URL to download data from/returns>
		public static string GetBuild() {
			return baseLink;
		}

		/// <summary>
		/// Gets a player based on their username
		/// </summary>
		/// <param name="Authentication">The username</param>
		/// <returns>The URL to download data from</returns>
		public static string GetPlayerByUsername(string Authentication) {
			return string.Format("{0}player/{1}?type=name", baseLink, Authentication);
		}

		/// <summary>
		/// Gets a player based on their user id
		/// </summary>
		/// <param name="Authentication">The user's id</param>
		/// <returns>The URL to download data from</returns>
		public static string GetPlayerByUserID(string Authentication) {
			return string.Format("{0}player/{1}?type=id", baseLink, Authentication);
		}

		/// <summary>
		/// Gets a world's information based on it's id
		/// </summary>
		/// <param name="WorldId">The world's id</param>
		/// <returns>The URL to download data from</returns>
		public static string GetWorld(string WorldId) {
			return string.Format("{0}world/{1}", baseLink, WorldId);
		}

		/// <summary>
		/// Gets the information about the lobby
		/// </summary>
		/// <returns>The URL to download data from</returns>
		public static string GetLobby() {
			return string.Format("{0}lobby", baseLink);
		}

		/// <summary>
		/// Gets the information about the online players
		/// </summary>
		/// <returns>The URL to download data from</returns>
		public static string GetOnline() {
			return string.Format("{0}online", baseLink);
		}

		/// <summary>
		/// Gets the information about the friends of 'ee api'
		/// </summary>
		/// <returns>The URL to download data from</returns>
		public static string GetFriends() {
			return string.Format("{0}friends", baseLink);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>The URL to download data from</returns>
		public static string GetGame() {
			return string.Format("{0}game", baseLink);
		}
	}
}
