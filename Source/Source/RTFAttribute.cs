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
    /// rtf attribute
    /// </summary>
    [Serializable()]
    public class RTFAttribute
    {
        /// <summary>
        /// initialize instance
        /// </summary>
        public RTFAttribute()
        {
        }

        private string strName = null;
        /// <summary>
        /// attribute's name
        /// </summary>
        [System.ComponentModel.DefaultValue( null)]
        public string Name
        {
            get
            {
                return strName; 
            }
            set
            {
                strName = value; 
            }
        }

        private int intValue = int.MinValue ;
        /// <summary>
        /// value
        /// </summary>
        [System.ComponentModel.DefaultValue( int.MinValue )]
        public int Value
        {
            get
            {
                return intValue; 
            }
            set
            {
                intValue = value; 
            }
        }
        public override string ToString()
        {
            return strName + "=" + intValue;
        }
    }

    /// <summary>
    /// RTF attribute list
    /// </summary>
    [Serializable()]
    [System.Diagnostics.DebuggerTypeProxy(typeof(RTFInstanceDebugView))]
    public class RTFAttributeList : System.Collections.CollectionBase
    {
        /// <summary>
        /// initialize instance
        /// </summary>
        public RTFAttributeList()
        {
        }

        public int this[string name]
        {
            get
            {
                foreach (RTFAttribute a in this)
                {
                    if (a.Name == name)
                        return a.Value;
                }
                return int.MinValue;
            }
            set
            {
                foreach (RTFAttribute a in this)
                {
                    if (a.Name == name)
                    {
                        a.Value = value;
                        return;
                    }
                }
                RTFAttribute item = new RTFAttribute();
                item.Name = name;
                item.Value = value;
                this.List.Add(item);
            }
        }

        public int Add(RTFAttribute item)
        {
            return this.List.Add(item);
        }

        public int Add(string name, int v)
        {
            RTFAttribute item = new RTFAttribute();
            item.Name = name;
            item.Value = v;
            return this.List.Add(item);
        }

        public void Remove(RTFAttribute item)
        {
            this.List.Remove(item);
        }

        public void Remove(string name)
        {
            for (int iCount = this.Count - 1; iCount >= 0; iCount--)
            {
                RTFAttribute item = (RTFAttribute)this.List[iCount];
                if (item.Name == name)
                {
                    this.List.RemoveAt(iCount);
                }
            }
        }

        public bool Contains(RTFAttribute item)
        {
            return this.List.Contains(item);
        }

        public bool Contains(string name)
        {
            foreach (RTFAttribute a in this)
            {
                if (a.Name == name)
                    return true;
            }
            return false;
        }

        public RTFAttributeList Clone()
        {
            RTFAttributeList list = new RTFAttributeList();
            foreach (RTFAttribute item in this)
            {
                RTFAttribute newItem = new RTFAttribute();
                newItem.Name = item.Name;
                newItem.Value = item.Value;
                list.List.Add(newItem);
            }
            return list;
        }
    }
}
