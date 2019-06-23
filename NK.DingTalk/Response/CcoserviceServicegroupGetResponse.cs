using NK.DingTalk.Base;
using NK.DingTalk.TopApi;
using System;
using System.Xml.Serialization;

namespace NK.DingTalk.Response
{
    /// <summary>
    /// CcoserviceServicegroupGetResponse.
    /// </summary>
    public class CcoserviceServicegroupGetResponse : DingTalkResponse
    {
        /// <summary>
        /// dingOpenErrcode
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// errorMsg
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public ServiceConversationModelDomain Result { get; set; }

        /// <summary>
        /// ServiceConversationModelDomain Data Structure.
        /// </summary>
        [Serializable]

        public class ServiceConversationModelDomain : TopObject
        {
            /// <summary>
            /// conversationType
            /// </summary>
            [XmlElement("conversation_type")]
            public long ConversationType { get; set; }

            /// <summary>
            /// ownerDingtalkId
            /// </summary>
            [XmlElement("owner_dingtalk_id")]
            public string OwnerDingtalkId { get; set; }

            /// <summary>
            /// ownerName
            /// </summary>
            [XmlElement("owner_name")]
            public string OwnerName { get; set; }

            /// <summary>
            /// ownerNick
            /// </summary>
            [XmlElement("owner_nick")]
            public string OwnerNick { get; set; }

            /// <summary>
            /// ownerUserid
            /// </summary>
            [XmlElement("owner_userid")]
            public string OwnerUserid { get; set; }

            /// <summary>
            /// title
            /// </summary>
            [XmlElement("title")]
            public string Title { get; set; }

            /// <summary>
            /// type
            /// </summary>
            [XmlElement("type")]
            public long Type { get; set; }
        }

    }
}
