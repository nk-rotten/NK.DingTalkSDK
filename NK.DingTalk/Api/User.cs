using Newtonsoft.Json;
using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.DingTalk.Api
{
    public class User
    {
        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="userId">员工id</param>
        /// <param name="lang">通讯录语言(默认zh_CN，未来会支持en_US)</param>
        /// <returns></returns>
        public OapiUserGetResponse Get(string accessToken, string userId, string lang = "zh_CN")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/get");
            OapiUserGetRequest request = new OapiUserGetRequest
            {
                Userid = userId
            };
            request.SetHttpMethod("GET");
            OapiUserGetResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取部门用户userid列表
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="deptId">部门id</param>
        /// <returns></returns>
        public OapiUserGetDeptMemberResponse GetDeptMember(string accessToken, string deptId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/getDeptMember");
            OapiUserGetDeptMemberRequest req = new OapiUserGetDeptMemberRequest
            {
                DeptId = deptId
            };
            req.SetHttpMethod("GET");
            OapiUserGetDeptMemberResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 获取部门用户
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="departmentId">获取的部门id</param>
        /// <param name="offSet">支持分页查询，与size参数同时设置时才生效，此参数代表偏移量</param>
        /// <param name="size">支持分页查询，与offset参数同时设置时才生效，此参数代表分页大小，最大100</param>
        /// <returns></returns>
        public OapiUserSimplelistResponse SimpleList(string accessToken, long departmentId, long offSet, long size)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/simplelist");
            OapiUserSimplelistRequest request = new OapiUserSimplelistRequest();
            request.DepartmentId = departmentId;
            request.Offset = offSet;
            request.Size = size;
            request.SetHttpMethod("GET");
            OapiUserSimplelistResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取部门用户详情
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="departmentId">获取的部门id，1表示根部门</param>
        /// <param name="offSet">支持分页查询，与size参数同时设置时才生效，此参数代表偏移量,偏移量从0开始</param>
        /// <param name="size">支持分页查询，与offset参数同时设置时才生效，此参数代表分页大小，最大100</param>
        /// <param name="order">支持分页查询，部门成员的排序规则，默认 是按自定义排序；
        ///entry_asc：代表按照进入部门的时间升序，
        ///entry_desc：代表按照进入部门的时间降序，
        ///modify_asc：代表按照部门信息修改时间升序，
        ///modify_desc：代表按照部门信息修改时间降序，
        ///custom：代表用户定义(未定义时按照拼音)排序</param>
        /// <returns></returns>
        public OapiUserListbypageResponse ListByPage(string accessToken, long departmentId, long offSet, long size, string order = "entry_desc")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/listbypage");
            OapiUserListbypageRequest request = new OapiUserListbypageRequest();
            request.DepartmentId = departmentId;
            request.Offset = offSet;
            request.Size = size;
            request.Order = order;
            request.SetHttpMethod("GET");
            OapiUserListbypageResponse res = client.Execute(request, accessToken);
            return res;
        }

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <returns></returns>
        public OapiUserGetAdminResponse GetAdmin(string accessToken)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/get_admin");
            OapiUserGetAdminRequest request = new OapiUserGetAdminRequest();
            request.SetHttpMethod("GET");
            OapiUserGetAdminResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取管理员通讯录权限范围
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="userId">员工id</param>
        /// <returns></returns>
        public OapiUserGetAdminScopeResponse GetAdminScope(string accessToken, string userId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/user/get_admin_scope");
            OapiUserGetAdminScopeRequest req = new OapiUserGetAdminScopeRequest();
            req.Userid = userId;
            OapiUserGetAdminScopeResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 根据unionid获取userid
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="unionId">员工在当前开发者企业账号范围内的唯一标识，系统生成，固定值，不会改变</param>
        public OapiUserGetUseridByUnionidResponse GetUserIdByUnionId(string accessToken, string unionId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/getUseridByUnionid");
            OapiUserGetUseridByUnionidRequest request = new OapiUserGetUseridByUnionidRequest();
            request.Unionid = unionId;
            request.SetHttpMethod("GET");
            OapiUserGetUseridByUnionidResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="userId">员工在当前企业内的唯一标识，也称staffId。可由企业在创建时指定，并代表一定含义比如工号，创建后不可修改，企业内必须唯一。 长度为1 ~64个字符，如果不传，服务器将自动生成一个userid。</param>
        /// <param name="mobile">手机号码，企业内必须唯一，不可重复。如果是国际号码，请使用+xx-xxxxxx的格式</param>
        /// <param name="name">成员名称。 长度为1 ~64个字符</param>
        /// <param name="departments">数组类型，数组里面值为整型，成员所属部门id列表</param>
        /// <returns></returns>
        public OapiUserCreateResponse Create(string accessToken, string mobile, string name, List<long> departments, string userId = "")
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/create");
            OapiUserCreateRequest request = new OapiUserCreateRequest
            {
                Userid = userId,
                Mobile = mobile,
                Name = name,
                Department = JsonConvert.SerializeObject(departments)
            };
            OapiUserCreateResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="userId">员工id</param>
        /// <returns></returns>
        public OapiUserDeleteResponse Delete(string accessToken, string userId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/delete");
            OapiUserDeleteRequest request = new OapiUserDeleteRequest
            {
                Userid = userId
            };
            request.SetHttpMethod("GET");
            OapiUserDeleteResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取企业员工人数
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="onlyActive">0：包含未激活钉钉的人员数量 1：不包含未激活钉钉的人员数量</param>
        /// <returns></returns>
        public OapiUserGetOrgUserCountResponse GetOrgUserCount(string accessToken, long onlyActive)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/get_org_user_count");
            OapiUserGetOrgUserCountRequest request = new OapiUserGetOrgUserCountRequest();
            request.OnlyActive = onlyActive;
            request.SetHttpMethod("GET");
            OapiUserGetOrgUserCountResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId">员工id，不可修改，长度为1~64个字符</param>
        /// <param name="name">成员名称，长度为1~64个字符</param>
        /// <returns></returns>
        public OapiUserUpdateResponse Update(string accessToken, string userId, string name)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/update");
            OapiUserUpdateRequest request = new OapiUserUpdateRequest();
            request.Name = name;
            request.Userid = userId;
            OapiUserUpdateResponse response = client.Execute(request, accessToken);
            return response;
        }

    }
}
