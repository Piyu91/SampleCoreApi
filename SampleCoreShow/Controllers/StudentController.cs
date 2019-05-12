using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleCoreShow.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : ControllerBase
    {
        private readonly IBusiness _business;
        public StudentController(IBusiness business)
        {
            _business = business;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _business.getStudents();
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_business.getStudentById(id));
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError); 
            }
        }
    }
}