using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.bipaas.menu.publish
    /// </summary>
    public class OapiBipaasMenuPublishRequest : BaseDingTalkRequest<OapiBipaasMenuPublishResponse>
    {
        /// <summary>
        /// 金融云租户ID
        /// </summary>
        public string AntcloudTenantId { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.bipaas.menu.publish";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("antcloud_tenant_id", this.AntcloudTenantId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("antcloud_tenant_id", this.AntcloudTenantId);
        }

        #endregion
    }
}
