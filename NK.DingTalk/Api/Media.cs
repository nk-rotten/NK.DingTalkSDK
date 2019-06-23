using NK.DingTalk.Request;
using NK.DingTalk.Response;
using NK.DingTalk.TopApi.Util;

namespace NK.DingTalk.Api
{
    public class Media
    {
        /// <summary>
        /// 上传媒体文件 用于上传图片、语音媒体资源文件以及普通文件（如doc、ppt），接口返回媒体资源标识media_id。请注意：media_id是可复用的，同一个media_id多次使用。 media_id对应的资源文件，仅能在钉钉客户端内使用。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="type">媒体文件类型，分别有图片（image）、语音（voice）、普通文件(file)</param>
        /// <param name="media">form-data中媒体文件标识，有filename、filelength、content-type等信息</param>
        /// <returns></returns>
        public OapiMediaUploadResponse Upload(string accessToken,string type, FileItem media)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/media/upload");
            OapiMediaUploadRequest request = new OapiMediaUploadRequest();
            request.Type = type;
            request.Media = media;
            OapiMediaUploadResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
