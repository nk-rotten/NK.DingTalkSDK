using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System.Collections.Generic;
using static NK.DingTalk.Request.OapiWorkrecordAddRequest;

namespace NK.DingTalk.Api
{
    public class WorkRecord
    {
        /// <summary>
        /// 发起待办目前待办事项有防骚扰控制，具体为： 1、每人每天最多收到一条表单内容相同的待办。触发这个限制，会返回错误码854001 2、每人每天最多收到100条待办。触发这个限制，会返回错误码854002
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId">待办事项对应的用户id</param>
        /// <param name="createTime">待办时间。Unix时间戳，毫秒级</param>
        /// <param name="title">待办事项的标题</param>
        /// <param name="url">待办事项的跳转链接</param>
        /// <param name="list">待办事项表单</param>
        /// <returns></returns>
        public OapiWorkrecordAddResponse AddWorkRecord(string accessToken,string userId,long createTime,string title,string url,List<FormItemVoDomain> list)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/workrecord/add");
            OapiWorkrecordAddRequest req = new OapiWorkrecordAddRequest();
            req.Userid = userId;
            req.CreateTime = createTime;
            req.Title = title;
            req.Url = url;
            req.FormItemList_ = list;
            OapiWorkrecordAddResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 更新待办 企业可以调用该接口更新待办事项状态，调用成功后，该待办事项在该用户的“待办事项”列表页面中消失。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId">待办事项对应的用户id</param>
        /// <param name="recordId">待办事项唯一id</param>
        /// <returns></returns>
        public OapiWorkrecordUpdateResponse UploadWorkRecord(string accessToken,string userId,string recordId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/workrecord/update");
            OapiWorkrecordUpdateRequest req = new OapiWorkrecordUpdateRequest();
            req.Userid = userId;
            req.RecordId = recordId;
            OapiWorkrecordUpdateResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 获取用户待办事项 企业可以调用该接口分页获取用户的待办事项列表。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId">待办事项对应的用户id</param>
        /// <param name="offset">分页游标，从0开始，如返回结果中has_more为true，则表示还有数据，offset再传上一次的offset+limit</param>
        /// <param name="limit">分页大小，最多50</param>
        /// <param name="status">待办事项状态，0表示未完成，1表示完成</param>
        /// <returns></returns>
        public OapiWorkrecordGetbyuseridResponse GetWorkRecordByUserId(string accessToken,string userId,long offset,long limit,long status)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/workrecord/getbyuserid");
            OapiWorkrecordGetbyuseridRequest req = new OapiWorkrecordGetbyuseridRequest();
            req.Userid = userId;
            req.Offset = offset;
            req.Limit = limit;
            req.Status = status;
            OapiWorkrecordGetbyuseridResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }
    }
}
