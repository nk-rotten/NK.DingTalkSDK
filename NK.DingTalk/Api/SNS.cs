using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.DingTalk.Api
{
    public class SNS
    {
        /// <summary>
        /// 服务端通过临时授权码获取授权用户的个人信息
        /// </summary>
        /// <param name="tmpAuthCode">用户授权的临时授权码code，只能使用一次；在前面步骤中跳转到redirect_uri时会追加code参数</param>
        /// <param name="appId"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public OapiSnsGetuserinfoBycodeResponse GetUserInfoByCode(string tmpAuthCode,string appId,string secret)
        {
            DefaultDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/sns/getuserinfo_bycode");
            OapiSnsGetuserinfoBycodeRequest req = new OapiSnsGetuserinfoBycodeRequest();
            req.TmpAuthCode = tmpAuthCode;
            OapiSnsGetuserinfoBycodeResponse response = client.Execute(req, appId, secret);
            return response;
        }
    }
}
