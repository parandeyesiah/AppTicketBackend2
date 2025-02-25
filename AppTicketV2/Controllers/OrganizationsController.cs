using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.EF.DBContext;
using DataAccess.EF.Models;
using AppTicketV2.ViewModels;
using DataAccess;
using DataAccess.EF.DBContext;
using DataAccess.EF.Models;
using AppTicketV2.Mappers;
using AppTicketV2.DTOs;

namespace AppTicketV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly AppTicketDBContext _context;

        public OrganizationsController(AppTicketDBContext context)
        {
            _context = context;
        }

        // GET: api/Organizations
        [HttpGet]
        public async Task<IEnumerable<OrganizationViewModel>> GetOrganizations()
        {
            //return await _context.Organizations.ToListAsync();
            IEnumerable<Organization> orgs =await  OrganizationData.GetAllOrganizations(_context);
            List<OrganizationViewModel> output = new List<OrganizationViewModel>();
            orgs.ToList().ForEach(org => {
                OrganizationViewModel organ = new OrganizationViewModel();
                organ = OrganizationMapper.OrganizationToOrganizationModel(org);
                
                output.Add(organ);
            });

            return output;
        }

        //GET: api/Organizations/5
        [HttpGet("{id}")]
        public async Task<OrganizationViewModel> GetOrganization(int id)
        {
            var organization = await OrganizationData.GetOrganizationById(_context,id);
            
            if (organization == null)
            {
                return new OrganizationViewModel();
            }
            OrganizationViewModel organ = new OrganizationViewModel();
            organ = OrganizationMapper.OrganizationToOrganizationModel(organization);
            return organ;
        }

        //// PUT: api/Organizations/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<APIOutput> PutOrganization(OrganizationDTO organization)
        {
            APIOutput output = new APIOutput();
            var orgEntity = await OrganizationData.GetOrganizationById(_context, Int32.Parse(organization.OrganizationID));
            if (orgEntity == null)
            {
                output.status = "false";
                output.message = "چنین سازمانی یافت نشد.";
                return output;
            }
            OrganizationViewModel orgvm = OrganizationMapper.OrganizationDtoToOrganizationViewModel(organization);
            orgEntity = OrganizationMapper.OrganizationViewModelToOrganization(orgvm, orgEntity);
            await _context.SaveChangesAsync();



            return output;
        }

        //// POST: api/Organizations
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<APIOutput> PostOrganizations([FromBody] OrganizationDTO organization)
        {
            APIOutput output = new APIOutput();
            OrganizationViewModel orgvm = OrganizationMapper.OrganizationDtoToOrganizationViewModel(organization);
            Organization orgEntity = new Organization();
            orgEntity = OrganizationMapper.OrganizationViewModelToOrganization(orgvm, orgEntity);
            //_context.Organizations.Add(organization);
            OrganizationData.CreateOrganization(_context, orgEntity);
            await _context.SaveChangesAsync();
            return output ;
           // return CreatedAtAction("GetOrganization", new { id = organization.OrganizationID }, organization);
        }

        //// DELETE: api/Organizations/5
        [HttpDelete("{id}")]
        public APIOutput DeleteOrganization(int id)
        {
            APIOutput output = new APIOutput();
            OrganizationData.DeleteOrganization(_context, id);
            _context.SaveChanges();

            return output;
        }

        //private bool OrganizationExists(int id)
        //{
        //    return _context.Organizations.Any(e => e.OrganizationID == id);
        //}
    }
}
