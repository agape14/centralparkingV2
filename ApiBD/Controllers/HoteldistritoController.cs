using ApiBD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [Route("api/hoteldistritos")]
    [ApiController]
    public class HoteldistritoController : Controller
    {
        public HoteldistritoController() { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDistrito>>> Get()
        {
            var hotelDistritos = new List<HotelDistrito>
            {
                new HotelDistrito { Hotel = "Marriott",                     Distrito = "MIRAFLORES",    CodDistrito = "150122" },
                new HotelDistrito { Hotel = "Clinica Stella Maris",         Distrito = "PUEBLO LIBRE",  CodDistrito = "150121" },
                new HotelDistrito { Hotel = "Hotel Pullman",                Distrito = "SAN ISIDRO",    CodDistrito = "150131" },
                new HotelDistrito { Hotel = "BBVA Oficinas Corporativas",   Distrito = "SAN ISIDRO",    CodDistrito = "150131" },
                new HotelDistrito { Hotel = "CC. Polo I",                   Distrito = "SURCO",         CodDistrito = "150140" },
                new HotelDistrito { Hotel = "CC. Polo II",                  Distrito = "SURCO",         CodDistrito = "150140" },
                new HotelDistrito { Hotel = "Pacifico Seguros",             Distrito = "SAN ISIDRO",    CodDistrito = "150131" },
                new HotelDistrito { Hotel = "Clinica Tezza",                Distrito = "SURCO",         CodDistrito = "150140" },
                new HotelDistrito { Hotel = "Sagrado Corazón de Jesus",     Distrito = "SURCO",         CodDistrito = "150140" },
                new HotelDistrito { Hotel = "Edificio More",                Distrito = "SURCO",         CodDistrito = "150140" },
                new HotelDistrito { Hotel = "Hotel Sheraton",               Distrito = "LIMA",          CodDistrito = "150101" },
                new HotelDistrito { Hotel = "Prime Towers",                 Distrito = "MAGDALENA",     CodDistrito = "150120" },
                new HotelDistrito { Hotel = "Hotel Pullman",                Distrito = "MIRAFLORES",    CodDistrito = "150122" }
            };
            return hotelDistritos;
        }
    }
}
