using System;
using System.Runtime.InteropServices;

namespace DotGecko.Gecko.Interop
{
	/* THIS IS A PUBLIC EMBEDDING API */

	/**
	 * nsIWebBrowserFind
	 *
	 * Searches for text in a web browser.
	 *
	 * Get one by doing a GetInterface on an nsIWebBrowser.
	 *
	 * By default, the implementation will search the focussed frame, or
	 * if there is no focussed frame, the web browser content area. It
	 * does not by default search subframes or iframes. To change this
	 * behaviour, and to explicitly set the frame to search, 
	 * QueryInterface to nsIWebBrowserFindInFrames.
	 */
	[ComImport, Guid("2f977d44-5485-11d4-87e2-0010a4e75ef2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIWebBrowserFind //: nsISupports
	{
		/**
		 * findNext
		 *
		 * Finds, highlights, and scrolls into view the next occurrence of the
		 * search string, using the current search settings. Fails if the
		 * search string is empty.
		 *
		 * @return  Whether an occurrence was found
		 */
		Boolean FindNext();

		/**
		 * searchString
		 *
		 * The string to search for. This must be non-empty to search.
		 */
		String SearchString { [return: MarshalAs(UnmanagedType.LPWStr)] get; [param: MarshalAs(UnmanagedType.LPWStr)] set; }

		/**
		 * findBackwards
		 *
		 * Whether to find backwards (towards the beginning of the document).
		 * Default is false (search forward).
		 */
		Boolean FindBackwards { get; set; }

		/**
		 * wrapFind
		 *
		 * Whether the search wraps around to the start (or end) of the document
		 * if no match was found between the current position and the end (or
		 * beginning). Works correctly when searching backwards. Default is
		 * false.
		 */
		Boolean WrapFind { get; set; }

		/**
		 * entireWord
		 *
		 * Whether to match entire words only. Default is false.
		 */
		Boolean EntireWord { get; set; }

		/**
		 * matchCase
		 *
		 * Whether to match case (case sensitive) when searching. Default is false.
		 */
		Boolean MatchCase { get; set; }

		/**
		 * searchFrames
		 *
		 * Whether to search through all frames in the content area. Default is true.
		 * 
		 * Note that you can control whether the search propagates into child or
		 * parent frames explicitly using nsIWebBrowserFindInFrames, but if one,
		 * but not both, of searchSubframes and searchParentFrames are set, this
		 * returns false.
		 */
		Boolean SearchFrames { get; set; }
	}

	/**
	 * nsIWebBrowserFindInFrames
	 *
	 * Controls how find behaves when multiple frames or iframes are present.
	 *
	 * Get by doing a QueryInterface from nsIWebBrowserFind.
	 */
	[ComImport, Guid("e0f5d182-34bc-11d5-be5b-b760676c6ebc"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIWebBrowserFindInFrames //: nsISupports
	{
		/**
		 * currentSearchFrame
		 *
		 * Frame at which to start the search. Once the search is done, this will
		 * be set to be the last frame searched, whether or not a result was found.
		 * Has to be equal to or contained within the rootSearchFrame.
		 */
		nsIDOMWindow CurrentSearchFrame { get; set; }

		/**
		 * rootSearchFrame
		 *
		 * Frame within which to confine the search (normally the content area frame).
		 * Set this to only search a subtree of the frame hierarchy.
		 */
		nsIDOMWindow RootSearchFrame { get; set; }

		/**
		 * searchSubframes
		 *
		 * Whether to recurse down into subframes while searching. Default is true.
		 *
		 * Setting nsIWebBrowserfind.searchFrames to true sets this to true.
		 */
		Boolean SearchSubframes { get; set; }

		/**
		 * searchParentFrames
		 *
		 * Whether to allow the search to propagate out of the currentSearchFrame into its
		 * parent frame(s). Search is always confined within the rootSearchFrame. Default
		 * is true.
		 *
		 * Setting nsIWebBrowserfind.searchFrames to true sets this to true.
		 */
		Boolean SearchParentFrames { get; set; }
	}
}
