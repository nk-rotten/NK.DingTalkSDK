using NK.DingTalk.Request;
using NK.DingTalk.Response;

namespace NK.DingTalk.Api
{
    public class Health
    {
        /// <summary>
        /// 获取用户钉钉运动开启状态 企业使用此接口可查询用户是否启用了钉钉运动，如果未开启，不会参与企业的钉钉运动排名。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public OapiHealthStepinfoGetuserstatusResponse GetUserStatus(string accessToken,string userId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/health/stepinfo/getuserstatus");
            OapiHealthStepinfoGetuserstatusRequest request = new OapiHealthStepinfoGetuserstatusRequest();
            request.Userid = userId;
            OapiHealthStepinfoGetuserstatusResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取个人或部门的钉钉运动数据 查询企业用户或部门每天的钉钉运动步数，最多可以查询31天的数据。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="starDates">时间列表，注意时间格式是YYYYMMDD</param>
        /// <param name="objectId">可以传入用户userid或者部门id</param>
        /// <param name="type">0表示取用户步数，1表示取部门步数</param>
        /// <returns></returns>
        public OapiHealthStepinfoListResponse List(string accessToken,string starDates,string objectId,long type)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/health/stepinfo/list");
            OapiHealthStepinfoListRequest request = new OapiHealthStepinfoListRequest();
            request.StatDates = starDates;
            request.Type = type;
            request.ObjectId = objectId;
            OapiHealthStepinfoListResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 批量获取钉钉运动数据 在钉钉运动中，每天会对员工运动步数统计和排名，如果企业想更灵活的定制统计规则，比如按月、按部门等维度，可使用此接口。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userIds">员工userid列表，最多传50个</param>
        /// <param name="statDate">时间，注意时间格式是YYMMDD</param>
        /// <returns></returns>
        public OapiHealthStepinfoListbyuseridResponse ListByUserID(string accessToken,string userIds,string statDate)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/health/stepinfo/listbyuserid");
            OapiHealthStepinfoListbyuseridRequest request = new OapiHealthStepinfoListbyuseridRequest();
            request.Userids = userIds;
            request.StatDate = statDate;
            OapiHealthStepinfoListbyuseridResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
