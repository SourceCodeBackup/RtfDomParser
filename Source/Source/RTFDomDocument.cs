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
using System.Collections;
using System.Text;
using System.ComponentModel ;

namespace XDesigner.RTF
{
    /// <summary>
    /// RTF Document
    /// </summary>
    /// <remarks>
    /// This type is the root of RTF Dom tree structure
    /// </remarks>
    public partial class RTFDomDocument : RTFDomElement
    {
        /// <summary>
        /// initialize instance
        /// </summary>
        public RTFDomDocument()
        {
            this.OwnerDocument = this;
        }


        private string strFollowingChars = null;
        /// <summary>
        /// following characters
        /// </summary>
        [System.ComponentModel.DefaultValue( null)]
        public string FollowingChars
        {
            get
            {
                return strFollowingChars; 
            }
            set
            {
                strFollowingChars = value; 
            }
        }

        private string strLeadingChars = null;
        /// <summary>
        /// leading characters
        /// </summary>
        [System.ComponentModel.DefaultValue(null)]
        public string LeadingChars
        {
            get
            {
                return strLeadingChars; 
            }
            set
            {
                strLeadingChars = value; 
            }
        }

        private System.Text.Encoding myDefaultEncoding = System.Text.Encoding.Default ;
        /// <summary>
        /// text encoding of current font
        /// </summary>
        private System.Text.Encoding myFontChartset = null;
        /// <summary>
        /// text encoding of associate font 
        /// </summary>
        private System.Text.Encoding myAssociateFontChartset = null;
        /// <summary>
        /// text encoding
        /// </summary>
        internal System.Text.Encoding RuntimeEncoding
        {
            get
            {
                if (myFontChartset != null)
                {
                    return myFontChartset;
                }
                if (myAssociateFontChartset != null)
                {
                    return myAssociateFontChartset;
                }
                return myDefaultEncoding;
            }
        }

        /// <summary>
        /// default font name
        /// </summary>
        private static string DefaultFontName = System.Windows.Forms.Control.DefaultFont.Name;


        private RTFFontTable myFontTable = new RTFFontTable();
        /// <summary>
        /// font table
        /// </summary>
        public RTFFontTable FontTable
        {
            get
            {
                return myFontTable;
            }
            set
            {
                myFontTable = value;
            }
        }

        private RTFColorTable myColorTable = new RTFColorTable();
        /// <summary>
        /// color table
        /// </summary>
        public RTFColorTable ColorTable
        {
            get
            {
                return myColorTable;
            }
            set
            {
                myColorTable = value;
            }
        }

        private RTFDocumentInfo myInfo = new RTFDocumentInfo();
        /// <summary>
        /// document information
        /// </summary>
        public RTFDocumentInfo Info
        {
            get
            {
                return myInfo;
            }
            set
            {
                myInfo = value;
            }
        }

        private string strGenerator = null;
        /// <summary>
        /// document generator
        /// </summary>
        [DefaultValue( null )]
        public string Generator
        {
            get
            {
                return strGenerator;
            }
            set
            {
                strGenerator = value;
            }
        }

        private int intPaperWidth = 12240;
        /// <summary>
        /// paper width
        /// </summary>
        [DefaultValue( 12240 )]
        public int PaperWidth
        {
            get
            {
                return intPaperWidth; 
            }
            set
            {
                intPaperWidth = value; 
            }
        }

        private int intPaperHeight = 15840;
        /// <summary>
        /// paper height
        /// </summary>
        [DefaultValue( 15840 )]
        public int PaperHeight
        {
            get
            {
                return intPaperHeight; 
            }
            set
            {
                intPaperHeight = value; 
            }
        }

        private int intLeftMargin = 1800;
        /// <summary>
        /// left margin
        /// </summary>
        [DefaultValue( 1800 )]
        public int LeftMargin
        {
            get
            {
                return intLeftMargin; 
            }
            set
            {
                intLeftMargin = value; 
            }
        }

        private int intTopMargin = 1440;
        /// <summary>
        /// top margin
        /// </summary>
        [DefaultValue( 1440 )]
        public int TopMargin
        {
            get
            {
                return intTopMargin; 
            }
            set
            {
                intTopMargin = value; 
            }
        }

        private int intRightMargin = 1800;
        /// <summary>
        /// right margin
        /// </summary>
        [System.ComponentModel.DefaultValue(1800)]
        public int RightMargin
        {
            get
            {
                return intRightMargin;
            }
            set
            {
                intRightMargin = value;
            }
        }

        private int intBottomMargin = 1440;
        /// <summary>
        /// bottom margin
        /// </summary>
        [System.ComponentModel.DefaultValue(1440)]
        public int BottomMargin
        {
            get
            {
                return intBottomMargin;
            }
            set
            {
                intBottomMargin = value;
            }
        }

        private bool bolLandscape = false;
        /// <summary>
        /// landscape
        /// </summary>
        [System.ComponentModel.DefaultValue(false)]
        public bool Landscape
        {
            get
            {
                return bolLandscape;
            }
            set
            {
                bolLandscape = value;
            }
        }

        /// <summary>
        /// client area width
        /// </summary>
        [Browsable( false )]
        public int ClientWidth
        {
            get
            {
                if (bolLandscape)
                {
                    return intPaperHeight - intLeftMargin - intRightMargin;
                }
                else
                {
                    return intPaperWidth - intLeftMargin - intRightMargin;
                }
            }
        }

        private bool bolChangeTimesNewRoman = true;
        /// <summary>
        /// convert "Times new roman" to default font when parse rtf content
        /// </summary>
        [DefaultValue( true )]
        public bool ChangeTimesNewRoman
        {
            get
            {
                return bolChangeTimesNewRoman;
            }
            set
            {
                bolChangeTimesNewRoman = value;
            }
        }
        //private Stack myElements = new Stack();

        /// <summary>
        /// progress event
        /// </summary>
        public event ProgressEventHandler Progress = null;

        /// <summary>
        /// raise progress event
        /// </summary>
        /// <param name="max">progress max value</param>
        /// <param name="Value">progress value</param>
        /// <param name="message">progress message</param>
        /// <returns>user cancel</returns>
        protected bool OnProgress(int max, int Value, string message)
        {
            if (Progress != null)
            {
                ProgressEventArgs args = new ProgressEventArgs(max, Value, message);
                Progress(this, args);
                return args.Cancel;
            }
            return false;
        }


