using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.im.chat.cid.convert
    /// </summary>
    public class OapiImChatCidConvertRequest : BaseDingTalkRequest<OapiImChatCidConvertResponse>
    {
        /// <summary>
        /// 开放的chatId
        /// </summary>
        public string ChatId { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.im.chat.cid.convert";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("chat_id", this.ChatId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("chat_id", this.ChatId);
            RequestValidator.ValidateMaxLength("chat_id", this.ChatId, 128);
        }

        #endregion
    }
}
