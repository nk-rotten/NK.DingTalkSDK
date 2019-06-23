using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.corp.message.corpconversation.getsendresult
    /// </summary>
    public class CorpMessageCorpconversationGetsendresultRequest : BaseDingTalkRequest<CorpMessageCorpconversationGetsendresultResponse>
    {
        /// <summary>
        /// 微应用的agentid
        /// </summary>
        public Nullable<long> AgentId { get; set; }

        /// <summary>
        /// 异步任务的id
        /// </summary>
        public Nullable<long> TaskId { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.corp.message.corpconversation.getsendresult";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_TOP;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("agent_id", this.AgentId);
            parameters.Add("task_id", this.TaskId);
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
