using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace EEApi.Internal.HTTP
{
    internal static class HTTPGet {
		#region work
		public static int APIRequestsMade = 0;

		/// <summary>
		/// Download the data in byte[] from the URL
		/// </summary>
		/// <param name="Request">The URL to download data from</param>
		/// <returns>The response from the web server</returns>
		public static byte[] Get(string Request) {
			APIRequestsMade++;
			try {
				using (var httpRequestMaker = new WebClient() { Proxy = null }) {
					var res = httpRequestMaker.DownloadData(Request);

					if (HTTPGet.IsValidJson(Encoding.ASCII.GetString(res)))
						return res;

					return null;
				}
			} catch (WebException e) {
				if (e.Response == null)
					return null;

				var resp = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();

				/*
				Console.WriteLine(" WEB DOWNLOAD REQUEST ERROR\n____________________________\n");
				Console.WriteLine(e.Message);
				Console.WriteLine("'" + Request + "'");
				Console.WriteLine("Response: " + resp);
				Console.WriteLine("_______________________________________________________________________________");
				*/

				if(HTTPGet.IsValidJson(resp))
					return Encoding.ASCII.GetBytes(resp);
				return null;
			} catch (Exception e) { //webrequest does not support concurrent IO or something
				return null;
			}
		}

		/// <summary>
		/// Determine if a stirng is valid json
		/// </summary>
		/// <param name="strInput">The JSON to check</param>
		/// <returns></returns>
		private static bool IsValidJson(string strInput) {
			strInput = strInput.Trim();
			if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
				(strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
			{
				try {
					var obj = JToken.Parse(strInput);
					return true;
				} catch (JsonReaderException jex) {
					//Exception in parsing json
					Console.WriteLine(jex.Message);
					return false;
				} catch (Exception ex) //some other exception
				{
					Console.WriteLine(ex.ToString());
					return false;
				}
			} else {
				return false;
			}
		}
		#endregion

		#region tidy-ups
		/// <summary>
		/// Get the build info of the API
		/// </summary>
		/// <returns></returns>
		public static byte[] GetBuild() {
			return Get(APILinks.GetBuild());
		}

		/// <summary>
		/// Get the friends
		/// </summary>
		/// <returns></returns>
		public static byte[] GetFriends() {
			return Get(APILinks.GetFriends());
		}

		/// <summary>
		/// Get the game
		/// </summary>
		/// <returns></returns>
		public static byte[] GetGame() {
			return Get(APILinks.GetGame());
		}

		/// <summary>
		/// Get the lobby
		/// </summary>
		/// <returns></returns>
		public static byte[] GetLobby() {
			return Get(APILinks.GetLobby());
		}

		/// <summary>
		/// Get the people online
		/// </summary>
		/// <returns></returns>
		public static byte[] GetOnline() {
			return Get(APILinks.GetOnline());

		}

		/// <summary>
		/// Get a player based on their username
		/// </summary>
		/// <param name="Username">Their username</param>
		/// <returns></returns>
		public static byte[] GetPlayerByUsername(string Username) {
			return Get(APILinks.GetPlayerByUsername(Username));
		}

		/// <summary>
		/// Get a player based on their user id
		/// </summary>
		/// <param name="UserID">Their UserID</param>
		/// <returns></returns>
		public static byte[] GetPlayerByUserID(string UserID) {
			return Get(APILinks.GetPlayerByUserID(UserID));
		}

		/// <summary>
		/// Get the world information about a world
		/// </summary>
		/// <param name="WorldID">The WorldId of the world</param>
		/// <returns></returns>
		public static byte[] GetWorld(string WorldID) {
			return Get(APILinks.GetWorld(WorldID));
		}
		#endregion

		public static uint? Timeout { get; set; }
	}
}
