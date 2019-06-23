using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.ccoservice.entrance.sendnotify
    /// </summary>
    public class OapiCcoserviceEntranceSendnotifyRequest : BaseDingTalkRequest<OapiCcoserviceEntranceSendnotifyResponse>
    {
        /// <summary>
        /// 微应用ID
        /// </summary>
        public Nullable<long> AppId { get; set; }

        /// <summary>
        /// 文本的通知
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 员工ID
        /// </summary>
        public string Userid { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.ccoservice.entrance.sendnotify";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("app_id", this.AppId);
            parameters.Add("content", this.Content);
            parameters.Add("userid", this.Userid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("app_id", this.AppId);
            RequestValidator.ValidateRequired("content", this.Content);
            RequestValidator.ValidateRequired("userid", this.Userid);
        }

        #endregion
    }
}
