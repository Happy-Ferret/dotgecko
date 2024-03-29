using System;
using System.Runtime.InteropServices;

namespace DotGecko.Gecko.Interop
{
	public static class nsIWebProgressListenerConstants
	{
		/**
		 * State Transition Flags
		 *
		 * These flags indicate the various states that requests may transition
		 * through as they are being loaded.  These flags are mutually exclusive.
		 *
		 * For any given request, onStateChange is called once with the STATE_START
		 * flag, zero or more times with the STATE_TRANSFERRING flag or once with the
		 * STATE_REDIRECTING flag, and then finally once with the STATE_STOP flag.
		 * NOTE: For document requests, a second STATE_STOP is generated (see the
		 * description of STATE_IS_WINDOW for more details).
		 *
		 * STATE_START
		 *   This flag indicates the start of a request.  This flag is set when a
		 *   request is initiated.  The request is complete when onStateChange is
		 *   called for the same request with the STATE_STOP flag set.
		 *
		 * STATE_REDIRECTING
		 *   This flag indicates that a request is being redirected.  The request
		 *   passed to onStateChange is the request that is being redirected.  When a
		 *   redirect occurs, a new request is generated automatically to process the
		 *   new request.  Expect a corresponding STATE_START event for the new
		 *   request, and a STATE_STOP for the redirected request.
		 *
		 * STATE_TRANSFERRING
		 *   This flag indicates that data for a request is being transferred to an
		 *   end consumer.  This flag indicates that the request has been targeted,
		 *   and that the user may start seeing content corresponding to the request.
		 *
		 * STATE_NEGOTIATING
		 *   This flag is not used.
		 *
		 * STATE_STOP
		 *   This flag indicates the completion of a request.  The aStatus parameter
		 *   to onStateChange indicates the final status of the request.
		 */
		public const UInt32 STATE_START = 0x00000001;
		public const UInt32 STATE_REDIRECTING = 0x00000002;
		public const UInt32 STATE_TRANSFERRING = 0x00000004;
		public const UInt32 STATE_NEGOTIATING = 0x00000008;
		public const UInt32 STATE_STOP = 0x00000010;

		/**
		 * State Type Flags
		 *
		 * These flags further describe the entity for which the state transition is
		 * occuring.  These flags are NOT mutually exclusive (i.e., an onStateChange
		 * event may indicate some combination of these flags).
		 *
		 * STATE_IS_REQUEST
		 *   This flag indicates that the state transition is for a request, which
		 *   includes but is not limited to document requests.  (See below for a
		 *   description of document requests.)  Other types of requests, such as
		 *   requests for inline content (e.g., images and stylesheets) are
		 *   considered normal requests.
		 *
		 * STATE_IS_DOCUMENT
		 *   This flag indicates that the state transition is for a document request.
		 *   This flag is set in addition to STATE_IS_REQUEST.  A document request
		 *   supports the nsIChannel interface and its loadFlags attribute includes
		 *   the nsIChannel::LOAD_DOCUMENT_URI flag.
		 * 
		 *   A document request does not complete until all requests associated with
		 *   the loading of its corresponding document have completed.  This includes
		 *   other document requests (e.g., corresponding to HTML <iframe> elements).
		 *   The document corresponding to a document request is available via the
		 *   DOMWindow attribute of onStateChange's aWebProgress parameter.
		 *
		 * STATE_IS_NETWORK
		 *   This flag indicates that the state transition corresponds to the start
		 *   or stop of activity in the indicated nsIWebProgress instance.  This flag
		 *   is accompanied by either STATE_START or STATE_STOP, and it may be
		 *   combined with other State Type Flags.
		 *
		 *   Unlike STATE_IS_WINDOW, this flag is only set when activity within the
		 *   nsIWebProgress instance being observed starts or stops.  If activity
		 *   only occurs in a child nsIWebProgress instance, then this flag will be
		 *   set to indicate the start and stop of that activity.
		 *
		 *   For example, in the case of navigation within a single frame of a HTML
		 *   frameset, a nsIWebProgressListener instance attached to the
		 *   nsIWebProgress of the frameset window will receive onStateChange calls
		 *   with the STATE_IS_NETWORK flag set to indicate the start and stop of
		 *   said navigation.  In other words, an observer of an outer window can
		 *   determine when activity, that may be constrained to a child window or
		 *   set of child windows, starts and stops.
		 *
		 * STATE_IS_WINDOW
		 *   This flag indicates that the state transition corresponds to the start
		 *   or stop of activity in the indicated nsIWebProgress instance.  This flag
		 *   is accompanied by either STATE_START or STATE_STOP, and it may be
		 *   combined with other State Type Flags.
		 *
		 *   This flag is similar to STATE_IS_DOCUMENT.  However, when a document
		 *   request completes, two onStateChange calls with STATE_STOP are
		 *   generated.  The document request is passed as aRequest to both calls.
		 *   The first has STATE_IS_REQUEST and STATE_IS_DOCUMENT set, and the second
		 *   has the STATE_IS_WINDOW flag set (and possibly the STATE_IS_NETWORK flag
		 *   set as well -- see above for a description of when the STATE_IS_NETWORK
		 *   flag may be set).  This second STATE_STOP event may be useful as a way
		 *   to partition the work that occurs when a document request completes.
		 */
		public const UInt32 STATE_IS_REQUEST = 0x00010000;
		public const UInt32 STATE_IS_DOCUMENT = 0x00020000;
		public const UInt32 STATE_IS_NETWORK = 0x00040000;
		public const UInt32 STATE_IS_WINDOW = 0x00080000;

