using AppEnvironment;
using Business.CityBusinessService;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace HuseyinBerkayTelli_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityBusinessService _cityBusinessService;
        public CityController(ICityBusinessService cityBusinessService)
        {
            _cityBusinessService = cityBusinessService;
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CityVM model)
        {

            var createCity = _cityBusinessService.Create(model);
            if (!createCity.IsSuccess)
            {
                return BadRequest(createCity.Message ?? MessageType.RecordAlreadyExists.ToString());
            }
            return Ok(createCity.Data);
        }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var delCity = _cityBusinessService.Remove(id);
            if (!delCity.IsSuccess)
            {
                return BadRequest(delCity.Message ?? MessageType.DeleteFailed.ToString());
            }
            return Ok(delCity.Message ?? MessageType.DeleteSuccess.ToString());
        }
        [HttpPut]

        [Route("Update/{id:int}")]
        public IActionResult Update(int id, [FromBody] CityVM request)
        {
            var zoneCity = _cityBusinessService.Edit(id, request);
            if (!zoneCity.IsSuccess)
            {
                return BadRequest(zoneCity.Message ?? MessageType.UpdateFailed.ToString());
            }
            return Ok(zoneCity.Data);

        }
        [HttpGet]
        [Route("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var cityBy = _cityBusinessService.GetById(id);
            if (!cityBy.IsSuccess)
            {
                return BadRequest(cityBy.Message ?? MessageType.RecordNotFound.ToString());
            }
            return Ok(cityBy.Data);
        }
        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {

            var zone = _cityBusinessService.GetAll();
            if (!zone.IsSuccess)
            {
                return BadRequest(zone.Message ?? MessageType.RecordNotFound.ToString());
            }
            return Ok(zone.Data);

        }
    }
}
