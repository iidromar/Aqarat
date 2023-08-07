using HSPA.Data;
using HSPA.Interfaces;
using HSPA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HSPA.Dtos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace HSPA.Controllers
{
    [Authorize]
    public class CityController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork uow, IMapper mapper) { 
            this.uow = uow;
            this.mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await uow.CityRepository.GetCitiesAsync();
            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);
            return Ok(citiesDto);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = mapper.Map<City>(cityDto);
            city.LastUpdatedBy = 1;
            city.LastUpdatedOn = DateTime.Now;
            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
        {
            //try
            //{
                //if (id != cityDto.Id)
                //    return BadRequest("Update Not Allowed");
                var cityFromDB = await uow.CityRepository.FindCity(id);
                //if (cityFromDB == null)
                //    return BadRequest("Update Not Allowed");
                cityFromDB.LastUpdatedBy = 1;
                cityFromDB.LastUpdatedOn = DateTime.Now;
                mapper.Map(cityDto, cityFromDB);
                await uow.SaveAsync();
                return StatusCode(200);
            //}
            //catch
            //{
            //    return StatusCode(500, "Some Unkown Error Occured.");
            //}
  
        }
        [HttpPut("updateCityName/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityUpdateDto cityDto)
        {
            var cityFromDB = await uow.CityRepository.FindCity(id);
            cityFromDB.LastUpdatedBy = 1;
            cityFromDB.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDto, cityFromDB);
            await uow.SaveAsync();
            return StatusCode(200);
        }
        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
        {
            var cityFromDB = await uow.CityRepository.FindCity(id);
            cityFromDB.LastUpdatedBy = 1;
            cityFromDB.LastUpdatedOn = DateTime.Now;
            cityToPatch.ApplyTo(cityFromDB, ModelState);
            await uow.SaveAsync();
            return StatusCode(200);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.CityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return Ok(id);
        }


    }
}
