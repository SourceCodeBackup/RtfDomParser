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
using System.Collections ;

namespace XDesigner.RTF
{
	/// <summary>
	/// rtf color table
	/// </summary>
    [System.Diagnostics.DebuggerDisplay("Count={Count}")]
    [System.Diagnostics.DebuggerTypeProxy(typeof(RTFInstanceDebugView))]
	public class RTFColorTable
	{
		/// <summary>
		/// initialize instance
		/// </summary>
		public RTFColorTable()
		{
		}

		private ArrayList myItems = new ArrayList();
		/// <summary>
		/// get color at special index
		/// </summary>
		public System.Drawing.Color this[ int index ]
		{
			get
            {
                return ( System.Drawing.Color ) myItems[ index ] ;
            }
		}

		/// <summary>
		/// get color at special index , if index out of range , return default color
		/// </summary>
		/// <param name="index">index</param>
		/// <param name="DefaultValue">default value</param>
		/// <returns>color value</returns>
		public System.Drawing.Color GetColor( int index , System.Drawing.Color DefaultValue )
		{
			index -- ;
			if( index >= 0 && index < myItems.Count )
				return ( System.Drawing.Color ) myItems[ index ] ;
			else
				return DefaultValue ;
		}

        private bool bolCheckValueExistWhenAdd = true ;
        /// <summary>
        /// check color value exist when add color to list
        /// </summary>
        public bool CheckValueExistWhenAdd
        {
            get
            {
                return bolCheckValueExistWhenAdd; 
            }
            set
            {
                bolCheckValueExistWhenAdd = value; 
            }
        }

		/// <summary>
		/// add color to list
		/// </summary>
		/// <param name="c">new color value</param>
		public void Add( System.Drawing.Color c )
		{
			if( c.IsEmpty )
				return ;
			if( c.A == 0 )
				return ;
			
			if( c.A != 255 )
			{
				c = System.Drawing.Color.FromArgb( 255 , c );
			}

            if (bolCheckValueExistWhenAdd)
            {
                if (IndexOf(c) < 0)
                {
                    myItems.Add(c);
                }
            }
            else
            {
                myItems.Add(c);
            }
		}
		/// <summary>
		/// delete special color
		/// </summary>
		/// <param name="c">color value</param>
		public void Remove( System.Drawing.Color c )
		{
			int index = IndexOf( c );
			if( index >= 0 )
				myItems.RemoveAt( index );
		}
		/// <summary>
		/// get color index
		/// </summary>
		/// <param name="c">color</param>
		/// <returns>index , if not found , return -1</returns>
		public int IndexOf( System.Drawing.Color c )
		{
			if( c.A == 0 )
				return -1 ;

			if( c.A != 255 )
			{
				c = System.Drawing.Color.FromArgb( 255 , c );
			}
			for( int iCount = 0 ; iCount < myItems.Count ; iCount ++ )
			{
				System.Drawing.Color color = ( System.Drawing.Color ) myItems[ iCount ] ;
				if( color.ToArgb() == c.ToArgb())
					return iCount ;
			}
			return -1 ;
		}
		/// <summary>
		/// 清空列表
		/// </summary>
		public void Clear()
		{
			myItems.Clear();
		}
		/// <summary>
		/// 元素个数
		/// </summary>
		public int Count
		{
			get{ return myItems.Count ; }
		}

		/// <summary>
		/// 输出颜色表
		/// </summary>
		/// <param name="writer">RTF文档书写器</param>
		public void Write( RTFWriter writer )
		{
			writer.WriteStartGroup();
			writer.WriteKeyword( RTFConsts._colortbl );
			writer.WriteRaw(";");
			for( int iCount = 0 ; iCount < myItems.Count ; iCount ++ )
			{
				System.Drawing.Color c = ( System.Drawing.Color ) myItems[ iCount ] ;
				writer.WriteKeyword( "red" + c.R );
				writer.WriteKeyword( "green" + c.G );
				writer.WriteKeyword( "blue" + c.B );
				writer.WriteRaw(";");
			}
			writer.WriteEndGroup();
		}

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns>复制品</returns>
        public RTFColorTable Clone()
        {
            RTFColorTable table = new RTFColorTable();
            for (int iCount = 0; iCount < myItems.Count; iCount++)
            {
                System.Drawing.Color c = ( System.Drawing.Color ) myItems[ iCount ] ;
                table.myItems.Add(c);
            }
            return table;
        }
    }
}