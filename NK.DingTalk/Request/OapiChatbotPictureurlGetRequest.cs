using System;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.chatbot.pictureurl.get
    /// </summary>
    public class OapiChatbotPictureurlGetRequest : BaseDingTalkRequest<OapiChatbotPictureurlGetResponse>
    {
        /// <summary>
        /// 图片临时下载码
        /// </summary>
        public string DownloadCode { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.chatbot.pictureurl.get";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("download_code", this.DownloadCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("download_code", this.DownloadCode);
            RequestValidator.ValidateMaxLength("download_code", this.DownloadCode, 4000);
        }

        #endregion
    }
}
