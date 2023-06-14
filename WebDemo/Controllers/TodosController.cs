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
    //public static class DataStore
    //{
    //    public static List<Todo> todos = new()
    //    {
    //        new Todo{Id = "1", Name = "Todo1", Content = "Descr1 more information on enabling Web API for empty projects", Priority = 3, Status = "New" },
    //        new Todo{Id = "2", Name = "Todo2", Content = "Descr2 more information on enabling Web API for empty projects", Priority = 3, Status = "New" },
    //        new Todo{Id = "3", Name = "Todo3", Content = "Descr3 more information on enabling Web API for empty projects", Priority = 3, Status = "New" },

    //    };


    //    public static List<Vendor> vendors = new()
    //    {
    //        new Vendor{Id = 1, FirstName = "Adam1", LastName = "Vendor1", HourlyRate = 100, Status = Status.Applicant},
    //        new Vendor{Id = 2, FirstName = "Adam2", LastName = "Vendor2", HourlyRate = 100, Status = Status.Applicant},
    //        new Vendor{Id = 3, FirstName = "Adam3", LastName = "Vendor3", HourlyRate = 100, Status = Status.Applicant},

    //    };
    //}

        [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IVendorRepository vendorRepository;
        private readonly ITodoRepository repository;



        // private IValidator<Todo> validator;
        // TodoValidator validator = new TodoValidator(DataStore.todos);

        public TodosController(IVendorRepository vendorRepository, ITodoRepository repository, IValidator<Todo> validator)
        {
            this.vendorRepository = vendorRepository;
            this.repository = repository; // as TodoRepository;//this.validator = validator;
        }


        [HttpGet]
        public ActionResult<List<Todo>> GetAllTodos()
        {
            return Ok(DataStore.todos);
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> Get(string id)
        {
            Todo todo;
            try
            {
                todo = repository.Get(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
           
            return Ok(todo);
        }

        [HttpPost]
        public ActionResult<List<Todo>> AddTodo(Todo todo)
        {
            TodoValidator todoValidator = new(DataStore.todos);
            var validatorResult = todoValidator.Validate(todo);

            if (!validatorResult.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
            }

            repository.Add(todo);
            return Ok(DataStore.todos);
        }

        //[HttpPost]
        //public ActionResult<List<Vendor>> AddVendor(Vendor vendor)
        //{
        //    VendorValidator todoValidator = new();
        //    var validatorResult = todoValidator.Validate(vendor);

        //    if (!validatorResult.IsValid)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
        //    }

        //    vendorRepository.Add(vendor);
        //    return Ok(DataStore.vendors);
        //}



        [HttpPut("{id}")]
        public ActionResult<Todo> UpdateTodo(Todo req)
        {
            try
            {
                var todo = repository.Update(req);
            }
            catch (Exception)
            {
                return NotFound("Todo not found"); 
            }
            
            return Ok(DataStore.todos);
        }

        [HttpDelete("{id}")]
        public ActionResult<Todo> DeleteTodo(string id)
        {
            Todo todo;
            try
            {
                todo = repository.Delete(id);
            }
            catch (Exception)
            {
                return NotFound("Todo not found");
            }

            return Ok(todo);
        }
    }
}