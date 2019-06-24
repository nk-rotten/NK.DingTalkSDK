using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NK.DingTalk.Api
{
    public class Department
    {
        /// <summary>
        /// 查询部门的所有上级父部门路径
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="id">希望查询的部门的id，包含查询的部门本身</param>
        /// <returns></returns>
        public OapiDepartmentListParentDeptsByDeptResponse ListParentDeptsByDept(string accessToken, string id)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/department/list_parent_depts_by_dept");
            OapiDepartmentListParentDeptsByDeptRequest request = new OapiDepartmentListParentDeptsByDeptRequest();
            request.Id = id;
            request.SetHttpMethod("GET");
            OapiDepartmentListParentDeptsByDeptResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 查询指定用户的所有上级父部门路径当传入员工A的userId时，返回的结果按顺序依次为其所有父部门的ID，直到根部门，如[[456,123,1],[789,1]]。
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="userId">希望查询的用户的id</param>
        /// <returns></returns>
        public OapiDepartmentListParentDeptsResponse ListParentDepts(string accessToken, string userId)
        {
            if (string.IsNullOrEmpty(accessToken))
                accessToken = AccessToken.GetAccessToken();
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/department/list_parent_depts");
            OapiDepartmentListParentDeptsRequest request = new OapiDepartmentListParentDeptsRequest();
            request.UserId = userId;
            request.SetHttpMethod("GET");
            OapiDepartmentListParentDeptsResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取部门详情
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="id">部门id</param>
        /// <param name="lang">通讯录语言(默认zh_CN，未来会支持en_US)</param>
        /// <returns></returns>
        public OapiDepartmentGetResponse Get(string accessToken, string id, string lang = "zh_CN")
        {
            if (string.IsNullOrEmpty(accessToken))
                accessToken = AccessToken.GetAccessToken();
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/department/get");
            OapiDepartmentGetRequest request = new OapiDepartmentGetRequest();
            request.Id = id;
            request.SetHttpMethod("GET");
            OapiDepartmentGetResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取子部门ID列表
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="id">父部门id。根部门的话传1</param>
        /// <returns></returns>
        public OapiDepartmentListIdsResponse ListIDs(string accessToken, string id)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/department/list_ids");
            OapiDepartmentListIdsRequest request = new OapiDepartmentListIdsRequest();
            request.Id = id;
            request.SetHttpMethod("GET");
            OapiDepartmentListIdsResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="id">父部门id（如果不传，默认部门为根部门，根部门ID为1）</param>
        /// <param name="lang">通讯录语言（默认zh_CN，未来会支持en_US）</param>
        /// <param name="fetchChild">是否递归部门的全部子部门，ISV微应用固定传递false</param>
        /// <returns></returns>
        public OapiDepartmentListResponse List(string accessToken, string id, string lang = "zh_CN", bool fetchChild = false)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/department/list");
            OapiDepartmentListRequest request = new OapiDepartmentListRequest();
            request.Id = id;
            request.Lang = lang;
            request.FetchChild = fetchChild;
            request.SetHttpMethod("GET");
            OapiDepartmentListResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="name">部门名称，长度限制为1~64个字符，不允许包含字符‘-’‘，’以及‘,’</param>
        /// <param name="parentId">父部门id，根部门id为1</param>
        /// <param name="order">在父部门中的排序值，order值小的排序靠前</param>
        /// <param name="createDeptGroup">是否创建一个关联此部门的企业群，默认为false</param>
        /// <param name="deptHiding">是否隐藏部门, true表示隐藏 false表示显示</param>
        /// <param name="deptPermits">可以查看指定隐藏部门的其他部门列表，如果部门隐藏，则此值生效，取值为其他的部门id组成的字符串，使用“|”符号进行分割。总数不能超过200</param>
        /// <param name="userPermits">可以查看指定隐藏部门的其他人员列表，如果部门隐藏，则此值生效，取值为其他的人员userid组成的的字符串，使用“|”符号进行分割。总数不能超过200</param>
        /// <param name="outerDept">限制本部门成员查看通讯录，限制开启后，本部门成员只能看到限定范围内的通讯录。true表示限制开启</param>
        /// <param name="outerPermitDepts">outerDept为true时，可以配置额外可见部门，值为部门id组成的的字符串，使用“|”符号进行分割。总数不能超过200</param>
        /// <param name="outerPermitUsers">outerDept为true时，可以配置额外可见人员，值为userid组成的的字符串，使用“|”符号进行分割。总数不能超过200</param>
        /// <param name="outerDeptOnlySelf">outerDept为true时，可以配置该字段，为true时，表示只能看到所在部门及下级部门通讯录</param>
        /// <param name="sourceIdentifier">部门标识字段，开发者可用该字段来唯一标识一个部门，并与钉钉外部通讯录里的部门做映射</param>
        /// <returns></returns>
        public OapiDepartmentCreateResponse Create(string accessToken, string name, string parentId, string order = "", bool createDeptGroup = false, bool deptHiding = false, string deptPermits = "", string userPermits = "", bool outerDept = false, string outerPermitDepts = "", string outerPermitUsers = "", bool outerDeptOnlySelf = false, string sourceIdentifier = "")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/department/create");
            OapiDepartmentCreateRequest request = new OapiDepartmentCreateRequest();
            request.Parentid = parentId;
            request.Order = order;
            request.CreateDeptGroup = createDeptGroup;
            request.Name = name;
            request.DeptHiding = deptHiding;
            request.DeptPermits = deptPermits;
            request.UserPermits = userPermits;
            request.OuterDept = outerDept;
            request.OuterPermitDepts = outerPermitDepts;
            request.OuterPermitUsers = outerPermitUsers;
            request.OuterDeptOnlySelf = outerDeptOnlySelf;
            request.SourceIdentifier = sourceIdentifier;
            OapiDepartmentCreateResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="id">部门id</param>
        /// <param name="lang">通讯录语言(默认zh_CN另外支持en_US)</param>
        /// <param name="name">部门名称，长度限制为1~64个字符，不允许包含字符‘-’‘，’以及‘,’</param>
        /// <param name="parentId">父部门id，根部门id为1</param>
        /// <param name="order">在父部门中的排序值，order值小的排序靠前</param>
        /// <param name="createDeptGroup">是否创建一个关联此部门的企业群</param>
        /// <param name="groupContainSubDept">部门群是否包含子部门</param>
        /// <param name="groupContainOuterDept">部门群是否包含外包部门</param>
        /// <param name="groupContainHiddenDept">部门群是否包含隐藏部门</param>
        /// <param name="autoAddUser">如果有新人加入部门是否会自动加入部门群</param>
        /// <param name="deptManagerUseridList">部门的主管列表,取值为由主管的userid组成的字符串，不同的userid使用“|”符号进行分割</param>
        /// <param name="deptHiding">是否隐藏部门, true表示隐藏 false表示显示</param>
        /// <param name="deptPermits">可以查看指定隐藏部门的其他部门列表，如果部门隐藏，则此值生效，取值为其他的部门id组成的的字符串，使用“|”符号进行分割。总数不能超过200</param>
        /// <param name="userPermits">可以查看指定隐藏部门的其他人员列表，如果部门隐藏，则此值生效，取值为其他的人员userid组成的字符串，使用“|”符号进行分割。总数不能超过200</param>
        /// <param name="outerDept">是否本部门的员工仅可见员工自己, 为true时，本部门员工默认只能看到员工自己</param>
        /// <param name="outerPermitDepts">本部门的员工仅可见员工自己为true时，可以配置额外可见部门，值为部门id组成的的字符串，使用|符号进行分割。总数不能超过200</param>
        /// <param name="outerPermitUsers">本部门的员工仅可见员工自己为true时，可以配置额外可见人员，值为userid组成的的字符串，使用|符号进行分割。总数不能超过200</param>
        /// <param name="outerDeptOnlySelf">outerDept为true时，可以配置该字段，为true时，表示只能看到所在部门及下级部门通讯录</param>
        /// <param name="orgDeptOwner">企业群群主</param>
        /// <param name="sourceIdentifier">部门标识字段，开发者可用该字段来唯一标识一个部门，并与钉钉外部通讯录里的部门做映射</param>
        /// <returns></returns>
        public OapiDepartmentUpdateResponse Update(string accessToken, long id, string lang = "zh_CN", string name = "", string parentId = "", string order = "", bool createDeptGroup = false, bool groupContainSubDept = false, bool groupContainOuterDept = false, bool groupContainHiddenDept = false, bool autoAddUser = false, string deptManagerUseridList = "", bool deptHiding = false, string deptPermits = "", string userPermits = "", bool outerDept = false, string outerPermitDepts = "", string outerPermitUsers = "", bool outerDeptOnlySelf = false, string orgDeptOwner = "", string sourceIdentifier = "")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/department/update");
            OapiDepartmentUpdateRequest request = new OapiDepartmentUpdateRequest();
            request.Id = id;
            request.Lang = lang;
            request.Name = name;
            request.Parentid = parentId;
            request.Order = order;
            request.CreateDeptGroup = createDeptGroup;
            request.GroupContainSubDept = groupContainSubDept;
            request.GroupContainOuterDept = groupContainOuterDept;
            request.GroupContainHiddenDept = groupContainHiddenDept;
            request.AutoAddUser = autoAddUser;
            request.DeptManagerUseridList = deptManagerUseridList;
            request.DeptHiding = deptHiding;
            request.DeptPermits = deptPermits;
            request.UserPermits = userPermits;
            request.OuterDept = outerDept;
            request.OuterPermitDepts = outerPermitDepts;
            request.OuterPermitUsers = outerPermitUsers;
            request.OuterDeptOnlySelf = outerDeptOnlySelf;
            request.OrgDeptOwner = orgDeptOwner;
            request.SourceIdentifier = sourceIdentifier;
            OapiDepartmentUpdateResponse response = client.Execute(request, accessToken);
            return response;
        }
    }
}
