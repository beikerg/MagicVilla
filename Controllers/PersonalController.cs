using MagicVilla.Datos;
using MagicVilla.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Cryptography.X509Certificates;

namespace MagicVilla.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonalController : ControllerBase
    {
        private readonly SoftlandDbContext _dbContext;

        public PersonalController(SoftlandDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        private IActionResult CambiarBase(string databaseName)
        {

            var connectionString = _dbContext.Database.GetConnectionString();
            var builder = new SqlConnectionStringBuilder(connectionString);
            builder.InitialCatalog = databaseName;

            try
            {
                _dbContext.Database.SetConnectionString(builder.ConnectionString);
                _dbContext.Database.EnsureCreated();

                // Realiza alguna operación de prueba para validar la conexión y la base de datos
                //var count = _dbContext.sw_personal.Count();

                var connectionString2 = _dbContext.Database.GetConnectionString();


                var personal = _dbContext.meses.Count();

                return Ok(new { message = "La base de datos se ha cambiado correctamente.", connectionString2, personal });
            }
            catch (SqlException ex)
            {
                var errorMessages = new List<string>();

                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Add($"Error {i + 1}: {ex.Errors[i].Message}");
                }

                return BadRequest($"Error al cambiar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                // ...

                return BadRequest($"Error al cambiar la base de datos: {ex.Message}");
            }
        }


        [HttpGet("{databaseName}")]
        public ActionResult<IEnumerable<Personal>> Get(string databaseName)
        {

            var result = CambiarBase(databaseName);

            if(result is OkObjectResult)
            {
                var personal = _dbContext.sw_personal.ToList();

                return Ok(personal);
            }
            else
            {
                
                return Ok(result);

            } 


            //var connectionString = _dbContext.Database.GetConnectionString();
            //var builder = new SqlConnectionStringBuilder(connectionString);
            //builder.InitialCatalog = databaseName;

            //try
            //{
            //    _dbContext.Database.SetConnectionString(builder.ConnectionString);
            //    _dbContext.Database.EnsureCreated();

            //    // Realiza alguna operación de prueba para validar la conexión y la base de datos
            //    //var count = _dbContext.sw_personal.Count();

            //    var connectionString2 = _dbContext.Database.GetConnectionString();

            //    if(databaseName == "ORBIZ")
            //    {

            //        var personal = _dbContext.meses.ToList();

            //        return Ok(new { message = "La base de datos se ha cambiado correctamente.", connectionString2, personal });

            //    }

            //    if(databaseName == "SwMaritimos")
            //    {
            //        var personal = _dbContext.SwBDSoftland.ToList();
            //        return Ok(new { message = "La base de datos se ha cambiado correctamente.", connectionString2, personal });
            //    }

            //    if(databaseName == "TIENDADB")
            //    {
            //        var personal = _dbContext.Productos.ToList();
            //        return Ok(new { message = "La base de datos se ha cambiado correctamente.", connectionString2, personal });
            //    }

            //    return Ok("Casa");


            //}
            //catch (SqlException ex)
            //{
            //    var errorMessages = new List<string>();

            //    for (int i = 0; i < ex.Errors.Count; i++)
            //    {
            //        errorMessages.Add($"Error {i + 1}: {ex.Errors[i].Message}");
            //    }

            //    return BadRequest($"Error al cambiar la base de datos: {string.Join("; ", errorMessages)}");
            //}

            //catch (Exception ex)
            //{
            //    return BadRequest($"Error al cambiar la base de datos: {ex.Message}");
            //}
        }

      



        //[HttpGet("{databaseName}")]
        //public IActionResult GetClientes(string databaseName)
        //{
        //   var connectionString = configuration.GetConnectionString("DefaultConnection")
        //      .Replace("{{databaseName}}", databaseName);

        //using (var dbContext = new SoftDbContext(connectionString))
        //{
        // var personal = dbContext.sw_personal.ToList();
        //return Ok(personal);
        //  return Ok(connectionString);
        //}
        //}
    }
}
