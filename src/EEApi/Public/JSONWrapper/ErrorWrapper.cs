using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi.JSONWrapper {
	public class ErrorWrapper : Wrapper {
		internal ErrorWrapper(string _Error) { Error = _Error; }
		internal ErrorWrapper() { }

		#region properties
		/// <summary>
		/// The error returned by the server
		/// </summary>
		public string Error { get; set; }
		#endregion
	}
}
