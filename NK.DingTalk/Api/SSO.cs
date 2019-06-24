using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.DingTalk.Api
{
    public class SSO
    {
        /// <summary>
        /// 获取应用后台免登的accessToken 本接口获取的accessToken只在微应用后台管理免登服务中使用。
        /// </summary>
        /// <param name="corpId">企业Id</param>
        /// <param name="corpSecret">这里必须填写专属的SSOSecret</param>
        public OapiSsoGettokenResponse GetToken(string corpId,string corpSecret)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/sso/gettoken");
            OapiSsoGettokenRequest request = new OapiSsoGettokenRequest();
            request.Corpid = corpId;
            request.Corpsecret = corpSecret;
            request.SetHttpMethod("GET");
            OapiSsoGettokenResponse response = client.Execute(request);
            return response;
        }

        /// <summary>
        /// 获取应用管理员的身份信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public OapiSsoGetuserinfoResponse GetUserInfo(string accessToken,string code)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/sso/getuserinfo");
            OapiSsoGetuserinfoRequest request = new OapiSsoGetuserinfoRequest();
            request.Code = code;
            request.SetHttpMethod("GET");
            OapiSsoGetuserinfoResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
