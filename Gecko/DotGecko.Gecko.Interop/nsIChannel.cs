using System;
using System.Runtime.InteropServices;
using System.Text;
using nsISupports = System.Object;

namespace DotGecko.Gecko.Interop
{
	public static class nsIChannelConstants
	{
		/**************************************************************************
		 * Channel specific load flags:
		 *
		 * Bits 23-31 are reserved for future use by this interface or one of its
		 * derivatives (e.g., see nsICachingChannel).
		 */

		/**
		 * Set (e.g., by the docshell) to indicate whether or not the channel
		 * corresponds to a document URI.
		 */
		public const UInt32 LOAD_DOCUMENT_URI = 1 << 16;

		/** 
		 * If the end consumer for this load has been retargeted after discovering 
		 * its content, this flag will be set:
		 */
		public const UInt32 LOAD_RETARGETED_DOCUMENT_URI = 1 << 17;

		/**
		 * This flag is set to indicate that this channel is replacing another
		 * channel.  This means that:
		 *
		 * 1) the stream listener this channel will be notifying was initially
		 *    passed to the asyncOpen method of some other channel
		 *
		 *   and
		 *
		 * 2) this channel's URI is a better identifier of the resource being
		 *    accessed than this channel's originalURI.
		 *
		 * This flag can be set, for example, for redirects or for cases when a
		 * single channel has multiple parts to it (and thus can follow
		 * onStopRequest with another onStartRequest/onStopRequest pair, each pair
		 * for a different request).
		 */
		public const UInt32 LOAD_REPLACE = 1 << 18;

		/**
		 * Set (e.g., by the docshell) to indicate whether or not the channel
		 * corresponds to an initial document URI load (e.g., link click).
		 */
		public const UInt32 LOAD_INITIAL_DOCUMENT_URI = 1 << 19;

		/**
		 * Set (e.g., by the URILoader) to indicate whether or not the end consumer
		 * for this load has been determined.
		 */
		public const UInt32 LOAD_TARGETED = 1 << 20;

		/**
		 * If this flag is set, the channel should call the content sniffers as
		 * described in nsNetCID.h about NS_CONTENT_SNIFFER_CATEGORY.
		 *
		 * Note: Channels may ignore this flag; however, new channel implementations
		 * should only do so with good reason.
		 */
		public const UInt32 LOAD_CALL_CONTENT_SNIFFERS = 1 << 21;

		/**
		 * This flag tells the channel to use URI classifier service to check
		 * the URI when opening the channel.
		 */
		public const UInt32 LOAD_CLASSIFY_URI = 1 << 22;
	}

