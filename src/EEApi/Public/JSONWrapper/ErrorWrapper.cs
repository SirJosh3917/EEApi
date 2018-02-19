using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi.JSONWrapper {
	internal class ErrorWrapper {
		internal ErrorWrapper(string _Error = null) { Error = _Error; }
		internal ErrorWrapper() { }

		#region properties
		/// <summary>
		/// The error returned by the server
		/// </summary>
		public string Error { get; set; }
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
