using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.user.get_org_user_count
    /// </summary>
    public class OapiUserGetOrgUserCountRequest : BaseDingTalkRequest<OapiUserGetOrgUserCountResponse>
    {
        /// <summary>
        /// 0：包含未激活钉钉的人员数量 1：不包含未激活钉钉的人员数量
        /// </summary>
        public Nullable<long> OnlyActive { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.user.get_org_user_count";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("onlyActive", this.OnlyActive);
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
