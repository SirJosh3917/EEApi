using System;
using System.Collections.Generic;
using System.Text;
using EEApi.JSONWrapper;
/*
namespace EEApi.old {

	#region /
	/// <summary>
	/// Public class "Build" for warrping the internal wrappers into
	/// </summary>
	public class Build : Build {
		internal Build(Build original) {
			stackoverflow.CopyAllTo<Build>(original, this);
		}
	}
	#endregion

	#region /online
	/// <summary>
	/// Public class "Online" for wrapping the internal wrappers into
	/// </summary>
	public class Online : Online {
		internal Online(Online original) {
			stackoverflow.CopyAllTo<Online>(original, this);
		}
	}
	#endregion

	#region /friends
	/// <summary>
	/// Public class "Friends" for wrapping the internal wrappers into
	/// </summary>
	public class Friends : Friends {
		internal Friends(Friends original) {
			stackoverflow.CopyAllTo<Friends>(original, this);
		}
	}
	#endregion

	#region /game
	/// <summary>
	/// Public class "Game" for wrapping the internal wrappers into
	/// </summary>
	public class Game : Game {
		internal Game(Game original) {
			if(original != null)
				stackoverflow.CopyAllTo<Game>(original, this);
		}
	}
	#endregion

	#region /lobby
	/// <summary>
	/// Public class "Lobby" for wrapping the internal wrappers into
	/// </summary>
	public class Lobby : Lobby {
		internal Lobby(Lobby original) {
			stackoverflow.CopyAllTo<Lobby>(original, this);
		}
	}
	#endregion

	#region /player/
	/// <summary>
	/// Public class "Player" for wrapping the internal wrappers into
	/// </summary>
	public class Player : PlayerWrapper {
		internal Player(PlayerWrapper original) {
			if(original != null)
				stackoverflow.CopyAllTo<PlayerWrapper>(original, this);
		}
	}
	#endregion

	#region /world/
	/// <summary>
	/// Public class "World" for wrapping the internal wrappers into
	/// </summary>
	public class World : WorldWrapper {
		internal World(WorldWrapper original) {
			stackoverflow.CopyAllTo<WorldWrapper>(original, this);
		}
	}
	#endregion
	
	internal static class stackoverflow {
		static stackoverflow() {

		}

		public const string url = "https://stackoverflow.com/questions/4142934/net-is-there-a-class-to-copy-properties-of-one-class-to-another";

		internal static void CopyAllTo<T>(T source, T target) {
			var type = typeof(T);
			foreach (var sourceProperty in type.GetProperties()) {
				var targetProperty = type.GetProperty(sourceProperty.Name);
				targetProperty.SetValue(target, sourceProperty.GetValue(source, null), null);
			}
			foreach (var sourceField in type.GetFields()) {
				var targetField = type.GetField(sourceField.Name);
				targetField.SetValue(target, sourceField.GetValue(source));
			}
		}
	}
}
/**/