using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi;

namespace NK.DingTalk.Response
{
    /// <summary>
    /// OapiCustomizeConfigSetResponse.
    /// </summary>
    public class OapiCustomizeConfigSetResponse : DingTalkResponse
    {
        /// <summary>
        /// 成功
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 返回成功
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

    }
}
