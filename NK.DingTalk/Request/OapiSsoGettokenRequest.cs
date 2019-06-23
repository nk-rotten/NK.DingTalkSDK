using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.sso.gettoken
    /// </summary>
    public class OapiSsoGettokenRequest : BaseDingTalkRequest<OapiSsoGettokenResponse>
    {
        /// <summary>
        /// 企业Id
        /// </summary>
        public string Corpid { get; set; }

        /// <summary>
        /// 这里必须填写专属的SSOSecret
        /// </summary>
        public string Corpsecret { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.sso.gettoken";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("corpid", this.Corpid);
            parameters.Add("corpsecret", this.Corpsecret);
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
