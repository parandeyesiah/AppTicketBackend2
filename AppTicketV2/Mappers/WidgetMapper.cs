using AppTicketV2.DTOs;
using AppTicketV2.ViewModels;
using DataAccess.EF.Models;

namespace AppTicketV2.Mappers
{
    public static class WidgetMapper
    {
        public static WidgetViewModel WidgetToWidgetViewModel(Widget widget)
        {
            WidgetViewModel widgetVM = new WidgetViewModel();
            widgetVM.WidgetID = widget.WidgetID.ToString();
            widgetVM.WidgetName = widget.WidgetName;
            widgetVM.Color = widget.Color;
            widgetVM.Position = widget.Position;

            return widgetVM;
        }

        public static WidgetViewModel WidgetDtoToWidgetViewModel(WidgetDTO dto)
        {
            WidgetViewModel vm = new WidgetViewModel();
            vm.WidgetID = dto.WidgetID;
            vm.WidgetName = dto.WidgetName;
            vm.Color = dto.Color;
            vm.Position = dto.Position;
            return vm;

        }

        public static Widget WidgetViewModelToWidget(WidgetViewModel vm , Widget entity)
        {
            
            entity.WidgetName = vm.WidgetName;
            entity.Color = vm.Color;
            entity.Position = vm.Position;

            return entity;
        }
    }
}
