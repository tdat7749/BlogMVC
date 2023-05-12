using Blog.ViewModel.Common;
using Blog.ViewModel.System.Role;
using Blog.ViewModel.System.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.System.RoleService
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetListRoles();

        public Task<JsonResponse> RegisterRoles(RegisterRoleModel model);

        public Task<List<string>> GetListRolesUser(string id);
    }
}
