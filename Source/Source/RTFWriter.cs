/***************************************************************************

  Rtf Dom Parser

  Copyright (c) 2010 sinosoft , written by yuans.
  http://www.sinoreport.net

  This program is free software; you can redistribute it and/or
  modify it under the terms of the GNU General Public License
  as published by the Free Software Foundation; either version 2
  of the License, or (at your option) any later version.
  
  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.
  
  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

****************************************************************************/

using System;

namespace XDesigner.RTF
{
	/// <summary>
    /// RTF text writer ,  this source code evolution from other software.
	/// </summary>
	public class RTFWriter : System.IDisposable
	{
	
		#region test ******************************************************
         
		/// <summary>
		/// Test generate rtf file
		/// after execute this function you can open c:\a.rtf
		/// </summary>
		internal static void TestWriteFile( )
		{
			RTFWriter w = new RTFWriter( "c:\\a.rtf" ) ;
			TestBuildRTF( w );
			w.Close();
			System.Windows.Forms.MessageBox.Show("OK , you can open file c:\\a.rtf 了.");
		}

		/// <summary>
		/// Test generate rtf text and copy to windows clipboard
		/// after execute this function , you can paste rtf text in MS Word
		/// </summary>
		internal static void TestClipboard()
		{
			System.IO.StringWriter myStr = new System.IO.StringWriter();
			RTFWriter w = new RTFWriter( myStr );
			TestBuildRTF( w );
			w.Close();
			System.Windows.Forms.DataObject data = new System.Windows.Forms.DataObject();
			data.SetData( System.Windows.Forms.DataFormats.Rtf , myStr.ToString());
			System.Windows.Forms.Clipboard.SetDataObject( data , true );
			System.Windows.Forms.MessageBox.Show("OK, you can paste words in MS Word.");
		}

		/// <summary>
		/// Test to generate a little rtf document
		/// </summary>
		/// <param name="w">RTF text writer</param>
		private static void TestBuildRTF( RTFWriter w )
		{
			w.Encoding = System.Text.Encoding.GetEncoding( 936 );
			// write header
			w.WriteStartGroup();
			w.WriteKeyword("rtf1");
			w.WriteKeyword("ansi");
			w.WriteKeyword("ansicpg" + w.Encoding.CodePage );
			// wirte font table
			w.WriteStartGroup();
			w.WriteKeyword("fonttbl");
			w.WriteStartGroup();
			w.WriteKeyword("f0");
			w.WriteText("Arial;");
			w.WriteEndGroup();
			w.WriteStartGroup();
			w.WriteKeyword("f1");
            w.WriteText("Times New Roman;");
			w.WriteEndGroup();
			w.WriteEndGroup();
			// write color table
			w.WriteStartGroup();
			w.WriteKeyword("colortbl");
			w.WriteText(";");
			w.WriteKeyword("red0");
			w.WriteKeyword("green0");
			w.WriteKeyword("blue255");
			w.WriteText(";");
			w.WriteEndGroup();
			// write content
			w.WriteKeyword("qc");	// set alignment center
			w.WriteKeyword("f0");	// set font
			w.WriteKeyword("fs30");	// set font size
			w.WriteText("This is the first paragraph text ");
			w.WriteKeyword("cf1");	// set text color
            w.WriteText("Arial ");
			w.WriteKeyword("cf0");	// set default color
			w.WriteKeyword("f1");	// set font
			w.WriteText("Align center ABC12345");
			w.WriteKeyword("par");	// new paragraph
			w.WriteKeyword("pard");	// clear format
			w.WriteKeyword("f1");	// set font 
			w.WriteKeyword("fs20");	// set font size
			w.WriteKeyword("cf1");
			w.WriteText("This is the secend paragraph Arial left alignment ABC12345");
			// finish
			w.WriteEndGroup();
		}

		#endregion

		/// <summary>
		/// Initialize instance
		/// </summary>
		/// <param name="w">text writer</param>
		public RTFWriter( System.IO.TextWriter w )
		{
			myWriter = w ;
		}

		/// <summary>
		/// Initialize instance
		/// </summary>
		/// <param name="strFileName">file name</param>
		public RTFWriter( string strFileName )
		{
			myWriter = new System.IO.StreamWriter(
				strFileName , 
				false , 
				System.Text.Encoding.ASCII );
		}

