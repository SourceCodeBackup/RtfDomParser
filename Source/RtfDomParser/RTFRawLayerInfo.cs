using System;
using System.Collections.Generic;
using System.Text;

namespace RtfDomParser
{
    public class RTFRawLayerInfo
    {
        private int _UCValue = 0;

        public int UCValue
        {
            get { return _UCValue; }
            set
            {
                _UCValue = value;
                _UCValueCount = 0;
            }
        }

        private int _UCValueCount = 0;

        public int UCValueCount
        {
            get { return _UCValueCount; }
            set { _UCValueCount = value; }
        }
        /// <summary>
        /// 检查UC累计值
        /// </summary>
        /// <returns>检查通过，能添加单字节字符</returns>
        public bool CheckUCValueCount()
        {
            _UCValueCount--;
            return _UCValueCount < 0;
        }
        public RTFRawLayerInfo Clone()
        {
            return (RTFRawLayerInfo)this.MemberwiseClone();
        }
    }
}
