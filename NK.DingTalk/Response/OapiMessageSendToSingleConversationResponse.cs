using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi;

namespace NK.DingTalk.Response
{
    /// <summary>
    /// OapiMessageSendToSingleConversationResponse.
    /// </summary>
    public class OapiMessageSendToSingleConversationResponse : DingTalkResponse
    {
        /// <summary>
        /// 错误码 0 表示成功
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 推送消息标识
        /// </summary>
        [XmlElement("msg_id")]
        public string MsgId { get; set; }

    }
}
