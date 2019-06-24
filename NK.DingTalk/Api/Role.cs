using NK.DingTalk.Request;
using NK.DingTalk.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.DingTalk.Api
{
    public class Role
    {
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="offSet">分页偏移，默认值：0</param>
        /// <param name="size">分页大小，默认值：20，最大值200</param>
        /// <returns></returns>
        public OapiRoleListResponse List(string accessToken, long offSet = 0, long size = 20)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/list");
            OapiRoleListRequest request = new OapiRoleListRequest();
            request.Offset = offSet;
            request.Size = size;
            OapiRoleListResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取角色下的员工列表
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="roleId">角色ID</param>
        /// <param name="offSet">分页偏移，默认值：0</param>
        /// <param name="size">分页大小，默认值：20，最大值200</param>
        /// <returns></returns>
        public OapiRoleSimplelistResponse SimpleListByRole(string accessToken, long roleId, long offSet = 0, long size = 20)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/simplelist");
            OapiRoleSimplelistRequest request = new OapiRoleSimplelistRequest();
            request.RoleId = roleId;
            request.Offset = offSet;
            request.Size = size;
            OapiRoleSimplelistResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取角色组
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId">角色组的Id</param>
        public OapiRoleGetrolegroupResponse GetRoleGroup(string accessToken,long groupId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/getrolegroup");
            OapiRoleGetrolegroupRequest request = new OapiRoleGetrolegroupRequest();
            request.GroupId = groupId;
            OapiRoleGetrolegroupResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 获取角色详情
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public OapiRoleGetroleResponse GetRole(string accessToken, long roleId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/getrole");
            OapiRoleGetroleRequest req = new OapiRoleGetroleRequest();
            req.RoleId = roleId;
            OapiRoleGetroleResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="roleName">角色名称</param>
        /// <param name="groupId">角色组id</param>
        /// <returns></returns>
        public OapiRoleAddroleResponse AddRole(string accessToken,string roleName,long groupId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/role/add_role");
            OapiRoleAddroleRequest req = new OapiRoleAddroleRequest();
            req.RoleName = roleName;
            req.GroupId = groupId;
            OapiRoleAddroleResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="roleName">角色名称</param>
        /// <param name="roleId">角色id</param>
        /// <returns></returns>
        public OapiRoleUpdateroleResponse UpdateRole(string accessToken, string roleName, long roleId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/role/update_role");
            OapiRoleUpdateroleRequest req = new OapiRoleUpdateroleRequest();
            req.RoleName = roleName;
            req.RoleId = roleId;
            OapiRoleUpdateroleResponse rsp = client.Execute(req, accessToken);
            return rsp;
        }

        /// <summary>
        /// 删除角色 【注意】删除角色前，需确保角色下面的员工没有被赋予这个角色
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="roleId">角色id</param>
        /// <returns></returns>
        public OapiRoleDeleteroleResponse DeleteRole(string accessToken, long roleId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/deleterole");
            OapiRoleDeleteroleRequest request = new OapiRoleDeleteroleRequest();
            request.RoleId = roleId;
            OapiRoleDeleteroleResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 创建角色组
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="name">角色组名称</param>
        /// <returns></returns>
        public OapiRoleAddrolegroupResponse AddRoleGroup(string accessToken, string name)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/role/add_role_group");
            OapiRoleAddrolegroupRequest req = new OapiRoleAddrolegroupRequest();
            req.Name = name;
            OapiRoleAddrolegroupResponse response = client.Execute(req, accessToken);
            return response;
        }

        /// <summary>
        /// 批量增加员工角色
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="roleIds">角色id list，最大列表长度：20</param>
        /// <param name="userIds">员工id list，最大列表长度：100</param>
        /// <returns></returns>
        public OapiRoleAddrolesforempsResponse AddRolesForemps(string accessToken,string roleIds,string userIds)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/addrolesforemps");
            OapiRoleAddrolesforempsRequest request = new OapiRoleAddrolesforempsRequest();
            request.RoleIds = roleIds;
            request.UserIds = userIds;

            OapiRoleAddrolesforempsResponse response = client.Execute(request, accessToken);
            return response;
        }

        /// <summary>
        /// 批量删除员工角色
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="roleIds">角色标签id，最大列表长度：20</param>
        /// <param name="userIds">用户userId，最大列表长度：100</param>
        /// <returns></returns>
        public OapiRoleRemoverolesforempsResponse RemoveRolesForemps(string accessToken, string roleIds, string userIds)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/removerolesforemps");
            OapiRoleRemoverolesforempsRequest request = new OapiRoleRemoverolesforempsRequest();
            request.RoleIds = roleIds;
            request.UserIds = userIds;

            OapiRoleRemoverolesforempsResponse response = client.Execute(request, accessToken);
            return response;
        }

    }
}
