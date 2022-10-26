using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DRBAPI.Data;
using DRBAPI.Models;

namespace DRBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabangsController : ControllerBase
    {
        private readonly DRBAPIContext _context;
        private readonly DRContextProcedures _contextProcedures;


        public CabangsController(DRBAPIContext context, 
            DRContextProcedures contextProcedures)
        {
            _context = context;
            _contextProcedures = contextProcedures;
        }

        // GET: api/Cabangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cabang>>> GetCabangs()
        {
            return await _context.Cabangs.ToListAsync();
        }

        // GET: api/Cabangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cabang>> GetCabang(string id)
        {
            var cabang = await _context.Cabangs.FindAsync(id);

            if (cabang == null)
            {
                return NotFound();
            }

            return cabang;
        }

        // PUT: api/Cabangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCabang(string id, Cabang cabang)
        {
            if (id != cabang.KodeCabang)
            {
                return BadRequest();
            }

            _context.Entry(cabang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabangExists(id))
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

        // POST: api/Cabangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cabang>> PostCabang(Cabang cabang)
        {
            _context.Cabangs.Add(cabang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CabangExists(cabang.KodeCabang))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCabang", new { id = cabang.KodeCabang }, cabang);
        }

        // DELETE: api/Cabangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCabang(string id)
        {
            var cabang = await _context.Cabangs.FindAsync(id);
            if (cabang == null)
            {
                return NotFound();
            }

            _context.Cabangs.Remove(cabang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CabangExists(string id)
        {
            return _context.Cabangs.Any(e => e.KodeCabang == id);
        }

        //calling stored procedure
        [HttpGet("GetCabangProcedure")]
        public async Task<IEnumerable<ProcCabang>> GetCabangProcedure(string xkode_cabang, string xnama_cabang, string xalamat, string xwilayah, int xperintah, string cari)

        {
            return await _contextProcedures.ProcCabangs
                .FromSqlRaw("call proc_cabang({0},{1},{2},{3},{4},{5})", xkode_cabang, xnama_cabang,xalamat , xwilayah , xperintah , cari )
                .ToListAsync();
        }
    }
}

