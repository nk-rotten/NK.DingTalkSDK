using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.smartdevice.visitor.removevisitor
    /// </summary>
    public class OapiSmartdeviceVisitorRemovevisitorRequest : BaseDingTalkRequest<OapiSmartdeviceVisitorRemovevisitorResponse>
    {
        /// <summary>
        /// 预约编号
        /// </summary>
        public string ReservationId { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.smartdevice.visitor.removevisitor";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("reservation_id", this.ReservationId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("reservation_id", this.ReservationId);
        }

        #endregion
    }
}
