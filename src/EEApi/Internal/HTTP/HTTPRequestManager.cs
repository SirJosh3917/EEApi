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
		public static BuildWrapper GetBuild(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new BuildWrapper() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new BuildWrapper() { Error = new IsError(ew) };

			return AutoDeserialize<BuildWrapper>(Data);
		}

		/// <summary>
		/// Convert a byte[] request to FriendWrapper
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>FriendWrapper of the deserialized Json</returns>
		public static FriendsWrapper GetFriends(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new FriendsWrapper() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new FriendsWrapper() { Error = new IsError(ew) };

			var ds = AutoDeserialize<FriendWrapper[]>(Data);
			FriendsWrapper fw = new FriendsWrapper(ds);

			fw.Error = new IsError(GetErrorWrapper(Data));

			return fw;
		}

		/// <summary>
		/// Convert a byte[] request to LobbyWrapper
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>LobbyWrapper of the deserialized Json</returns>
		public static LobbyWrapper GetLobby(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new LobbyWrapper() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new LobbyWrapper() { Error = new IsError(ew) };

			return new LobbyWrapper() { Rooms = GetRooms(Data) };
		}

		/// <summary>
		/// Convert a byte[] request to OnlineWrapper
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>OnlineWrapper of the deserialized Json</returns>
		public static OnlineWrapper GetOnline(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new OnlineWrapper() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new OnlineWrapper() { Error = new IsError(ew) };

			return 
				new OnlineWrapperJSON() { Players = 
													AutoDeserialize<Dictionary<string, string>>(Data) }
																										.Convert();
		}

		/// <summary>
		/// Convert a byte[] request to PlayerWrapper
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>PlayerWrapper of the deserialized Json</returns>
		public static PlayerWrapper GetPlayer(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new PlayerWrapper() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new PlayerWrapper() { Error = new IsError(ew) };

			return AutoDeserialize<PlayerWrapperJSON>(Data).Convert();
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

			return AutoDeserialize<RoomWrapper[]>(Data);
		}

		/// <summary>
		/// Convert a byte[] request to VersionWrapper
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>VersionWrapper of the deserialized Json</returns>
		public static GameWrapper GetGame(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new GameWrapper() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new GameWrapper() { Error = new IsError(ew) };

			return AutoDeserialize<GameWrapper>(Data);
		}

		/// <summary>
		/// Convert a byte[] request to WorldWrapper
		/// </summary>
		/// <param name="Data">HTTP Request data</param>
		/// <returns>WorldWrapper of the deserialized Json</returns>
		public static WorldWrapper GetWorld(byte[] Data) {
			if (IsBad(Data)) //ensure the byte[] is good
				return new WorldWrapper() { Error = Error(DataLength0) };

			var ew = GetErrorWrapper(Data); //make sure it isn't convertable to errorwrapper ( else there's an error )
			if (ew != null)
				return new WorldWrapper() { Error = new IsError(ew) };

			return AutoDeserialize<WorldWrapper>(Data);
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
			return JsonConvert.DeserializeObject<T>(result, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    });
		}
		#endregion
	}
}
