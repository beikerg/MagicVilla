using MagicVilla.Datos;
using MagicVilla.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanCuentasController : ControllerBase
    {
        private readonly ILogger<PlanCuentasController> _logger;
        private readonly SoftlandDbContext _dbContext;

        public PlanCuentasController(ILogger<PlanCuentasController> logger, SoftlandDbContext dbContext)
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


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<PlanCuentas>> Get(string databaseName)
        {
            var result = CambiarBase(databaseName);

            if(result is OkObjectResult)
            {
                var cuentas = _dbContext.cwpctas.ToList();
                return Ok(cuentas);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("CuentaNivel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<PlanCuentas> GetCuentaNivel(string databaseName) 
        {
            if(databaseName == null)
            {
                _logger.LogError("Error al traer datos ");
                return BadRequest();
            }

            var result = CambiarBase(databaseName);

            if(result is OkObjectResult)
            {
                var cuentaTipo = _dbContext.cwpctas.Where(c => c.PCNIVEL == 1).ToList();
                
                if(cuentaTipo == null)
                {
                    return NotFound(cuentaTipo);
                }
                return Ok(cuentaTipo);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
