using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NK.DingTalk.Request.OapiChatSendRequest;

namespace NK.DingTalk.Api
{
    public class Chat
    {
        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="chatId">群会话的id，可以在调用创建群会话接口的返回结果里面获取，也可以通过dd.chooseChat获取</param>
        /// <param name="msg">消息内容，消息类型和样例可参考“消息类型与数据格式”文档 https://open-doc.dingtalk.com/microapp/serverapi2/ye8tup</param>
        /// <returns></returns>
        public OapiChatSendResponse Send(string accessToken, string chatId, MsgDomain msg)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/chat/send");
            OapiChatSendRequest request = new OapiChatSendRequest();
            request.Chatid = chatId;
            request.Msg_ = msg;
            OapiChatSendResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 查询群消息已读人员列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="messageId">发送群消息接口返回的加密消息id</param>
        /// <param name="cursor">分页查询的游标，第一次可以传0，后续传返回结果中的next_cursor的值。当返回结果中，没有next_cursor时，表示没有后续的数据了，可以结束调用</param>
        /// <param name="size">分页查询的大小，最大可以传100</param>
        /// <returns></returns>
        public OapiChatGetReadListResponse GetReadList(string accessToken, string messageId, long cursor, long size)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/chat/getReadList");
            OapiChatGetReadListRequest request = new OapiChatGetReadListRequest();
            request.SetHttpMethod("GET");
            request.MessageId = messageId;
            request.Cursor = cursor;
            request.Size = size;
            OapiChatGetReadListResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 创建会话
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="name">群名称，长度限制为1~20个字符</param>
        /// <param name="owner">群主userId，员工唯一标识ID；必须为该会话useridlist的成员之一</param>
        /// <param name="userIds">群成员列表，每次最多支持40人，群人数上限为1000</param>
        /// <param name="showHistory">新成员是否可查看聊天历史消息（新成员入群是否可查看最近100条聊天记录）， 0代表否， 1代表是， 不传默认为否</param>
        /// <param name="searchable">群可搜索，0-默认，不可搜索，1-可搜索</param>
        /// <param name="validationType">入群验证，0：不入群验证（默认） 1：入群验证</param>
        /// <param name="mentionAllAuthority">@all 权限，0-默认，所有人，1-仅群主可@all</param>
        /// <param name="chatBannedType">群禁言，0-默认，不禁言，1-全员禁言</param>
        /// <param name="managementType">管理类型，0-默认，所有人可管理，1-仅群主可管理</param>
        /// <returns></returns>
        public OapiChatCreateResponse Create(string accessToken, string name, string owner, List<string> userIds, long showHistory = 0, long searchable = 0, long validationType = 0, long mentionAllAuthority = 0, long chatBannedType = 0, long managementType = 0)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/chat/create");
            OapiChatCreateRequest request = new OapiChatCreateRequest();
            request.Name = name;
            request.Owner = owner;
            request.Useridlist = userIds;
            request.ShowHistoryType = showHistory;
            request.Searchable = searchable;
            request.ValidationType = validationType;
            request.MentionAllAuthority = mentionAllAuthority;
            request.ChatBannedType = chatBannedType;
            request.ManagementType = managementType;
            OapiChatCreateResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 修改会话
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="chatId">群会话的id</param>
        /// <param name="name">群名称。长度限制为1~20个字符，不传则不修改</param>
        /// <param name="owner">群主userId，员工唯一标识ID；必须为该会话成员之一；不传则不修改</param>
        /// <param name="icon">群头像mediaid</param>
        /// <param name="addUserIds">添加成员列表，每次最多支持40人，群人数上限为1000</param>
        /// <param name="delUserIds">删除成员列表，每次最多支持40人，群人数上限为1000</param>
        /// <param name="showHistory">新成员可查看聊天历史 0否 1是</param>
        /// <param name="searchable">群可搜索，0-默认，不可搜索，1-可搜索</param>
        /// <param name="validationType">入群验证，0：不入群验证（默认） 1：入群验证</param>
        /// <param name="mentionAllAuthority">@all 权限，0-默认，所有人，1-仅群主可@all</param>
        /// <param name="chatBannedType">群禁言，0-默认，不禁言，1-全员禁言</param>
        /// <param name="managementType">管理类型，0-默认，所有人可管理，1-仅群主可管理</param>
        /// <returns></returns>
        public OapiChatUpdateResponse Update(string accessToken, string chatId, string name, string owner, string icon = "", List<string> addUserIds = null, List<string> delUserIds = null, long showHistory = 0, long searchable = 0, long validationType = 0, long mentionAllAuthority = 0, long chatBannedType = 0, long managementType = 0)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/chat/update");
            OapiChatUpdateRequest request = new OapiChatUpdateRequest();
            request.Chatid = chatId;
            request.Name = name;
            request.Owner = owner;
            request.Icon = icon;
            request.AddUseridlist = addUserIds;
            request.DelUseridlist = delUserIds;
            request.ShowHistoryType = showHistory;
            request.Searchable = searchable;
            request.ValidationType = validationType;
            request.MentionAllAuthority = mentionAllAuthority;
            request.ChatBannedType = chatBannedType;
            request.ManagementType = managementType;
            OapiChatUpdateResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取会话
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="chatId">群会话的id</param>
        /// <returns></returns>
        public OapiChatGetResponse Get(string accessToken, string chatId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/chat/get");
            OapiChatGetRequest request = new OapiChatGetRequest();
            request.SetHttpMethod("GET");
            request.Chatid = chatId;
            OapiChatGetResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
