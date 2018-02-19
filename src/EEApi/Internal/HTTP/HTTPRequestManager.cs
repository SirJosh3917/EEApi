using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using EEApi.JSONWrapper;

namespace EEApi.Internal.HTTP {
	internal static class HTTPRequestManager {
		#region errorwrapper helpers
		internal static ErrorWrapper GetErrorWrapper(byte[] Data) {
			string result = Encoding.UTF8.GetString(Data);

			//first try to convert it to an error using try catch because json.net doesn't support checking stuff
			try {
				var ew = JsonConvert.DeserializeObject<ErrorWrapper>(result);
				if (ew.Error == null || ew.Error.Length == 0) //json.net will convert, but we need to make sure it found an error
					return null;
				return ew;
			} catch (Newtonsoft.Json.JsonException e) {
				return null;
			}
		}

		/// <summary>
		/// The message to spew out when byte[] Data's length is 0.
		/// </summary>
		public const string DataLength0 = "No data recieved";
		public const string InvalidJson = "Invalid JSON was recieved while parsing.";

		/// <summary>
		/// If the byte[] of Data is bad, this will dictate so.
		/// </summary>
		/// <param name="Data">The data in question</param>
		/// <returns>If it's unsuit for use</returns>
		public static bool IsBad(byte[] Data) {
			return Data == null || Data.Length == 0;
		}

		/// <summary>
		/// Create an IsError class
		/// </summary>
		/// <param name="Msg">The message to put in the IsError</param>
		/// <returns>An IsError with the ErrorOccurred to true and the Error set to Msg</returns>
		public static IsError Error(string Msg) {
			return new IsError(new ErrorWrapper(Msg));
		}
		#endregion

		#region tidy-ups

		/// <summary>
		/// Convert a byte[] request to Build
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>Build of the deserialized Json</returns>
		public static Build GetBuild(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new Build() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new Build() { Error = new IsError(ew) };

			var build = AutoDeserialize<Build>(Data);

			if (build == null)
				build = new Build() { Error = null };

			if (build.Error == null)
				build.Error = new IsError(true, InvalidJson);

			return build;
		}

		/// <summary>
		/// Convert a byte[] request to Friends
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>Friends of the deserialized Json</returns>
		public static Friends GetFriends(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new Friends() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new Friends() { Error = new IsError(ew) };

			var friends = new Friends(AutoDeserialize<FriendWrapper[]>(Data));

			if (friends == null)
				friends = new Friends() { Error = null };

			if (friends.Error == null)
				friends.Error = new IsError(true, InvalidJson);

			return friends;
		}

		/// <summary>
		/// Convert a byte[] request to Lobby
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>Lobby of the deserialized Json</returns>
		public static Lobby GetLobby(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new Lobby() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new Lobby() { Error = new IsError(ew) };

			var lobby = new Lobby() { Rooms = GetRooms(Data) };

			if (lobby == null)
				lobby = new Lobby() { Error = null };

			if (lobby.Error == null)
				lobby.Error = new IsError(true, InvalidJson);

			return lobby;
		}

		/// <summary>
		/// Convert a byte[] request to Online
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>Online of the deserialized Json</returns>
		public static Online GetOnline(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new Online() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new Online() { Error = new IsError(ew) };

			List<OnlinePlayer> onlineList = new List<OnlinePlayer>();
			var data = AutoDeserialize<Dictionary<string, string>>(Data);

			foreach (var i in data.Keys)
				onlineList.Add(new OnlinePlayer(i, data[i]));

			var online = new Online() { PlayersOnline = onlineList.ToArray() };

			if (online == null)
				online = new Online() { Error = null };

			if (online.Error == null)
				online.Error = new IsError(true, InvalidJson);

			return online;
		}

		/// <summary>
		/// Convert a byte[] request to Player
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>Player of the deserialized Json</returns>
		public static Player GetPlayer(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new Player() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new Player() { Error = new IsError(ew) };

			var playerJson = AutoDeserialize<PlayerJSON>(Data);

			var player = JSONConverters.GetFrom(playerJson);

			if (player == null)
				player = new Player() { Error = null };

			if (player.Error == null)
				player.Error = new IsError(true, InvalidJson);

			return player;
		}

		/// <summary>
		/// Convert a byte[] request to RoomWrapper
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>RoomWrapper of the deserialized Json</returns>
		public static RoomWrapper[] GetRooms(byte[] Data) { //this method wouldn't be called if there wasn't any data
			if (IsBad(Data)) //ensure the byte[] is good
				return null;

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return null;

			var rooms = AutoDeserialize<RoomWrapper[]>(Data);

			return rooms;
		}

		/// <summary>
		/// Convert a byte[] request to Game
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>Game of the deserialized Json</returns>
		public static Game GetGame(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new Game() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new Game() { Error = new IsError(ew) };

			var game = AutoDeserialize<Game>(Data);

			if (game == null)
				game = new Game() { Error = null };

			if (game.Error == null)
				game.Error = new IsError(true, InvalidJson);

			return game;
		}

		/// <summary>
		/// Convert a byte[] request to World
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>World of the deserialized Json</returns>
		public static World GetWorld(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new World() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new World() { Error = new IsError(ew) };

			var world = AutoDeserialize<World>(Data);

			if (world == null)
				world = new World() { Error = null };

			if (world.Error == null)
				world.Error = new IsError(true, InvalidJson);

			return world;
		}

		/// <summary>
		/// Automatically convert a byte[] to a string and then deserialize that to T
		/// </summary>
		/// <typeparam name="T">The object to deserialize to</typeparam>
		/// <param name="Data">The information downloaded from the URL</param>
		/// <returns>A T, which is a deserialized form of byte[] Data</returns>
		public static T AutoDeserialize<T>(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return default(T);

			string result = Encoding.UTF8.GetString(Data); //tostring and deserialize

			try {
				return JsonConvert.DeserializeObject<T>(result, new JsonSerializerSettings {
					NullValueHandling = NullValueHandling.Ignore,
					MissingMemberHandling = MissingMemberHandling.Ignore,
					Error = JSONDeserializationErrorHandler,

				});
			} catch { return default(T); } //we already handle errors below
		}

		private static void JSONDeserializationErrorHandler(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e) {
			//error
			//TODO: handle it?
		}
		#endregion
	}
}
