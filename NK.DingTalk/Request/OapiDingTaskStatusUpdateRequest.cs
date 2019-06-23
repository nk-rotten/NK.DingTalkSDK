using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.ding.task.status.update
    /// </summary>
    public class OapiDingTaskStatusUpdateRequest : BaseDingTalkRequest<OapiDingTaskStatusUpdateResponse>
    {
        /// <summary>
        /// 操作人id
        /// </summary>
        public string OperatorUserid { get; set; }

        /// <summary>
        /// 任务ID
        /// </summary>
        public string TaskId { get; set; }

        /// <summary>
        /// 任务状态:1-未完成;2-完成
        /// </summary>
        public Nullable<long> TaskStatus { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.ding.task.status.update";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("operator_userid", this.OperatorUserid);
            parameters.Add("task_id", this.TaskId);
            parameters.Add("task_status", this.TaskStatus);
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
