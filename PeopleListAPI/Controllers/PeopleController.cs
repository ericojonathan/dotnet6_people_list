using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleList.Domain.Interfaces;
using PeopleList.Domain.Entities;

namespace PeopleListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PeopleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return Ok(await _unitOfWork.People.GetAllAsync());
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(long id)
        {            
            var person = await _unitOfWork.People.FindAsync(p => p.ID == id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPerson(long id, Person person)
        {
            //if (id != person.ID || person?.FirstName?.Count() < 3)
            //{
            //    return BadRequest();
            //}

            ////_context.Entry(person).State = EntityState.Modified;            
            //await _unitOfWork.People.UpdatePerson(person);
            //_unitOfWork.Complete();            

            return NoContent();
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            if (person?.FirstName?.Count() < 3)
            {
                return BadRequest();
            }
            
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetPerson", new { id = person?.ID }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(long id)
        {
            var person = await _unitOfWork.People.FindAsync((p) => p.ID == id);
            if (person == null)
            {
                return NotFound();
            }
            
            _unitOfWork.People.Remove(person.First());
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        private bool PersonExists(long id)
        {
            return _unitOfWork.People.GetAll().Any(p => p.ID == id);
        }
    }
}
