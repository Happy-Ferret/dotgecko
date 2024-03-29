using System;
using System.Runtime.InteropServices;

namespace DotGecko.Gecko.Interop
{
	public static class nsIContextMenuListenerConstants
	{
		/** Flag. No context. */
		public const UInt32 CONTEXT_NONE = 0;
		/** Flag. Context is a link element. */
		public const UInt32 CONTEXT_LINK = 1;
		/** Flag. Context is an image element. */
		public const UInt32 CONTEXT_IMAGE = 2;
		/** Flag. Context is the whole document. */
		public const UInt32 CONTEXT_DOCUMENT = 4;
		/** Flag. Context is a text area element. */
		public const UInt32 CONTEXT_TEXT = 8;
		/** Flag. Context is an input element. */
		public const UInt32 CONTEXT_INPUT = 16;
	}

	/**
	 * An optional interface for embedding clients wishing to receive
	 * notifications for context menu events (e.g. generated by
	 * a user right-mouse clicking on a link). The embedder implements
	 * this interface on the web browser chrome object associated
	 * with the window that notifications are required for. When a context
	 * menu event, the browser will call this interface if present.
	 * 
	 * @see nsIDOMNode
	 * @see nsIDOMEvent
	 */
	[ComImport, Guid("3478b6b0-3875-11d4-94ef-0020183bf181"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIContextMenuListener //: nsISupports
	{
		/**
		 * Called when the browser receives a context menu event (e.g. user is right-mouse
		 * clicking somewhere on the document). The combination of flags, event and node
		 * provided in the call indicate where and what was clicked on.
		 *
		 * The following table describes what context flags and node combinations are
		 * possible.
		 *
		 * <TABLE>
		 * <TR><TD><B>aContextFlag</B></TD><TD>aNode</TD></TR>
		 * <TR><TD>CONTEXT_LINK</TD><TD>&lt;A&gt;</TD></TR>
		 * <TR><TD>CONTEXT_IMAGE</TD><TD>&lt;IMG&gt;</TD></TR>
		 * <TR><TD>CONTEXT_IMAGE | CONTEXT_LINK</TD><TD>&lt;IMG&gt;
		 *       with an &lt;A&gt; as an ancestor</TD></TR>
		 * <TR><TD>CONTEXT_INPUT</TD><TD>&lt;INPUT&gt;</TD></TR>
		 * <TR><TD>CONTEXT_TEXT</TD><TD>&lt;TEXTAREA&gt;</TD></TR>
		 * <TR><TD>CONTEXT_DOCUMENT</TD><TD>&lt;HTML&gt;</TD></TR>
		 * </TABLE>
		 *
		 * @param aContextFlags Flags indicating the kind of context.
		 * @param aEvent The DOM context menu event.
		 * @param aNode The DOM node most relevant to the context.
		 *
		 * @return <CODE>NS_OK</CODE> always.
		 */
		void OnShowContextMenu(UInt32 aContextFlags, nsIDOMEvent aEvent, nsIDOMNode aNode);
	}
}
