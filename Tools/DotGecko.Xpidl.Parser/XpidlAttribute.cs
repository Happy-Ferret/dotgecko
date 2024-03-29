﻿using System;

namespace DotGecko.Xpidl.Parser
{
	public sealed class XpidlAttribute : XpidlNode
	{
		internal XpidlAttribute(String name, String type, Boolean isReadOnly, XpidlModifiers<XpidlMethodModifier> modifiers)
		{
			m_Name = name;
			m_Type = type;
			m_IsReadOnly = isReadOnly;
			m_Modifiers = (modifiers ?? new XpidlModifiers<XpidlMethodModifier>()).AsReadOnly();
		}

		public String Name
		{
			get { return m_Name; }
		}

		public String Type
		{
			get { return m_Type; }
		}

		public Boolean IsReadOnly
		{
			get { return m_IsReadOnly; }
		}

		public XpidlModifiers<XpidlMethodModifier> Modifiers
		{
			get { return m_Modifiers; }
		}

		public override String ToString()
		{
			return String.Format("{0}attribute {1} {2};", IsReadOnly ? "readonly " : String.Empty, Type, Name);
		}

		private readonly String m_Name;
		private readonly String m_Type;
		private readonly Boolean m_IsReadOnly;
		private readonly XpidlModifiers<XpidlMethodModifier> m_Modifiers;
	}
}
