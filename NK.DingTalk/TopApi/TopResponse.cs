﻿using System;
using NK.DingTalk.Base;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NK.DingTalk.TopApi
{
    [Serializable]
    public abstract class TopResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("msg")]
        public string ErrMsg { get; set; }

        /// <summary>
        /// 子错误码
        /// </summary>
        [XmlElement("sub_code")]
        public string SubErrCode { get; set; }

        /// <summary>
        /// 子错误信息
        /// </summary>
        [XmlElement("sub_msg")]
        public string SubErrMsg { get; set; }

        /// <summary>
        /// 响应原始内容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 响应结果是否错误
        /// </summary>
        public bool IsError
        {
            get
            {
                return !string.IsNullOrEmpty(this.ErrCode) || !string.IsNullOrEmpty(this.SubErrCode);
            }
        }
    }
}