		/**
		 * State Modifier Flags
		 *
		 * These flags further describe the transition which is occuring.  These
		 * flags are NOT mutually exclusive (i.e., an onStateChange event may
		 * indicate some combination of these flags).
		 *
		 * STATE_RESTORING
		 *   This flag indicates that the state transition corresponds to the start
		 *   or stop of activity for restoring a previously-rendered presentation.
		 *   As such, there is no actual network activity associated with this
		 *   request, and any modifications made to the document or presentation
		 *   when it was originally loaded will still be present.
		 */
		public const UInt32 STATE_RESTORING = 0x01000000;

		/**
		 * State Security Flags
		 *
		 * These flags describe the security state reported by a call to the
		 * onSecurityChange method.  These flags are mutually exclusive.
		 *
		 * STATE_IS_INSECURE
		 *   This flag indicates that the data corresponding to the request
		 *   was received over an insecure channel.
		 *
		 * STATE_IS_BROKEN
		 *   This flag indicates an unknown security state.  This may mean that the
		 *   request is being loaded as part of a page in which some content was
		 *   received over an insecure channel.
		 *
		 * STATE_IS_SECURE
		 *   This flag indicates that the data corresponding to the request was
		 *   received over a secure channel.  The degree of security is expressed by
		 *   STATE_SECURE_HIGH, STATE_SECURE_MED, or STATE_SECURE_LOW.
		 */
		public const UInt32 STATE_IS_INSECURE = 0x00000004;
		public const UInt32 STATE_IS_BROKEN = 0x00000001;
		public const UInt32 STATE_IS_SECURE = 0x00000002;

		/**
		 * Security Strength Flags
		 *
		 * These flags describe the security strength and accompany STATE_IS_SECURE
		 * in a call to the onSecurityChange method.  These flags are mutually
		 * exclusive.
		 *
		 * These flags are not meant to provide a precise description of data
		 * transfer security.  These are instead intended as a rough indicator that
		 * may be used to, for example, color code a security indicator or otherwise
		 * provide basic data transfer security feedback to the user.
		 *
		 * STATE_SECURE_HIGH
		 *   This flag indicates a high degree of security.
		 *
		 * STATE_SECURE_MED
		 *   This flag indicates a medium degree of security.
		 *
		 * STATE_SECURE_LOW
		 *   This flag indicates a low degree of security.
		 */
		public const UInt32 STATE_SECURE_HIGH = 0x00040000;
		public const UInt32 STATE_SECURE_MED = 0x00010000;
		public const UInt32 STATE_SECURE_LOW = 0x00020000;

		/**
		  * State bits for EV == Extended Validation == High Assurance
		  *
		  * These flags describe the level of identity verification
		  * in a call to the onSecurityChange method. 
		  *
		  * STATE_IDENTITY_EV_TOPLEVEL
		  *   The topmost document uses an EV cert.
		  *   NOTE: Available since Gecko 1.9
		  */
		public const UInt32 STATE_IDENTITY_EV_TOPLEVEL = 0x00100000;
	}

