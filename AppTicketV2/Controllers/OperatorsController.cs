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
    public class OperatorsController : ControllerBase
    {
        private readonly AppTicketDBContext _context;

        public OperatorsController(AppTicketDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<OperatorViewModel>> GetOperatorsAsync()
        {

            IEnumerable<Operator> Operators = OperatorData.GetAllOperators(_context);
            List<OperatorViewModel> output = new List<OperatorViewModel>();
            Operators.ToList().ForEach(w =>
            {
                OperatorViewModel Operator = new OperatorViewModel();
                Operator = OperatorMapper.OperatorToOperatorViewModel(w);

                output.Add(Operator);
            });

            return output;
        }

        [HttpGet("{id}")]
        public async Task<OperatorViewModel> GetOperator(int id)
        {
            var entity = await OperatorData.GetOperatorById(_context, id);

            if (entity == null)
            {
                return new OperatorViewModel();
            }
            OperatorViewModel vm = new OperatorViewModel();
            vm = OperatorMapper.OperatorToOperatorViewModel(entity);
            return vm;
        }

        [HttpPut("{id}")]
        public async Task<APIOutput> PutOperator(OperatorDTO dto)
        {
            APIOutput output = new APIOutput();
            var entity = await OperatorData.GetOperatorById(_context, dto.OperatorID);
            if (entity == null)
            {
                output.status = "false";
                output.message = "چنین اپراتوری یافت نشد.";
                return output;
            }
            OperatorViewModel vm = OperatorMapper.OperatorDtoToOperatorViewModel(dto);
            entity = OperatorMapper.OperatorViewModelToOperator(vm, entity);
            await _context.SaveChangesAsync();



            return output;
        }

        [HttpPost]
        public async Task<APIOutput> PostOperators([FromBody] OperatorDTO dto)
        {
            APIOutput output = new APIOutput();
            OperatorViewModel vm = OperatorMapper.OperatorDtoToOperatorViewModel(dto);
            Operator entity = new Operator();
            entity = OperatorMapper.OperatorViewModelToOperator(vm, entity);
            //_context.Organizations.Add(organization);
            OperatorData.CreateOperator(_context, entity);
            await _context.SaveChangesAsync();
            return output;
            // return CreatedAtAction("GetOrganization", new { id = organization.OrganizationID }, organization);
        }

        [HttpDelete("{id}")]
        public APIOutput DeleteOperator(int id)
        {
            APIOutput output = new APIOutput();
            OperatorData.DeleteOperator(_context, id);
            _context.SaveChanges();

            return output;
        }
    }
}
