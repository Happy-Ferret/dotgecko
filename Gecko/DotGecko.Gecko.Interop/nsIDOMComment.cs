using System;
using System.Runtime.InteropServices;
using System.Text;
using DOMStringMarshaler = DotGecko.Gecko.Interop.AStringMarshaler;

namespace DotGecko.Gecko.Interop
{
	/**
	 * The nsIDOMComment interface inherits from nsIDOMCharacterData and represents 
	 * the content of a comment, i.e., all the characters between the starting 
	 * '<!--' and ending '-->'.
	 * 
	 * For more information on this interface please see 
	 * http://www.w3.org/TR/DOM-Level-2-Core/
	 */
	[ComImport, Guid("eaf04950-d409-41a0-a99d-2e4e43c1e33d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIDOMComment : nsIDOMCharacterData
	{
		#region nsIDOMNode Members

		new void GetNodeName([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] StringBuilder result);
		new void GetNodeValue([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] StringBuilder result);
		new void SetNodeValue([In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] String value);
		new UInt16 NodeType { get; }
		new nsIDOMNode ParentNode { get; }
		new nsIDOMNodeList ChildNodes { get; }
		new nsIDOMNode FirstChild { get; }
		new nsIDOMNode LastChild { get; }
		new nsIDOMNode PreviousSibling { get; }
		new nsIDOMNode NextSibling { get; }
		new nsIDOMNamedNodeMap Attributes { get; }
		new nsIDOMDocument OwnerDocument { get; }
		new nsIDOMNode InsertBefore(nsIDOMNode newChild, nsIDOMNode refChild); // raises(DOMException);
		new nsIDOMNode ReplaceChild(nsIDOMNode newChild, nsIDOMNode oldChild); // raises(DOMException);
		new nsIDOMNode RemoveChild(nsIDOMNode oldChild); // raises(DOMException);
		new nsIDOMNode AppendChild(nsIDOMNode newChild); // raises(DOMException);
		new Boolean HasChildNodes();
		new nsIDOMNode CloneNode(Boolean deep);
		new void Normalize();
		new Boolean IsSupported([In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] String feature, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] String version);
		new void GetNamespaceURI([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] StringBuilder result);
		new void GetPrefix([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] StringBuilder result);
		new void GetLocalName([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] StringBuilder result);
		new Boolean HasAttributes();

		#endregion

		#region nsIDOMCharacterData Members

		new void GetData([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] StringBuilder result);
		new void SetData([In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] String value);
		new UInt32 Length { get; }
		new void SubstringData(UInt32 offset, UInt32 count, [In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] StringBuilder result);
		new void AppendData([In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] String arg);
		new void InsertData(UInt32 offset, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] String arg);
		new void DeleteData(UInt32 offset, UInt32 count);
		new void ReplaceData(UInt32 offset, UInt32 count, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DOMStringMarshaler))] String arg);

		#endregion
	}
}
