using System;
using System.Runtime.InteropServices;
using nsISupports = System.IntPtr;

namespace DotGecko.Gecko.Interop
{
	/*
	 * DO NOT USE THIS INTERFACE.  IT IS HORRIBLY BROKEN, USES NS_COMFALSE
	 * AND IS BASICALLY IMPOSSIBLE TO USE CORRECTLY THROUGH PROXIES OR
	 * XPCONNECT.  IF YOU SEE NEW USES OF THIS INTERFACE IN CODE YOU ARE
	 * REVIEWING, YOU SHOULD INSIST ON nsISimpleEnumerator.
	 *
	 * DON'T MAKE ME COME OVER THERE.
	 */
	[ComImport, Guid("ad385286-cbc4-11d2-8cca-0060b0fc14a3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIEnumerator //: nsISupports
	{
		/** First will reset the list. will return NS_FAILED if no items
		 */
		void First();

		/** Next will advance the list. will return failed if already at end
		 */
		void Next();

		/** CurrentItem will return the CurrentItem item it will fail if the 
		 *  list is empty
		 */
		[return: MarshalAs(UnmanagedType.IUnknown)]
		nsISupports CurrentItem();

		/** return if the collection is at the end.  that is the beginning following 
		 *  a call to Prev and it is the end of the list following a call to next
		 */
		void IsDone();
	}

	[ComImport, Guid("75f158a0-cadd-11d2-8cca-0060b0fc14a3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIBidirectionalEnumerator : nsIEnumerator
	{
		#region nsIEnumerator Members

		new void First();
		new void Next();
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new nsISupports CurrentItem();
		new void IsDone();

		#endregion

		/** Last will reset the list to the end. will return NS_FAILED if no items
		 */
		void Last();

		/** Prev will decrement the list. will return failed if already at beginning
		 */
		void Prev();
	}
}
