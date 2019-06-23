using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.isv.call.removeuserlist
    /// </summary>
    public class IsvCallRemoveuserlistRequest : BaseDingTalkRequest<IsvCallRemoveuserlistResponse>
    {
        /// <summary>
        /// 要删除的员工userid列表
        /// </summary>
        public string StaffIdList { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.isv.call.removeuserlist";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_TOP;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("staff_id_list", this.StaffIdList);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("staff_id_list", this.StaffIdList);
            RequestValidator.ValidateMaxListSize("staff_id_list", this.StaffIdList, 20);
        }

        #endregion
    }
}
