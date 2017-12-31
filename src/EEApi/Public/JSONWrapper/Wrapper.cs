using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi.JSONWrapper {
	public abstract class Wrapper {
		internal Wrapper() { this.Error = new IsError(false, null); }

		#region properties
		/// <summary>
		/// Has an error occured? Check here first before using the class!
		/// </summary>
		public IsError Error { get; set; }
		#endregion

		/// <summary>
		/// Convert the current class to proper JSON
		/// </summary>
		/// <returns>JSON of this class.</returns>
		public string ToJson() {
			return Newtonsoft.Json.JsonConvert.SerializeObject(this);
		}

		public override string ToString() {
			return this.ToJson();
		}
	}
}
