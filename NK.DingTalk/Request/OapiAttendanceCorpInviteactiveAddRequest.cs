using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.attendance.corp.inviteactive.add
    /// </summary>
    public class OapiAttendanceCorpInviteactiveAddRequest : BaseDingTalkRequest<OapiAttendanceCorpInviteactiveAddResponse>
    {
        /// <summary>
        /// 管理员的手机号
        /// </summary>
        public string AdminMobile { get; set; }

        /// <summary>
        /// 被邀请员工的手机号
        /// </summary>
        public string InvitedMobile { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.attendance.corp.inviteactive.add";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("admin_mobile", this.AdminMobile);
            parameters.Add("invited_mobile", this.InvitedMobile);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("admin_mobile", this.AdminMobile);
            RequestValidator.ValidateRequired("invited_mobile", this.InvitedMobile);
        }

        #endregion
    }
}
