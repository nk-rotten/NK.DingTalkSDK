using NK.DingTalk.Base;
using NK.DingTalk.TopApi;
using System;
using System.Xml.Serialization;

namespace NK.DingTalk.Response
{
    /// <summary>
    /// CcoserviceServicegroupAddmemberResponse.
    /// </summary>
    public class CcoserviceServicegroupAddmemberResponse : DingTalkResponse
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
        public AddMembersResponseModelDomain Result { get; set; }

        /// <summary>
        /// AddMembersResponseModelDomain Data Structure.
        /// </summary>
        [Serializable]

        public class AddMembersResponseModelDomain : TopObject
        {
            /// <summary>
            /// dingtalkId
            /// </summary>
            [XmlElement("dingtalk_id")]
            public string DingtalkId { get; set; }
        }

    }
}
