using System;
using System.Collections.Generic;
using System.Text;

namespace EEApi.JSONWrapper {

	/// <summary>
	/// If an error occurs in a wrapper, this will specify IF there is one and the error.
	/// </summary>
	public class IsError {
		#region constructors

		/// <summary>
		/// Create an IsError based on raw data
		/// </summary>
		/// <param name="_ErrorOccurred">If there is an error</param>
		/// <param name="_Error">The error</param>
		internal IsError(bool _ErrorOccurred, string _Error = null) {
			this.ErrorOccurred = _ErrorOccurred;

			if (_ErrorOccurred == false)
				this.Error = null;
			else
				this.Error = _Error;
		}

		/// <summary>
		/// The ErrorWrapper to inherit if errors
		/// </summary>
		/// <param name="inherit">The ErrorWrapper to copy data from.</param>
		internal IsError(ErrorWrapper inherit) {
			if (inherit == null) {
				this.ErrorOccurred = false;
				this.Error = null;
			} else {
				this.ErrorOccurred = true;
				this.Error = inherit.Error;
			}
		}

		internal IsError() { }
		#endregion

		#region properties
		/// <summary>
		/// If an error happened
		/// </summary>
		public bool ErrorOccurred { get; set; }

		/// <summary>
		/// The cause of the error according to the API
		/// </summary>
		public string Error { get; set; }
		#endregion
	}
}
