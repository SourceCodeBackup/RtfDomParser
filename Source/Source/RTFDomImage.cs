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
    /// image element
    /// </summary>
    [Serializable()]
    public class RTFDomImage : RTFDomElement
    {
        /// <summary>
        /// initialize instance
        /// </summary>
        public RTFDomImage()
        {
        }

        private string strID = null;
        /// <summary>
        /// id
        /// </summary>
        [System.ComponentModel.DefaultValue(null)]
        public string ID
        {
            get
            {
                return strID;
            }
            set
            {
                strID = value;
            }
        }

        private byte[] bsData = null;
        /// <summary>
        /// data
        /// </summary>
        [System.ComponentModel.Browsable( false )]
        [System.Xml.Serialization.XmlIgnore()]
        public byte[] Data
        {
            get
            {
                return bsData; 
            }
            set
            {
                bsData = value; 
            }
        }

        [System.ComponentModel.Browsable( false )]
        [System.Xml.Serialization.XmlElement()]
        [System.ComponentModel.DesignerSerializationVisibility( System.ComponentModel.DesignerSerializationVisibility.Hidden )]
        public string Base64Data
        {
            get
            {
                if (bsData == null)
                    return null;
                else
                    return Convert.ToBase64String(bsData);
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    bsData = Convert.FromBase64String(value);
                }
                else
                {
                    bsData = null;
                }
            }
        }

        private int intScaleX = 100;
        /// <summary>
        /// scale rate at the X coordinate, in percent unit.
        /// </summary>
        [System.ComponentModel.DefaultValue(100)]
        public int ScaleX
        {
            get
            {
                return intScaleX;
            }
            set
            {
                intScaleX = value;
            }
        }

        private int intScaleY = 100;
        /// <summary>
        /// scale rate at the Y coordinate , in percent unit.
        /// </summary>
        [System.ComponentModel.DefaultValue(100)]
        public int ScaleY
        {
            get
            {
                return intScaleY;
            }
            set
            {
                intScaleY = value;
            }
        }

        private int intDesiredWidth = 0;
        /// <summary>
        /// desired width
        /// </summary>
        [System.ComponentModel.DefaultValue( 0 )]
        public int DesiredWidth
        {
            get
            {
                return intDesiredWidth; 
            }
            set
            {
                intDesiredWidth = value; 
            }
        }

        private int intDesiredHeight = 0;
        /// <summary>
        /// desired height
        /// </summary>
        [System.ComponentModel.DefaultValue(0)]
        public int DesiredHeight
        {
            get
            {
                return intDesiredHeight; 
            }
            set
            {
                intDesiredHeight = value; 
            }
        }

        private int intWidth = 0;
        /// <summary>
        /// width
        /// </summary>
        [System.ComponentModel.DefaultValue(0)]
        public int Width
        {
            get
            {
                return intWidth; 
            }
            set
            {
                intWidth = value; 
            }
        }

        private int intHeight = 0;
        /// <summary>
        /// height
        /// </summary>
        [System.ComponentModel.DefaultValue(0)]
        public int Height
        {
            get
            {
                return intHeight; 
            }
            set
            {
                intHeight = value; 
            }
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

        public override string ToString()
        {
            string txt = "Image:" + intWidth + "*" + intHeight;
            if (bsData != null && bsData.Length > 0)
                txt = txt + " " + Convert.ToDouble( bsData.Length / 1024.0).ToString("0.00") + "KB";
            return txt;
        }
    }
}
