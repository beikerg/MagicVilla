﻿using MagicVilla.Datos;
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
        private readonly ILogger<PersonalController> _logger;
        private readonly SoftlandDbContext _dbContext;

        public PersonalController(ILogger<PersonalController> logger, SoftlandDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
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


        [HttpGet("Personal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        }

        [HttpGet("rut")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Personal> GetPersonal(string databaseName, string Ficha)
        {
            if(databaseName == null || Ficha == null ) 
            {
                _logger.LogError("Error al traer datos " + Ficha);
                return BadRequest();
            }

            //Cambiar base de datos
            var result = CambiarBase(databaseName);

            if(result is OkObjectResult) 
            {
                var personal = _dbContext.sw_personal.FirstOrDefault(p => p.ficha == Ficha);

                if(personal == null)
                {
                    return NotFound(personal);
                }

                return Ok(personal);
            }
            else
            {
                return BadRequest(result);
            }

        }

        


     
    }
}
 