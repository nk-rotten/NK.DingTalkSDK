using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.hrm.employee.updateresumerecord
    /// </summary>
    public class OapiHrmEmployeeUpdateresumerecordRequest : BaseDingTalkRequest<OapiHrmEmployeeUpdateresumerecordResponse>
    {
        /// <summary>
        /// 成长记录第一条内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 成长记录kv展示内容：json格式，顺序展示
        /// </summary>
        public string KVContent { get; set; }

        /// <summary>
        /// pc端url
        /// </summary>
        public string PcUrl { get; set; }

        /// <summary>
        /// 手机端url
        /// </summary>
        public string PhoneUrl { get; set; }

        /// <summary>
        /// 20180428 零点零分零秒
        /// </summary>
        public Nullable<long> RecordTimestamp { get; set; }

        /// <summary>
        /// 成长记录唯一标识
        /// </summary>
        public string ResumeId { get; set; }

        /// <summary>
        /// 成长记录title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 被操作人员工userid
        /// </summary>
        public string Userid { get; set; }

        /// <summary>
        /// webOA后台url
        /// </summary>
        public string WebUrl { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.hrm.employee.updateresumerecord";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("content", this.Content);
            parameters.Add("k_v_content", this.KVContent);
            parameters.Add("pc_url", this.PcUrl);
            parameters.Add("phone_url", this.PhoneUrl);
            parameters.Add("record_timestamp", this.RecordTimestamp);
            parameters.Add("resume_id", this.ResumeId);
            parameters.Add("title", this.Title);
            parameters.Add("userid", this.Userid);
            parameters.Add("web_url", this.WebUrl);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("resume_id", this.ResumeId);
            RequestValidator.ValidateRequired("userid", this.Userid);
        }

        #endregion
    }
}
