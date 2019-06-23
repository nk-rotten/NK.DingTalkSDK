using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi;

namespace NK.DingTalk.Response
{
    /// <summary>
    /// OapiDepartmentListParentDeptsByDeptResponse.
    /// </summary>
    public class OapiDepartmentListParentDeptsByDeptResponse : DingTalkResponse
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
        /// parentIds
        /// </summary>
        [XmlArray("parentIds")]
        [XmlArrayItem("number")]
        public List<long> ParentIds { get; set; }

    }
}
