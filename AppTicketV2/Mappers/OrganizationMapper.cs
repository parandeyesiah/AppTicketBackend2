using AppTicketV2.DTOs;
using AppTicketV2.ViewModels;
using DataAccess.EF.Models;

namespace AppTicketV2.Mappers
{
    public static class OrganizationMapper
    {
        public static OrganizationViewModel OrganizationToOrganizationModel(Organization organization)
        {
            OrganizationViewModel organ = new OrganizationViewModel();
            organ.OrganizationID = organization.OrganizationID.ToString();
            organ.OrganizationName = organization.OrganizationName;

            return organ;
        }

        public static OrganizationViewModel OrganizationDtoToOrganizationViewModel(OrganizationDTO organization)
        {
            OrganizationViewModel organ = new OrganizationViewModel();
            organ.OrganizationID = organization.OrganizationID;
            organ.OrganizationName = organization.OrganizationName;
            return organ;

        }

        public static Organization OrganizationViewModelToOrganization(OrganizationViewModel orgvm , Organization orgEntity)
        {
            
            orgEntity.OrganizationName = orgvm.OrganizationName;

            return orgEntity;
        }
    }
}
