using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

//http://ee-api.lrussell.net/game

namespace EEApi.JSONWrapper {

	/// <summary>
	/// A class for the Game, retreivable by /game
	/// </summary>
	public class Game : Wrapper {
		internal Game() { }

		#region properties
		/// <summary>
		/// Provides EE's Game Version, also found in { config, config, verison }.
		/// </summary>
		public int? Version { get; set; }
		#endregion
	}
}
