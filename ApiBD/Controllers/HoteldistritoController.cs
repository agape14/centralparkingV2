using ApiBD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ApiBD.Controllers
{
    [Route("api/hoteldistritos")]
    [ApiController]
    public class HoteldistritoController : Controller
    {
        private readonly CentralParkingContext _dbContext;
        public HoteldistritoController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDistrito>>> Get()
        {
            var hotelDistritos = new List<HotelDistrito>
            {
                new HotelDistrito { Hotel = "Marriott",                     Distrito = "MIRAFLORES",    CodDistrito = "150122" },
                new HotelDistrito { Hotel = "Hotel Pullman",                Distrito = "MIRAFLORES",    CodDistrito = "150122" },
                new HotelDistrito { Hotel = "Clinica Stella Maris",         Distrito = "PUEBLO LIBRE",  CodDistrito = "150121" },
                new HotelDistrito { Hotel = "Hotel Pullman",                Distrito = "SAN ISIDRO",    CodDistrito = "150131" },
                new HotelDistrito { Hotel = "BBVA Oficinas Corporativas",   Distrito = "SAN ISIDRO",    CodDistrito = "150131" },
                new HotelDistrito { Hotel = "Pacifico Seguros",             Distrito = "SAN ISIDRO",    CodDistrito = "150131" },
                new HotelDistrito { Hotel = "CC. Polo I",                   Distrito = "SURCO",         CodDistrito = "150140" },
                new HotelDistrito { Hotel = "CC. Polo II",                  Distrito = "SURCO",         CodDistrito = "150140" },
                new HotelDistrito { Hotel = "Clinica Tezza",                Distrito = "SURCO",         CodDistrito = "150140" },
                new HotelDistrito { Hotel = "Sagrado Corazón de Jesus",     Distrito = "SURCO",         CodDistrito = "150140" },
                new HotelDistrito { Hotel = "Edificio More",                Distrito = "SURCO",         CodDistrito = "150140" },
                new HotelDistrito { Hotel = "Hotel Sheraton",               Distrito = "LIMA",          CodDistrito = "150101" },
                new HotelDistrito { Hotel = "Prime Towers",                 Distrito = "MAGDALENA",     CodDistrito = "150120" },
                
            };
            return hotelDistritos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TbConfUbigeoServicio>>> GetDistritoPorIdServicio(int id)
        {
            var listUbiServ = from datos in this._dbContext.TbConfUbigeoServicios
                              where datos.IdServicio == id
                              select datos;
            var ubigeoservicio = await listUbiServ
                .Include(t => t.TbConfUbigeo)
                .AsNoTracking()
                .ToListAsync();

            if (ubigeoservicio == null)
            {
                return NotFound();
            }
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                MaxDepth = 64
            };

            var ubiserJson = JsonSerializer.Serialize(ubigeoservicio, options);

            // Retorna la respuesta JSON
            return Ok(ubiserJson);
        }

        //[HttpGet("{codubi}")]
        //[Route("estacionamientos")]
        //public async Task<ActionResult<IEnumerable<TbEstacionamiento>>> GetEstacionamientoPorIdDistrito(string codubi)
        //{
        //    var listEstacionamientos = from datos in this._dbContext.TbEstacionamientos
        //                      where datos.CodUbi == codubi
        //                      select datos;
        //    var estacionamientos = await listEstacionamientos
        //        .Include(t => t.TbConfUbigeo)
        //        .AsNoTracking()
        //        .ToListAsync();

        //    if (estacionamientos == null)
        //    {
        //        return NotFound();
        //    }
        //    var options = new JsonSerializerOptions
        //    {
        //        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        //        MaxDepth = 64
        //    };

        //    var estacionamientoJson = JsonSerializer.Serialize(estacionamientos, options);
        //    return Ok(estacionamientoJson);
        //}


    }
}
