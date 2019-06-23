using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.service.reauth_corp
    /// </summary>
    public class OapiServiceReauthCorpRequest : BaseDingTalkRequest<OapiServiceReauthCorpResponse>
    {
        /// <summary>
        /// 套件下的微应用ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 未激活的corpid列表
        /// </summary>
        public List<string> CorpidList { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.service.reauth_corp";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("app_id", this.AppId);
            parameters.Add("corpid_list", TopUtils.ObjectToJson(this.CorpidList));
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateMaxListSize("corpid_list", this.CorpidList, 20);
        }

        #endregion
    }
}
