using System;
using System.Runtime.InteropServices;

namespace DotGecko.Gecko.Interop
{
	/**
	 * The nsIDOMBarProp interface is the interface for controlling and
	 * accessing the visibility of certain UI items (scrollbars, menubars,
	 * toolbars, ...) through the DOM.
	 */
	[ComImport, Guid("9eb2c150-1d56-11d3-8221-0060083a0bcf"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIDOMBarProp //: nsISupports
	{
		Boolean Visible { get; set; }
	}
}
