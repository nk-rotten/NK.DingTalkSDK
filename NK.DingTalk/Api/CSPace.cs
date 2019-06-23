using NK.DingTalk.Request;
using NK.DingTalk.Response;
using NK.DingTalk.TopApi.Util;

namespace NK.DingTalk.Api
{
    public class CSPace
    {
        /// <summary>
        /// 发送钉盘文件给指定用户 将文件发送给指定用户，用户将收到以微应用名义发送的一条文件消息。 注意：浏览器可能会转义某些字符导致请求失败，调试时请使用curl或者代码模拟请求。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId">文件发送者微应用的agentId</param>
        /// <param name="userId">文件接收人的userid</param>
        /// <param name="mediaId">调用钉盘上传文件接口得到的mediaid，需要utf-8 urlEncode</param>
        /// <param name="fileName">文件名(需包含扩展名)，需要utf-8 urlEncode</param>
        /// <returns></returns>
        public OapiCspaceAddToSingleChatResponse AddToSingleChat(string accessToken, string agentId, string userId, string mediaId, string fileName)
        {
            OapiCspaceAddToSingleChatRequest request = new OapiCspaceAddToSingleChatRequest();
            request.AgentId = agentId;
            request.Userid = userId;
            request.MediaId = mediaId;
            request.FileName = fileName;

            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/cspace/add_to_single_chat?" + WebUtils.BuildQuery(request.GetParameters()));

            OapiCspaceAddToSingleChatResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 新增文件到用户钉盘 将mediaId指定的文件添加到用户指定的钉盘目录下，该mediaId可由本页提供的上传接口获取。该功能需要调用客户端JSAPI (例如移动端 dd.biz.cspace.chooseSpaceDir) 唤起钉钉客户端页面，由用户选择要添加到的钉盘目录。 注意：浏览器可能会转义某些字符导致请求失败，调试时请使用curl或者代码模拟请求。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId">微应用的agentId</param>
        /// <param name="code">code值为应用免登授权码, 微应用授权码参考文档，小程序授权码参考文档</param>
        /// <param name="mediaId">调用钉盘上传文件接口得到的mediaid，需要utf-8 urlEncode</param>
        /// <param name="spaceId">调用钉盘选择控件后获取的用户钉盘空间ID</param>
        /// <param name="folderId">调用钉盘选择控件后获取的用户钉盘文件夹ID。如接入审批附件，这里传0</param>
        /// <param name="name">上传文件的名称，不能包含非法字符，需要utf-8 urlEncode</param>
        /// <param name="overwrite">遇到同名文件是否覆盖，若不覆盖，则会自动重命名本次新增的文件，默认为false</param>
        /// <returns></returns>
        public OapiCspaceAddResponse Add(string accessToken, string code, string mediaId, string spaceId, string folderId, string name, bool overwrite = false, string agentId = "")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/cspace/add");
            OapiCspaceAddRequest request = new OapiCspaceAddRequest();
            request.AgentId = agentId;
            request.Code = code;
            request.MediaId = mediaId;
            request.SpaceId = spaceId;
            request.FolderId = folderId;
            request.Name = name;
            request.Overwrite = overwrite;
            request.SetHttpMethod("GET");
            OapiCspaceAddResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取企业下的自定义空间 针对企业或ISV的个性化需求，我们在企业下开辟了自定义空间来供企业或ISV使用。每个企业可以自定义若干存储空间，每个存储空间不能有重名的文件（全路径），不同存储空间可以存在同名文件；不同存储空间的文件是隔离的，不会相互影响。企业下的自定义空间属于企业，共享使用企业的容量，其中的文件只有企业内部人员才可能有权限访问，访问需要企业或ISV进行授权。每个企业可以自定义若干存储空间，如使用preview空间来存放需要预览的文件。每个ISV的微应用在企业下对应一个自定义空间；这些存储空间在钉钉客户端不可见，在电脑管理后台可以查看其占用企业空间的情况。  注意：浏览器可能会转义某些字符导致请求失败，调试时请使用curl或者代码模拟请求
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId">ISV调用时传入，微应用的agentId</param>
        /// <param name="domain">企业内部调用时传入，需要为10个字节以内的字符串，仅可包含字母和数字，大小写不敏感</param>
        /// <returns></returns>
        public OapiCspaceGetCustomSpaceResponse GetCustomSpace(string accessToken, string domain, string agentId = "")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/cspace/get_custom_space");
            OapiCspaceGetCustomSpaceRequest request = new OapiCspaceGetCustomSpaceRequest();
            request.AgentId = agentId;
            request.Domain = domain;
            request.SetHttpMethod("GET");
            OapiCspaceGetCustomSpaceResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 授权用户访问企业自定义空间 企业或ISV可授权企业下指定人员访问其使用的自定义空间。授权类型包括上传和下载， 预览权限等同于下载权限。 注意：浏览器可能会转义某些字符导致请求失败，调试时请使用curl或者代码模拟请求。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="type">权限类型，目前支持上传和下载，上传请传add，下载请传download</param>
        /// <param name="userId">企业用户userid</param>
        /// <param name="duration">权限有效时间，有效范围为0~3600秒</param>
        /// <param name="agentId">SV调用时传入，授权访问指定微应用的自定义空间</param>
        /// <param name="fileIds">授权访问的文件id列表，id之间用英文逗号隔开，如"fileId1,fileId2", type=download时必须传递</param>
        /// <param name="domain">企业内部调用时传入，授权访问该domain的自定义空间</param>
        /// <param name="path">授权访问的路径，如授权访问所有文件传"/"，授权访问/doc文件夹传"/doc/"，需要utf-8 urlEncode, type=add时必须传递</param>
        /// <returns></returns>
        public OapiCspaceGrantCustomSpaceResponse GrantCustomSpace(string accessToken, string type, string userId, long duration, string agentId = "", string fileIds = "", string domain = "", string path = "")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/cspace/grant_custom_space");
            OapiCspaceGrantCustomSpaceRequest request = new OapiCspaceGrantCustomSpaceRequest();
            request.AgentId = agentId;
            request.Domain = domain;
            request.Type = "";
            request.Userid = "";
            request.Path = "";
            request.Fileids = "";
            request.Duration = 0;
            request.SetHttpMethod("GET");
            OapiCspaceGrantCustomSpaceResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 单步文件上传 单步文件上传，标准 http multipart 上传，文件大小不得超过8M。浏览器可能会转义某些字符导致请求失败，调试时请使用curl或者代码模拟请求。 请保证自己的机器有足够的出口带宽，否则可能导致上传异常缓慢。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="fileSize">文件大小</param>
        /// <param name="agentId">微应用的agentId</param>
        /// <param name="file">文件</param>
        /// <returns></returns>
        public OapiFileUploadSingleResponse UploadSingle(string accessToken,long fileSize,string agentId,FileItem file)
        {
            OapiFileUploadSingleRequest request = new OapiFileUploadSingleRequest();
            request.FileSize = fileSize;
            request.AgentId = agentId;
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/file/upload/single?" + WebUtils.BuildQuery(request.GetParameters()));

            request = new OapiFileUploadSingleRequest();
            request.File = file;
            OapiFileUploadSingleResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 分块上传文件 文件分块上传第一步，开启上传事务，该接口返回upload_id，钉盘服务器以upload_id唯一标识一个上传任务。分块最小需大于100KB，最大不超过8M，最多支持10000块。 注意：浏览器可能会转义某些字符导致请求失败，调试时请使用curl或者代码模拟请求。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId">微应用的agentId</param>
        /// <param name="fileSize">文件大小</param>
        /// <param name="chunkNumber">文件总块数</param>
        /// <returns></returns>
        public OapiFileUploadTransactionResponse UploadTransaction(string accessToken,string agentId,long fileSize,long chunkNumber)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/file/upload/transaction");
            OapiFileUploadTransactionRequest request = new OapiFileUploadTransactionRequest();
            request.AgentId = agentId;
            request.FileSize = fileSize;
            request.ChunkNumbers = chunkNumber;
            request.SetHttpMethod("GET");
            OapiFileUploadTransactionResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 上传文件块 文件分块上传中间环节，传输文件块，除最后一块外每块的大小不得小于100KB，最大不超过超过8M，使用标准 http multipart 上传。 注意： 浏览器可能会转义某些字符导致请求失败，调试时请使用curl或者代码模拟请求。 请保证自己的机器有足够的出口带宽，否则可能导致上传异常缓慢。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId">微应用的agentId</param>
        /// <param name="chunkSequence">文件块号，从1开始计数</param>
        /// <param name="uploadId">上传事务id，需要utf-8 urlEncode</param>
        /// <param name="file">文件</param>
        /// <returns></returns>
        public OapiFileUploadChunkResponse UploadChunk(string accessToken,string agentId,long chunkSequence,string uploadId,FileItem file)
        {
            OapiFileUploadChunkRequest request = new OapiFileUploadChunkRequest();
            request.AgentId = agentId;
            request.ChunkSequence = chunkSequence;
            request.UploadId = uploadId;
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/file/upload/chunk?" + WebUtils.BuildQuery(request.GetParameters()));
            request = new OapiFileUploadChunkRequest();
            request.File = file;
            OapiFileUploadChunkResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 提交文件上传事务 文件分块上传最后一步，提交本次分块上传事务，默认情况下，系统会删除超过 24 小时没有提交的分块文件上传事务。 注意：浏览器可能会转义某些字符导致请求失败，调试时请使用curl或者代码模拟请求。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId">微应用的agentId</param>
        /// <param name="fileSize">文件大小</param>
        /// <param name="chunkNumber">文件总块数</param>
        /// <param name="uploadId">上传事务id，需要utf-8 urlEncode</param>
        /// <returns></returns>
        public OapiFileUploadTransactionResponse FileUploadTransaction(string accessToken,string agentId,long fileSize,long chunkNumber,string uploadId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/file/upload/transaction");
            OapiFileUploadTransactionRequest request = new OapiFileUploadTransactionRequest();
            request.AgentId=agentId;
            request.FileSize = fileSize;
            request.ChunkNumbers = chunkNumber;
            request.UploadId = uploadId;
            request.SetHttpMethod("GET");
            OapiFileUploadTransactionResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
