using System;
using System.Runtime.InteropServices;
using nsISupports = System.Object;

namespace DotGecko.Gecko.Interop
{
	/**
	 * This interface is implemented by an object that wants
	 * to observe an event corresponding to a topic.
	 */
	[ComImport, Guid("DB242E01-E4D9-11d2-9DDE-000064657374"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIObserver //: nsISupports
	{
		/**
		 * Observe will be called when there is a notification for the
		 * topic |aTopic|.  This assumes that the object implementing
		 * this interface has been registered with an observer service
		 * such as the nsIObserverService. 
		 *
		 * If you expect multiple topics/subjects, the impl is 
		 * responsible for filtering.
		 *
		 * You should not modify, add, remove, or enumerate 
		 * notifications in the implemention of observe. 
		 *
		 * @param aSubject : Notification specific interface pointer.
		 * @param aTopic   : The notification topic or subject.
		 * @param aData    : Notification specific wide string.
		 *                    subject event.
		 */
		void Observe([MarshalAs(UnmanagedType.IUnknown)] nsISupports aSubject, [MarshalAs(UnmanagedType.LPStr)] String aTopic, [MarshalAs(UnmanagedType.LPWStr)] String aData);
	}
}
