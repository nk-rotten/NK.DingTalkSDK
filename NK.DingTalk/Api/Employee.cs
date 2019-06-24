using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NK.DingTalk.Request.OapiSmartworkHrmEmployeeAddpreentryRequest;

namespace NK.DingTalk.Api
{
    public class Employee
    {

        /// <summary>
        /// 查询企业在职员工列表 分页查询企业在职员工userid列表。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="statusList">在职员工子状态筛选，其他状态无效。2，试用期；3，正式；5，待离职；-1，无状态</param>
        /// <param name="offset">分页游标，从0开始</param>
        /// <param name="size">分页大小，最大20</param>
        /// <returns></returns>
        public OapiSmartworkHrmEmployeeQueryonjobResponse ListStaffID(string accessToken, string statusList, long offset, long size)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/smartwork/hrm/employee/queryonjob");
            OapiSmartworkHrmEmployeeQueryonjobRequest req = new OapiSmartworkHrmEmployeeQueryonjobRequest();
            req.StatusList = statusList;
            req.Offset = offset;
            req.Size = size;
            OapiSmartworkHrmEmployeeQueryonjobResponse response = client.Execute(req, accessToken);
            return response;
        }

        /// <summary>
        /// 获取公司所有人员 包含试用期和正式员工
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="nextCursor">-1</param>
        /// <param name="reportRes"></param>
        /// <param name="pvd"></param>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public OapiSmartworkHrmEmployeeListResponse ListEmployee(string accessToken, long nextCursor, OapiSmartworkHrmEmployeeQueryonjobResponse reportRes, OapiSmartworkHrmEmployeeQueryonjobResponse.PageResultDomain pvd, OapiSmartworkHrmEmployeeListResponse modelList)
        {
            if (nextCursor != 0)
            {
                if (string.IsNullOrEmpty(accessToken))
                {
                    accessToken = AccessToken.GetAccessToken();
                }
                if (nextCursor == -1)
                {
                    nextCursor = 0;
                }
                reportRes = ListStaffID(AccessToken.GetAccessToken(), "2,3", nextCursor, 20);
                if (reportRes.Errcode != 0)
                    return null;
                else
                {
                    if (modelList.Result == null)
                        modelList.Result = ListStaff(accessToken, string.Join(",", reportRes.Result.DataList.ToArray())).Result;
                    else
                        modelList.Result.AddRange(ListStaff(accessToken, string.Join(",", reportRes.Result.DataList.ToArray())).Result);

                    reportRes.Result.NextCursor = reportRes.Result.NextCursor;
                    reportRes.Result.DataList = pvd.DataList;
                    ListEmployee(accessToken, reportRes.Result.NextCursor, reportRes, pvd, modelList);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获取员工花名册字段信息 根据员工userid，批量访问员工花名册字段信息。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userIdList">员工userid列表，最大列表长度：20</param>
        /// <param name="fieldFilterList">需要获取的花名册字段列表，最大列表长度：20。具体业务字段的code参见附录（大小写敏感）。不传入该参数时，企业可获取所有字段信息。</param>
        public OapiSmartworkHrmEmployeeListResponse ListStaff(string accessToken, string userIdList, string fieldFilterList = "")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/smartwork/hrm/employee/list");
            OapiSmartworkHrmEmployeeListRequest req = new OapiSmartworkHrmEmployeeListRequest();
            req.UseridList = userIdList;
            req.FieldFilterList = fieldFilterList;
            OapiSmartworkHrmEmployeeListResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 查询企业待入职员工列表 分页查询企业待入职员工userid列表。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="offset">分页游标，从0开始</param>
        /// <param name="size">分页大小，最大50</param>
        /// <returns></returns>
        public OapiSmartworkHrmEmployeeQuerypreentryResponse QueryPreentry(string accessToken, long offset, long size)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/smartwork/hrm/employee/querypreentry");
            OapiSmartworkHrmEmployeeQuerypreentryRequest req = new OapiSmartworkHrmEmployeeQuerypreentryRequest();
            req.Offset = offset;
            req.Size = size;
            OapiSmartworkHrmEmployeeQuerypreentryResponse response = client.Execute(req, accessToken);
            return response;
        }

        /// <summary>
        /// 查询企业离职员工列表 分页查询企业离职员工userid列表。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="offset">分页游标，从0开始</param>
        /// <param name="size">分页大小，最大50</param>
        /// <returns></returns>
        public OapiSmartworkHrmEmployeeQuerydimissionResponse QueryDimission(string accessToken, long offset, long size)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/smartwork/hrm/employee/querydimission");
            OapiSmartworkHrmEmployeeQuerydimissionRequest req = new OapiSmartworkHrmEmployeeQuerydimissionRequest();
            req.Offset = offset;
            req.Size = size;
            OapiSmartworkHrmEmployeeQuerydimissionResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 获取离职员工离职信息 根据员工userid列表，批量查询员工的离职信息。传入非离职员工userid，不会返回信息。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userids">员工userid列表，最大长度50</param>
        /// <returns></returns>
        public OapiSmartworkHrmEmployeeListdimissionResponse ListDimission(string accessToken, string userids)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/smartwork/hrm/employee/listdimission");
            OapiSmartworkHrmEmployeeListdimissionRequest req = new OapiSmartworkHrmEmployeeListdimissionRequest();
            req.UseridList = userids;
            OapiSmartworkHrmEmployeeListdimissionResponse response = client.Execute(req, accessToken);
            return response;
        }

        /// <summary>
        /// 添加企业待入职员工 此接口用于添加人员到企业待入职，并不同步员工详细档案信息。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="preEntryTime">预期入职时间</param>
        /// <param name="name">员工姓名</param>
        /// <param name="extendInfo">345</param>
        /// <param name="opUserId">操作人userid</param>
        /// <param name="mobile">手机号</param>
        /// <returns></returns>
        public OapiSmartworkHrmEmployeeAddpreentryResponse AddPreentry(string accessToken, DateTime preEntryTime, string name, string mobile, string extendInfo = "", string opUserId = "")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/smartwork/hrm/employee/addpreentry");
            OapiSmartworkHrmEmployeeAddpreentryRequest req = new OapiSmartworkHrmEmployeeAddpreentryRequest();
            PreEntryEmployeeAddParamDomain param = new PreEntryEmployeeAddParamDomain();
            param.PreEntryTime = preEntryTime;
            param.Name = name;
            param.ExtendInfo = extendInfo;
            param.OpUserid = opUserId;
            param.Mobile = mobile;
            req.Param_ = param;
            OapiSmartworkHrmEmployeeAddpreentryResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

    }
}
