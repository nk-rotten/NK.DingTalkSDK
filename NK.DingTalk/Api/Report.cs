using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NK.DingTalk.Response.OapiReportListResponse;


namespace NK.DingTalk.Api
{
    public class Report
    {
        /// <summary>
        /// 获取用户日志数据
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="userId">员工的userid</param>
        ///<param name="timplateName">要查询的模板名称</param>
        /// <param name="startTime">起始时间。时间的毫秒数</param>
        /// <param name="endTime">截止时间。时间的毫秒数，如：1520956800000</param>
        /// <param name="cursor">查询游标，初始传入0，后续从上一次的返回值中获取</param>
        /// <param name="size">每页数据量, 最大值是20</param>
        /// <returns></returns>
        public OapiReportListResponse ListReport(string accessToken, string timplateName, long startTime, long endTime, long cursor, long size, string userId = null)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/report/list");
            OapiReportListRequest request = new OapiReportListRequest
            {
                Userid = userId,
                StartTime = startTime,
                EndTime = endTime,
                Cursor = cursor,
                Size = size,
                TemplateName = timplateName
            };
            OapiReportListResponse response = client.Execute(request, accessToken);
            return response;
        }


        /// <summary>
        /// 递归获取日志记录 默认取前一天
        /// </summary>
        /// <param name="hasMore">是否还有下一页</param>
        /// <param name="nextCursor">下一游标 初始传入0，后续从上一次的返回值中获取</param>
        /// <param name="pvd"></param>
        /// <returns></returns>
        public PageVoDomain ListReport(string accessToken, bool hasMore, long nextCursor, PageVoDomain pvd)
        {
            if (hasMore)
            {
                if (string.IsNullOrEmpty(accessToken))
                {
                    accessToken = AccessToken.GetAccessToken();
                }
                Report report = new Report();
                OapiReportListResponse res = report.ListReport(accessToken, "QM经理建群日报", DateHelper.GetUnixDate(DateTime.Now.AddDays(-1)), DateHelper.GetUnixDate(DateTime.Now), nextCursor, 20L);
                if (res.Errcode != 0)
                {

                    return pvd;
                }

                if (pvd.DataList == null)
                    pvd.DataList = res.Result.DataList;
                else
                    pvd.DataList.AddRange(res.Result.DataList);
                pvd.NextCursor = res.Result.NextCursor;
                pvd.HasMore = res.Result.HasMore;
                ListReport(accessToken, pvd.HasMore, pvd.NextCursor, pvd);
            }
            return pvd;
        }

        public OapiReportListResponse ListReport(string accessToken, bool hasMore, long nextCursor, OapiReportListResponse reportRes, PageVoDomain pvd)
        {
            if (hasMore)
            {
                if (string.IsNullOrEmpty(accessToken))
                {
                    accessToken = AccessToken.GetAccessToken();
                }
                Report report = new Report();
                reportRes = report.ListReport(accessToken, "QM经理建群日报", DateHelper.GetUnixDate(DateTime.Now.AddDays(-1)), DateHelper.GetUnixDate(DateTime.Now), nextCursor, 20L);

                if (reportRes.Errcode != 0)
                {
                    return reportRes;
                }
                else
                {
                    if (pvd.DataList == null)
                        pvd.DataList = reportRes.Result.DataList;
                    else
                        pvd.DataList.AddRange(reportRes.Result.DataList);
                    reportRes.Result.NextCursor = reportRes.Result.NextCursor;
                    reportRes.Result.HasMore = reportRes.Result.HasMore;
                    reportRes.Result.DataList = pvd.DataList;
                    ListReport(accessToken, reportRes.Result.HasMore, reportRes.Result.NextCursor, reportRes, pvd);
                }
            }
            return reportRes;
        }

        /// <summary>
        /// 获取日志统计数据
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="reportId">日志id</param>
        /// <returns></returns>
        public OapiReportStatisticsResponse Statistics(string accessToken, string reportId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/report/statistics");
            OapiReportStatisticsRequest req = new OapiReportStatisticsRequest
            {
                ReportId = reportId
            };
            OapiReportStatisticsResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 获取日志相关人员列表
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="reportId">日志id</param>
        /// <param name="type">查询类型 0:已读人员列表 1:评论人员列表 2:点赞人员列表</param>
        /// <param name="offSet">分页查询的游标，最开始传0，后续传返回参数中的next_cursor值，默认值为0</param>
        /// <param name="size">分页参数，每页大小，最多传100，默认值为100</param>
        /// <returns></returns>
        public OapiReportStatisticsListbytypeResponse ListByType(string accessToken, string reportId, long type, long offSet = 0, long size = 100)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/report/statistics/listbytype");
            OapiReportStatisticsListbytypeRequest req = new OapiReportStatisticsListbytypeRequest
            {
                ReportId = reportId,
                Type = type,
                Offset = offSet,
                Size = size
            };
            OapiReportStatisticsListbytypeResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 获取日志接收人员列表
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="reportId">日志id</param>
        /// <param name="offSet">分页查询的游标，最开始传0，后续传返回参数中的next_cursor值，默认值为0</param>
        /// <param name="size">分页参数，每页大小，最多传100，默认值为100</param>
        /// <returns></returns>
        public OapiReportReceiverListResponse ListReceiver(string accessToken, string reportId, long offSet = 0, long size = 100)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/report/receiver/list");
            OapiReportReceiverListRequest req = new OapiReportReceiverListRequest()
            {
                ReportId = reportId,
                Offset = offSet,
                Size = size
            };
            OapiReportReceiverListResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 获取日志评论详情
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="reportId">日志id</param>
        /// <param name="offSet">分页查询的游标，最开始传0，后续传返回参数中的next_cursor值，默认值为0</param>
        /// <param name="size">分页参数，每页大小，最多传100，默认值为100</param>
        /// <returns></returns>
        public OapiReportCommentListResponse ListComment(string accessToken, string reportId, long offSet = 0, long size = 100)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/report/comment/list");
            OapiReportCommentListRequest req = new OapiReportCommentListRequest()
            {
                ReportId = reportId,
                Offset = offSet,
                Size = size
            };
            OapiReportCommentListResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 获取用户日志未读数
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public OapiReportGetunreadcountResponse GetUnReadCount(string accessToken, string userId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/report/getunreadcount");
            OapiReportGetunreadcountRequest request = new OapiReportGetunreadcountRequest
            {
                Userid = userId
            };
            OapiReportGetunreadcountResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取用户可见的日志模板
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="offSet">分页游标，从0开始。根据返回结果里的next_cursor是否为空来判断是否还有下一页，且再次调用时offset设置成next_cursor的值</param>
        /// <param name="size">分页大小，最大可设置成100</param>
        /// <param name="userId">用户id</param>
        public void ListTemplateByUserId(string accessToken, long offSet, long size, string userId = "")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/report/template/listbyuserid");
            OapiReportTemplateListbyuseridRequest req = new OapiReportTemplateListbyuseridRequest()
            {
                Userid = userId,
                Offset = offSet,
                Size = size
            };
            OapiReportTemplateListbyuseridResponse rsp = client.Execute(req, accessToken);
        }
    }
}
