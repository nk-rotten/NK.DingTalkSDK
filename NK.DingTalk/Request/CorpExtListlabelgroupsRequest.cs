using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.corp.ext.listlabelgroups
    /// </summary>
    public class CorpExtListlabelgroupsRequest : BaseDingTalkRequest<CorpExtListlabelgroupsResponse>
    {
        /// <summary>
        /// 偏移位置
        /// </summary>
        public Nullable<long> Offset { get; set; }

        /// <summary>
        /// 分页大小,最大100
        /// </summary>
        public Nullable<long> Size { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.corp.ext.listlabelgroups";
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
