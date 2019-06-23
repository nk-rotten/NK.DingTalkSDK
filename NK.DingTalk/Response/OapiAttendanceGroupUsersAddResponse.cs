using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi;

namespace NK.DingTalk.Response
{
    /// <summary>
    /// OapiAttendanceGroupUsersAddResponse.
    /// </summary>
    public class OapiAttendanceGroupUsersAddResponse : DingTalkResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        [XmlElement("result")]
        public ResultDomain Result { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// ErrorInfoDomain Data Structure.
/// </summary>
[Serializable]

public class ErrorInfoDomain : TopObject
{
	        /// <summary>
	        /// 错误码
	        /// </summary>
	        [XmlElement("code")]
	        public string Code { get; set; }
	
	        /// <summary>
	        /// 失败列表
	        /// </summary>
	        [XmlArray("failure_list")]
	        [XmlArrayItem("string")]
	        public List<string> FailureList { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("msg")]
	        public string Msg { get; set; }
}

	/// <summary>
/// ResultDomain Data Structure.
/// </summary>
[Serializable]

public class ResultDomain : TopObject
{
	        /// <summary>
	        /// 错误列表
	        /// </summary>
	        [XmlArray("error_info_list")]
	        [XmlArrayItem("error_info")]
	        public List<ErrorInfoDomain> ErrorInfoList { get; set; }
	
	        /// <summary>
	        /// 成功列表
	        /// </summary>
	        [XmlArray("success_list")]
	        [XmlArrayItem("string")]
	        public List<string> SuccessList { get; set; }
}

    }
}
