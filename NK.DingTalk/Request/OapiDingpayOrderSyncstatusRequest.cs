using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.dingpay.order.syncstatus
    /// </summary>
    public class OapiDingpayOrderSyncstatusRequest : BaseDingTalkRequest<OapiDingpayOrderSyncstatusResponse>
    {
        /// <summary>
        /// 钉支付订单号
        /// </summary>
        public string OrderNos { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.dingpay.order.syncstatus";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("order_nos", this.OrderNos);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("order_nos", this.OrderNos);
            RequestValidator.ValidateMaxListSize("order_nos", this.OrderNos, 20);
        }

        #endregion
    }
}
