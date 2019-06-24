using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.DingTalk.Api
{
    public static class AccessToken
    {
        public static string AccessTokenKey = "AccessTokenKey";
        public static string GetAccessToken()
        {
            string value = CacheHelper.GetCache<string>(AccessTokenKey);
            if (!string.IsNullOrEmpty(value))
                return value;
            //测试
            //"ding4uxjomils4jwiiap"
            //"7X-k8WA5D3cPdktnbkot_jPxW7FvstBZ4NITsJBI7EdT6c8BgUVBAyI3oAUWfqnV"
            //正式
            //"dingnzjnupiizxh0tbys"
            //"_tnoyOl07vNpPtuEJJVfWulcTcO0mOky7MVFyLjeTmhsIpHyoDXlHqOufnZyK8Up"

            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/gettoken");
            OapiGettokenRequest request = new OapiGettokenRequest
            {
                Appkey = "",// ConfigurationManager.AppSettings["DingTalkAppKey"],
                Appsecret = ""// ConfigurationManager.AppSettings["DingTalkAppSecret"]
            };
            request.SetHttpMethod("Get");
            OapiGettokenResponse response = client.Execute(request);
            value = response.AccessToken;
            CacheHelper.SetCache(AccessTokenKey, value, 7200);
            return value;
        }
    }
}