	/**
	 * The nsIWebProgressListener interface is implemented by clients wishing to
	 * listen in on the progress associated with the loading of asynchronous
	 * requests in the context of a nsIWebProgress instance as well as any child
	 * nsIWebProgress instances.  nsIWebProgress.idl describes the parent-child
	 * relationship of nsIWebProgress instances.
	 */
	[ComImport, Guid("570F39D1-EFD0-11d3-B093-00A024FFC08C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIWebProgressListener //: nsISupports
	{
		/**
		 * Notification indicating the state has changed for one of the requests
		 * associated with aWebProgress.
		 *
		 * @param aWebProgress
		 *        The nsIWebProgress instance that fired the notification
		 * @param aRequest
		 *        The nsIRequest that has changed state.
		 * @param aStateFlags
		 *        Flags indicating the new state.  This value is a combination of one
		 *        of the State Transition Flags and one or more of the State Type
		 *        Flags defined above.  Any undefined bits are reserved for future
		 *        use.
		 * @param aStatus
		 *        Error status code associated with the state change.  This parameter
		 *        should be ignored unless aStateFlags includes the STATE_STOP bit.
		 *        The status code indicates success or failure of the request
		 *        associated with the state change.  NOTE: aStatus may be a success
		 *        code even for server generated errors, such as the HTTP 404 error.
		 *        In such cases, the request itself should be queried for extended
		 *        error information (e.g., for HTTP requests see nsIHttpChannel).
		 */
		void OnStateChange(nsIWebProgress aWebProgress, nsIRequest aRequest, UInt32 aStateFlags, UInt32 aStatus);

		/**
		 * Notification that the progress has changed for one of the requests
		 * associated with aWebProgress.  Progress totals are reset to zero when all
		 * requests in aWebProgress complete (corresponding to onStateChange being
		 * called with aStateFlags including the STATE_STOP and STATE_IS_WINDOW
		 * flags).
		 *
		 * @param aWebProgress
		 *        The nsIWebProgress instance that fired the notification.
		 * @param aRequest
		 *        The nsIRequest that has new progress.
		 * @param aCurSelfProgress
		 *        The current progress for aRequest.
		 * @param aMaxSelfProgress
		 *        The maximum progress for aRequest.
		 * @param aCurTotalProgress
		 *        The current progress for all requests associated with aWebProgress.
		 * @param aMaxTotalProgress
		 *        The total progress for all requests associated with aWebProgress.
		 *
		 * NOTE: If any progress value is unknown, or if its value would exceed the
		 * maximum value of type long, then its value is replaced with -1.
		 *
		 * NOTE: If the object also implements nsIWebProgressListener2 and the caller
		 * knows about that interface, this function will not be called. Instead,
		 * nsIWebProgressListener2::onProgressChange64 will be called.
		 */
		void OnProgressChange(nsIWebProgress aWebProgress,
							  nsIRequest aRequest,
							  Int32 aCurSelfProgress,
							  Int32 aMaxSelfProgress,
							  Int32 aCurTotalProgress,
							  Int32 aMaxTotalProgress);

		/**
		 * Called when the location of the window being watched changes.  This is not
		 * when a load is requested, but rather once it is verified that the load is
		 * going to occur in the given window.  For instance, a load that starts in a
		 * window might send progress and status messages for the new site, but it
		 * will not send the onLocationChange until we are sure that we are loading
		 * this new page here.
		 *
		 * @param aWebProgress
		 *        The nsIWebProgress instance that fired the notification.
		 * @param aRequest
		 *        The associated nsIRequest.  This may be null in some cases.
		 * @param aLocation
		 *        The URI of the location that is being loaded.
		 */
		void OnLocationChange(nsIWebProgress aWebProgress, nsIRequest aRequest, nsIURI aLocation);

		/**
		 * Notification that the status of a request has changed.  The status message
		 * is intended to be displayed to the user (e.g., in the status bar of the
		 * browser).
		 *
		 * @param aWebProgress
		 *        The nsIWebProgress instance that fired the notification.
		 * @param aRequest
		 *        The nsIRequest that has new status.
		 * @param aStatus
		 *        This value is not an error code.  Instead, it is a numeric value
		 *        that indicates the current status of the request.  This interface
		 *        does not define the set of possible status codes.  NOTE: Some
		 *        status values are defined by nsITransport and nsISocketTransport.
		 * @param aMessage
		 *        Localized text corresponding to aStatus.
		 */
		void OnStatusChange(nsIWebProgress aWebProgress, nsIRequest aRequest, UInt32 aStatus, [MarshalAs(UnmanagedType.LPWStr)] String aMessage);

		/**
		 * Notification called for security progress.  This method will be called on
		 * security transitions (eg HTTP -> HTTPS, HTTPS -> HTTP, FOO -> HTTPS) and
		 * after document load completion.  It might also be called if an error
		 * occurs during network loading.
		 *
		 * @param aWebProgress
		 *        The nsIWebProgress instance that fired the notification.
		 * @param aRequest
		 *        The nsIRequest that has new security state.
		 * @param aState
		 *        A value composed of the Security State Flags and the Security
		 *        Strength Flags listed above.  Any undefined bits are reserved for
		 *        future use.
		 *
		 * NOTE: These notifications will only occur if a security package is
		 * installed.
		 */
		void OnSecurityChange(nsIWebProgress aWebProgress, nsIRequest aRequest, UInt32 aState);
	}
}
