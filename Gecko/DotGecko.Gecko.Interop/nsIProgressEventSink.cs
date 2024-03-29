using System;
using System.Runtime.InteropServices;
using nsISupports = System.Object;

namespace DotGecko.Gecko.Interop
{
	/**
	 * nsIProgressEventSink
	 *
	 * This interface is used to asynchronously convey channel status and progress
	 * information that is generally not critical to the processing of the channel.
	 * The information is intended to be displayed to the user in some meaningful
	 * way.
	 *
	 * An implementation of this interface can be passed to a channel via the
	 * channel's notificationCallbacks attribute.  See nsIChannel for more info.
	 *
	 * The channel will begin passing notifications to the progress event sink
	 * after its asyncOpen method has been called.  Notifications will cease once
	 * the channel calls its listener's onStopRequest method or once the channel
	 * is canceled (via nsIRequest::cancel).
	 *
	 * NOTE: This interface is actually not specific to channels and may be used
	 * with other implementations of nsIRequest.
	 */
	[ComImport, Guid("D974C99E-4148-4df9-8D98-DE834A2F6462"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIProgressEventSink //: nsISupports
	{
		/**
		 * Called to notify the event sink that progress has occurred for the
		 * given request.
		 *
		 * @param aRequest
		 *        the request being observed (may QI to nsIChannel).
		 * @param aContext
		 *        if aRequest is a channel, then this parameter is the listener
		 *        context passed to nsIChannel::asyncOpen.
		 * @param aProgress
		 *        numeric value in the range 0 to aProgressMax indicating the
		 *        number of bytes transfered thus far.
		 * @param aProgressMax
		 *        numeric value indicating maximum number of bytes that will be
		 *        transfered (or 0xFFFFFFFFFFFFFFFF if total is unknown).
		 */
		void OnProgress(nsIRequest aRequest, [MarshalAs(UnmanagedType.IUnknown)] nsISupports aContext, UInt64 aProgress, UInt64 aProgressMax);

		/**
		 * Called to notify the event sink with a status message for the given
		 * request.
		 *
		 * @param aRequest
		 *        the request being observed (may QI to nsIChannel).
		 * @param aContext
		 *        if aRequest is a channel, then this parameter is the listener
		 *        context passed to nsIChannel::asyncOpen.
		 * @param aStatus
		 *        status code (not necessarily an error code) indicating the
		 *        state of the channel (usually the state of the underlying
		 *        transport).  see nsISocketTransport for socket specific status
		 *        codes.
		 * @param aStatusArg
		 *        status code argument to be used with the string bundle service
		 *        to convert the status message into localized, human readable
		 *        text.  the meaning of this parameter is specific to the value
		 *        of the status code.  for socket status codes, this parameter
		 *        indicates the host:port associated with the status code.
		 */
		void OnStatus(nsIRequest aRequest, [MarshalAs(UnmanagedType.IUnknown)] nsISupports aContext, [MarshalAs(UnmanagedType.U4)] nsResult aStatus, [MarshalAs(UnmanagedType.LPWStr)] String aStatusArg);
	}
}
