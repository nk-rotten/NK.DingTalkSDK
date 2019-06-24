using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NK.DingTalk.Request;
using NK.DingTalk.Response;

namespace NK.DingTalk.Api
{
    public class Auth
    {
        /// <summary>
        /// 通讯录权限范围
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public OapiAuthScopesResponse Scopes(string accessToken)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/auth/scopes");
            OapiAuthScopesRequest request = new OapiAuthScopesRequest();
            request.SetHttpMethod("GET");
            OapiAuthScopesResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
