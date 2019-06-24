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
    public class Process
    {
        /// <summary>
        /// 发起审批实例
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="agentId">企业应用标识(ISV调用必须设置)</param>
        /// <param name="processCode">审批流的唯一码，process_code就在审批流编辑的页面URL中</param>
        /// <param name="approvers">审批人userid列表，最大列表长度：20。多个审批人用逗号分隔，按传入的顺序依次审批</param>
        /// <param name="originatorUserID">审批实例发起人的userid</param>
        /// <param name="deptId">发起人所在的部门，如果发起人属于根部门，传-1</param>
        /// <param name="ccList">抄送人userid列表，最大列表长度：20。多个抄送人用逗号分隔</param>
        /// <param name="ccPosition">抄送时间，分为（START, FINISH, START_FINISH）</param>
        /// <param name="name">表单每一栏的名称</param>
        /// <param name="value">表单每一栏的值</param>
        /// <returns></returns>
        public OapiProcessinstanceCreateResponse Create(string accessToken, string processCode, string originatorUserID, long deptId, string name, string value, long? agentId = 0, string approvers = "", string ccList = "", string ccPosition = "")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/processinstance/create");
            OapiProcessinstanceCreateRequest request = new OapiProcessinstanceCreateRequest
            {
                AgentId = 0,
                ProcessCode = processCode,
                Approvers = approvers,
                OriginatorUserId = originatorUserID,
                DeptId = deptId,
                CcList = ccList,
                CcPosition = ccPosition
            };
            List<FormComponentValueVoDomain> formComponentValues = new List<FormComponentValueVoDomain>();
            FormComponentValueVoDomain vo = new FormComponentValueVoDomain
            {
                Name = name,
                Value = value
            };
            formComponentValues.Add(vo);
            request.FormComponentValues_ = formComponentValues;
            OapiProcessinstanceCreateResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 批量获取审批实例id
        /// </summary>
        /// <param name="processCode">流程模板唯一标识，可在OA管理后台编辑审批表单部分查询</param>
        /// <param name="startTime">开始时间。Unix时间戳</param>
        /// <param name="endTime">结束时间，默认取当前时间。Unix时间戳</param>
        /// <param name="size">分页参数，每页大小，最多传10，默认值：10</param>
        /// <param name="cursor">分页查询的游标，最开始传0，后续传返回参数中的next_cursor值，默认值：0</param>
        /// <param name="userIdList">发起人用户id列表，用逗号分隔，最大列表长度：10</param>
        /// <param name="accessToken">accesstoken</param>
        /// <returns></returns>
        public OapiProcessinstanceListidsResponse ListIds(string processCode, long startTime, long endTime, string accessToken, long? size = 10, long cursor = 0, string userIdList = "")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/processinstance/listids");
            OapiProcessinstanceListidsRequest req = new OapiProcessinstanceListidsRequest
            {
                ProcessCode = processCode,
                StartTime = startTime,
                EndTime = endTime,
                Size = size,
                Cursor = cursor,
                UseridList = userIdList
            };
            OapiProcessinstanceListidsResponse response = client.Execute(req, accessToken);
            return response;
        }

        /// <summary>
        /// 获取单个审批实例
        /// </summary>
        /// <param name="id">审批实例id</param>
        /// <param name="accessToken">accesstoken</param>
        /// <returns></returns>
        public OapiProcessinstanceGetResponse Get(string id, string accessToken)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/processinstance/get");
            OapiProcessinstanceGetRequest request = new OapiProcessinstanceGetRequest
            {
                ProcessInstanceId = id
            };
            OapiProcessinstanceGetResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取用户待审批数量
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="accessToken">accesstoken</param>
        /// <returns></returns>
        public OapiProcessGettodonumResponse GetTodoNum(string id, string accessToken)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/process/gettodonum");
            OapiProcessGettodonumRequest req = new OapiProcessGettodonumRequest
            {
                Userid = id
            };
            OapiProcessGettodonumResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 获取用户可见的审批模板
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="offSet">分页游标，从0开始。根据返回结果里的next_cursor是否为空来判断是否还有下一页，且再次调用时offset设置成next_cursor的值</param>
        /// <param name="size">分页大小，最大可设置成100</param>
        /// <returns></returns>
        public OapiProcessListbyuseridResponse ListByUserId(string accessToken, long offSet, long size, string id = "")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/process/listbyuserid");
            OapiProcessListbyuseridRequest request = new OapiProcessListbyuseridRequest
            {
                Userid = id,
                Offset = offSet,
                Size = size
            };
            OapiProcessListbyuseridResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
