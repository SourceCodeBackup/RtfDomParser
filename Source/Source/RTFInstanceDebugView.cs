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
    /// debug information dispalyer at design time
    /// </summary>
    public class RTFInstanceDebugView
    {
        /// <summary>
        /// initialize instance
        /// </summary>
        /// <param name="instance"></param>
        public RTFInstanceDebugView(object instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");
            myInstance = instance;
        }

        private object myInstance = null;

        /// <summary>
        /// output debug item at design time
        /// </summary>
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.RootHidden)]
        public object Items
        {
            get
            {
                if (myInstance is System.Collections.IEnumerable)
                {
                    System.Collections.CollectionBase list = (System.Collections.CollectionBase)myInstance;
                    object[] items = new object[list.Count];
                    int iCount = 0;
                    foreach (object obj in list)
                    {
                        items[iCount] = obj;
                        iCount++;
                    }
                    return items;
                }
                else if (myInstance is RTFColorTable)
                {
                    RTFColorTable table = (RTFColorTable)myInstance;
                    object[] items = new object[table.Count];
                    for (int iCount = 0; iCount < table.Count; iCount++)
                    {
                        items[iCount] = table[iCount];
                    }
                    return items;
                }
                else if (myInstance is RTFDocumentInfo)
                {
                    RTFDocumentInfo info = (RTFDocumentInfo)myInstance;
                    return info.StringItems;
                }
                else
                {
                    return myInstance;
                }
            }
        }
    }
}
