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
            organ.Address = organization.Address;
            organ.CreatedDate = organization.CreatedDate;
            organ.OrganizationType = organization.OrganizationType;
            organ.Tel = organization.Tel;
            return organ;

        }

        public static Organization OrganizationViewModelToOrganization(OrganizationViewModel orgvm , Organization orgEntity)
        {
            
            orgEntity.OrganizationName = orgvm.OrganizationName;
            orgEntity.Address = orgvm.Address;
            orgEntity.CreatedDate= orgvm.CreatedDate;
            orgEntity.OrganizationType=orgvm.OrganizationType.ToString();
            orgEntity.Tel = orgvm.Tel;

            return orgEntity;
        }
    }
}
