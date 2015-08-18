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
    /// text element
    /// </summary>
    [Serializable()]
    public class RTFDomText : RTFDomElement
    {
        /// <summary>
        /// initialize instance
        /// </summary>
        public RTFDomText()
        {
            // text element can not contains any child element
            this.Locked = true;
        }

        private DocumentFormatInfo myFormat = new DocumentFormatInfo();
        /// <summary>
        /// format
        /// </summary>
        public DocumentFormatInfo Format
        {
            get
            {
                return myFormat;
            }
            set
            {
                myFormat = value;
            }
        }

        private string strText = null;
        /// <summary>
        /// text
        /// </summary>
        [System.ComponentModel.DefaultValue( null)]
        public string Text
        {
            get
            {
                return strText;
            }
            set
            {
                strText = value;
            }
        }
        public override string InnerText
        {
            get
            {
                return strText;
            }
        }
        public override string ToString()
        {
            return "Text:" + strText;
        }
    }
}
