using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi;

namespace NK.DingTalk.Response
{
    /// <summary>
    /// CorpExtListResponse.
    /// </summary>
    public class CorpExtListResponse : DingTalkResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
