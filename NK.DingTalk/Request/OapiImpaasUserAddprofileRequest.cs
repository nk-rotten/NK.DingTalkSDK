using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.impaas.user.addprofile
    /// </summary>
    public class OapiImpaasUserAddprofileRequest : BaseDingTalkRequest<OapiImpaasUserAddprofileResponse>
    {
        /// <summary>
        /// 添加的账号信息
        /// </summary>
        public string Request { get; set; }

        public AddProfileReqDomain Request_ { set { this.Request = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.impaas.user.addprofile";
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
            RequestValidator.ValidateRequired("request", this.Request);
        }

	/// <summary>
/// AddProfileReqDomain Data Structure.
/// </summary>
[Serializable]

public class AddProfileReqDomain : TopObject
{
	        /// <summary>
	        /// 头像mediaid
	        /// </summary>
	        [XmlElement("avatar_mediaid")]
	        public string AvatarMediaid { get; set; }
	
	        /// <summary>
	        /// 渠道
	        /// </summary>
	        [XmlElement("channel")]
	        public string Channel { get; set; }
	
	        /// <summary>
	        /// 附加信息
	        /// </summary>
	        [XmlElement("extension")]
	        public string Extension { get; set; }
	
	        /// <summary>
	        /// 账号id
	        /// </summary>
	        [XmlElement("id")]
	        public string Id { get; set; }
	
	        /// <summary>
	        /// 账号nick
	        /// </summary>
	        [XmlElement("nick")]
	        public string Nick { get; set; }
}

        #endregion
    }
}
