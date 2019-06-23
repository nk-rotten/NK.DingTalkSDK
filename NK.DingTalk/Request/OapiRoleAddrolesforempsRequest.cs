using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.role.addrolesforemps
    /// </summary>
    public class OapiRoleAddrolesforempsRequest : BaseDingTalkRequest<OapiRoleAddrolesforempsResponse>
    {
        /// <summary>
        /// 角色id list
        /// </summary>
        public string RoleIds { get; set; }

        /// <summary>
        /// 员工id list
        /// </summary>
        public string UserIds { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.role.addrolesforemps";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("roleIds", this.RoleIds);
            parameters.Add("userIds", this.UserIds);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("roleIds", this.RoleIds);
            RequestValidator.ValidateMaxListSize("roleIds", this.RoleIds, 20);
            RequestValidator.ValidateRequired("userIds", this.UserIds);
            RequestValidator.ValidateMaxListSize("userIds", this.UserIds, 20);
        }

        #endregion
    }
}
