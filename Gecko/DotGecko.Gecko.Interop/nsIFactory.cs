using System;
using System.Runtime.InteropServices;
using nsISupports = System.Object;

namespace DotGecko.Gecko.Interop
{
	/**
	 * A class factory allows the creation of nsISupports derived
	 * components without specifying a concrete base class.  
	 */
	[ComImport, Guid("00000001-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIFactory //: nsISupports
	{
		/**
		 * Creates an instance of a component.
		 *
		 * @param aOuter Pointer to a component that wishes to be aggregated
		 *               in the resulting instance. This will be nsnull if no
		 *               aggregation is requested.
		 * @param iid    The IID of the interface being requested in
		 *               the component which is being currently created.
		 * @param result [out] Pointer to the newly created instance, if successful.
		 * @return NS_OK - Component successfully created and the interface 
		 *                 being requested was successfully returned in result.
		 *         NS_NOINTERFACE - Interface not accessible.
		 *         NS_ERROR_NO_AGGREGATION - if an 'outer' object is supplied, but the
		 *                                   component is not aggregatable.
		 *         NS_ERROR* - Method failure.
		 */
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.U4)]
		nsResult CreateInstance([MarshalAs(UnmanagedType.IUnknown)] nsISupports aOuter, [In] ref Guid iid, out IntPtr retval);

		/**
		 * LockFactory provides the client a way to keep the component
		 * in memory until it is finished with it. The client can call
		 * LockFactory(PR_TRUE) to lock the factory and LockFactory(PR_FALSE)
		 * to release the factory.	 
		 *
		 * @param lock - Must be PR_TRUE or PR_FALSE
		 * @return NS_OK - If the lock operation was successful.
		 *         NS_ERROR* - Method failure.
		 */
		void LockFactory(Boolean aLock);
	}
}
