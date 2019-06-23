using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.process.workrecord.taskgroup.cancel
    /// </summary>
    public class OapiProcessWorkrecordTaskgroupCancelRequest : BaseDingTalkRequest<OapiProcessWorkrecordTaskgroupCancelResponse>
    {
        /// <summary>
        /// request
        /// </summary>
        public string Request { get; set; }

        public UpdateTaskRequestDomain Request_ { set { this.Request = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.process.workrecord.taskgroup.cancel";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("request", this.Request);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

	/// <summary>
/// UpdateTaskRequestDomain Data Structure.
/// </summary>
[Serializable]

public class UpdateTaskRequestDomain : TopObject
{
	        /// <summary>
	        /// 任务组id
	        /// </summary>
	        [XmlElement("activity_id")]
	        public string ActivityId { get; set; }
	
	        /// <summary>
	        /// 应用id
	        /// </summary>
	        [XmlElement("agentid")]
	        public Nullable<long> Agentid { get; set; }
	
	        /// <summary>
	        /// 实例id
	        /// </summary>
	        [XmlElement("process_instance_id")]
	        public string ProcessInstanceId { get; set; }
}

        #endregion
    }
}
