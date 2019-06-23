using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi;

namespace NK.DingTalk.Response
{
    /// <summary>
    /// OapiSnsSyncActivityResponse.
    /// </summary>
    public class OapiSnsSyncActivityResponse : DingTalkResponse
    {
        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

    }
}
