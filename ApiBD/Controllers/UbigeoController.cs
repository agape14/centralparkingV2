using ApiBD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ApiBD.Controllers
{
    [Route("api/ubigeo")]
    [ApiController]
    public class UbigeoController : ControllerBase
    {
        private readonly CentralParkingContext _dbContext;

        public UbigeoController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("departmentos")]
        public async Task<List<TbConfUbigeo>> GetDepartmentos()
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            var departments = await _dbContext.TbConfUbigeos
                .Select(u => new TbConfUbigeo
                {
                    CodUbi = u.CodUbi.Substring(0, 2),
                    Dpto = u.Dpto
                })
                .Distinct()
                .ToListAsync();
            var dptoJson = JsonSerializer.Serialize(departments, options);
            var DptosDeserializados = JsonSerializer.Deserialize<List<TbConfUbigeo>>(dptoJson, options);
            return DptosDeserializados;
        }

        [HttpGet("provincias/{cod}")]
        public async Task<List<TbConfUbigeo>> GetProvincias(string cod)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            var departments = await _dbContext.TbConfUbigeos.Where(u => u.CodUbi.StartsWith(cod)).Select(u => new TbConfUbigeo { CodUbi = u.CodUbi.Substring(0, 4), Prov = u.Prov })
                .Distinct()
                .ToListAsync();
            var provinciaJson = JsonSerializer.Serialize(departments, options);
            var ProvinciaDeserializados = JsonSerializer.Deserialize<List<TbConfUbigeo>>(provinciaJson, options);
            return ProvinciaDeserializados;
        }

        [HttpGet("distritos/{cod}")]
        public async Task<List<TbConfUbigeo>> GetDistritos(string cod)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            var distritos = await _dbContext.TbConfUbigeos.Where(u => u.CodUbi.StartsWith(cod)).Select(u => new TbConfUbigeo { CodUbi = u.CodUbi.Substring(0, 6), Dist = u.Dist })
                .Distinct()
                .ToListAsync();
            var distritosJson = JsonSerializer.Serialize(distritos, options);
            var DistritoDeserializados = JsonSerializer.Deserialize<List<TbConfUbigeo>>(distritosJson, options);
            return DistritoDeserializados;
        }
    }
}
