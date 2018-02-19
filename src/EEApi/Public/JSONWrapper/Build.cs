using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi.JSONWrapper {

	/// <summary>
	/// Retrieve the build date from the main / path
	/// </summary>
	public class Build : Wrapper {
		internal Build() { }

		#region properties
		/// <summary>
		/// The name of the host being used to serve API requests
		/// </summary>
		public string HostName { get; set; }

		/// <summary>
		/// The date of the EE Api build
		/// </summary>
		public DateTime BuildDate { get; set; }

		/// <summary>
		/// The amount of time the API has been up for concurrently
		/// </summary>
		public TimeSpan UpTime { get; set; }

		/// <summary>
		/// The time it is for the server when it received your request.
		/// </summary>
		public DateTime Time { get; set; }
		#endregion
	}
}
