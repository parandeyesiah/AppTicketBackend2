using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.EF.DBContext;
using DataAccess.EF.Models;
using AppTicketV2.DTOs;
using AppTicketV2.Mappers;
using AppTicketV2.ViewModels;
using DataAccess;

namespace AppTicketV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortalsController : ControllerBase
    {
        private readonly AppTicketDBContext _context;

        public PortalsController(AppTicketDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<PortalViewModel>> GetPortalsAsync()
        {

            IEnumerable<Portal> Portals = PortalData.GetAllPortals(_context);
            List<PortalViewModel> output = new List<PortalViewModel>();
            Portals.ToList().ForEach(w =>
            {
                PortalViewModel Portal = new PortalViewModel();
                Portal = PortalMapper.PortalToPortalViewModel(w);

                output.Add(Portal);
            });

            return output;
        }

        [HttpGet("{id}")]
        public async Task<PortalViewModel> GetPortal(int id)
        {
            var entity = await PortalData.GetPortalById(_context, id);

            if (entity == null)
            {
                return new PortalViewModel();
            }
            PortalViewModel vm = new PortalViewModel();
            vm = PortalMapper.PortalToPortalViewModel(entity);
            return vm;
        }

        [HttpPut("{id}")]
        public async Task<APIOutput> PutPortal(PortalDTO dto)
        {
            APIOutput output = new APIOutput();
            var entity = await PortalData.GetPortalById(_context, dto.PortalID);
            if (entity == null)
            {
                output.status = "false";
                output.message = "چنین پورتالی یافت نشد.";
                return output;
            }
            PortalViewModel vm = PortalMapper.PortalDtoToPortalViewModel(dto);
            entity = PortalMapper.PortalViewModelToPortal(vm, entity);
            await _context.SaveChangesAsync();



            return output;
        }

        [HttpPost]
        public async Task<APIOutput> PostPortals([FromBody] PortalDTO dto)
        {
            APIOutput output = new APIOutput();
            PortalViewModel vm = PortalMapper.PortalDtoToPortalViewModel(dto);
            Portal entity = new Portal();
            entity = PortalMapper.PortalViewModelToPortal(vm, entity);
            //_context.Organizations.Add(organization);
            PortalData.CreatePortal(_context, entity);
            await _context.SaveChangesAsync();
            return output;
            // return CreatedAtAction("GetOrganization", new { id = organization.OrganizationID }, organization);
        }

        [HttpDelete("{id}")]
        public APIOutput DeletePortal(int id)
        {
            APIOutput output = new APIOutput();
            PortalData.DeletePortal(_context, id);
            _context.SaveChanges();

            return output;
        }
    }
}
