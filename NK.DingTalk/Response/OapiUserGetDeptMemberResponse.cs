using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi;

namespace NK.DingTalk.Response
{
    /// <summary>
    /// OapiUserGetDeptMemberResponse.
    /// </summary>
    public class OapiUserGetDeptMemberResponse : DingTalkResponse
    {
        /// <summary>
        /// errcode
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// errmsg
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// userIds
        /// </summary>
        [XmlArray("userIds")]
        [XmlArrayItem("string")]
        public List<string> UserIds { get; set; }

    }
}
