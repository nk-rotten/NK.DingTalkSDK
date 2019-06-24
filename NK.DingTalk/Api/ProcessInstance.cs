using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NK.DingTalk.Request.OapiProcessinstanceCreateRequest;

namespace NK.DingTalk.Api
{
    public class ProcessInstance
    {
        /// <summary>
        /// 发起审批实例 https://open-doc.dingtalk.com/microapp/serverapi2/cmct1a
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="processCode">审批流的唯一码，process_code就在审批流编辑的页面URL中</param>
        /// <param name="list">审批流表单</param>
        /// <param name="originatorUserId">审批实例发起人的userid</param>
        /// <param name="deptId">发起人所在的部门，如果发起人属于根部门，传-1</param>
        /// <param name="agentId">企业应用标识(ISV调用必须设置)</param>
        /// <param name="approvers">审批人userid列表，最大列表长度：20。多个审批人用逗号分隔，按传入的顺序依次审批</param>
        /// <param name="cCPosition">抄送时间，分为（START, FINISH, START_FINISH）</param>
        /// <param name="cCList">抄送人userid列表，最大列表长度：20。多个抄送人用逗号分隔。该参数需要与cc_position参数一起传，抄送人才能生效</param>
        /// <returns></returns>
        public OapiProcessinstanceCreateResponse Create(string accessToken, string processCode, List<FormComponentValueVoDomain> list, string originatorUserId, long deptId, long agentId = 0, string approvers = "", string cCPosition = "", string cCList = "")
        {
            DefaultDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/processinstance/create");
            OapiProcessinstanceCreateRequest request = new OapiProcessinstanceCreateRequest();
            request.AgentId = agentId;
            request.ProcessCode = processCode;
            request.FormComponentValues_ = list;
            request.Approvers = approvers;
            request.OriginatorUserId = originatorUserId;
            request.DeptId = deptId;
            request.CcList = cCList;
            request.CcPosition = cCPosition;
            OapiProcessinstanceCreateResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 批量获取审批实例id 企业使用此接口可获取某个审批的实例id列表。企业可以再根据审批实例id，调用获取审批实例详情接口，获取实例详情信息。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="processCode">流程模板唯一标识，可在OA管理后台编辑审批表单部分查询</param>
        /// <param name="startTime">开始时间。Unix时间戳</param>
        /// <param name="endTime">结束时间，默认取当前时间。Unix时间戳</param>
        /// <param name="size">分页参数，每页大小，最多传20，默认值：20</param>
        /// <param name="cursor">分页查询的游标，最开始传0，后续传返回参数中的next_cursor值，默认值：0</param>
        /// <param name="userIds">发起人用户id列表，用逗号分隔，最大列表长度：20</param>
        /// <returns></returns>
        public OapiProcessinstanceListidsResponse ListIds(string accessToken, string processCode, long startTime, long endTime, long size = 20, long cursor = 0, string userIds = "")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/processinstance/listids");
            OapiProcessinstanceListidsRequest req = new OapiProcessinstanceListidsRequest();
            req.ProcessCode = processCode;
            req.StartTime = startTime;
            req.EndTime = endTime;
            req.Size = size;
            req.Cursor = cursor;
            req.UseridList = userIds;
            OapiProcessinstanceListidsResponse response = client.Execute(req, accessToken);
            return response;
        }

        /// <summary>
        /// 获取审批实例详情 根据审批实例id调用此接口获取审批实例详情，包括审批表单信息、操作记录列表、操作人、抄送人、审批任务列表等。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="processInstanceId">审批实例id</param>
        /// <returns></returns>
        public OapiProcessinstanceGetResponse Get(string accessToken, string processInstanceId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/processinstance/get");
            OapiProcessinstanceGetRequest request = new OapiProcessinstanceGetRequest();
            request.ProcessInstanceId = processInstanceId;
            OapiProcessinstanceGetResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取用户待审批数量 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public OapiProcessGettodonumResponse GetTodonum(string accessToken, string userId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/process/gettodonum");
            OapiProcessGettodonumRequest req = new OapiProcessGettodonumRequest();
            req.Userid = userId;
            OapiProcessGettodonumResponse response = client.Execute(req, accessToken);
            return response;
        }

        /// <summary>
        /// 获取用户可见的审批模板 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId">用户id</param>
        /// <param name="offset">分页游标，从0开始。根据返回结果里的next_cursor是否为空来判断是否还有下一页，且再次调用时offset设置成next_cursor的值</param>
        /// <param name="size">分页大小，最大可设置成100</param>
        /// <returns></returns>
        public OapiProcessListbyuseridResponse ListByUserId(string accessToken, string userId, long offset, long size)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/process/listbyuserid");
            OapiProcessListbyuseridRequest request = new OapiProcessListbyuseridRequest();
            request.Userid = userId;
            request.Offset = offset;
            request.Size = size;
            OapiProcessListbyuseridResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
