using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.EF.DBContext;
using DataAccess.EF.Models;
using AppTicketV2.Mappers;
using AppTicketV2.ViewModels;
using DataAccess;
using AppTicketV2.DTOs;

namespace AppTicketV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetController : ControllerBase
    {
        private readonly AppTicketDBContext _context;

        public WidgetController(AppTicketDBContext context)
        {
            _context = context;
        }

        // GET: api/Widgets
        
        [HttpGet("/api/GetWidgets")]
        public async Task<IEnumerable<WidgetViewModel>> GetWidgetsAsync()
        {
            //return await _context.Organizations.ToListAsync();
            IEnumerable<Widget> widgets = WidgetData.GetAllWidgets(_context);
            List<WidgetViewModel> output = new List<WidgetViewModel>();
            widgets.ToList().ForEach(w =>
            {
                WidgetViewModel widget = new WidgetViewModel();
                widget = WidgetMapper.WidgetToWidgetViewModel(w);

                output.Add(widget);
            });

            return output;
        }

        [HttpGet("{id}")]
        public async Task<WidgetViewModel> GetWidget(int id)
        {
            var entity = await WidgetData.GetWidgetById(_context, id);

            if (entity == null)
            {
                return new WidgetViewModel();
            }
            WidgetViewModel vm = new WidgetViewModel();
            vm = WidgetMapper.WidgetToWidgetViewModel(entity);
            return vm;
        }

        [HttpPut("{id}")]
        public async Task<APIOutput> PutWidget(WidgetDTO dto)
        {
            APIOutput output = new APIOutput();
            var entity = await WidgetData.GetWidgetById(_context, Int32.Parse(dto.WidgetID));
            if (entity == null)
            {
                output.status = "false";
                output.message = "چنین ویجتی یافت نشد.";
                return output;
            }
            WidgetViewModel vm = WidgetMapper.WidgetDtoToWidgetViewModel(dto);
            entity = WidgetMapper.WidgetViewModelToWidget(vm, entity);
            await _context.SaveChangesAsync();



            return output;
        }

        [HttpPost]
        public async Task<APIOutput> PostWidgets([FromBody] WidgetDTO dto)
        {
            APIOutput output = new APIOutput();
            WidgetViewModel vm = WidgetMapper.WidgetDtoToWidgetViewModel(dto);
            Widget entity = new Widget();
            entity = WidgetMapper.WidgetViewModelToWidget(vm, entity);
            //_context.Organizations.Add(organization);
            WidgetData.CreateWidget(_context, entity);
            await _context.SaveChangesAsync();
            return output;
            // return CreatedAtAction("GetOrganization", new { id = organization.OrganizationID }, organization);
        }

        [HttpDelete("{id}")]
        public APIOutput DeleteWidget(int id)
        {
            APIOutput output = new APIOutput();
            WidgetData.DeleteWidget(_context, id);
            _context.SaveChanges();

            return output;
        }

        //private bool WidgetExists(int id)
        //{
        //    return _context.Widget.Any(e => e.WidgetID == id);
        //}
    }
}
