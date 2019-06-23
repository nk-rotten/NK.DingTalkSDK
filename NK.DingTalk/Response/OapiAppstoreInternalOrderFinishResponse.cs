using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi;

namespace NK.DingTalk.Response
{
    /// <summary>
    /// OapiAppstoreInternalOrderFinishResponse.
    /// </summary>
    public class OapiAppstoreInternalOrderFinishResponse : DingTalkResponse
    {
        /// <summary>
        /// 服务结果码
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 服务结果描述
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

    }
}
