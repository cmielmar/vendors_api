using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using TodoApp.Models;
using WebDemo.Services;
using WebDemo.Validators;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDemo.Controllers
{
    public static class DataStore
    {
        public static List<Todo> todos = new()
        {
            new Todo{Id = "1", Name = "Todo1", Content = "Descr1 more information on enabling Web API for empty projects", Priority = 3, Status = "New" },
            new Todo{Id = "2", Name = "Todo2", Content = "Descr2 more information on enabling Web API for empty projects", Priority = 3, Status = "New" },
            new Todo{Id = "3", Name = "Todo3", Content = "Descr3 more information on enabling Web API for empty projects", Priority = 3, Status = "New" },

        };

        public static List<Vendor> vendors = new()
        {
            new Vendor{Id = 1, FirstName = "Adam1", LastName = "Vendor1", HourlyRate = 100, Status = "Applicant"},
            new Vendor{Id = 2, FirstName = "Adam2", LastName = "Vendor2", HourlyRate = 100, Status = "Applicant"},
            new Vendor{Id = 3, FirstName = "Adam3", LastName = "Vendor3", HourlyRate = 100, Status = "Applicant"},

        };

        //public static List<Vendor> vendors = new()
        //{
        //    new Vendor{Id = 1, FirstName = "Adam1", LastName = "Vendor1", HourlyRate = 100, Status = Status.Applicant},
        //    new Vendor{Id = 2, FirstName = "Adam2", LastName = "Vendor2", HourlyRate = 100, Status = Status.Applicant},
        //    new Vendor{Id = 3, FirstName = "Adam3", LastName = "Vendor3", HourlyRate = 100, Status = Status.Applicant},

        //};

        //public static List<Vendor> vendors = new()
        //{
        //    new Vendor{Id = 1, FirstName = "Adam1", LastName = "Vendor1"},
        //    new Vendor{Id = 2, FirstName = "Adam2", LastName = "Vendor2"},
        //    new Vendor{Id = 3, FirstName = "Adam3", LastName = "Vendor3"},

        //};
    }

    [ApiController]
    [Route("api/[controller]")]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorRepository vendorRepository;

        public VendorsController(IVendorRepository vendorRepository, IValidator<Todo> validator)
        {
            this.vendorRepository = vendorRepository;
        }


        [HttpGet]
        public ActionResult<List<Vendor>> GetAllVendors()
        {
            return Ok(DataStore.vendors);
        }

      

        [HttpGet("{id}")]
        public ActionResult<Vendor> Get(int id)
        {
            Vendor vendor;
            try
            {
                vendor = vendorRepository.Get(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
           
            return Ok(vendor);
        }

        [HttpPost]
        public ActionResult<List<Vendor>> Add(Vendor vendor)
        {
            vendorRepository.Add(vendor);
            return Ok(DataStore.vendors);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Vendor req)
        {
            try
            {
                vendorRepository.Update(req);
            }
            catch (Exception)
            {
                return NotFound("Vendor not found"); 
            }
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id)
        {
            try
            {
                vendorRepository.Delete(id);
            }
            catch (Exception)
            {
                return NotFound("Vendor not found");
            }

            return Ok();
        }
    }
}