        /// <summary>
        /// for chinese , can use System.Text.Encoding.GetEncoding( 936 );
        /// </summary>
        private System.Text.Encoding myEncoding = System.Text.Encoding.Default ;
		/// <summary>
		/// text encoding
		/// </summary>
		public System.Text.Encoding Encoding
		{
			get{ return myEncoding ;}
			set{ myEncoding = value;}
		}

		/// <summary>
		/// inner text writer
		/// </summary>
		private System.IO.TextWriter myWriter = null;

		private bool bolIndent = false;
		/// <summary>
		/// whether output rtf code with indent style
		/// </summary>
		/// <remarks>
        /// In rtf formation , recommend do not use indent . this option just to debugger , 
        /// in software development , use this option can genereate indented rtf code friendly to read,
        /// but after debug , recommend clear this option and set this attribute = false.
        /// </remarks>
		public bool Indent
		{
			get
            {
                return bolIndent ;
            }
			set
            {
                bolIndent = value;
            }
		}

		private string strIndentString = "   ";
		/// <summary>
		/// string used to indent
		/// </summary>
		public string IndentString
		{
			get
            {
                return strIndentString ;
            }
			set
            {
                strIndentString = value;
            }
		}

		/// <summary>
		/// current group level
		/// </summary>
		private int intGroupLevel = 0 ;

		/// <summary>
		/// close 
		/// </summary>
		public void Close()
		{
			if(this.intGroupLevel > 0 )
				throw new System.Exception("Some group does not finish");
			if( myWriter != null )
			{
				myWriter.Close();
				myWriter = null;
			}
		}

		/// <summary>
		/// write completed group wich one keyword
		/// </summary>
		/// <param name="KeyWord">keyword</param>
		public void WriteGroup( string KeyWord )
		{
			this.WriteStartGroup();
			this.WriteKeyword( KeyWord );
			this.WriteEndGroup();
		}

		/// <summary>
		/// begin write group
		/// </summary>
		public void WriteStartGroup( )
		{
			if( bolIndent )
			{
				InnerWriteNewLine();
				myWriter.Write("{");
			}
			else
				myWriter.Write("{");
			intGroupLevel ++ ;
		}

		/// <summary>
		/// end write group
		/// </summary>
		public void WriteEndGroup()
		{
			intGroupLevel -- ;
            if (intGroupLevel < 0)
            {
                throw new System.Exception("group level error");
            }
			if( bolIndent )
			{
				InnerWriteNewLine();
				InnerWrite("}");
			}
			else
				InnerWrite("}");
		}

		/// <summary>
		/// write raw text
		/// </summary>
		/// <param name="txt">text</param>
		public void WriteRaw( string txt )
		{
			if( txt != null && txt.Length > 0 )
			{
				InnerWrite( txt );
			}
		}
		/// <summary>
		/// write keyword
		/// </summary>
		/// <param name="Keyword">keyword</param>
		public void WriteKeyword( string Keyword )
		{
			WriteKeyword( Keyword , false );
		}
		/// <summary>
		/// write keyword
		/// </summary>
		/// <param name="Keyword">keyword</param>
		/// <param name="Ext">whether extern key word</param>
		public void WriteKeyword( string Keyword , bool Ext)
		{
			if( Keyword == null || Keyword.Length == 0)
				throw new System.ArgumentNullException("值不得为空");
			if( bolIndent == false && ( Keyword == "par" || Keyword == "pard" ) )
			{
                // at the front of par or pard can write new line , will not effect rtf render.
				InnerWrite( System.Environment.NewLine );
			}
			if( this.bolIndent )
			{
				if( Keyword == "par" || Keyword == "pard" )
				{
					this.InnerWriteNewLine();
				}
			}
			if( Ext )
				InnerWrite("\\*\\");
			else
				InnerWrite("\\");
			InnerWrite( Keyword );
		}

//		public void WriteRaw( string raw )
//		{
//			InnerWrite( raw );
//		}

