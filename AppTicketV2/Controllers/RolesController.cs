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
    public class RolesController : ControllerBase
    {
        private readonly AppTicketDBContext _context;

        public RolesController(AppTicketDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<RoleViewModel>> GetRolesAsync()
        {

            IEnumerable<Role> Roles = RoleData.GetAllRoles(_context);
            List<RoleViewModel> output = new List<RoleViewModel>();
            Roles.ToList().ForEach(w =>
            {
                RoleViewModel Role = new RoleViewModel();
                Role = RoleMapper.RoleToRoleViewModel(w);

                output.Add(Role);
            });

            return output;
        }

        [HttpGet("{id}")]
        public async Task<RoleViewModel> GetRole(int id)
        {
            var entity = await RoleData.GetRoleById(_context, id);

            if (entity == null)
            {
                return new RoleViewModel();
            }
            RoleViewModel vm = new RoleViewModel();
            vm = RoleMapper.RoleToRoleViewModel(entity);
            return vm;
        }

        [HttpPut("{id}")]
        public async Task<APIOutput> PutRole(RoleDTO dto)
        {
            APIOutput output = new APIOutput();
            var entity = await RoleData.GetRoleById(_context, dto.RoleID);
            if (entity == null)
            {
                output.status = "false";
                output.message = "چنین اپراتوری یافت نشد.";
                return output;
            }
            RoleViewModel vm = RoleMapper.RoleDtoToRoleViewModel(dto);
            entity = RoleMapper.RoleViewModelToRole(vm, entity);
            await _context.SaveChangesAsync();



            return output;
        }

        [HttpPost]
        public async Task<APIOutput> PostRoles([FromBody] RoleDTO dto)
        {
            APIOutput output = new APIOutput();
            RoleViewModel vm = RoleMapper.RoleDtoToRoleViewModel(dto);
            Role entity = new Role();
            entity = RoleMapper.RoleViewModelToRole(vm, entity);
            //_context.Organizations.Add(organization);
            RoleData.CreateRole(_context, entity);
            await _context.SaveChangesAsync();
            return output;
            // return CreatedAtAction("GetOrganization", new { id = organization.OrganizationID }, organization);
        }

        [HttpDelete("{id}")]
        public APIOutput DeleteRole(int id)
        {
            APIOutput output = new APIOutput();
            RoleData.DeleteRole(_context, id);
            _context.SaveChanges();

            return output;
        }
    }
}
