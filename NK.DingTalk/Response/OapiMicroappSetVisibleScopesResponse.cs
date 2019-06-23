using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi;

namespace NK.DingTalk.Response
{
    /// <summary>
    /// OapiMicroappSetVisibleScopesResponse.
    /// </summary>
    public class OapiMicroappSetVisibleScopesResponse : DingTalkResponse
    {
        /// <summary>
        /// 对返回码的文本描述内容
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 返回码
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

    }
}
