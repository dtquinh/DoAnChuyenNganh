using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi_doanchuyennganh.Models;

namespace webApi_doanchuyennganh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailsController : ControllerBase
    {
        private readonly doanchuyennganhContext _context;

        public BillDetailsController(doanchuyennganhContext context)
        {
            _context = context;
        }

        // GET: api/BillDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillDetail>>> GetBillDetails()
        {
            return await _context.BillDetails.ToListAsync();
        }

        // GET: api/BillDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillDetail>> GetBillDetail(int id)
        {
            var billDetail = await _context.BillDetails.FindAsync(id);

            if (billDetail == null)
            {
                return NotFound();
            }

            return billDetail;
        }

        // PUT: api/BillDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillDetail(int id, BillDetail billDetail)
        {
            if (id != billDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(billDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BillDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BillDetail>> PostBillDetail(BillDetail billDetail)
        {
            _context.BillDetails.Add(billDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BillDetailExists(billDetail.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBillDetail", new { id = billDetail.Id }, billDetail);
        }

        // DELETE: api/BillDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillDetail>> DeleteBillDetail(int id)
        {
            var billDetail = await _context.BillDetails.FindAsync(id);
            if (billDetail == null)
            {
                return NotFound();
            }

            _context.BillDetails.Remove(billDetail);
            await _context.SaveChangesAsync();

            return billDetail;
        }

        private bool BillDetailExists(int id)
        {
            return _context.BillDetails.Any(e => e.Id == id);
        }
    }
}
