using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System.Collections.Generic;

namespace NK.DingTalk.Api
{
    public class Calendar
    {
        /// <summary>
        /// 创建日程 调用该接口可以将企业员工的待办事项写入到钉钉日历并在钉钉日历中展示。 企业可在应用的权限管理页面申请该接口权限，具体可参考文档。https://open-doc.dingtalk.com/microapp/serverapi2/eev437#5ilhrv
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="uuid">请求的唯一标识, 保证请求唯一性</param>
        /// <param name="bizId">业务方自己的主键</param>
        /// <param name="creatorUserId">创建者userid</param>
        /// <param name="summary">日程主题</param>
        /// <param name="receiverUserIds">接收者userid</param>
        /// <param name="startUnixTimesTamp">开始的unix时间戳(单位:毫秒)</param>
        /// <param name="endUnixTimesTamp">结束的unix时间戳(单位:毫秒)</param>
        /// <param name="calendarType">日程类型:notification-提醒</param>
        /// <param name="url">点击日程跳转目标地址</param>
        /// <param name="minutes">距开始时多久进行提醒(单位:分钟)</param>
        /// <param name="remindType">提醒类型:app-应用内</param>
        /// <param name="location">地点</param>
        /// <param name="title">日程来源</param>
        /// <param name="description">备注</param>
        /// <param name="startTimeZone">开始时区</param>
        /// <param name="endTimeZone">结束时区</param>
        /// <returns></returns>
        public OapiCalendarCreateResponse Create(string accessToken, string uuid, string bizId, string creatorUserId, string summary, List<string> receiverUserIds, long startUnixTimesTamp, long endUnixTimesTamp, string calendarType, string url, long minutes = 15, string remindType = "app", string location = "", string title = "", string description = "", string startTimeZone = "Asia/Shanghai", string endTimeZone = "Asia/Shanghai")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/calendar/create");
            OapiCalendarCreateRequest request = new OapiCalendarCreateRequest();
            OapiCalendarCreateRequest.OpenCalendarCreateVoDomain creatVo = new OapiCalendarCreateRequest.OpenCalendarCreateVoDomain();
            creatVo.Uuid = uuid;
            creatVo.BizId = bizId;
            creatVo.CreatorUserid = creatorUserId;
            creatVo.Summary = summary;
            creatVo.ReceiverUserids = receiverUserIds;
            creatVo.CalendarType = calendarType;
            creatVo.Location = location;
            creatVo.Description = description;

            OapiCalendarCreateRequest.DatetimeVoDomain start = new OapiCalendarCreateRequest.DatetimeVoDomain();
            start.UnixTimestamp = startUnixTimesTamp;
            start.Timezone = startTimeZone;
            creatVo.StartTime = start;

            OapiCalendarCreateRequest.DatetimeVoDomain end = new OapiCalendarCreateRequest.DatetimeVoDomain();
            end.UnixTimestamp = endUnixTimesTamp;
            end.Timezone = endTimeZone;
            creatVo.EndTime = end;

            OapiCalendarCreateRequest.OpenCalendarSourceVoDomain source = new OapiCalendarCreateRequest.OpenCalendarSourceVoDomain();
            source.Url = url;
            source.Title = title;
            creatVo.Source = source;

            OapiCalendarCreateRequest.OpenCalendarReminderVoDomain reminder = new OapiCalendarCreateRequest.OpenCalendarReminderVoDomain();
            reminder.Minutes = minutes;
            reminder.RemindType = remindType;
            creatVo.Reminder = reminder;

            request.CreateVo_ = creatVo;
            OapiCalendarCreateResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
