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
using System.Text;

namespace XDesigner.RTF
{
    /// <summary>
    /// RTF element's list
    /// </summary>
    [Serializable()]
    [System.Diagnostics.DebuggerTypeProxy(typeof(RTFInstanceDebugView))]
    public class RTFDomElementList : System.Collections.CollectionBase
    {
        /// <summary>
        /// initialize instance
        /// </summary>
        public RTFDomElementList()
        {
        }

        /// <summary>
        ///  get the element at special index
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>element</returns>
        public RTFDomElement this[int index]
        {
            get
            {
                return (RTFDomElement)this.List[index];
            }
        }

        /// <summary>
        /// get the last element in the list
        /// </summary>
        public RTFDomElement LastElement
        {
            get
            {
                if (this.Count > 0)
                    return (RTFDomElement)this.List[this.Count - 1];
                else
                    return null;
            }
        }
        /// <summary>
        /// add element
        /// </summary>
        /// <param name="element">element</param>
        /// <returns>index</returns>
        public int Add(RTFDomElement element )
        {
            return this.List.Add( element );
        }
        /// <summary>
        /// insert element
        /// </summary>
        /// <param name="index">special index</param>
        /// <param name="element">element</param>
        public void Insert(int index, RTFDomElement element)
        {
            this.List.Insert(index, element);
        }
        /// <summary>
        /// Get the index of special element that starts with 0.
        /// </summary>
        /// <param name="element">element</param>
        /// <returns>index , if not find element , then return -1</returns>
        public int IndexOf(RTFDomElement element)
        {
            return this.List.IndexOf(element);
        }
        /// <summary>
        /// delete element
        /// </summary>
        /// <param name="node">element</param>
        public void Remove(RTFDomElement node)
        {
            this.List.Remove(node);
        }
        /// <summary>
        /// return element array
        /// </summary>
        /// <returns>array</returns>
        public RTFDomElement[] ToArray()
        {
            return (RTFDomElement[])this.InnerList.ToArray(typeof(RTFDomElement));
        }
    }
}
