using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System;
using System.Collections.Generic;

namespace NK.DingTalk.Api
{
    public class Attendance
    {
        /// <summary>
        /// 企业考勤排班详情 在钉钉考勤应用中，设置考勤组规则后，会生成每天的排班信息，包括工作日、周末、节假日等。如果企业想查询某天的排班情况，可使用此接口查询某天的考勤排班全量信息。 注：固定班制只能查到未来15天的排班信息。
        /// </summary>
        /// <param name="assessToken"></param>
        /// <param name="workDate">排班时间，只取年月日部分</param>
        /// <param name="offset">偏移位置，从0开始，后续传offset+size的值。当返回结果中的has_more为false时，表示没有多余的数据了</param>
        /// <param name="size">分页大小，最大200，默认值：200</param>
        public OapiAttendanceListscheduleResponse ListSchedule(string assessToken, DateTime workDate, long offset = 0, long size = 200)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/attendance/listschedule");
            OapiAttendanceListscheduleRequest request = new OapiAttendanceListscheduleRequest();
            request.WorkDate = workDate;
            request.Offset = offset;
            request.Size = size;
            OapiAttendanceListscheduleResponse execute = client.Execute(request, assessToken);
            return execute;
        }

        /// <summary>
        /// 企业考勤组详情 在钉钉考勤应用中，考勤组是一类具有相同的班次、考勤位置等考勤规则的人或部门的组合，企业可根据实际业务设置多个考勤组。如果企业想获取企业的考勤组与企业业务系统对接，可使用此接口查询所有的考勤组详情信息。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="offset">偏移位置，从0、1、2...依次递增，默认值：0</param>
        /// <param name="size">分页大小，最大10，默认值：10</param>
        /// <returns></returns>
        public OapiAttendanceGetsimplegroupsResponse GetSimpleGroup(string accessToken, long offset = 0, long size = 10)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/attendance/getsimplegroups");
            OapiAttendanceGetsimplegroupsRequest request = new OapiAttendanceGetsimplegroupsRequest();
            request.Offset = offset;
            request.Size = size;
            OapiAttendanceGetsimplegroupsResponse execute = client.Execute(request, accessToken);
            return execute;
        }

        /// <summary>
        /// 获取打卡详情 该接口用于返回企业内员工的实际打卡记录。比如，企业给一个员工设定的排班是上午9点和下午6点各打一次卡，但是员工在这期间打了多次，该接口会把所有的打卡记录都返回。 如果只要获取打卡结果数据，不需要详情数据，可使用获取打卡结果接口。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userIds">企业内的员工id列表，最多不能超过50个</param>
        /// <param name="checkDateFrom">查询考勤打卡记录的起始工作日。格式为“yyyy-MM-dd hh:mm:ss”。</param>
        /// <param name="checkDataTo">查询考勤打卡记录的结束工作日。格式为“yyyy-MM-dd hh:mm:ss”。注意，起始与结束工作日最多相隔7天</param>
        /// <param name="isI18n">取值为true和false，表示是否为海外企业使用，默认为false。其中，true：海外平台使用，false：国内平台使用</param>
        /// <returns></returns>
        public OapiAttendanceListRecordResponse ListRecord(string accessToken, List<string> userIds, string checkDateFrom, string checkDataTo, bool isI18n = false)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/attendance/listRecord");
            OapiAttendanceListRecordRequest request = new OapiAttendanceListRecordRequest();
            request.CheckDateFrom = checkDateFrom;
            request.CheckDateTo = checkDataTo;
            request.UserIds = userIds;
            request.IsI18n = isI18n;
            OapiAttendanceListRecordResponse execute = client.Execute(request, accessToken);
            return execute;
        }

        /// <summary>
        /// 获取打卡结果 该接口用于返回企业内员工的实际打卡结果。比如，企业给一个员工设定的排班是上午9点和下午6点各打一次卡，即使员工在这期间打了多次，该接口也只会返回两条记录，包括上午的打卡结果和下午的打卡结果。如果要获取打卡详细数据，比如打卡位置，可使用获取打卡详情接口。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userIdList">员工在企业内的UserID列表，企业用来唯一标识用户的字段。最多不能超过50个</param>
        /// <param name="workDateFrom">查询考勤打卡记录的起始工作日。格式为“yyyy-MM-dd HH:mm:ss”，HH:mm:ss可以使用00:00:00，具体查询的时候不会起作用，最后将返回此日期从0点到24点的结果</param>
        /// <param name="workDateTo">查询考勤打卡记录的结束工作日。格式为“yyyy-MM-dd HH:mm:ss”，HH:mm:ss可以使用00:00:00，具体查询的时候不会起作用，最后将返回此日期从0点到24点的结果。注意，起始与结束工作日最多相隔7天</param>
        /// <param name="offset">表示获取考勤数据的起始点，第一次传0，如果还有多余数据，下次获取传的offset值为之前的offset+limit，0、1、2...依次递增</param>
        /// <param name="limit">表示获取考勤数据的条数，最大不能超过50条</param>
        /// <param name="isI18n">取值为true和false，表示是否为海外企业使用，默认为false。其中，true：海外平台使用，false：国内平台使用</param>
        /// <returns></returns>
        public OapiAttendanceListResponse List(string accessToken, List<string> userIdList, string workDateFrom, string workDateTo, long offset = 0, long limit = 10, bool isI18n = false)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/attendance/list");
            OapiAttendanceListRequest request = new OapiAttendanceListRequest();
            request.WorkDateFrom = workDateFrom;
            request.WorkDateTo = workDateTo;
            request.UserIdList = userIdList;
            request.Offset = offset;
            request.Limit = limit;
            request.IsI18n = isI18n;
            OapiAttendanceListResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取请假时长 该接口可以自动根据排班规则统计出每个员工的请假时长，进而与企业自有的请假／财务系统对接，进行工资统计，如果您的企业使用了钉钉考勤并希望依赖考勤系统自动计算员工请假时长，可选择使用此接口。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="fromDate">请假开始时间</param>
        /// <param name="toDate">请假结束时间</param>
        /// <param name="userId">员工在企业内的UserID，企业用来唯一标识用户的字段</param>
        /// <returns></returns>
        public OapiAttendanceGetleaveapprovedurationResponse GetLeaveApproveDuration(string accessToken, DateTime fromDate, DateTime toDate, string userId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/attendance/getleaveapproveduration");
            OapiAttendanceGetleaveapprovedurationRequest request = new OapiAttendanceGetleaveapprovedurationRequest();
            request.FromDate = DateTime.Now;
            request.ToDate = DateTime.Now;
            request.Userid = "";
            OapiAttendanceGetleaveapprovedurationResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 查询请假状态 该接口用于查询指定企业下的指定用户在指定时间段内的请假状态。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userIdList">待查询用户id列表，支持最多100个用户的批量查询</param>
        /// <param name="startTime">开始时间 ，UNIX时间戳，支持最多180天的查询</param>
        /// <param name="endTime">结束时间 ，UNIX时间戳，支持最多180天的查询时间</param>
        /// <param name="offset">分页偏移，非负整数</param>
        /// <param name="size">分页大小，正整数，最大20</param>
        /// <returns></returns>
        public OapiAttendanceGetleavestatusResponse GetLeaveStatus(string accessToken, string userIdList, long startTime, long endTime, long offset, long size)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/attendance/getleavestatus");
            OapiAttendanceGetleavestatusRequest req = new OapiAttendanceGetleavestatusRequest();
            req.UseridList = userIdList;
            req.StartTime = startTime;
            req.EndTime = endTime;
            req.Offset = offset;
            req.Size = size;
            OapiAttendanceGetleavestatusResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 获取用户考勤组 在钉钉考勤应用中，考勤组是一类具有相同的班次、考勤位置等考勤规则的人或部门的组合，一个企业中的一个人只能属于一个考勤组。如果您的企业使用了钉钉考勤并希望获取员工的考勤组信息，可选择使用此接口。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId">员工在企业内的UserID，企业用来唯一标识用户的字段</param>
        /// <returns></returns>
        public OapiAttendanceGetusergroupResponse GetUserGroup(string accessToken, string userId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/attendance/getusergroup");
            OapiAttendanceGetusergroupRequest request = new OapiAttendanceGetusergroupRequest();
            request.Userid = userId;
            OapiAttendanceGetusergroupResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
