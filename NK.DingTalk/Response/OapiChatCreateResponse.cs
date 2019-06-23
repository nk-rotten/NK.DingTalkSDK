using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi;

namespace NK.DingTalk.Response
{
    /// <summary>
    /// OapiChatCreateResponse.
    /// </summary>
    public class OapiChatCreateResponse : DingTalkResponse
    {
        /// <summary>
        /// chatid
        /// </summary>
        [XmlElement("chatid")]
        public string Chatid { get; set; }

        /// <summary>
        /// conversationTag
        /// </summary>
        [XmlElement("conversationTag")]
        public long ConversationTag { get; set; }

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
        /// openConversationId
        /// </summary>
        [XmlElement("openConversationId")]
        public string OpenConversationId { get; set; }

    }
}
