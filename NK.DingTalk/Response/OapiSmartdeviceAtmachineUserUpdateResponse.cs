using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi;

namespace NK.DingTalk.Response
{
    /// <summary>
    /// OapiSmartdeviceAtmachineUserUpdateResponse.
    /// </summary>
    public class OapiSmartdeviceAtmachineUserUpdateResponse : DingTalkResponse
    {
        /// <summary>
        /// 服务调用结果码
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 服务调用结果码描述
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

    }
}
