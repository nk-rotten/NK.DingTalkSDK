using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NK.DingTalk.Request;
using NK.DingTalk.Response;
using static NK.DingTalk.Request.OapiMessageCorpconversationAsyncsendV2Request;

namespace NK.DingTalk.Api
{
    public class Message
    {
        /// <summary>
        /// 发送工作通知消息 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="msg">消息内容，消息类型和样例参考“消息类型与数据格式”。最长不超过2048个字节</param>
        /// <param name="agentId">应用agentId</param>
        /// <param name="deptIds">接收者的部门id列表，最大列表长度：20,  接收者是部门id下(包括子部门下)的所有用户</param>
        /// <param name="userIds">接收者的用户userid列表，最大列表长度：100</param>
        /// <param name="toAllUser">是否发送给企业全部用户</param>
        /// <returns></returns>
        public OapiMessageCorpconversationAsyncsendV2Response Send(string accessToken, MsgDomain msg, long agentId, string deptIds = "", string userIds = "", bool toAllUser = false)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/message/corpconversation/asyncsend_v2");

            OapiMessageCorpconversationAsyncsendV2Request request = new OapiMessageCorpconversationAsyncsendV2Request();
            request.UseridList = userIds;
            request.AgentId = agentId;
            request.ToAllUser = toAllUser;
            request.DeptIdList = deptIds;
            request.Msg_ = msg;

            OapiMessageCorpconversationAsyncsendV2Response response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 查询工作通知消息的发送结果
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId">微应用的agentid</param>
        /// <param name="taskId">异步任务的id</param>
        /// <returns></returns>
        public OapiMessageCorpconversationGetsendresultResponse GetSendResult(string accessToken, long agentId = 0, long taskId = 0)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/message/corpconversation/getsendresult");
            OapiMessageCorpconversationGetsendresultRequest request = new OapiMessageCorpconversationGetsendresultRequest();
            request.AgentId = agentId;
            request.TaskId = taskId;
            OapiMessageCorpconversationGetsendresultResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 工作通知消息撤回
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId">微应用的agentid</param>
        /// <param name="taskId">异步任务的id</param>
        /// <returns></returns>
        public OapiMessageCorpconversationRecallResponse Recall(string accessToken, long agentId = 0, long taskId = 0)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/message/corpconversation/recall");
            OapiMessageCorpconversationRecallRequest request = new OapiMessageCorpconversationRecallRequest();
            request.AgentId = agentId;
            request.MsgTaskId = taskId;
            OapiMessageCorpconversationRecallResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 发送普通消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sender">消息发送者 userId</param>
        /// <param name="cId">群会话或者个人会话的id，通过JSAPI的dd.chooseChatForNormalMsg接口唤起联系人界面选择之后即可拿到会话cid</param>
        /// <param name="msg">消息内容，消息类型和样例可参考“消息类型与数据格式”文档。最长不超过2048个字节</param>
        /// <returns></returns>
        public OapiMessageSendToConversationResponse SendToConversation(string accessToken, string sender, string cId, OapiMessageSendToConversationRequest.MsgDomain msg)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/message/send_to_conversation");

            OapiMessageSendToConversationRequest req = new OapiMessageSendToConversationRequest();
            req.Sender = sender;
            req.Cid = cId;
            req.Msg_ = msg;

            OapiMessageSendToConversationResponse response = client.Execute(req, accessToken);
            return response;
        }
    }
}
