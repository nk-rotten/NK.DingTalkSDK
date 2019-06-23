using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.smartwork.attends.listschedule
    /// </summary>
    public class SmartworkAttendsListscheduleRequest : BaseDingTalkRequest<SmartworkAttendsListscheduleResponse>
    {
        /// <summary>
        /// 偏移位置
        /// </summary>
        public Nullable<long> Offset { get; set; }

        /// <summary>
        /// 分页大小，最大200
        /// </summary>
        public Nullable<long> Size { get; set; }

        /// <summary>
        /// 排班时间，只取年月日部分
        /// </summary>
        public Nullable<DateTime> WorkDate { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.smartwork.attends.listschedule";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_TOP;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("offset", this.Offset);
            parameters.Add("size", this.Size);
            parameters.Add("work_date", this.WorkDate);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("work_date", this.WorkDate);
        }

        #endregion
    }
}
