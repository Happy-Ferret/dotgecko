using System;
using System.Runtime.InteropServices;
using DOMString = DotGecko.Gecko.Interop.nsAString;

namespace DotGecko.Gecko.Interop
{
	/**
	 * nsIDOMEntityReference is an interface to a node that represents a 
	 * reference to one of the entities defined in the document.
	 *
	 * For more information on this interface please see 
	 * http://www.w3.org/TR/DOM-Level-2-Core/
	 *
	 * @status FROZEN
	 */
	[ComImport]
	[Guid("a6cf907a-15b3-11d2-932e-00805f8add32")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface nsIDOMEntityReference : nsIDOMNode
	{
		#region nsIDOMNode Members

		new void GetNodeName(DOMString result);
		new void GetNodeValue(DOMString result);
		new void SetNodeValue(DOMString value);
		new UInt16 GetNodeType();
		new nsIDOMNode GetParentNode();
		new nsIDOMNodeList GetChildNodes();
		new nsIDOMNode GetFirstChild();
		new nsIDOMNode GetLastChild();
		new nsIDOMNode GetPreviousSibling();
		new nsIDOMNode GetNextSibling();
		new nsIDOMNamedNodeMap GetAttributes();
		new nsIDOMDocument GetOwnerDocument();
		new nsIDOMNode InsertBefore(nsIDOMNode newChild, nsIDOMNode refChild);
		new nsIDOMNode ReplaceChild(nsIDOMNode newChild, nsIDOMNode oldChild);
		new nsIDOMNode RemoveChild(nsIDOMNode oldChild);
		new nsIDOMNode AppendChild(nsIDOMNode newChild);
		new Boolean HasChildNodes();
		new nsIDOMNode CloneNode(Boolean deep);
		new void Normalize();
		new Boolean IsSupported(DOMString feature, DOMString version);
		new void GetNamespaceURI(DOMString result);
		new void GetPrefix(DOMString result);
		new void SetPrefix(DOMString value);
		new void GetLocalName(DOMString result);
		new Boolean HasAttributes();

		#endregion
	}
}
