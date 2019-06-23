using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NK.DingTalk.TopApi.Util;
using NK.DingTalk.TopApi;
using NK.DingTalk.Response;

namespace NK.DingTalk.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.alitrip.btrip.cost.center.entity.set
    /// </summary>
    public class OapiAlitripBtripCostCenterEntitySetRequest : BaseDingTalkRequest<OapiAlitripBtripCostCenterEntitySetResponse>
    {
        /// <summary>
        /// 请求对象
        /// </summary>
        public string Rq { get; set; }

        public OpenCostCenterSetEntityRqDomain Rq_ { set { this.Rq = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.alitrip.btrip.cost.center.entity.set";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("rq", this.Rq);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

	/// <summary>
/// OpenOrgEntityDoDomain Data Structure.
/// </summary>
[Serializable]

public class OpenOrgEntityDoDomain : TopObject
{
	        /// <summary>
	        /// 员工/部门/角色id
	        /// </summary>
	        [XmlElement("entity_id")]
	        public string EntityId { get; set; }
	
	        /// <summary>
	        /// 人员类型:1员工，2部门，3角色
	        /// </summary>
	        [XmlElement("entity_type")]
	        public string EntityType { get; set; }
}

	/// <summary>
/// OpenCostCenterSetEntityRqDomain Data Structure.
/// </summary>
[Serializable]

public class OpenCostCenterSetEntityRqDomain : TopObject
{
	        /// <summary>
	        /// 企业id
	        /// </summary>
	        [XmlElement("corpid")]
	        public string Corpid { get; set; }
	
	        /// <summary>
	        /// 人员信息列表
	        /// </summary>
	        [XmlArray("entity_list")]
	        [XmlArrayItem("open_org_entity_do")]
	        public List<OpenOrgEntityDoDomain> EntityList { get; set; }
	
	        /// <summary>
	        /// 第三方成本中心id
	        /// </summary>
	        [XmlElement("thirdpart_id")]
	        public string ThirdpartId { get; set; }
}

        #endregion
    }
}
