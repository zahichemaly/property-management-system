using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PropertyManagementAPI.Models;
using PropertyManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace PropertyManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class ApartmentsController : Controller
    {
        private readonly ILogger<ApartmentsController> _logger;
        private IApartmentInfoRepository _apartmentInfoRepository;

        public ApartmentsController(ILogger<ApartmentsController> logger, IApartmentInfoRepository apartmentInfoRepository)
        {
            _logger = logger;
            _apartmentInfoRepository = apartmentInfoRepository;
        }
        [HttpGet("{id}")]
        public IActionResult GetApartment(int id)
        {
            try
            {
                if (!_apartmentInfoRepository.ApartmentExists(id))
                {
                    _logger.LogInformation($"Apartment with id {id} wasn't found.");
                    return NotFound();
                }
                var apartment = _apartmentInfoRepository.GetApartment(id);
                var result = Mapper.Map<ApartmentDto>(apartment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting apartment with id {id}", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }
        // get all apartments
        // sort by descending price
        // includes optional filtering
        // includes optional paging
        [HttpGet("{address?}/{nbOfRooms?}/{priceFrom?}/{priceTo?}/{pageSize?}/{pageNumber?}")]
        public IActionResult GetApartments(string address = null, 
            int? nbOfRooms = null, 
            int? priceFrom = null, 
            int? priceTo = null, 
            int? pageNumber = 1,
            int? pageSize = null)
        {
            var apartments = _apartmentInfoRepository.GetApartments();
            var results = Mapper.Map<IEnumerable<ApartmentDto>>(apartments);
            if (address != null)
            {
                results = results.Where(x => x.Address.Equals(address, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            if (nbOfRooms != null)
            {
                results = results.Where(x => x.NbOfRooms == nbOfRooms).ToList();
            }
            if (priceFrom != null)
            {
                results = results.Where(x => (x.Price >= priceFrom)).ToList();
            }
            if (priceTo != null)
            {
                results = results.Where(x => (x.Price <= priceTo)).ToList();
            }
            if (pageSize != null)
            {
                results = PaginatedList<ApartmentDto>.Create(results, pageNumber ?? 1, pageSize ?? 5);
            }
            return Ok(results.OrderByDescending(x => x.Price));

        }
        [HttpPost]
        public IActionResult CreateApartment([FromBody] ApartmentForCreationDto apartment)
        {
            if (apartment == null)
            {
                return BadRequest();
            }

            var apartmentEntity = Mapper.Map<Entities.Apartment>(apartment);
            _apartmentInfoRepository.AddApartment(apartmentEntity);

            if (!_apartmentInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            
            return CreatedAtAction(nameof(GetApartment), new { apartmentEntity.Id }, apartmentEntity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateApatment(int id, [FromBody] ApartmentForUpdateDto apartment)
        {
            if (!_apartmentInfoRepository.ApartmentExists(id))
            {
                return NotFound();
            }
            // checking if model apartment is valid
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var apartmentToUpdate = _apartmentInfoRepository.GetApartment(id);
            Mapper.Map(apartment, apartmentToUpdate);
            if (!_apartmentInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteApartment(int id)
        {
            if (!_apartmentInfoRepository.ApartmentExists(id))
            {
                return NotFound();
            }
            var apartmentToDelete = _apartmentInfoRepository.GetApartment(id);
            _apartmentInfoRepository.DeleteApartment(apartmentToDelete);
            if (!_apartmentInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return NoContent();
        }
    }
}