	/**
	 * The nsIChannel interface allows clients to construct "GET" requests for
	 * specific protocols, and manage them in a uniform way.  Once a channel is
	 * created (via nsIIOService::newChannel), parameters for that request may
	 * be set by using the channel attributes, or by QI'ing to a subclass of
	 * nsIChannel for protocol-specific parameters.  Then, the URI can be fetched
	 * by calling nsIChannel::open or nsIChannel::asyncOpen.
	 *
	 * After a request has been completed, the channel is still valid for accessing
	 * protocol-specific results.  For example, QI'ing to nsIHttpChannel allows
	 * response headers to be retrieved for the corresponding http transaction. 
	 *
	 * This interface must be used only from the XPCOM main thread.
	 */
	[ComImport, Guid("c63a055a-a676-4e71-bf3c-6cfa11082018"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIChannel : nsIRequest
	{
		#region nsIRequest Members

		new void GetName([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AUTF8StringMarshaler))] StringBuilder result);
		new Boolean IsPending();
		new nsResult Status { [return: MarshalAs(UnmanagedType.U4)] get; }
		new void Cancel([MarshalAs(UnmanagedType.U4)] nsResult aStatus);
		new void Suspend();
		new void Resume();
		new nsILoadGroup LoadGroup { get; set; }
		new UInt32 LoadFlags { get; set; }

		#endregion

		/**
		 * The original URI used to construct the channel. This is used in
		 * the case of a redirect or URI "resolution" (e.g. resolving a
		 * resource: URI to a file: URI) so that the original pre-redirect
		 * URI can still be obtained.  This is never null.  Attempts to
		 * set it to null must throw.
		 *
		 * NOTE: this is distinctly different from the http Referer (referring URI),
		 * which is typically the page that contained the original URI (accessible
		 * from nsIHttpChannel).
		 */
		nsIURI OriginalURI { get; set; }

		/**
		 * The URI corresponding to the channel.  Its value is immutable.
		 */
		nsIURI URI { get; }

		/**
		 * The owner, corresponding to the entity that is responsible for this
		 * channel.  Used by the security manager to grant or deny privileges to
		 * mobile code loaded from this channel.
		 *
		 * NOTE: this is a strong reference to the owner, so if the owner is also
		 * holding a strong reference to the channel, care must be taken to 
		 * explicitly drop its reference to the channel.
		 */
		nsISupports Owner { [return: MarshalAs(UnmanagedType.IUnknown)] get; [param: MarshalAs(UnmanagedType.IUnknown)] set; }

		/**
		 * The notification callbacks for the channel.  This is set by clients, who
		 * wish to provide a means to receive progress, status and protocol-specific 
		 * notifications.  If this value is NULL, the channel implementation may use
		 * the notification callbacks from its load group.  The channel may also
		 * query the notification callbacks from its load group if its notification
		 * callbacks do not supply the requested interface.
		 * 
		 * Interfaces commonly requested include: nsIProgressEventSink, nsIPrompt,
		 * and nsIAuthPrompt/nsIAuthPrompt2.
		 *
		 * When the channel is done, it must not continue holding references to
		 * this object.
		 *
		 * NOTE: A channel implementation should take care when "caching" an
		 * interface pointer queried from its notification callbacks.  If the
		 * notification callbacks are changed, then a cached interface pointer may
		 * become invalid and may therefore need to be re-queried.
		 */
		nsIInterfaceRequestor NotificationCallbacks { get; set; }

		/**
		 * Transport-level security information (if any) corresponding to the channel.
		 */
		nsISupports SecurityInfo { [return: MarshalAs(UnmanagedType.IUnknown)] get; }

		/**
		 * The MIME type of the channel's content if available. 
		 * 
		 * NOTE: the content type can often be wrongly specified (e.g., wrong file
		 * extension, wrong MIME type, wrong document type stored on a server, etc.),
		 * and the caller most likely wants to verify with the actual data.
		 *
		 * Setting contentType before the channel has been opened provides a hint
		 * to the channel as to what the MIME type is.  The channel may ignore this
		 * hint in deciding on the actual MIME type that it will report.
		 *
		 * Setting contentType after onStartRequest has been fired or after open()
		 * is called will override the type determined by the channel.
		 *
		 * Setting contentType between the time that asyncOpen() is called and the
		 * time when onStartRequest is fired has undefined behavior at this time.
		 *
		 * The value of the contentType attribute is a lowercase string.  A value
		 * assigned to this attribute will be parsed and normalized as follows:
		 *  1- any parameters (delimited with a ';') will be stripped.
		 *  2- if a charset parameter is given, then its value will replace the
		 *     the contentCharset attribute of the channel.
		 *  3- the stripped contentType will be lowercased.
		 * Any implementation of nsIChannel must follow these rules.
		 */
		void GetContentType([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACStringMarshaler))] StringBuilder result);
		void SetContentType([In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACStringMarshaler))] String value);

		/**
		 * The character set of the channel's content if available and if applicable.
		 * This attribute only applies to textual data.
		 *
		 * The value of the contentCharset attribute is a mixedcase string.
		 */
		void GetContentCharset([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACStringMarshaler))] StringBuilder result);
		void SetContentCharset([In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ACStringMarshaler))] String value);

		/**
		 * The length of the data associated with the channel if available.  A value
		 * of -1 indicates that the content length is unknown.
		 *
		 * Callers should prefer getting the "content-length" property
		 * as 64-bit value by QIing the channel to nsIPropertyBag2,
		 * if that interface is exposed by the channel.
		 */
		Int32 ContentLength { get; set; }

		/**
		 * Synchronously open the channel.
		 *
		 * @return blocking input stream to the channel's data.
		 *
		 * NOTE: nsIChannel implementations are not required to implement this
		 * method.  Moreover, since this method may block the calling thread, it
		 * should not be called on a thread that processes UI events.  Like any
		 * other nsIChannel method it must not be called on any thread other
		 * than the XPCOM main thread.
		 *
		 * NOTE: Implementations should throw NS_ERROR_IN_PROGRESS if the channel
		 * is reopened.
		 */
		nsIInputStream Open();

		/**
		 * Asynchronously open this channel.  Data is fed to the specified stream
		 * listener as it becomes available.  The stream listener's methods are
		 * called on the thread that calls asyncOpen and are not called until
		 * after asyncOpen returns.  If asyncOpen returns successfully, the
		 * channel promises to call at least onStartRequest and onStopRequest.
		 *
		 * If the nsIRequest object passed to the stream listener's methods is not
		 * this channel, an appropriate onChannelRedirect notification needs to be
		 * sent to the notification callbacks before onStartRequest is called.
		 * Once onStartRequest is called, all following method calls on aListener
		 * will get the request that was passed to onStartRequest.
		 *
		 * If the channel's and loadgroup's notification callbacks do not provide
		 * an nsIChannelEventSink when onChannelRedirect would be called, that's
		 * equivalent to having called onChannelRedirect.
		 *
		 * If asyncOpen returns successfully, the channel is responsible for
		 * keeping itself alive until it has called onStopRequest on aListener or
		 * called onChannelRedirect.
		 *
		 * Implementations are allowed to synchronously add themselves to the
		 * associated load group (if any).
		 *
		 * NOTE: Implementations should throw NS_ERROR_ALREADY_OPENED if the
		 * channel is reopened.
		 *
		 * @param aListener the nsIStreamListener implementation
		 * @param aContext an opaque parameter forwarded to aListener's methods
		 * @see nsIChannelEventSink for onChannelRedirect
		 */
		void AsyncOpen(nsIStreamListener aListener, [MarshalAs(UnmanagedType.IUnknown)] nsISupports aContext);
	}
}
