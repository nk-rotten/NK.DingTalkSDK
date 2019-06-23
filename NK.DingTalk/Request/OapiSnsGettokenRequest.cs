using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.sns.gettoken
    /// </summary>
    public class OapiSnsGettokenRequest : BaseDingTalkRequest<OapiSnsGettokenResponse>
    {
        /// <summary>
        /// 由钉钉开放平台提供给开放应用的唯一标识
        /// </summary>
        public string Appid { get; set; }

        /// <summary>
        /// 由钉钉开放平台提供的密钥
        /// </summary>
        public string Appsecret { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.sns.gettoken";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("appid", this.Appid);
            parameters.Add("appsecret", this.Appsecret);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
