using AppTicketV2.DTOs;
using AppTicketV2.ViewModels;
using DataAccess.EF.Models;
using Humanizer;

namespace AppTicketV2.Mappers
{
    public static class RoleMapper
    {
        public static RoleViewModel RoleToRoleViewModel(Role Role)
        {
            RoleViewModel vm = new RoleViewModel();
            vm.RoleName = Role.RoleName;
            vm.RoleID = Role.RoleID;
            

            return vm;
        }

        public static RoleViewModel RoleDtoToRoleViewModel(RoleDTO dto)
        {
            RoleViewModel vm = new RoleViewModel();
            vm.RoleName = dto.RoleName;
            vm.RoleID = dto.RoleID;
            return vm;

        }

        public static Role RoleViewModelToRole(RoleViewModel vm, Role entity)
        {

            entity.RoleName = vm.RoleName;
            entity.RoleID = vm.RoleID;
            return entity;
        }
    }
}
