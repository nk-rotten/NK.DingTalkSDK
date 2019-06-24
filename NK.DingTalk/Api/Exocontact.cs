using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.DingTalk.Api
{
    public class Exocontact
    {
        /// <summary>
        /// 获取外部联系人标签列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="offset">偏移位置</param>
        /// <param name="size">分页大小，最大100</param>
        /// <returns></returns>
        public OapiExtcontactListlabelgroupsResponse ListLabelGroups(string accessToken, long offset, long size)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/extcontact/listlabelgroups");
            OapiExtcontactListlabelgroupsRequest request = new OapiExtcontactListlabelgroupsRequest();
            request.Offset = offset;
            request.Size = size;
            OapiExtcontactListlabelgroupsResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取外部联系人列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="offset">偏移位置</param>
        /// <param name="size">分页大小，最大100</param>
        /// <returns></returns>
        public OapiExtcontactListResponse List(string accessToken, long offset, long size)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/extcontact/list");
            OapiExtcontactListRequest request = new OapiExtcontactListRequest();
            request.Offset = offset;
            request.Size = size;
            OapiExtcontactListResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取外部联系人详情
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public OapiExtcontactGetResponse Get(string accessToken, string userId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/extcontact/get");
            OapiExtcontactGetRequest request = new OapiExtcontactGetRequest();
            request.UserId = userId;
            OapiExtcontactGetResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 添加外部联系人
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="labelIds">标签列表</param>
        /// <param name="followerUserId">负责人userId</param>
        /// <param name="name">名称</param>
        /// <param name="stateCode">手机号国家码</param>
        /// <param name="mobile">手机号</param>
        /// <param name="title">职位</param>
        /// <param name="shareDeptIds">共享给的部门ID</param>
        /// <param name="address">地址</param>
        /// <param name="remark">备注</param>
        /// <param name="companyName">企业名</param>
        /// <param name="shareUserIds">共享给的员工userId列表</param>
        /// <returns></returns>
        public OapiExtcontactCreateResponse Create(string accessToken, List<string> labelIds, string followerUserId, string name, string stateCode, string mobile, string title = "", List<string> shareDeptIds = null, string address = "", string remark = "", string companyName = "", List<string> shareUserIds = null)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/extcontact/create");
            OapiExtcontactCreateRequest request = new OapiExtcontactCreateRequest();
            OapiExtcontactCreateRequest.OpenExtContactDomain openExtContact = new OapiExtcontactCreateRequest.OpenExtContactDomain();
            openExtContact.Title = title;
            openExtContact.LabelIds = labelIds;
            openExtContact.ShareDeptIds = shareDeptIds;
            openExtContact.Address = address;
            openExtContact.Remark = remark;
            openExtContact.FollowerUserId = followerUserId;
            openExtContact.Name = name;
            openExtContact.StateCode = stateCode;
            openExtContact.CompanyName = companyName;
            openExtContact.ShareUserIds = shareUserIds;
            openExtContact.Mobile = mobile;
            request.Contact_ = openExtContact;
            OapiExtcontactCreateResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 更新外部联系人
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId">该外部联系人的userId</param>
        /// <param name="labelIds">标签列表</param>
        /// <param name="followerUserId">负责人userId</param>
        /// <param name="name">名称</param>
        /// <param name="title">职位</param>
        /// <param name="shareDeptIds">共享给的部门ID</param>
        /// <param name="address">地址</param>
        /// <param name="remark">备注</param>
        /// <param name="companyName">企业名</param>
        /// <param name="shareUserIds">共享给的员工userId列表</param>
        /// <returns></returns>
        public OapiExtcontactUpdateResponse Update(string accessToken, string userId, List<string> labelIds, string followerUserId, string name,  string title = "", List<string> shareDeptIds = null, string address = "", string remark = "", string companyName = "", List<string> shareUserIds = null)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/extcontact/update");
            OapiExtcontactUpdateRequest request = new OapiExtcontactUpdateRequest();
            OapiExtcontactUpdateRequest.OpenExtContactDomain openExtContact = new OapiExtcontactUpdateRequest.OpenExtContactDomain();
            openExtContact.UserId = userId;
            openExtContact.Title = title;
            openExtContact.LabelIds = labelIds;
            openExtContact.ShareDeptIds = shareDeptIds;
            openExtContact.Address = address;
            openExtContact.Remark = remark;
            openExtContact.FollowerUserId = followerUserId;
            openExtContact.Name = name;
            openExtContact.CompanyName = companyName;
            openExtContact.ShareUserIds = shareUserIds;
            request.Contact_ = openExtContact;
            request.Contact_ = openExtContact;
            OapiExtcontactUpdateResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 删除外部联系人
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public OapiExtcontactDeleteResponse Delete(string accessToken, string userId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/extcontact/delete");
            OapiExtcontactDeleteRequest request = new OapiExtcontactDeleteRequest();
            request.UserId = userId;
            OapiExtcontactDeleteResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
