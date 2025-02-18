using AppTicketV2.DTOs;
using AppTicketV2.ViewModels;
using DataAccess.EF.Models;
using Humanizer;

namespace AppTicketV2.Mappers
{
    public static class OperatorMapper
    {
        public static OperatorViewModel OperatorToOperatorViewModel(Operator Operator)
        {
            OperatorViewModel vm = new OperatorViewModel();
            vm.CreatedDate = Operator.CreatedDate;
            vm.OperatorID = Operator.OperatorID;
            vm.ParentID = Operator.ParentID;
            vm.Username = Operator.Username;
            vm.Password = Operator.Password;
            vm.Status = Operator.Status;
            vm.FirstName = Operator.FirstName;
            vm.LastName = Operator.LastName;
            vm.ParentID = Operator.ParentID;

            return vm;
        }

        public static OperatorViewModel OperatorDtoToOperatorViewModel(OperatorDTO dto)
        {
            OperatorViewModel vm = new OperatorViewModel();
            vm.CreatedDate = dto.CreatedDate;
            vm.OperatorID = dto.OperatorID;
            vm.ParentID = dto.ParentID;
            vm.Username = dto.Username;
            vm.Password = dto.Password;
            vm.Status = dto.Status;
            vm.FirstName = dto.FirstName;
            vm.LastName = dto.LastName;
            vm.ParentID = dto.ParentID;
            return vm;

        }

        public static Operator OperatorViewModelToOperator(OperatorViewModel vm, Operator entity)
        {

            entity.CreatedDate = vm.CreatedDate;
            entity.OperatorID = vm.OperatorID;
            entity.ParentID = vm.ParentID;
            entity.Username = vm.Username;
            entity.Password = vm.Password;
            entity.Status = vm.Status;
            entity.FirstName = vm.FirstName;
            entity.LastName = vm.LastName;
            entity.ParentID = vm.ParentID;
            return entity;
        }
    }
}
