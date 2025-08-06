using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;

namespace PrototipoApi.Controllers
{
    [Route("api/managementbudgets")]
    [ApiController]
    public class ManagementBudgetsController : ControllerBase
    {
        private readonly ContextoBaseDatos _context;

        public ManagementBudgetsController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: api/ManagementBudgets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagementBudgetDto>>> GetManagementBudget()
        {
            var budgets = await _context.ManagementBudgets.ToListAsync();
            var dtos = budgets.Select(b => new ManagementBudgetDto
            {
                ManagementBudgetId = b.ManagementBudgetId,
                InitialAmount = b.InitialAmount,
                CurrentAmount = b.CurrentAmount,
                LastUpdatedDate = b.LastUpdatedDate
            }).ToList();
            return Ok(dtos);
        }

        //// GET: api/ManagementBudgets/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ManagementBudgetDto>> GetManagementBudget(int id)
        //{
        //    var b = await _context.ManagementBudget.FindAsync(id);
        //    if (b == null)
        //        return NotFound();
        //    var dto = new ManagementBudgetDto
        //    {
        //        ManagementBudgetId = b.ManagementBudgetId,
        //        InitialAmount = b.InitialAmount,
        //        CurrentAmount = b.CurrentAmount,
        //        LastUpdatedDate = b.LastUpdatedDate
        //    };
        //    return Ok(dto);
        //}

        // PUT: api/ManagementBudgets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagementBudget(int id, ManagementBudgetDto dto)
        {
            if (id != dto.ManagementBudgetId)
                return BadRequest();
            var entity = await _context.ManagementBudgets.FindAsync(id);
            if (entity == null)
                return NotFound();
            entity.InitialAmount = dto.InitialAmount;
            entity.CurrentAmount = dto.CurrentAmount;
            entity.LastUpdatedDate = dto.LastUpdatedDate;
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagementBudgetExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        //// POST: api/ManagementBudgets
        //[HttpPost]
        //public async Task<ActionResult<ManagementBudgetDto>> PostManagementBudget(ManagementBudgetDto dto)
        //{
        //    var entity = new ManagementBudget
        //    {
        //        InitialAmount = dto.InitialAmount,
        //        CurrentAmount = dto.CurrentAmount,
        //        LastUpdatedDate = dto.LastUpdatedDate
        //    };
        //    _context.ManagementBudget.Add(entity);
        //    await _context.SaveChangesAsync();
        //    dto.ManagementBudgetId = entity.ManagementBudgetId;
        //    return CreatedAtAction(nameof(GetManagementBudget), new { id = entity.ManagementBudgetId }, dto);
        //}

        //// DELETE: api/ManagementBudgets/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteManagementBudget(int id)
        //{
        //    var entity = await _context.ManagementBudget.FindAsync(id);
        //    if (entity == null)
        //        return NotFound();
        //    _context.ManagementBudget.Remove(entity);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        private bool ManagementBudgetExists(int id)
        {
            return _context.ManagementBudgets.Any(e => e.ManagementBudgetId == id);
        }
    }
}
