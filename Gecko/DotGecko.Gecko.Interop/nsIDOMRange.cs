using System;
using System.Runtime.InteropServices;
using System.Text;
using DOMStringMarshaler = DotGecko.Gecko.Interop.AStringMarshaler;

namespace DotGecko.Gecko.Interop
{
	// Constants for nsIDOMRange ( "a6cf90ce-15b3-11d2-932e-00805f8add32" ) interface
	public static class nsIDOMRangeConstants
	{
		// CompareHow
		public const UInt16 START_TO_START = 0;
		public const UInt16 START_TO_END = 1;
		public const UInt16 END_TO_END = 2;
		public const UInt16 END_TO_START = 3;
	}

	/**
	 * The nsIDOMRange interface is an interface to a DOM range object.
	 *
	 * For more information on this interface please see
	 * http://www.w3.org/TR/DOM-Level-2-Traversal-Range/
	 */
	[ComImport, Guid("a6cf90ce-15b3-11d2-932e-00805f8add32"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIDOMRange //: nsISupports
	{
		nsIDOMNode StartContainer { get; } // raises(DOMException) on retrieval

		Int32 StartOffset { get; } // raises(DOMException) on retrieval

		nsIDOMNode EndContainer { get; } // raises(DOMException) on retrieval

		Int32 EndOffset { get; } // raises(DOMException) on retrieval

		Boolean Collapsed { get; } // raises(DOMException) on retrieval

		nsIDOMNode CommonAncestorContainer { get; } // raises(DOMException) on retrieval

		void SetStart(nsIDOMNode refNode, Int32 offset); // raises(RangeException, DOMException);

		void SetEnd(nsIDOMNode refNode, Int32 offset); // raises(RangeException, DOMException);

		void SetStartBefore(nsIDOMNode refNode); // raises(RangeException, DOMException);

		void SetStartAfter(nsIDOMNode refNode); // raises(RangeException, DOMException);

		void SetEndBefore(nsIDOMNode refNode); // raises(RangeException, DOMException);

		void SetEndAfter(nsIDOMNode refNode); // raises(RangeException, DOMException);

		void Collapse(Boolean toStart); // raises(DOMException);

		void SelectNode(nsIDOMNode refNode); // raises(RangeException, DOMException);

		void SelectNodeContents(nsIDOMNode refNode); // raises(RangeException, DOMException);

		Int16 CompareBoundaryPoints(UInt16 how, nsIDOMRange sourceRange); // raises(DOMException);

		void DeleteContents(); // raises(DOMException);

		nsIDOMDocumentFragment ExtractContents(); // raises(DOMException);

		nsIDOMDocumentFragment CloneContents(); // raises(DOMException);

		void InsertNode(nsIDOMNode newNode); // raises(DOMException, RangeException);

		void SurroundContents(nsIDOMNode newParent); // raises(DOMException, RangeException);

		nsIDOMRange CloneRange(); // raises(DOMException);

		void ToString([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] StringBuilder result); // raises(DOMException);

		void Detach();
	}
}
