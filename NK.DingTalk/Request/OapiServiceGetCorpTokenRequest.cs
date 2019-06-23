using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.service.get_corp_token
    /// </summary>
    public class OapiServiceGetCorpTokenRequest : BaseDingTalkRequest<OapiServiceGetCorpTokenResponse>
    {
        /// <summary>
        /// 授权方corpid
        /// </summary>
        public string AuthCorpid { get; set; }

        /// <summary>
        /// 永久授权码，通过get_permanent_code获取
        /// </summary>
        public string PermanentCode { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.service.get_corp_token";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("auth_corpid", this.AuthCorpid);
            parameters.Add("permanent_code", this.PermanentCode);
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
