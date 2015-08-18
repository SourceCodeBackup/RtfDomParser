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
using System.ComponentModel;
using System.Collections;

namespace XDesigner.RTF
{
    /// <summary>
    /// table row
    /// </summary>
    [Serializable()]
    public class RTFDomTableRow : RTFDomElement
    {
        /// <summary>
        /// initialize instance
        /// </summary>
        public RTFDomTableRow()
        {
        }

        [NonSerialized()]
        private ArrayList myCellSettings = new ArrayList();
        /// <summary>
        /// cell settings
        /// </summary>
        [Browsable( false )]
        [System.Xml.Serialization.XmlIgnore()]
        internal ArrayList CellSettings
        {
            get
            {
                return myCellSettings;
            }
            set
            {
                myCellSettings = value;
            }
        }

        private int intLevel = 1;
        /// <summary>
        /// document level
        /// </summary>
        [DefaultValue( 1 )]
        public int Level
        {
            get 
            {
                return intLevel; 
            }
            set
            {
                intLevel = value;
            }
        }

        private int intRowIndex = 0;
        /// <summary>
        /// row index
        /// </summary>
        [DefaultValue( 0 )]
        internal int RowIndex
        {
            get
            {
                return intRowIndex;
            }
            set
            {
                intRowIndex = value;
            }
        }

        private bool bolIsLastRow = false;
        /// <summary>
        /// is the last row
        /// </summary>
        [DefaultValue( false )]
        public bool IsLastRow
        {
            get
            {
                return bolIsLastRow;
            }
            set
            {
                bolIsLastRow = value;
            }
        }

        private bool bolHeader = false;
        /// <summary>
        /// is header row
        /// </summary>
        [DefaultValue( false )]
        public bool Header
        {
            get
            {
                return bolHeader;
            }
            set
            {
                bolHeader = value;
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


        private int intPaddingLeft = int.MinValue;
        /// <summary>
        /// padding left
        /// </summary>
        [System.ComponentModel.DefaultValue(int.MinValue)]
        public int PaddingLeft
        {
            get
            {
                return intPaddingLeft;
            }
            set
            {
                intPaddingLeft = value;
            }
        }


        private int intPaddingTop = int.MinValue;
        /// <summary>
        /// top padding
        /// </summary>
        [System.ComponentModel.DefaultValue(int.MinValue)]
        public int PaddingTop
        {
            get
            {
                return intPaddingTop;
            }
            set
            {
                intPaddingTop = value;
            }
        }


        private int intPaddingRight = int.MinValue;
        /// <summary>
        /// right padding
        /// </summary>
        [System.ComponentModel.DefaultValue(int.MinValue)]
        public int PaddingRight
        {
            get
            {
                return intPaddingRight;
            }
            set
            {
                intPaddingRight = value;
            }
        }

        private int intPaddingBottom = int.MinValue;
        /// <summary>
        /// bottom padding
        /// </summary>
        [System.ComponentModel.DefaultValue(int.MinValue)]
        public int PaddingBottom
        {
            get
            {
                return intPaddingBottom;
            }
            set
            {
                intPaddingBottom = value;
            }
        }

        private int intWidth = 0;
        /// <summary>
        /// width
        /// </summary>
        [DefaultValue( 0 )]
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

        public override string ToString()
        {
            return "Row " + intRowIndex;
        }

    }
}
