using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.impaas.user.getlogintoken
    /// </summary>
    public class OapiImpaasUserGetlogintokenRequest : BaseDingTalkRequest<OapiImpaasUserGetlogintokenResponse>
    {
        /// <summary>
        /// 获取免登token请求
        /// </summary>
        public string Request { get; set; }

        public GetLoginTokenReqDomain Request_ { set { this.Request = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.impaas.user.getlogintoken";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("request", this.Request);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

	/// <summary>
/// GetLoginTokenReqDomain Data Structure.
/// </summary>
[Serializable]

public class GetLoginTokenReqDomain : TopObject
{
	        /// <summary>
	        /// 渠道类型
	        /// </summary>
	        [XmlElement("channel")]
	        public string Channel { get; set; }
	
	        /// <summary>
	        /// 二方账号
	        /// </summary>
	        [XmlElement("id")]
	        public string Id { get; set; }
}

        #endregion
    }
}
