﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;
using System.IO;

using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor;

namespace XmlEditor.Tests.Utils
{
	public class MockDocument : IDocument
	{
		string text = String.Empty;
		TextSection textSectionUsedWithGetTextMethod;
		ITextSource snapshot;
		
		public List<int> PositionToOffsetReturnValues = new List<int>();
		
		MockTextEditor editor;
		
		public MockDocument(MockTextEditor editor = null)
		{
			this.editor = editor;
		}
		public string Text {
			get { return text; }
			set { text = value; }
		}
		
		public int LineCount {
			get {
				throw new NotImplementedException();
			}
		}
		
		public ITextSourceVersion Version {
			get {
				throw new NotImplementedException();
			}
		}
		
		public int TextLength {
			get { return text.Length; }
		}
		
		public IDocumentLine GetLine(int lineNumber)
		{
			throw new NotImplementedException();
		}
		
		public IDocumentLine GetLineForOffset(int offset)
		{
			throw new NotImplementedException();
		}
		
		public int GetOffset(int line, int column)
		{
			int offset = PositionToOffsetReturnValues[0];
			PositionToOffsetReturnValues.RemoveAt(0);
			return offset;
		}
		
		public int GetOffset(TextLocation location)
		{
			return GetOffset(location.Line, location.Column);
		}
		
		public TextLocation GetLocation(int offset)
		{
			throw new NotImplementedException();
		}
		
		public void Insert(int offset, string text)
		{
			this.text = this.text.Insert(offset, text);
			if (editor != null && editor.Caret.Offset == offset)
				editor.Caret.Offset += text.Length;
		}
		
		public void Insert(int offset, string text, AnchorMovementType defaultAnchorMovementType)
		{
			throw new NotImplementedException();
		}
		
		public void Remove(int offset, int length)
		{
			throw new NotImplementedException();
		}
		
		public void Replace(int offset, int length, string newText)
		{
			throw new NotImplementedException();
		}
		
		public void StartUndoableAction()
		{
			throw new NotImplementedException();
		}
		
		public void EndUndoableAction()
		{
			throw new NotImplementedException();
		}
		
		public IDisposable OpenUndoGroup()
		{
			throw new NotImplementedException();
		}
		
		public ITextAnchor CreateAnchor(int offset)
		{
			throw new NotImplementedException();
		}
		
		public void SetSnapshot(ITextSource snapshot)
		{
			this.snapshot = snapshot;
		}
		
		public ITextSource CreateSnapshot()
		{
			return snapshot;
		}
		
		public ITextSource CreateSnapshot(int offset, int length)
		{
			throw new NotImplementedException();
		}
		
		public TextReader CreateReader()
		{
			throw new NotImplementedException();
		}
		
		public char GetCharAt(int offset)
		{
			return text[offset];
		}
		
		public string GetText(int offset, int length)
		{
			textSectionUsedWithGetTextMethod = new TextSection(offset, length);
			return text.Substring(offset, length);
		}
		
		public TextSection GetTextSectionUsedWithGetTextMethod()
		{
			return textSectionUsedWithGetTextMethod;
		}
		
		public object GetService(Type serviceType)
		{
			throw new NotImplementedException();
		}
		
		public event EventHandler<TextChangeEventArgs> TextChanging {
			add { throw new NotImplementedException(); }
			remove { throw new NotImplementedException(); }
		}
		
		public event EventHandler<TextChangeEventArgs> TextChanged;
		
		public void RaiseChangedEvent()
		{
			TextChangeEventArgs e = new TextChangeEventArgs(0, "", "a");
			if (TextChanged != null) {
				TextChanged(this, e);
			}
		}

		public TextReader CreateReader(int offset, int length)
		{
			throw new NotImplementedException();
		}
		
		public event EventHandler ChangeCompleted;
		
		public IDocument CreateDocumentSnapshot()
		{
			throw new NotImplementedException();
		}
		
		public IDocumentLine GetLineByNumber(int lineNumber)
		{
			throw new NotImplementedException();
		}
		
		public IDocumentLine GetLineByOffset(int offset)
		{
			throw new NotImplementedException();
		}
		
		public string GetText(ISegment segment)
		{
			throw new NotImplementedException();
		}
		
		public int IndexOf(char c, int startIndex, int count)
		{
			throw new NotImplementedException();
		}
		
		public int IndexOfAny(char[] anyOf, int startIndex, int count)
		{
			throw new NotImplementedException();
		}
		
		public int IndexOf(string searchText, int startIndex, int count, StringComparison comparisonType)
		{
			throw new NotImplementedException();
		}
		
		public int LastIndexOf(char c, int startIndex, int count)
		{
			throw new NotImplementedException();
		}
		
		public int LastIndexOf(string searchText, int startIndex, int count, StringComparison comparisonType)
		{
			throw new NotImplementedException();
		}
	}
}