        /// <summary>
        /// load a rtf file and parse
        /// </summary>
        /// <param name="fileName">file name</param>
        public void Load(string fileName)
        {
            using (System.IO.FileStream stream = new System.IO.FileStream(
                fileName,
                System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                Load(stream);
            }
        }

        /// <summary>
        /// load a rtf document from a stream and parse content
        /// </summary>
        /// <param name="stream">stream</param>
        public void Load(System.IO.Stream stream)
        {
            this.Elements.Clear();
            bolStartContent = false;
            RTFReader reader = new RTFReader(stream);
            DocumentFormatInfo format = new DocumentFormatInfo();
            Load(reader, format);
            // combination table rows to table
            CombinTable(this);
            FixElements(this);
        }


        /// <summary>
        /// load a rtf document from a text reader and parse content
        /// </summary>
        /// <param name="reader">text reader</param>
        public void Load(System.IO.TextReader reader )
        {
            this.Elements.Clear();
            bolStartContent = false;
            RTFReader r = new RTFReader(reader);
            DocumentFormatInfo format = new DocumentFormatInfo();
            Load(r, format);
            // combination table rows to table
            CombinTable(this);
            FixElements(this);
        }

        /// <summary>
        /// load a rtf document from a string in rtf format and parse content
        /// </summary>
        /// <param name="rtfText">text</param>
        public void LoadRTFText(string rtfText)
        {
            System.IO.StringReader reader = new System.IO.StringReader(rtfText);
            this.Elements.Clear();
            bolStartContent = false;
            RTFReader rtfReader = new RTFReader(reader);
            DocumentFormatInfo format = new DocumentFormatInfo();
            Load(rtfReader, format);
            CombinTable(this);
            FixElements(this);
        }


        private void FixElements(RTFDomElement parentElement)
        {
            // combin text element , decrease number of RTFDomText instance
            ArrayList result = new ArrayList();
            foreach (RTFDomElement element in parentElement.Elements)
            {
                if (element is RTFDomText)
                {
                    if (result.Count > 0 && result[result.Count - 1] is RTFDomText)
                    {
                        RTFDomText lastText = (RTFDomText)result[result.Count - 1];
                        RTFDomText txt = (RTFDomText)element;
                        if (lastText.Text.Trim().Length == 0 || txt.Text.Trim().Length == 0)
                        {
                            if (lastText.Text.Trim().Length == 0)
                            {
                                // close text format
                                lastText.Format = txt.Format.Clone();
                            }
                            lastText.Text = lastText.Text + txt.Text;
                        }
                        else
                        {
                            if (lastText.Format.EqualsSettings(txt.Format))
                            {
                                lastText.Text = lastText.Text + txt.Text;
                            }
                            else
                            {
                                result.Add(txt);
                            }
                        }
                    }
                    else
                    {
                        result.Add(element);
                    }
                }
                else
                {
                    result.Add(element);
                }
            }//foreach
            parentElement.Elements.Clear();
            foreach (RTFDomElement element in result)
            {
                parentElement.AppendChild(element);
            }

            foreach (RTFDomElement element in parentElement.Elements.ToArray())
            {
                if (element is RTFDomTable)
                {
                    UpdateTableCells((RTFDomTable)element, true);
                }
            }
            foreach (RTFDomElement element in parentElement.Elements)
            {
                FixElements(element);
            }
        }
        private RTFDomElement[] GetLastElements()
        {
            ArrayList result = new ArrayList();
            RTFDomElement element = this;
            while (element != null)
            {
                result.Add(element);
                element = element.Elements.LastElement;
            }
            return (RTFDomElement[])result.ToArray(typeof(RTFDomElement));
        }

        public RTFDomElement GetLastElement(Type elementType)
        {
            RTFDomElement[] elements = GetLastElements();
            for (int iCount = elements.Length - 1; iCount >= 0; iCount--)
            {
                if (elementType.IsInstanceOfType(elements[iCount]))
                    return elements[iCount];
            }
            return null;
        }

        public RTFDomElement GetLastElement(Type elementType, bool lockStatus)
        {
            RTFDomElement[] elements = GetLastElements();
            for (int iCount = elements.Length - 1; iCount >= 0; iCount--)
            {
                if (elementType.IsInstanceOfType(elements[iCount]))
                {
                    if (elements[iCount].Locked == lockStatus)
                    {
                        return elements[iCount];
                    }
                }
            }
            return null;
        }

        public RTFDomElement GetLastElement()
        {
            RTFDomElement[] elements = GetLastElements();
            return elements[elements.Length - 1];
        }


        private void AddContentElement(RTFDomElement newElement)
        {
            RTFDomElement[] elements = GetLastElements();
            RTFDomElement element = elements[elements.Length - 1];
            if ( newElement != null && newElement.NativeLevel > 0)
            {
                for (int iCount = elements.Length - 1; iCount >= 0; iCount--)
                {
                    if ( elements[ iCount ].NativeLevel == newElement.NativeLevel )
                    {
                        for (int iCount2 = iCount; iCount2 < elements.Length; iCount2++)
                        {
                            elements[iCount2].Locked = true;
                        }
                        break;
                    }
                }
            }
            for (int iCount = elements.Length - 1; iCount >= 0; iCount--)
            {
                if (elements[iCount].Locked == false)
                {
                    element = elements[iCount];
                    if (element is RTFDomImage)
                    {
                        element.Locked = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (element is RTFDomTableRow)
            {
                // If the last element is table row 
                // can not contains any element , 
                // so need create a cell element.
                RTFDomTableCell cell = new RTFDomTableCell();
                element.AppendChild(cell);
                if (newElement != null)
                {
                    cell.AppendChild(newElement);
                }
            }
            else
            {
                if (newElement != null)
                {
                    if (element is RTFDomParagraph && newElement is RTFDomParagraph)
                    {
                        // If both is paragraph , append new paragraph to the parent of old paragraph
                        element.Locked = true;
                        element.Parent.AppendChild(newElement);
                    }
                    else
                    {
                        element.AppendChild(newElement);
                    }
                }
            }
        }

        private int ListTextFlag = 0;
        private bool bolStartContent = false;

        /// <summary>
        /// convert a hex string to a byte array
        /// </summary>
        /// <param name="hex">hex string</param>
        /// <returns>byte array</returns>
        private byte[] HexToBytes(string hex)
        {
            string chars = "0123456789abcdef";

            int index = 0;
            int Value = 0;
            int CharCount = 0;
            ByteBuffer buffer = new ByteBuffer();
            for (int iCount = 0; iCount < hex.Length; iCount++)
            {
                char c = hex[iCount];
                c = char.ToLower(c);
                index = chars.IndexOf(c);
                if (index >= 0)
                {
                    CharCount++;
                    Value = Value * 16 + index;
                    if (CharCount > 0 && (CharCount % 2) == 0)
                    {
                        buffer.Add((byte)Value);
                        Value = 0;
                    }
                }
            }
            return buffer.ToArray();
        }

        private void CombinTable(RTFDomElement parentElement)
        {
            ArrayList result = new ArrayList();
            ArrayList rows = new ArrayList();
            int lastRowWidth = -1;
            foreach (RTFDomElement element in parentElement.Elements)
            {
                if (element is RTFDomTableRow)
                {
                    RTFDomTableRow row = (RTFDomTableRow)element;
                    row.Locked = false;
                    for (int iCount = 0; iCount < row.Elements.Count; iCount++)
                    {
                        row.Elements[iCount].Attributes = (RTFAttributeList)row.CellSettings[iCount];
                    }
                    foreach (RTFDomTableCell cell in row.Elements)
                    {
                        CombinTable(cell);
                    }

                    // split to table
                    if (row.HasAttribute(RTFConsts._lastrow))
                    {
                        // if current row mark the last row , then 
                        // generate a new table
                        rows.Add(row);
                        result.Add(CreateTable(rows));
                        lastRowWidth = -1;
                    }
                    else
                    {
                        int width = 0;
                        if (row.HasAttribute(RTFConsts._trwWidth))
                        {
                            width = row.Attributes[RTFConsts._trwWidth];
                            if (row.HasAttribute(RTFConsts._trwWidthA))
                            {
                                width = width - row.Attributes[RTFConsts._trwWidthA];
                            }
                        }
                        else
                        {
                            foreach (RTFDomTableCell cell in row.Elements)
                            {
                                if (cell.HasAttribute(RTFConsts._cellx))
                                {
                                    width = Math.Max(width, cell.Attributes[RTFConsts._cellx]);
                                }
                            }
                        }
                        if (lastRowWidth > 0 && lastRowWidth != width)
                        {
                            // If row's width is change , then can consider multi-table combin
                            // then split and generate new table
                            result.Add(CreateTable(rows));
                        }
                        lastRowWidth = width;
                        rows.Add(row);
                    }
                }
                else
                {
                    CombinTable(element);
                    if (rows.Count > 0)
                    {
                        result.Add(CreateTable(rows));
                    }
                    result.Add(element);
                }
            }//foreach
            if (rows.Count > 0)
            {
                result.Add(CreateTable(rows));
            }
            parentElement.Locked = false;
            parentElement.Elements.Clear();
            foreach (RTFDomElement element in result)
            {
                parentElement.AppendChild(element);
            }
        }
        /// <summary>
        /// create table
        /// </summary>
        /// <param name="rows">table rows</param>
        /// <returns>new table</returns>
        private RTFDomTable CreateTable(ArrayList rows)
        {
            if (rows.Count > 0)
            {
                RTFDomTable table = new RTFDomTable();
                int index = 0;
                foreach (RTFDomTableRow row in rows)
                {
                    row.RowIndex = index;
                    index++;
                    table.AppendChild(row);
                }
                rows.Clear();
                return table;
            }
            else
            {
                throw new ArgumentException("rows");
            }
        }

        private int intDefaultRowHeight = 400;
        /// <summary>
        /// default row's height, in twips.
        /// </summary>
        public int DefaultRowHeight
        {
            get
            {
                return intDefaultRowHeight;
            }
            set
            {
                intDefaultRowHeight = value;
            }
        }
         
        private void UpdateTableCells(RTFDomTable table, bool fixTableCellSize)
        {
            // number of table column
            int columns = 0;
            // flag of cell merge
            bool merge = false;
            // right position of all cells
            ArrayList rights = new ArrayList();

            // right position of table
            int tableLeft = 0;

            foreach (RTFDomTableRow row in table.Elements)
            {
                int lastCellX = 0;

                columns = Math.Max(columns, row.Elements.Count);
                if (row.HasAttribute(RTFConsts._irow))
                {
                    row.RowIndex = row.Attributes[RTFConsts._irow];
                }
                row.IsLastRow = row.HasAttribute(RTFConsts._lastrow);
                row.Header = row.HasAttribute(RTFConsts._trhdr);
                // read row height
                if (row.HasAttribute(RTFConsts._trrh))
                {
                    row.Height = row.Attributes[RTFConsts._trrh];
                    if (row.Height == 0)
                    {
                        row.Height = this.DefaultRowHeight;
                    }
                    else if (row.Height < 0)
                    {
                        row.Height = -row.Height;
                    }
                }
                else
                {
                    row.Height = this.DefaultRowHeight;
                }
                // read default padding of cell
                if (row.HasAttribute(RTFConsts._trpaddl))
                {
                    row.PaddingLeft = row.Attributes[RTFConsts._trpaddl];
                }
                else
                {
                    row.PaddingLeft = int.MinValue;
                }
                if (row.HasAttribute(RTFConsts._trpaddt))
                {
                    row.PaddingTop = row.Attributes[RTFConsts._trpaddt];
                }
                else
                {
                    row.PaddingTop = int.MinValue;
                }

                if (row.HasAttribute(RTFConsts._trpaddr))
                {
                    row.PaddingRight = row.Attributes[RTFConsts._trpaddr];
                }
                else
                {
                    row.PaddingRight = int.MinValue;
                }

                if (row.HasAttribute(RTFConsts._trpaddb))
                {
                    row.PaddingBottom = row.Attributes[RTFConsts._trpaddb];
                }
                else
                {
                    row.PaddingBottom = int.MinValue;
                }

                if (row.HasAttribute(RTFConsts._trleft))
                {
                    tableLeft = row.Attributes[RTFConsts._trleft];
                }

                int widthCount = 0;
                foreach (RTFDomTableCell cell in row.Elements)
                {
                    // set cell's dispaly format

                    if (cell.HasAttribute(RTFConsts._clvmgf))
                    {
                        // cell vertically merge
                        merge = true;
                    }
                    if (cell.HasAttribute(RTFConsts._clvmrg))
                    {
                        // cell vertically merge by another cell
                        merge = true;
                    }
                    if (cell.HasAttribute(RTFConsts._clpadl))
                    {
                        cell.PaddingLeft = cell.Attributes[RTFConsts._clpadl];
                    }
                    else
                    {
                        cell.PaddingLeft = int.MinValue;
                    }
                    if (cell.HasAttribute(RTFConsts._clpadr))
                    {
                        cell.PaddingRight = cell.Attributes[RTFConsts._clpadr];
                    }
                    else
                    {
                        cell.PaddingRight = int.MinValue;
                    }
                    if (cell.HasAttribute(RTFConsts._clpadt))
                    {
                        cell.PaddingTop = cell.Attributes[RTFConsts._clpadt];
                    }
                    else
                    {
                        cell.PaddingTop = int.MinValue;
                    }
                    if (cell.HasAttribute(RTFConsts._clpadb))
                    {
                        cell.PaddingBottom = cell.Attributes[RTFConsts._clpadb];
                    }
                    else
                    {
                        cell.PaddingBottom = int.MinValue;
                    }

                    // whether dispaly border line
                    cell.LeftBorder = cell.HasAttribute(RTFConsts._clbrdrl);
                    cell.TopBorder = cell.HasAttribute(RTFConsts._clbrdrt);
                    cell.RightBorder = cell.HasAttribute(RTFConsts._clbrdrr);
                    cell.BottomBorder = cell.HasAttribute(RTFConsts._clbrdrb);
                    // vertial alignment
                    if (cell.HasAttribute(RTFConsts._clvertalt))
                        cell.VerticalAlignment = RTFVerticalAlignment.Top;
                    else if (cell.HasAttribute(RTFConsts._clvertalc))
                        cell.VerticalAlignment = RTFVerticalAlignment.Middle;
                    else if (cell.HasAttribute(RTFConsts._clvertalb))
                        cell.VerticalAlignment = RTFVerticalAlignment.Bottom;
                    // background color
                    if (cell.HasAttribute(RTFConsts._clcbpat))
                    {
                        cell.BackColor = this.ColorTable[cell.Attributes[RTFConsts._clcbpat] - 1];
                    }
                    if (cell.HasAttribute(RTFConsts._clcfpat))
                    {
                        cell.BorderColor = this.ColorTable[cell.Attributes[RTFConsts._clcfpat] - 1];
                    }

                    // cell's width
                    int cellWidth = 2763;// cell's default with is 2763 Twips(570 Document)
                    if (cell.HasAttribute(RTFConsts._cellx))
                    {
                        cellWidth = cell.Attributes[RTFConsts._cellx] - lastCellX;
                        if (cellWidth < 100)
                            cellWidth = 100;
                    }
                    int right = lastCellX + cellWidth;
                    // fix cell's right position , if this position is very near with another cell's 
                    // right position( less then 45 twips or 3 pixel), then consider these two position
                    // is the same , this can decrease number of table columns
                    for (int iCount = 0; iCount < rights.Count; iCount++)
                    {
                        if (Math.Abs(right - (int)rights[iCount]) < 45)
                        {
                            right = (int)rights[iCount];
                            cellWidth = right - lastCellX;
                            break;
                        }
                    }

                    cell.Left = lastCellX;
                    cell.Width = cellWidth;
                    widthCount += cellWidth;
                    //int right = cell.Left + cell.Width;
                    if (rights.Contains(right) == false)
                    {
                        // becase of convert twips to unit of document may cause truncation error.
                        // This may cause rights.Contains mistake . so scale cell's with with 
                        // native twips unit , after all computing , convert to unit of document.
                        rights.Add(right);
                    }
                    lastCellX = lastCellX + cellWidth;
                }//foreach
                row.Width = widthCount;
            }//foreach
            if (rights.Count == 0)
            {
                // can not detect cell's width , so consider set cell's width
                // automatic, then set cell's default width.
                int cols = 1;
                foreach (RTFDomTableRow row in table.Elements)
                {
                    cols = Math.Max(cols, row.Elements.Count);
                }
                int w = (int)(this.ClientWidth / cols);
                for (int iCount = 0; iCount < cols; iCount++)
                {
                    rights.Add(iCount * w + w);
                }
            }
            // computing cell's rowspan and colspan , number of rights array is the number of table columns.

            rights.Add(0);
            rights.Sort();
            // add table column instance
            for (int iCount = 1; iCount < rights.Count; iCount++)
            {
                RTFDomTableColumn col = new RTFDomTableColumn();
                col.Width = (int)rights[iCount] - (int)rights[iCount - 1];
                table.Columns.Add(col);
            }

            for (int rowIndex = 1; rowIndex < table.Elements.Count; rowIndex++)
            {
                RTFDomTableRow row = (RTFDomTableRow)table.Elements[rowIndex];
                for (int colIndex = 0; colIndex < row.Elements.Count; colIndex++)
                {
                    RTFDomTableCell cell = (RTFDomTableCell)row.Elements[colIndex];
                    if (cell.Width == 0)
                    {
                        // If current cell not special width , then use the width of cell which 
                        // in the same colum and in the last row
                        RTFDomTableRow preRow = (RTFDomTableRow)table.Elements[rowIndex - 1];
                        if (preRow.Elements.Count > colIndex)
                        {
                            RTFDomTableCell preCell = (RTFDomTableCell)preRow.Elements[colIndex];
                            cell.Left = preCell.Left;
                            cell.Width = preCell.Width;
                            CopyStyleAttribute(cell, preCell.Attributes);
                        }
                    }
                }
            }
            if (merge == false)
            {
                // If not detect cell merge , maby exist cell merge in the same row
                foreach (RTFDomTableRow row in table.Elements)
                {
                    if (row.Elements.Count < table.Columns.Count)
                    {
                        // if number of row's cells not equals the number of table's columns
                        // then exist cell merge.
                        merge = true;
                        break;
                    }
                }
            }
            if (merge)
            {
                // detect cell merge , begin merge operation

                // Becase of in rtf format,cell which merged by another cell in the same row , 
                // does no written in rtf text , so delay create those cell instance .
                foreach (RTFDomTableRow row in table.Elements)
                {
                    if (row.Elements.Count != table.Columns.Count)
                    {
                        // If number of row's cells not equals number of table's columns ,
                        // then consider there are hanppend  horizontal merge.
                        RTFDomElement[] cells = row.Elements.ToArray();
                        foreach (RTFDomTableCell cell in cells)
                        {
                            int index = rights.IndexOf(cell.Left);
                            int index2 = rights.IndexOf(cell.Left + cell.Width);
                            int intColSpan = index2 - index;
                            // detect vertical merge
                            bool verticalMerge = cell.HasAttribute(RTFConsts._clvmrg);
                            if (verticalMerge == false)
                            {
                                // If this cell does not merged by another cell abover , 
                                // then set colspan
                                cell.ColSpan = intColSpan;
                            }
                            for (int iCount = 0; iCount < intColSpan - 1; iCount++)
                            {
                                RTFDomTableCell newCell = new RTFDomTableCell();
                                newCell.Attributes = cell.Attributes.Clone();
                                row.Elements.Insert(row.Elements.IndexOf(cell) + 1, newCell);
                                if (verticalMerge)
                                {
                                    // This cell has been merged.
                                    newCell.Attributes[RTFConsts._clvmrg] = 1;
                                    newCell.OverrideCell = cell;
                                }
                            }//for
                        }
                        if (row.Elements.Count != table.Columns.Count)
                        {
                            // If the last cell has been merged. then supply new cells.
                            RTFDomTableCell lastCell = (RTFDomTableCell)row.Elements.LastElement;
                            for (int iCount = row.Elements.Count; iCount < rights.Count; iCount++)
                            {
                                RTFDomTableCell newCell = new RTFDomTableCell();
                                CopyStyleAttribute(newCell, lastCell.Attributes);
                                row.Elements.Add(newCell);
                            }
                        }//if
                    }//if
                }//foreach

                // set cell's vertial merge.
                foreach (RTFDomTableRow row in table.Elements)
                {
                    foreach (RTFDomTableCell cell in row.Elements)
                    {
                        if (cell.HasAttribute(RTFConsts._clvmgf) == false)
                        {
                            //if this cell does not mark vertial merge , then next cell
                            continue;
                        }
                        // if this cell mark vertial merge.
                        int colIndex = row.Elements.IndexOf(cell);
                        for (int rowIndex = table.Elements.IndexOf(row) + 1;
                            rowIndex < table.Elements.Count;
                            rowIndex++)
                        {
                            RTFDomTableRow row2 = (RTFDomTableRow)table.Elements[rowIndex];
                            if (colIndex >= row2.Elements.Count)
                            {
                                System.Console.Write("");
                            }
                            RTFDomTableCell cell2 = (RTFDomTableCell)row2.Elements[colIndex];
                            if (cell2.HasAttribute(RTFConsts._clvmrg))
                            {
                                if (cell2.OverrideCell != null)
                                {
                                    // If this cell has been merge by another cell( must in the same row )
                                    // then break the circle
                                    break;
                                }
                                // increase vertial merge.
                                cell.RowSpan++;
                                cell2.OverrideCell = cell;
                            }//if
                            else
                            {
                                // if this cell not mark merged by another cell , then break the circel
                                break;
                            }
                        }//for
                    }
                }

                // set cell's OverridedCell information
                foreach (RTFDomTableRow row in table.Elements)
                {
                    foreach (RTFDomTableCell cell in row.Elements)
                    {
                        if (cell.RowSpan > 1 || cell.ColSpan > 1)
                        {
                            for (int rowIndex = 1; rowIndex <= cell.RowSpan; rowIndex++)
                            {
                                for (int colIndex = 1; colIndex <= cell.ColSpan; colIndex++)
                                {
                                    int r = table.Elements.IndexOf(row) + rowIndex - 1;
                                    int c = row.Elements.IndexOf(cell) + colIndex - 1;
                                    RTFDomTableCell cell2 = (RTFDomTableCell)table.Elements[r].Elements[c];
                                    if (cell != cell2)
                                    {
                                        cell2.OverrideCell = cell;
                                    }
                                }//for
                            }//for
                        }//if
                    }//foreach
                }//foreach

            }//if

            if (fixTableCellSize)
            {

                // Fix table's left position use the first table column
                if (table.Columns.Count > 0)
                {
                    ((RTFDomTableColumn)table.Columns[0]).Width -= tableLeft;
                }
            }

        }

        private void CopyStyleAttribute(RTFDomTableCell cell, RTFAttributeList table)
        {
            RTFAttributeList attrs = table.Clone();
            attrs.Remove(RTFConsts._clvmgf);
            attrs.Remove(RTFConsts._clvmrg);
            cell.Attributes = attrs;
        }

        public override string ToString()
        {
            return "RTFDocument:" + this.myInfo.Title;
        }

        private bool ApplyText(RTFTextContainer myText, RTFReader reader, DocumentFormatInfo format)
        {
            if (myText.HasContent)
            {
                string strText = myText.Text;
                myText.Clear();

                // if current element is image element , then finish handle image element
                RTFDomImage img = (RTFDomImage)GetLastElement( typeof( RTFDomImage )) ;
                if( img != null && img.Locked == false )
                {
                    img.Data = HexToBytes(strText);
                    img.Format = format.Clone();
                    img.Width = (int)(img.DesiredWidth * img.ScaleX / 100);
                    img.Height = (int)(img.DesiredHeight * img.ScaleY / 100);
                    img.Locked = true;
                    if (reader.TokenType != RTFTokenType.GroupEnd)
                    {
                        ReadToEndGround(reader);
                    }
                    return true;
                }
                else if (format.ReadText && bolStartContent)
                {
                    RTFDomText txt = new RTFDomText();
                    txt.NativeLevel = myText.Level;
                    txt.Format = format.Clone();
                    if (txt.Format.Align == RTFAlignment.Justify)
                        txt.Format.Align = RTFAlignment.Left;
                    txt.Text = strText;
                    AddContentElement(txt);
                }
            }
            return false;
        }


        private int intTokenCount = 0;

        private void Load(RTFReader reader , DocumentFormatInfo parentFormat )
        {
            bool ForbitPard = false;
            DocumentFormatInfo format = null;
            if (parentFormat == null)
            {
                format = new DocumentFormatInfo();
            }
            else
            {
                format = parentFormat.Clone();
                format.NativeLevel = parentFormat.NativeLevel + 1;
            }
            RTFTextContainer myText = new RTFTextContainer( this );
            int levelBack = reader.Level;
            while (reader.ReadToken() != null)
            {
                if (reader.TokenCount - intTokenCount > 100)
                {
                    intTokenCount = reader.TokenCount;
                    OnProgress(reader.ContentLength, reader.ContentPosition, null);
                }
                if (bolStartContent)
                {
                    if (myText.Accept(reader.CurrentToken))
                    {
                        myText.Level = reader.Level;
                        continue;
                    }
                    else if (myText.HasContent)
                    {
                        if (ApplyText(myText, reader, format))
                        {
                            break;
                        }
                    }
                }

                if (reader.TokenType == RTFTokenType.GroupEnd)
                {
                    RTFDomElement[] elements = GetLastElements();
                    for (int iCount = 0 ; iCount < elements.Length ; iCount ++ )
                    {
                        RTFDomElement element = elements[iCount];
                        if (element.NativeLevel >= 0 && element.NativeLevel > reader.Level)
                        {
                            for (int iCount2 = iCount ; iCount2 < elements.Length; iCount2++)
                            {
                                elements[iCount2].Locked = true;
                            }
                            break;
                        }
                    }//for

                    break;
                }

                if (reader.Level < levelBack)
                {
                    break;
                }

                if (reader.TokenType == RTFTokenType.GroupStart)
                {
                    //level++;
                    Load(reader, format);
                    if (reader.Level < levelBack)
                    {
                        break;
                    }
                    //continue;
                }

                if (reader.TokenType == RTFTokenType.Control 
                    || reader.TokenType == RTFTokenType.Keyword 
                    || reader.TokenType == RTFTokenType.ExtKeyword)
                {
                    switch (reader.Keyword)
                    {
                        case RTFConsts._listtable:
                        case RTFConsts._listoverride:
                            // unknow keyword
                            ReadToEndGround(reader);
                            break;
                        case RTFConsts._ansi :
                            break;
                        case RTFConsts._ansicpg :
                            // read default encoding
                            myDefaultEncoding = Encoding.GetEncoding(reader.Parameter);
                            break;
                        case RTFConsts._fonttbl :
                            // read font table
                            ReadFontTable(reader);
                            break;
                        case "filetbl":
                            // unsupport file list
                            ReadToEndGround( reader );
                            break ;// finish current level
                            //break;
                        case RTFConsts._colortbl :
                            // read color table
                            ReadColorTable(reader);
                            return;// finish current level
                            //break;
                        case "stylesheet":
                            // unsupport style sheet list
                            ReadToEndGround(reader);
                            break;
                        case RTFConsts._generator :
                            // read document generator
                            this.Generator = ReadInnerText(reader, true );
                            break;
                        case RTFConsts._info :
                            // read document information
                            ReadDocumentInfo(reader);
                            return ;
                        case RTFConsts._header:
                        case RTFConsts._footer:
                        case RTFConsts._headerl:
                        case RTFConsts._headerr:
                        case RTFConsts._headerf:
                        case RTFConsts._footerl:
                        case RTFConsts._footerr:
                        case RTFConsts._footerf:
                            {
                                // unsupport footer
                                ReadToEndGround(reader);
                                break;
                            }
                        case RTFConsts._xmlns:
                            {
                                // unsupport xml namespace
                                ReadToEndGround(reader);
                                break;
                            }
                        case  RTFConsts._nonesttables:
                            {
                                // I support nest table , then ignore this keyword
                                ReadToEndGround(reader);
                                break;
                            }
                        case  RTFConsts._xmlopen:
                            {
                                // unsupport xmlopen keyword
                                break;
                            }
                        case RTFConsts._revtbl:
                            {
                                //ReadToEndGround(reader);
                                break;
                            }
                        
                        case RTFConsts._pntext:
                        case RTFConsts._pntxtb:
                        case RTFConsts._pntxta:
                        case RTFConsts._bkmkend:
                            {
                                ForbitPard = true;
                                format.ReadText = false;
                                break;
                            }

                        //**************** read document information ***********************
                        case RTFConsts._paperw:
                            {
                                // read paper width
                                intPaperWidth = reader.Parameter;
                                break;
                            }
                        case RTFConsts._paperh:
                            {
                                // read paper height
                                intPaperHeight = reader.Parameter;
                                break;
                            }
                        case RTFConsts._margl:
                            {
                                // read left margin
                                intLeftMargin = reader.Parameter;
                                break;
                            }
                        case RTFConsts._margr:
                            {
                                // read right margin
                                intRightMargin = reader.Parameter;
                                break;
                            }
                        case RTFConsts._margb:
                            {
                                // read bottom margin
                                intBottomMargin = reader.Parameter;
                                break;
                            }
                        case RTFConsts._margt:
                            {
                                // read top margin 
                                intTopMargin = reader.Parameter;
                                break;
                            }
                        case RTFConsts._landscape:
                            {
                                // set landscape
                                bolLandscape = true;
                                break;
                            }
                        case RTFConsts._fchars :
                            this.FollowingChars = ReadInnerText(reader, true);
                            break;
                        case RTFConsts._lchars :
                            this.LeadingChars = ReadInnerText(reader, true);
                            break;
                        case "pnseclvl":
                            // ignore this keyword
                            ReadToEndGround(reader);
                            break; ;
                        //**************** read paragraph format ***********************
                        case RTFConsts._pard:
                            {
                                bolStartContent = true;
                                if (ForbitPard)
                                    continue;
                                // clear paragraph format
                                format.ResetParagraph();
                                break;
                            }
                        case RTFConsts._par:
                            {
                                // new paragraph
                                RTFDomParagraph p = new RTFDomParagraph();
                                p.Format = format.Clone();
                                AddContentElement(p);
                                break;
                            }
                        case RTFConsts._ql:
                            {
                                // left alignment
                                format.Align = RTFAlignment.Left;
                                break;
                            }
                        case RTFConsts._qc:
                            {
                                // center alignment
                                format.Align = RTFAlignment.Center;
                                break;
                            }
                        case RTFConsts._qr:
                            {
                                // right alignment
                                format.Align = RTFAlignment.Right;
                                break;
                            }
                        case RTFConsts._qj:
                            {
                                // jusitify alignment
                                format.Align = RTFAlignment.Justify;
                                break;
                            }
                        case RTFConsts._fi:
                            {
                                // indent first line
                                if (reader.Parameter >= 400)
                                    format.ParagraphFirstLineIndent = reader.Parameter; //doc.StandTabWidth;
                                else
                                    format.ParagraphFirstLineIndent = 0;
                                ////UpdateParagraph( CurrentParagraphEOF , format );
                                break;
                            }
                        case RTFConsts._pnlvlbody:
                            {
                                // numbered list style
                                format.NumberedList = true;
                                format.BulletedList = false;
                                if (format.Parent != null)
                                {
                                    format.Parent.NumberedList = format.NumberedList;
                                    format.Parent.BulletedList = format.BulletedList;
                                }
                                break;
                            }
                        case RTFConsts._pnlvlblt:
                            {
                                // bulleted list style
                                format.NumberedList = false;
                                format.BulletedList = true;
                                if (format.Parent != null)
                                {
                                    format.Parent.NumberedList = format.NumberedList;
                                    format.Parent.BulletedList = format.BulletedList;
                                }
                                break;
                            }
                        case RTFConsts._listtext:
                            {
                                string txt = ReadInnerText(reader, true); 
                                if (txt != null)
                                {
                                    txt = txt.Trim();
                                    if (txt.StartsWith("l"))
                                        ListTextFlag = 1;
                                    else
                                        ListTextFlag = 2;
                                }
                                break;
                            }
                        case RTFConsts._ls:
                            {
                                if (ListTextFlag == 1)
                                {
                                    format.NumberedList = false;
                                    format.BulletedList = true;
                                }
                                else if (ListTextFlag == 2)
                                {
                                    format.NumberedList = true;
                                    format.BulletedList = false;
                                }
                                ListTextFlag = 0;
                                break;
                            }
                        case RTFConsts._li:
                            {
                                if (reader.HasParam)
                                {
                                    format.LeftIndent = reader.Parameter;
                                }
                                break;
                            }
                        case RTFConsts._line:
                            {
                                bolStartContent = true;
                                // break line
                                if (format.ReadText )
                                {
                                    RTFDomLine line = new RTFDomLine();
                                    line.NativeLevel = reader.Level;
                                    AddContentElement( line );
                                }
                                break;
                            }
                        // ****************** read text format ******************************
                        case RTFConsts._insrsid :
                            break;
                        case RTFConsts._plain:
                            {
                                // clear text format
                                format.ResetText();
                                break;
                            }
                        case RTFConsts._f:
                            {
                                // font name
                                if ( format.ReadText )
                                {
                                    string FontName = this.FontTable.GetFontName(reader.Parameter);
                                    if (FontName != null)
                                        FontName = FontName.Trim();
                                    if (FontName == null || FontName.Length == 0)
                                        FontName = DefaultFontName;

                                    if (this.ChangeTimesNewRoman)
                                    {
                                        if (FontName == "Times New Roman")
                                            FontName = DefaultFontName;
                                    }
                                    format.FontName = FontName;
                                }
                                myFontChartset = this.FontTable[reader.Parameter].Encoding;
                                break;
                            }
                        case RTFConsts._af:
                            {
                                myAssociateFontChartset = this.FontTable[reader.Parameter].Encoding;
                                break;
                            }
                        case RTFConsts._fs:
                            {
                                // font size
                                if (format.ReadText)
                                {
                                    if ( reader.HasParam)
                                    {
                                        format.FontSize = reader.Parameter / 2.0f;
                                    }
                                }
                                break;
                            }
                        case RTFConsts._cf:
                            {
                                // font color
                                if (format.ReadText)
                                {
                                    if (reader.HasParam)
                                    {
                                        format.TextColor = this.ColorTable.GetColor( reader.Parameter, System.Drawing.Color.Black);
                                    }
                                }
                                break;
                            }
                        case RTFConsts._cb:
                        case RTFConsts._chcbpat:
                            {
                                // background color
                                if (format.ReadText)
                                {
                                    if ( reader.HasParam )
                                    {
                                        format.BackColor = this.ColorTable.GetColor(reader.Parameter, System.Drawing.Color.Empty);
                                    }
                                }
                                break;
                            }
                        case RTFConsts._b:
                            {
                                // bold
                                if (format.ReadText)
                                {
                                    format.Bold = (reader.HasParam == false || reader.Parameter != 0);
                                }
                                break;
                            }
                        case RTFConsts._i:
                            {
                                // italic
                                if (format.ReadText)
                                {
                                    format.Italic = (reader.HasParam == false || reader.Parameter != 0);
                                }
                                break;
                            }
                        case RTFConsts._ul:
                            {
                                // under line
                                if (format.ReadText)
                                {
                                    format.Underline = (reader.HasParam == false || reader.Parameter != 0);
                                }
                                break;
                            }
                        case RTFConsts._strike:
                            {
                                // strikeout
                                if (format.ReadText)
                                {
                                    format.Strikeout = (reader.HasParam == false || reader.Parameter != 0);
                                }
                                break;
                            }
                        case RTFConsts._sub:
                            {
                                // subscript
                                if (format.ReadText)
                                {
                                    format.Subscript = (reader.HasParam == false || reader.Parameter != 0);
                                }
                                break;
                            }
                        case RTFConsts._super:
                            {
                                // superscript
                                if (format.ReadText)
                                {
                                    format.Superscript = (reader.HasParam == false || reader.Parameter != 0);
                                }
                                break;
                            }
                        case RTFConsts._brdrb:
                            {
                                format.BottomBorder = true;
                                break;
                            }
                        case RTFConsts._brdrl:
                            {
                                format.LeftBorder = true;
                                break;
                            }
                        case RTFConsts._brdrr:
                            {
                                format.RightBorder = true;
                                break;
                            }
                        case RTFConsts._brdrt:
                            {
                                format.TopBorder = true;
                                break;
                            }
                        case RTFConsts._brdrcf:
                            {
                                format.BorderColor = this.ColorTable[reader.Parameter - 1];
                                break;
                            }
                        case RTFConsts._chbrdr:
                            {
                                format.LeftBorder = true;
                                format.TopBorder = true;
                                format.RightBorder = true;
                                format.BottomBorder = true;
                                break;
                            }
                        case RTFConsts._bkmkstart:
                            {
                                // book mark
                                if ( format.ReadText && bolStartContent)
                                {
                                    RTFDomBookmark bk = new RTFDomBookmark();
                                    bk.Name = ReadInnerText(reader, true);
                                    AddContentElement(bk);
                                }
                                break;
                            }

                        case RTFConsts._field:
                            {
                                // field
                                ReadDomField(reader , format );
                                return; // finish current level
                                //break;
                            }
                        
                        case RTFConsts._objdata:
                        case RTFConsts._objclass:
                            {
                                ReadToEndGround(reader);
                                break;
                            }

                        #region read image **********************************

                        case RTFConsts._shppict :
                            // continue the following token
                            break;
                        case RTFConsts._nonshppict :
                            // unsupport keyword
                            ReadToEndGround(reader);
                            break;
                        case RTFConsts._pict:
                            {
                                // read image data
                                bolStartContent = true;
                                RTFDomImage img = new RTFDomImage();
                                img.NativeLevel = reader.Level;
                                AddContentElement( img );
                            }
                            break;
                        case RTFConsts._picscalex:
                            {
                                RTFDomImage img = (RTFDomImage)GetLastElement(typeof(RTFDomImage));
                                if (img != null)
                                {
                                    img.ScaleX = reader.Parameter;
                                }
                                break;
                            }
                        case RTFConsts._picscaley:
                            {
                                RTFDomImage img = (RTFDomImage)GetLastElement(typeof(RTFDomImage));
                                if (img != null)
                                {
                                    img.ScaleY = reader.Parameter;
                                }
                                break;
                            }
                        case RTFConsts._picwgoal:
                            {
                                RTFDomImage img = (RTFDomImage)GetLastElement(typeof(RTFDomImage));
                                if (img != null)
                                {
                                    img.DesiredWidth = reader.Parameter;
                                }
                                break;
                            }
                        case RTFConsts._pichgoal:
                            {
                                RTFDomImage img = (RTFDomImage)GetLastElement(typeof(RTFDomImage));
                                if (img != null)
                                {
                                    img.DesiredHeight = reader.Parameter;
                                }
                                break;
                            }
                        case RTFConsts._blipuid:
                            {
                                RTFDomImage img = (RTFDomImage)GetLastElement(typeof(RTFDomImage));
                                if (img != null)
                                {
                                    img.ID = ReadInnerText(reader, true);
                                }
                                break;
                            }

                        #endregion

                        #region read shape ************************************************
                        case RTFConsts._sp:
                            {
                                // begin read shape property
                                int level = 0;
                                string vName = null;
                                string vValue = null;
                                while (reader.ReadToken() != null)
                                {
                                    if (reader.TokenType == RTFTokenType.GroupStart)
                                    {
                                        level++;
                                    }
                                    else if (reader.TokenType == RTFTokenType.GroupEnd)
                                    {
                                        level--;
                                        if (level < 0)
                                        {
                                            break;
                                        }
                                    }
                                    else if (reader.Keyword == RTFConsts._sn)
                                    {
                                        vName = ReadInnerText(reader, true);
                                    }
                                    else if (reader.Keyword == RTFConsts._sv)
                                    {
                                        vValue = ReadInnerText(reader, true);
                                    }
                                }//while
                                RTFDomShape shape = (RTFDomShape)GetLastElement(typeof(RTFDomShape));
                                if (shape != null)
                                {
                                    shape.ExtAttrbutes[vName] = vValue;
                                }
                                else
                                {
                                    RTFDomShapeGroup g = (RTFDomShapeGroup)GetLastElement(typeof(RTFDomShapeGroup));
                                    if (g != null)
                                    {
                                        g.ExtAttrbutes[vName] = vValue;
                                    }
                                }
                                break;
                            }
                        case RTFConsts._shptxt:
                            {
                                // handle following token
                                break;
                            }
                        case RTFConsts._shprslt:
                            {
                                // ignore this level
                                ReadToEndGround( reader );
                                break  ;
                            }
                        case RTFConsts._shp:
                            {
                                RTFDomShape shape = new RTFDomShape();
                                shape.NativeLevel = reader.Level;
                                AddContentElement(shape);
                                break;
                            }
                        case RTFConsts._shpleft:
                            {
                                RTFDomShape shape = (RTFDomShape)GetLastElement(typeof(RTFDomShape));
                                if (shape != null)
                                {
                                    shape.Left = reader.Parameter;
                                }
                                break;
                            }
                        case RTFConsts._shptop:
                            {
                                RTFDomShape shape = (RTFDomShape)GetLastElement(typeof(RTFDomShape));
                                if (shape != null)
                                {
                                    shape.Top = reader.Parameter;
                                }
                                break;
                            }
                        case RTFConsts._shpright:
                            {
                                RTFDomShape shape = (RTFDomShape)GetLastElement(typeof(RTFDomShape));
                                if (shape != null)
                                {
                                    shape.Width = reader.Parameter - shape.Left;
                                }
                                break;
                            }
                        case RTFConsts._shpbottom:
                            {
                                RTFDomShape shape = (RTFDomShape)GetLastElement(typeof(RTFDomShape));
                                if (shape != null)
                                {
                                    shape.Height = reader.Parameter - shape.Top;
                                }
                                break;
                            }
                        case RTFConsts._shplid:
                            {
                                RTFDomShape shape = (RTFDomShape)GetLastElement(typeof(RTFDomShape));
                                if (shape != null)
                                {
                                    shape.ShapeID = reader.Parameter;
                                }
                                break;
                            }
                        case RTFConsts._shpz:
                            {
                                RTFDomShape shape = (RTFDomShape)GetLastElement(typeof(RTFDomShape));
                                if (shape != null)
                                {
                                    shape.ZIndex = reader.Parameter;
                                }
                                break;
                            }
                        case RTFConsts._shpgrp:
                            {
                                RTFDomShapeGroup group = new RTFDomShapeGroup();
                                group.NativeLevel = reader.Level;
                                AddContentElement(group);
                                break;
                            }
                        case RTFConsts._shpinst:
                            {
                                break;
                            }
                        #endregion

                        #region read table ************************************************
                        case RTFConsts._intbl:
                        case RTFConsts._trowd:
                        case RTFConsts._itap:
                            {
                                // these keyword said than current paragraph is table row
                                RTFDomElement[] es = GetLastElements();
                                RTFDomElement lastUnlockElement = null;
                                RTFDomElement lastTableElement = null;
                                for (int iCount = es.Length - 1; iCount >= 0; iCount--)
                                {
                                    RTFDomElement e = es[iCount];
                                    if (e.Locked == false)
                                    {
                                        if (lastUnlockElement == null && !(e is RTFDomParagraph))
                                        {
                                            lastUnlockElement = e;
                                        }
                                        if (e is RTFDomTableRow || e is RTFDomTableCell)
                                        {
                                            lastTableElement = e;
                                            break;
                                        }
                                    }
                                }
                                if ( reader.Keyword == RTFConsts._intbl)
                                {
                                    if (lastTableElement == null)
                                    {
                                        // if can not find unlocked row 
                                        // then new row
                                        RTFDomTableRow row = new RTFDomTableRow();
                                        row.NativeLevel = reader.Level;
                                        lastUnlockElement.AppendChild(row);
                                    }
                                }
                                else if ( reader.Keyword == RTFConsts._trowd)
                                {
                                    // clear row format
                                    RTFDomTableRow row = null;
                                    if (lastTableElement == null)
                                    {
                                        row = new RTFDomTableRow();
                                        row.NativeLevel = reader.Level;
                                        lastUnlockElement.AppendChild(row);
                                    }
                                    else
                                    {
                                        row = lastTableElement as RTFDomTableRow;
                                        if (row == null)
                                        {
                                            row = (RTFDomTableRow)lastTableElement.Parent;
                                        }
                                    }
                                    row.Attributes.Clear();
                                    row.CellSettings.Clear();
                                }
                                else if (reader.Keyword == RTFConsts._itap)
                                {
                                    // set nested level
                                    RTFDomTableRow row = null;

                                    if (reader.Parameter == 0)
                                    {
                                        // is the 0 level , belong to document , not to a table
                                        foreach (RTFDomElement element in es)
                                        {
                                            if (element is RTFDomTableRow || element is RTFDomTableCell)
                                            {
                                                element.Locked = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // in a row
                                        if (lastTableElement == null)
                                        {
                                            row = new RTFDomTableRow();
                                            row.NativeLevel = reader.Level;
                                            lastUnlockElement.AppendChild(row);
                                        }
                                        else
                                        {
                                            row = lastTableElement as RTFDomTableRow;
                                            if (row == null)
                                            {
                                                row = (RTFDomTableRow)lastTableElement.Parent;
                                            }
                                            //row.Attributes.Clear();
                                            //row.CellSettings = new ArrayList();
                                        }
                                        if ( reader.Parameter == row.Level)
                                        {
                                        }
                                        else if ( reader.Parameter > row.Level)
                                        {
                                            // nested row
                                            RTFDomTableRow newRow = new RTFDomTableRow();
                                            newRow.Level = reader.Parameter;
                                            RTFDomTableCell parentCell = (RTFDomTableCell)GetLastElement(typeof(RTFDomTableCell), false);
                                            if (parentCell == null)
                                                this.AddContentElement(newRow);
                                            else
                                                parentCell.AppendChild(newRow);
                                        }
                                        else if (reader.Parameter < row.Level)
                                        {
                                            // exit nested row
                                        }
                                    }
                                }//else if
                                break;
                            }
                        case RTFConsts._nesttableprops:
                            {
                                // ignore
                                break;
                            }
                        case RTFConsts._row:
                            {
                                // finish read row
                                RTFDomElement[] es = GetLastElements();
                                for (int iCount = es.Length - 1; iCount >= 0; iCount--)
                                {
                                    es[iCount].Locked = true;
                                    if (es[iCount] is RTFDomTableRow)
                                    {
                                        break;
                                    }
                                }
                                break;
                            }
                        case RTFConsts._nestrow:
                            {
                                // finish nested row
                                RTFDomElement[] es = GetLastElements();
                                for (int iCount = es.Length - 1; iCount >= 0; iCount--)
                                {
                                    es[iCount].Locked = true;
                                    if (es[iCount] is RTFDomTableRow)
                                    {
                                        break;
                                    }
                                }
                                break;
                            }
                        case RTFConsts._trrh:
                        case RTFConsts._trautofit :
                        case RTFConsts._irowband :
                        case RTFConsts._trhdr:
                        case RTFConsts._trkeep:
                        case RTFConsts._trkeepfollow :
                        case RTFConsts._trleft:
                        case RTFConsts._trqc :
                        case RTFConsts._trql :
                        case RTFConsts._trqr :
                        case RTFConsts._trcbpat:
                        case RTFConsts._trcfpat:
                        case RTFConsts._trpat:
                        case RTFConsts._trshdng:
                        case RTFConsts._trwWidth:
                        case RTFConsts._trwWidthA:
                        case RTFConsts._irow:
                        case RTFConsts._trpaddb:
                        case RTFConsts._trpaddl:
                        case RTFConsts._trpaddr:
                        case RTFConsts._trpaddt:
                        case RTFConsts._trpaddfb :
                        case RTFConsts._trpaddfl :
                        case RTFConsts._trpaddfr :
                        case RTFConsts._trpaddft :
                        case RTFConsts._lastrow:
                            {
                                // meet row control word , not parse at first , just save it 
                                RTFDomTableRow row = (RTFDomTableRow)GetLastElement(typeof(RTFDomTableRow), false);
                                if (row != null)
                                {
                                    row.Attributes.Add( reader.Keyword , reader.Parameter );
                                }
                                break;
                            }
                        case RTFConsts._clvmgf:
                        case RTFConsts._clvmrg:
                        case RTFConsts._cellx:
                        case RTFConsts._clvertalt:
                        case RTFConsts._clvertalc:
                        case RTFConsts._clvertalb:
                        case RTFConsts._clNoWrap:
                        case RTFConsts._clcbpat:
                        case RTFConsts._clcfpat:
                        case RTFConsts._clpadl:
                        case RTFConsts._clpadt:
                        case RTFConsts._clpadr:
                        case RTFConsts._clpadb:
                        case RTFConsts._clbrdrl:
                        case RTFConsts._clbrdrt:
                        case RTFConsts._clbrdrr:
                        case RTFConsts._clbrdrb:
                            {
                                // meet cell control word , no parse at first , just save it
                                RTFDomTableRow row = (RTFDomTableRow)GetLastElement(typeof(RTFDomTableRow), false);
                                //if (row != null && row.Locked == false )
                                {
                                    RTFAttributeList style = null;
                                    if (row.CellSettings.Count > 0)
                                    {
                                        style = (RTFAttributeList)row.CellSettings[row.CellSettings.Count - 1];
                                        if (style.Contains(RTFConsts._cellx))
                                        {
                                            // if find repeat control word , then can consider this control word
                                            // belong to the next cell . userly cellx is the last control word of 
                                            // a cell , when meet cellx , the current cell defind is finished.
                                            style = new RTFAttributeList();
                                            row.CellSettings.Add(style);
                                        }
                                    }
                                    if (style == null)
                                    {
                                        style = new RTFAttributeList();
                                        row.CellSettings.Add(style);
                                    }
                                    style.Add(reader.Keyword, reader.Parameter);
                                }
                                break;
                            }
                        case RTFConsts._cell:
                            {
                                // finish cell content
                                this.AddContentElement(null);
                                RTFDomElement[] es = GetLastElements();
                                for (int iCount = es.Length - 1; iCount >= 0; iCount--)
                                {
                                    if (es[iCount].Locked == false)
                                    {
                                        es[iCount].Locked = true;
                                        if (es[iCount] is RTFDomTableCell)
                                        {
                                            ((RTFDomTableCell)es[iCount]).Format = format;
                                            break;
                                        }
                                    }
                                }
                                break;
                            }
                        case RTFConsts._nestcell:
                            {
                                // finish nested cell content
                                AddContentElement(null);
                                RTFDomElement[] es = GetLastElements();
                                for (int iCount = es.Length - 1; iCount >= 0; iCount--)
                                {
                                    es[iCount].Locked = true;
                                    if (es[iCount] is RTFDomTableCell)
                                    {
                                        ((RTFDomTableCell)es[iCount]).Format = format;
                                        break;
                                    }
                                }
                                break;
                            }
                        #endregion
                        default :
                            // unsupport keyword
                            if (reader.TokenType == RTFTokenType.ExtKeyword && reader.FirstTokenInGroup )
                            {
                                // if meet unsupport extern keyword , and this token is the first token in 
                                // current group , then ingore whole group.
                                ReadToEndGround(reader);
                                break ;
                            }
                            break;
                    }//switch
                }
                
            }//while
            if (myText.HasContent)
            {
                ApplyText(myText, reader, format);
            }
        }
         

        /// <summary>
        /// read data , until at the front of the end token belong the current level.
        /// </summary>
        /// <param name="reader"></param>
        private void ReadToEndGround( RTFReader reader )
        {
            reader.ReadToEndGround( );
        }


        /// <summary>
        /// read font table
        /// </summary>
        /// <param name="group"></param>
        private void ReadFontTable(RTFReader reader)
        {
            myFontTable.Clear();
            while (reader.ReadToken() != null)
            {
                if (reader.TokenType == RTFTokenType.GroupEnd)
                {
                    break;
                }
                else if (reader.TokenType == RTFTokenType.GroupStart)
                {
                    int index = -1;
                    string name = null;
                    int charset = 0;
                    while (reader.ReadToken() != null)
                    {
                        if (reader.TokenType == RTFTokenType.GroupEnd)
                        {
                            break;
                        }
                        else if (reader.TokenType == RTFTokenType.GroupStart)
                        {
                            // if meet nested level , then ignore
                            reader.ReadToken();
                            ReadToEndGround(reader);
                            reader.ReadToken();
                        }
                        else if (reader.Keyword == "f" && reader.HasParam)
                        {
                            index = reader.Parameter;
                        }
                        else if (reader.Keyword == RTFConsts._fcharset)
                        {
                            charset = reader.Parameter;
                        }
                        else if (reader.CurrentToken.IsTextToken)
                        {
                            name = ReadInnerText(reader, reader.CurrentToken, false, false);
                            if (name != null)
                            {
                                name = name.Trim();

                                if (name.EndsWith(";"))
                                {
                                    name = name.Substring(0, name.Length - 1);
                                }
                            }
                        }
                    }
                    if (index >= 0 && name != null)
                    {
                        if (name.EndsWith(";"))
                            name = name.Substring(0, name.Length - 1);
                        name = name.Trim();
                        //System.Console.WriteLine( "Index:" + index + "  Name:" + name );
                        RTFFont font = new RTFFont(index, name);
                        font.Charset = charset;
                        myFontTable.Add(font);
                    }
                }//else
            }//while
        }

        /// <summary>
        /// read color table
        /// </summary>
        /// <param name="group"></param>
        private void ReadColorTable(RTFReader reader)
        {
            myColorTable.Clear();
            myColorTable.CheckValueExistWhenAdd = false;
            int r = -1;
            int g = -1;
            int b = -1;
            while (reader.ReadToken() != null)
            {
                if (reader.TokenType == RTFTokenType.GroupEnd)
                {
                    break;
                }
                switch (reader.Keyword)
                {
                    case "red":
                        r = reader.Parameter;
                        break;
                    case "green":
                        g = reader.Parameter;
                        break;
                    case "blue":
                        b = reader.Parameter;
                        break;
                    case ";":
                        if (r >= 0 && g >= 0 && b >= 0)
                        {
                            System.Drawing.Color c = System.Drawing.Color.FromArgb(255, r, g, b);
                            myColorTable.Add(c);
                            r = -1;
                            g = -1;
                            b = -1;
                        }
                        break;
                }
            }
            if (r >= 0 && g >= 0 && b >= 0)
            {
                // read the last color
                System.Drawing.Color c = System.Drawing.Color.FromArgb(255, r, g, b);
                myColorTable.Add(c);
            }
        }

        /// <summary>
        /// read document information
        /// </summary>
        /// <param name="group"></param>
        private void ReadDocumentInfo(RTFReader reader)
        {
            myInfo.Clear();
            int level = 0;
            while (reader.ReadToken() != null)
            {
                if (reader.TokenType == RTFTokenType.GroupStart)
                {
                    level++;
                }
                else if (reader.TokenType == RTFTokenType.GroupEnd)
                {
                    level--;
                    if (level < 0)
                    {
                        break;
                    }
                }
                else
                {
                    switch (reader.Keyword)
                    {
                        case "creatim":
                            myInfo.Creatim = ReadDateTime(reader);
                            level--;
                            break;
                        case "revtim":
                            myInfo.Revtim = ReadDateTime(reader);
                            level--;
                            break;
                        case "printim":
                            myInfo.Printim = ReadDateTime(reader);
                            level--;
                            break;
                        case "buptim":
                            myInfo.Buptim = ReadDateTime(reader);
                            level--;
                            break;
                        default:
                            if (reader.Keyword != null)
                            {
                                if (reader.HasParam)
                                {
                                    myInfo.SetInfo(reader.Keyword, reader.Parameter.ToString());
                                }
                                else
                                {
                                    myInfo.SetInfo(reader.Keyword, ReadInnerText(reader, true));
                                }
                            }
                            break;
                    }
                }
            }//while
        }

        /// <summary>
        /// read datetime
        /// </summary>
        /// <param name="reader">reader</param>
        /// <returns>datetime value</returns>
        private DateTime ReadDateTime(RTFReader reader)
        {
            int yr = 1900;
            int mo = 1;
            int dy = 1;
            int hr = 0;
            int min = 0;
            int sec = 0;
            while (reader.ReadToken() != null)
            {
                if (reader.TokenType == RTFTokenType.GroupEnd)
                {
                    break;
                }
                switch (reader.Keyword)
                {
                    case "yr":
                        yr = reader.Parameter;
                        break;
                    case "mo":
                        mo = reader.Parameter;
                        break;
                    case "dy":
                        dy = reader.Parameter;
                        break;
                    case "hr":
                        hr = reader.Parameter;
                        break;
                    case "min":
                        min = reader.Parameter;
                        break;
                    case "sec":
                        sec = reader.Parameter;
                        break;
                }//switch
            }//while
            return new DateTime(yr, mo, dy, hr, min, sec);
        }

        /// <summary>
        /// read field
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private RTFDomField ReadDomField(RTFReader reader, DocumentFormatInfo format)
        {
            RTFDomField field = new RTFDomField();
            field.NativeLevel = reader.Level;
            AddContentElement(field);
            int levelBack = reader.Level;
            while (reader.ReadToken() != null)
            {
                if (reader.Level < levelBack)
                {
                    break;
                }

                if (reader.TokenType == RTFTokenType.GroupStart)
                {
                }
                else if (reader.TokenType == RTFTokenType.GroupEnd)
                {
                    
                }
                else
                {
                    switch (reader.Keyword)
                    {
                        case RTFConsts._flddirty:
                            {
                                field.Method = RTFDomFieldMethod.Dirty;
                                break;
                            }
                        case RTFConsts._fldedit:
                            {
                                field.Method = RTFDomFieldMethod.Edit;
                                break;
                            }
                        case RTFConsts._fldlock:
                            {
                                field.Method = RTFDomFieldMethod.Lock;
                                break;
                            }
                        case RTFConsts._fldpriv:
                            {
                                field.Method = RTFDomFieldMethod.Priv;
                                break;
                            }
                        case RTFConsts._fldrslt:
                            {
                                RTFDomElementContainer result = new RTFDomElementContainer();
                                result.Name = RTFConsts._fldrslt;
                                field.AppendChild(result);
                                Load(reader, format);
                                result.Locked = true;
                                //field.Result = ReadInnerText(reader, true);
                                break;
                            }
                        case RTFConsts._fldinst:
                            {
                                RTFDomElementContainer inst = new RTFDomElementContainer();
                                inst.Name = RTFConsts._fldinst;
                                field.AppendChild(inst);
                                Load(reader, format);
                                inst.Locked = true;
                                string txt = inst.InnerText;
                                if (txt != null)
                                {
                                    int index = txt.IndexOf(RTFConsts._HYPERLINK);
                                    if (index >= 0)
                                    {
                                        string link = null;
                                        int index1 = txt.IndexOf('\"', index);
                                        if (index1 > 0 && txt.Length > index1 + 2)
                                        {
                                            int index2 = txt.IndexOf('\"', index1 + 2);
                                            if (index2 > index1)
                                            {
                                                link = txt.Substring(index1 + 1, index2 - index1 - 1);
                                                if (format.Parent != null)
                                                {
                                                    if (link.StartsWith("_Toc"))
                                                        link = "#" + link;
                                                    format.Parent.Link = link;
                                                }
                                                break;
                                            }
                                        }//if
                                    }//if
                                }

                                break;
                            }
                    }//switch
                }
            }//while
            field.Locked = true;
            return field;

        }//private RTFDomField ReadDomField(RTFReader reader)


        private string ReadInnerText(RTFReader reader, bool deeply)
        {
            return ReadInnerText(reader, null, deeply, false);
        }

        /// <summary>
        /// read the following plain text in the current level
        /// </summary>
        /// <param name="reader">RTF reader</param>
        /// <param name="deeply">whether read the text in the sub level</param>
        /// <returns>text</returns>
        private string ReadInnerText(
            RTFReader reader,
            RTFToken firstToken,
            bool deeply, 
            bool breakMeetControlWord)
        {
            int level = 0;
            RTFTextContainer container = new RTFTextContainer(this);
            container.Accept(firstToken);
            while (true)
            {
                RTFTokenType type = reader.PeekTokenType();
                if (type == RTFTokenType.Eof)
                    break;
                if (type == RTFTokenType.GroupStart)
                {
                    level++;
                }
                else if (type == RTFTokenType.GroupEnd)
                {
                    level--;
                    if (level < 0)
                    {
                        break;
                    }
                }
                reader.ReadToken();

                if (deeply || level == 0)
                {
                    if (container.Accept(reader.CurrentToken))
                    {
                        continue;
                    }
                    else
                    {
                        if (breakMeetControlWord)
                        {
                            break;
                        }
                    }
                }

            }//while
            return container.Text;
        }

        public override string ToDomString()
        {
            System.Text.StringBuilder builder = new StringBuilder();
            builder.Append(this.ToString());
            builder.Append( Environment.NewLine + "   Info");
            foreach (string item in myInfo.StringItems)
            {
                builder.Append(Environment.NewLine + "      " + item);
            }
            builder.Append( Environment.NewLine + "   ColorTable(" + myColorTable.Count + ")");
            for (int iCount = 0; iCount < myColorTable.Count; iCount ++ )
            {
                System.Drawing.Color c = myColorTable[iCount];
                builder.Append(Environment.NewLine + "      " + iCount + ":" + c.R + " " + c.G + " " + c.B );
            }
            builder.Append(Environment.NewLine + "   FontTable(" + myFontTable.Count + ")");
            foreach (RTFFont font in myFontTable)
            {
                builder.Append(Environment.NewLine + "      " + font.ToString());
            }
            builder.Append(Environment.NewLine + "   -----------------------");
            ToDomString(this.Elements, builder, 1);
            return builder.ToString();
        }
    }
}
