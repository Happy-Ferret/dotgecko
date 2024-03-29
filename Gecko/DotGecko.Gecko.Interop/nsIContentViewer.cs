using System;
using System.Runtime.InteropServices;
using nsISupports = System.Object;
using nsIWidgetPtr = System.IntPtr;
using nsIDocumentPtr = System.IntPtr;

namespace DotGecko.Gecko.Interop
{
	[ComImport, Guid("75306a89-e3ad-4a2b-9daf-ac4de06661a4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIContentViewer //: nsISupports
	{
		void Init(nsIWidgetPtr aParentWidget, [In] ref nsIntRect aBounds);

		nsISupports Container { [return: MarshalAs(UnmanagedType.IUnknown)] get; [param: MarshalAs(UnmanagedType.IUnknown)] set; }

		void LoadStart([MarshalAs(UnmanagedType.IUnknown)] nsISupports aDoc);
		void LoadComplete(UInt32 aStatus);

		/**
		 * Checks if the document wants to prevent unloading by firing beforeunload on
		 * the document, and if it does, prompts the user. The result is returned.
		 *
		 * @param aCallerClosesWindow indicates that the current caller will close the
		 *        window. If the method returns true, all subsequent calls will be
		 *        ignored.
		 */
		Boolean PermitUnload([Optional] Boolean aCallerClosesWindow);

		/**
		 * Works in tandem with permitUnload, if the caller decides not to close the
		 * window it indicated it will, it is the caller's responsibility to reset
		 * that with this method.
		 *
		 * @Note this method is only meant to be called on documents for which the
		 *  caller has indicated that it will close the window. If that is not the case
		 *  the behavior of this method is undefined.
		 */
		void ResetCloseWindow();
		void PageHide(Boolean isUnload);

		/**
		 * All users of a content viewer are responsible for calling both
		 * close() and destroy(), in that order. 
		 *
		 * close() should be called when the load of a new page for the next
		 * content viewer begins, and destroy() should be called when the next
		 * content viewer replaces this one.
		 *
		 * |historyEntry| sets the session history entry for the content viewer.  If
		 * this is null, then Destroy() will be called on the document by close().
		 * If it is non-null, the document will not be destroyed, and the following
		 * actions will happen when destroy() is called (*):
		 *  - Sanitize() will be called on the viewer's document
		 *  - The content viewer will set the contentViewer property on the
		 *    history entry, and release its reference (ownership reversal).
		 *  - hide() will be called, and no further destruction will happen.
		 *
		 *  (*) unless the document is currently being printed, in which case
		 *      it will never be saved in session history.
		 *
		 */
		void Close(nsISHEntry historyEntry);
		void Destroy();

		void Stop();

		nsIDOMDocument DOMDocument { get; set; }

		/**
		 * Returns DOMDocument as nsIDocument and without addrefing.
		 */
		nsIDocumentPtr GetDocument();


		void GetBounds(ref nsIntRect aBounds);
		void SetBounds([In] ref nsIntRect aBounds);

		/**
		 * The previous content viewer, which has been |close|d but not
		 * |destroy|ed.
		 */
		nsIContentViewer PreviousViewer { get; set; }

		void Move(Int32 aX, Int32 aY);

		void Show();
		void Hide();

		Boolean Sticky { get; set; }

		/*
		 * This is called when the DOM window wants to be closed.  Returns true
		 * if the window can close immediately.  Otherwise, returns false and will
		 * close the DOM window as soon as practical.
		 */
		Boolean RequestWindowClose();

		/**
		 * Attach the content viewer to its DOM window and docshell.
		 * @param aState A state object that might be useful in attaching the DOM
		 *               window.
		 * @param aSHEntry The history entry that the content viewer was stored in.
		 *                 The entry must have the docshells for all of the child
		 *                 documents stored in its child shell list.
		 */
		void Open([MarshalAs(UnmanagedType.IUnknown)] nsISupports aState, nsISHEntry aSHEntry);

		/**
		 * Clears the current history entry.  This is used if we need to clear out
		 * the saved presentation state.
		 */
		void ClearHistoryEntry();

		/*
		 * Change the layout to view the document with page layout (like print preview), but
		 * dynamic and editable (like Galley layout).
		*/
		void SetPageMode(Boolean aPageMode, nsIPrintSettings aPrintSettings);

		/**
		 * Get the history entry that this viewer will save itself into when
		 * destroyed.  Can return null
		 */
		nsISHEntry HistoryEntry { get; }

		/*
		 * Indicates when we're in a state where content shouldn't be allowed to
		 * trigger a tab-modal prompt (as opposed to a window-modal prompt) because
		 * we're part way through some operation (eg beforeunload) that shouldn't be
		 * rentrant if the user closes the tab while the prompt is showing.
		 * See bug 613800.
		 */
		Boolean IsTabModalPromptAllowed { get; }
	}
}
