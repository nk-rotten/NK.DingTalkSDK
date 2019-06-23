using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System.Collections.Generic;

namespace NK.DingTalk.Api
{
    public class MicroApp
    {
        /// <summary>
        /// 获取应用列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public OapiMicroappListResponse List(string accessToken)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/microapp/list");
            OapiMicroappListRequest req = new OapiMicroappListRequest();
            OapiMicroappListResponse response = client.Execute(req, accessToken);
            return response;
        }

        /// <summary>
        /// 获取员工可见的应用列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public OapiMicroappListByUseridResponse ListByUserId(string accessToken, string userId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/microapp/list_by_userid");
            OapiMicroappListByUseridRequest req = new OapiMicroappListByUseridRequest();
            req.Userid = userId;
            req.SetHttpMethod("GET");
            OapiMicroappListByUseridResponse response = client.Execute(req, accessToken);
            return response;
        }

        /// <summary>
        /// 获取应用的可见范围
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId">需要查询的应用实例化agentId</param>
        /// <returns></returns>
        public OapiMicroappVisibleScopesResponse VisibleScopes(string accessToken, long agentId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/microapp/visible_scopes");
            OapiMicroappVisibleScopesRequest req = new OapiMicroappVisibleScopesRequest();
            req.AgentId = agentId;
            OapiMicroappVisibleScopesResponse response = client.Execute(req, accessToken);
            return response;
        }

        /// <summary>
        /// 设置应用的可见范围
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId">应用实例化id</param>
        /// <param name="deptVisibleScopes">设置可见的部门id列表，格式为JSON数组</param>
        /// <param name="userVisibleScopes">设置可见的员工id列表，格式为JSON数组</param>
        /// <param name="isHidden">是否仅限管理员可见，true代表仅限管理员可见</param>
        /// <returns></returns>
        public OapiMicroappSetVisibleScopesResponse SetVisibleScopes(string accessToken, long agentId, List<long> deptVisibleScopes, List<string> userVisibleScopes, bool isHidden = false)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/microapp/set_visible_scopes");
            OapiMicroappSetVisibleScopesRequest req = new OapiMicroappSetVisibleScopesRequest();
            req.AgentId = agentId;
            req.DeptVisibleScopes = deptVisibleScopes;
            req.UserVisibleScopes = userVisibleScopes;
            req.IsHidden = isHidden;
            OapiMicroappSetVisibleScopesResponse response = client.Execute(req, accessToken);
            return response;
        }




    }
}