		/// <summary>
		/// text encoding
		/// </summary>
		private System.Text.Encoding Unicode = System.Text.Encoding.Unicode ;
		/// <summary>
		/// write plain text
		/// </summary>
		/// <param name="Text">文本值</param>
		public void WriteText( string Text )
		{
			if( Text == null || Text.Length == 0 )
				return ;

			WriteText( Text , true );
		}

		/// <summary>
		/// write plain text, can choose write a white space automatic
		/// </summary>
		/// <param name="Text">text</param>
		/// <param name="AutoAddWhitespace">wirte a white space automatic</param>
		public void WriteText( string Text , bool AutoAddWhitespace )
		{
			if( Text == null || Text.Length == 0 )
				return ;
			
			if( AutoAddWhitespace )
			{
				InnerWrite( ' ' );
			}

			for( int iCount = 0 ; iCount < Text.Length ; iCount ++ )
			{
				char c = Text[ iCount ] ;
				if( c == '\t')
				{
					this.WriteKeyword("tab");
					InnerWrite(' ');
				}
				if( c > 32 && c < 127 )
				{
					// some specify characters , must be convert
					if( c == '\\' || c == '{' || c == '}' )
						InnerWrite( '\\');
					InnerWrite( c );
				}
				else
				{
					byte[] bs = myEncoding.GetBytes( c.ToString());
					for(int iCount2 = 0 ; iCount2 < bs.Length ; iCount2 ++ )
					{
						InnerWrite("\\\'");
						WriteByte( bs[ iCount2 ] );
					}
				}
			}//for( int iCount = 0 ; iCount < Text.Length ; iCount ++ )
		}

		/// <summary>
		/// current position
		/// </summary>
		private int intPosition = 0 ;
		/// <summary>
		/// current line head
		/// </summary>
		private int intLineHead = 0 ;

		/// <summary>
		/// hex characters
		/// </summary>
		private const string Hexs = "0123456789abcdef";

		/// <summary>
		/// write binary data
		/// </summary>
		/// <param name="bs">binary data</param>
		public void WriteBytes( byte[] bs )
		{
			if( bs == null || bs.Length == 0 )
				return ;
			WriteRaw( " " );
			for( int iCount = 0 ; iCount < bs.Length ; iCount ++ )
			{
				if( ( iCount % 32 ) == 0 )
				{
					this.WriteRaw( System.Environment.NewLine );
					this.WriteIndent();
				}
				else if( ( iCount % 8 ) == 0 )
				{
					this.WriteRaw(" ");
				}
				byte b = bs[ iCount ] ;
				int h = ( b & 0xf0 ) >> 4  ;
				int l = b & 0xf ;
				myWriter.Write( Hexs[ h ] );
				myWriter.Write( Hexs[ l ] );
				intPosition += 2 ;
			}
		}

		/// <summary>
		/// write a byte data
		/// </summary>
		/// <param name="b">byte data</param>
		public void WriteByte( byte b )
		{
			int h = ( b & 0xf0 ) >> 4 ;
			int l = b & 0xf ;
			myWriter.Write( Hexs[ h ] );
			myWriter.Write( Hexs[ l ] );
			intPosition += 2 ;
			//FixIndent();
		}

		#region internal function ******************************************************

		private void InnerWrite( char c )
		{
			intPosition ++ ;
			myWriter.Write( c );
		}
		private void InnerWrite( string txt )
		{
			intPosition += txt.Length ;
			myWriter.Write( txt );
		}

		private void FixIndent()
		{
			if( this.bolIndent )
			{
				if( intPosition - intLineHead > 100 )
					InnerWriteNewLine();
			}
		}

		private void InnerWriteNewLine()
		{
			if( this.bolIndent )
			{
				if( intPosition > 0 )
				{
					InnerWrite( System.Environment.NewLine );
					intLineHead = intPosition ;
					WriteIndent();
				}
			}
		}

		private void WriteIndent( )
		{
			if( bolIndent )
			{
				for( int iCount = 0 ; iCount < intGroupLevel ; iCount ++ )
				{
					InnerWrite( this.strIndentString );
				}
			}
		}

		#endregion 

		/// <summary>
		/// dispose instance
		/// </summary>
		public void Dispose()
		{
			this.Close();
		}
	}
}