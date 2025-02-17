using AppTicketV2.DTOs;
using AppTicketV2.ViewModels;
using DataAccess.EF.Models;
using Humanizer;

namespace AppTicketV2.Mappers
{
    public static class PortalMapper
    {
        public static PortalViewModel PortalToPortalViewModel(Portal portal)
        {
            PortalViewModel vm = new PortalViewModel();
            vm.PortalUrl = portal.PortalUrl;
            vm.PortalID = portal.PortalID;
            vm.PortalName = portal.PortalName;
            vm.WidgetID = portal.WidgetID;
            vm.ParentPortalID = portal.ParentPortalID;
            vm.OrgID = portal.OrgID;
            vm.WidgetPropertyID = portal.WidgetPropertyID.Value;
            
            return vm;
        }

        public static PortalViewModel PortalDtoToPortalViewModel(PortalDTO dto)
        {
            PortalViewModel vm = new PortalViewModel();
            vm.PortalUrl = dto.PortalUrl;
            vm.PortalID = dto.PortalID;
            vm.PortalName = dto.PortalName;
            vm.WidgetID = dto.WidgetID;
            vm.ParentPortalID = dto.ParentPortalID;
            vm.OrgID = dto.OrgID;
            vm.WidgetPropertyID = dto.WidgetPropertyID;
            return vm;

        }

        public static Portal PortalViewModelToPortal(PortalViewModel vm, Portal entity)
        {

            entity.PortalUrl = vm.PortalUrl;
            entity.PortalID = vm.PortalID;
            entity.PortalName = vm.PortalName;
            entity.WidgetID = vm.WidgetID;
            entity.ParentPortalID = vm.ParentPortalID;
            entity.OrgID = vm.OrgID;
            entity.WidgetPropertyID = vm.WidgetPropertyID;
            return entity;
        }
    }
}
