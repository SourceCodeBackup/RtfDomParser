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
using System.ComponentModel ;

namespace XDesigner.RTF
{
    /// <summary>
    /// shape element
    /// </summary>
    [Serializable()]
    public class RTFDomShape : RTFDomElement
    {
        /// <summary>
        /// initialize instance
        /// </summary>
        public RTFDomShape()
        {
        }

        private int intLeft = 0;
        /// <summary>
        /// left position
        /// </summary>
        [DefaultValue( 0 )]
        public int Left
        {
            get
            {
                return intLeft;
            }
            set
            {
                intLeft = value;
            }
        }

        private int intTop = 0;
        /// <summary>
        /// top position
        /// </summary>
        [DefaultValue( 0 )]
        public int Top
        {
            get
            {
                return intTop;
            }
            set
            {
                intTop = value;
            }
        }

        private int intWidth = 0;
        /// <summary>
        /// width
        /// </summary
        [DefaultValue(0)]
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
        [DefaultValue(0)]
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

        private int intZIndex = 0;
        /// <summary>
        /// Z index
        /// </summary>
        [DefaultValue(0)]
        public int ZIndex
        {
            get
            {
                return intZIndex;
            }
            set
            {
                intZIndex = value;
            }
        }

        private int intShapeID = 0;
        /// <summary>
        /// shape id
        /// </summary>
        [DefaultValue(0)]
        public int ShapeID
        {
            get
            {
                return intShapeID;
            }
            set
            {
                intShapeID = value;
            }
        }

        private StringAttributeCollection myExtAttrbutes = new StringAttributeCollection();
        /// <summary>
        /// ext attribute
        /// </summary>
        public StringAttributeCollection ExtAttrbutes
        {
            get
            {
                return myExtAttrbutes; 
            }
            set
            {
                myExtAttrbutes = value; 
            }
        }

        public override string ToString()
        {
            return "Shape:Left:" + intLeft + " Top:" + intTop + " Width:" + intWidth + " Height:" + intHeight;
        }
    }
}
