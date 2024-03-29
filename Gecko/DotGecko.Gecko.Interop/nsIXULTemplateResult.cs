using System;
using System.Runtime.InteropServices;
using System.Text;
using nsISupports = System.Object;

namespace DotGecko.Gecko.Interop
{
	/**
	 * A single result generated from a template query. Each result is identified
	 * by an id, which must be unique within the set of results produced from a
	 * query. The result may optionally be identified by an RDF resource.
	 *
	 * Generally, the result and its id will be able to uniquely identify a node
	 * in the source data, such as an RDF or XML node. In other contexts, such as
	 * a database query, a result would represent a particular record.
	 *
	 * A result is expected to only be created by a query processor.
	 *
	 * Each result also contains a set of variable bindings. The value for a
	 * particular variable may be retrieved using the getBindingFor and
	 * getBindingObjectFor methods.
	 */
	[ComImport, Guid("ebea0230-36fa-41b7-8e31-760806057965"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface nsIXULTemplateResult //: nsISupports
	{
		/**
		 * True if the result represents a container.
		 */
		Boolean IsContainer { get; }

		/**
		 * True if the result represents an empty container.
		 */
		Boolean IsEmpty { get; }

		/**
		 * True if the template builder may use this result as the reference point
		 * for additional recursive processing of the template. The template builder
		 * will reprocess the template using this result as the reference point and
		 * generate output content that is expected to be inserted as children of the
		 * output generated for this result. If false, child content is not
		 * processed. This property identifies only the default handling and may be
		 * overriden by syntax used in the template.
		 */
		Boolean MayProcessChildren { get; }

		/**
		 * ID of the result. The DOM element created for this result, if any, will
		 * have its id attribute set to this value. The id must be unique for a
		 * query.
		 */
		void GetId([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AStringMarshaler))] StringBuilder retval);

		/**
		 * Resource for the result, which may be null. If set, the resource uri
		 * must be the same as the ID property.
		 */
		nsIRDFResource Resource { get; }

		/**
		 * The type of the object. The predefined value 'separator' may be used
		 * for separators. Other values may be used for application specific
		 * purposes.
		 */
		void GetType([In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AStringMarshaler))] StringBuilder retval);

		/**
		 * Get the string representation of the value of a variable for this
		 * result. This string will be used in the action body from a template as
		 * the replacement text. For instance, if the text ?name appears in an
		 * attribute within the action body, it will be replaced with the result
		 * of this method. The question mark is considered part of the variable
		 * name, thus aVar should be ?name and not simply name.
		 *
		 * @param aVar the variable to look up
		 *
		 * @return the value for the variable or a null string if it has no value
		 */
		void GetBindingFor(nsIAtom aVar, [In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AStringMarshaler))] StringBuilder retval);

		/**
		 * Get an object value for a variable such as ?name for this result. 
		 *
		 * This method may return null for a variable, even if getBindingFor returns
		 * a non-null value for the same variable. This method is provided as a
		 * convenience when sorting results.
		 *
		 * @param aVar the variable to look up
		 *
		 * @return the value for the variable or null if it has no value
		 */
		[return: MarshalAs(UnmanagedType.IUnknown)]
		nsISupports GetBindingObjectFor(nsIAtom aVar);

		/**
		 * Indicate that a particular rule of a query has matched and that output
		 * will be generated for it. Both the query as compiled by the query
		 * processor's compileQuery method and the XUL <rule> element are supplied.
		 * The query must always be one that was compiled by the query processor
		 * that created this result. The <rule> element must always be a child of
		 * the <query> element that was used to compile the query.
		 *
		 * @param aQuery the query that matched
		 * @param aRuleNode the rule node that matched
		 */
		void RuleMatched([MarshalAs(UnmanagedType.IUnknown)] nsISupports aQuery, nsIDOMNode aRuleNode);

		/**
		 * Indicate that the output for a result has beeen removed and that the
		 * result is no longer being used by the builder.
		 */
		void HasBeenRemoved();
	}
}
