using NK.DingTalk.Request;
using NK.DingTalk.Response;

namespace NK.DingTalk.Api
{
    public class Checkin
    {
        /// <summary>
        /// 获取部门用户签到记录 企业使用此接口可获取部门人员的签到记录，进行统计分析，也可以基于高德地图（http://lbs.amap.com/）API接口开发人员分布图和热力图。 注意：目前最多获取1000人以内的签到数据，如果所传部门ID及其子部门下的user超过1000，会报错。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="departmentId">部门id（1 表示根部门）</param>
        /// <param name="startTime">开始时间。Unix时间戳，如：1520956800000</param>
        /// <param name="endTime">结束时间。Unix时间戳，如：1520956800000。开始时间和结束时间的间隔不能大于45天</param>
        /// <param name="offSet">支持分页查询，与size 参数同时设置时才生效，此参数代表偏移量，从0、1、2...依次递增</param>
        /// <param name="order">支持分页查询，与offset 参数同时设置时才生效，此参数代表分页大小，最大100</param>
        /// <param name="size">排序 asc 为正序 desc 为倒序</param>
        /// <returns></returns>
        public OapiCheckinRecordResponse Record(string accessToken, string departmentId, long startTime, long endTime, long offSet = 0, string order = "ase", long size = 0)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/checkin/record");
            OapiCheckinRecordRequest request = new OapiCheckinRecordRequest();
            request.DepartmentId = departmentId;
            request.StartTime = startTime;
            request.EndTime = endTime;
            request.Offset = offSet;
            request.Order = order;
            request.Size = size;
            request.SetHttpMethod("GET");
            OapiCheckinRecordResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取用户签到记录 企业使用此接口可获取指定人员的签到记录，进行统计分析，也可以基于高德地图（http://lbs.amap.com）API接口开发人员分布图和热力图。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="startTime">起始时间。Unix时间戳，如：1520956800000</param>
        /// <param name="endTime">结束时间。Unix时间戳，如：1520956800000。如果是取1个人的数据，时间范围最大到10天，如果是取多个人的数据，时间范围最大1天。</param>
        /// <param name="userIdList">需要查询的用户列表，最大列表长度：10</param>
        /// <param name="size">分页查询的游标，最开始可以传0，然后以1、2依次递增</param>
        /// <param name="cursor">分页查询的每页大小，最大100</param>
        /// <returns></returns>
        public OapiCheckinRecordGetResponse GetRecord(string accessToken,long startTime,long endTime,string userIdList,long size,long cursor)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/checkin/record/get");
            OapiCheckinRecordGetRequest request = new OapiCheckinRecordGetRequest();
            request.StartTime = startTime;
            request.EndTime = endTime;
            request.Size = size;
            request.Cursor = cursor;
            request.UseridList = userIdList;
            OapiCheckinRecordGetResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
