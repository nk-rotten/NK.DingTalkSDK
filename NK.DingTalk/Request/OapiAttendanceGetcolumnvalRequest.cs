using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.attendance.getcolumnval
    /// </summary>
    public class OapiAttendanceGetcolumnvalRequest : BaseDingTalkRequest<OapiAttendanceGetcolumnvalResponse>
    {
        /// <summary>
        /// 列id
        /// </summary>
        public string ColumnIdList { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public Nullable<DateTime> FromDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public Nullable<DateTime> ToDate { get; set; }

        /// <summary>
        /// 用户的userId
        /// </summary>
        public string Userid { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.attendance.getcolumnval";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("column_id_list", this.ColumnIdList);
            parameters.Add("from_date", this.FromDate);
            parameters.Add("to_date", this.ToDate);
            parameters.Add("userid", this.Userid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateMaxListSize("column_id_list", this.ColumnIdList, 20);
        }

        #endregion
    }
}
