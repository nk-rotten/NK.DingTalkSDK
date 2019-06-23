using NK.DingTalk.Request;
using NK.DingTalk.Response;

namespace NK.DingTalk.Api
{
    public class BlackBoard
    {
        /// <summary>
        /// 获取用户公告数据 企业使用此接口可获取指定人员的公告情况，在企业自定义工作首页进行公告轮播展示。列出用户当前有权限看到的10条公告。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public OapiBlackboardListtoptenResponse ListTopten(string accessToken,string userId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/blackboard/listtopten");
            OapiBlackboardListtoptenRequest request = new OapiBlackboardListtoptenRequest();
            request.Userid = userId;
            OapiBlackboardListtoptenResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
