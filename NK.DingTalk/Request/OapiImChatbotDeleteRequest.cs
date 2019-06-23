using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.im.chatbot.delete
    /// </summary>
    public class OapiImChatbotDeleteRequest : BaseDingTalkRequest<OapiImChatbotDeleteResponse>
    {
        /// <summary>
        /// 开放的机器人userId
        /// </summary>
        public string ChatbotUserId { get; set; }

        /// <summary>
        /// 开放的会话conversationId
        /// </summary>
        public string OpenConversationId { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.im.chatbot.delete";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("chatbot_user_id", this.ChatbotUserId);
            parameters.Add("open_conversation_id", this.OpenConversationId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("chatbot_user_id", this.ChatbotUserId);
            RequestValidator.ValidateMaxLength("chatbot_user_id", this.ChatbotUserId, 128);
            RequestValidator.ValidateRequired("open_conversation_id", this.OpenConversationId);
            RequestValidator.ValidateMaxLength("open_conversation_id", this.OpenConversationId, 128);
        }

        #endregion
    }
}
