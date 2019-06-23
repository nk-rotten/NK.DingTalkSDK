using NK.DingTalk.Base;
using NK.DingTalk.Response;
using NK.DingTalk.TopApi.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.DingTalk.TopApi
{
    /// <summary>
    /// DingTalk上传请求接口，支持同时上传多个文件。
    /// </summary>
    public interface IDingTalkUploadRequest<T> : IDingTalkRequest<T> where T : DingTalkResponse
    {
        /// <summary>
        /// 获取所有的Key-Value形式的文件请求参数字典。其中：
        /// Key: 请求参数名
        /// Value: 文件对象
        /// </summary>
        /// <returns>文件请求参数字典</returns>
        IDictionary<string, FileItem> GetFileParameters();
    }
}
