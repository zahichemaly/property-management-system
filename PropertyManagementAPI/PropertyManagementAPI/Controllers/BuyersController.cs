using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PropertyManagementAPI.Models;
using PropertyManagementAPI.Services;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagementAPI.Controllers
{
    [Route("/api/[controller]")]
    public class BuyersController : Controller
    {
        private readonly ILogger<BuyersController> _logger;
        private IBuyerInfoRepository _buyerInfoRepository;

        public BuyersController(ILogger<BuyersController> logger, IBuyerInfoRepository buyerInfoRepository)
        {
            _logger = logger;
            _buyerInfoRepository = buyerInfoRepository;
        }
        [HttpGet]
        public IActionResult GetBuyers()
        {
            var buyers = _buyerInfoRepository.GetBuyers();
            // map to a Buyer Model without the list of Apartments
            var results = Mapper.Map<IEnumerable<BuyerWithoutApartmentsDto>>(buyers);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetBuyer(int id, bool includeApartments = false)
        {
            if (!_buyerInfoRepository.BuyerExists(id)) 
            {
                return NotFound();
            }
            var buyer = _buyerInfoRepository.GetBuyer(id);
            // map to a Buyer Model that shows the list of his owned apartments
            var result = Mapper.Map<BuyerDto>(buyer);
            return Ok(result);
        }

        // get all apartments owned by a specific buyer
        [HttpGet("{buyerId}/apartments")]
        public IActionResult GetApartments(int buyerId)
        {
            try
            {
                if (!_buyerInfoRepository.BuyerExists(buyerId))
                {
                    _logger.LogInformation($"Buyer with id {buyerId} wasn't found when accessing apartments.");
                    return NotFound();
                }
                var ownedApartments = _buyerInfoRepository.GetApartments(buyerId);
                var result = Mapper.Map<IEnumerable<ApartmentDto>>(ownedApartments);
                return Ok(ownedApartments);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting apartment with id {buyerId}", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }

        }

        // get a specific apartment owned by a specific buyer
        [HttpGet("{buyerId}/apartments/{apartmentId}")]
        public IActionResult GetApartment(int buyerId, int apartmentId)
        {
            if (!_buyerInfoRepository.BuyerExists(buyerId))
            {
                _logger.LogInformation($"Buyer with id {buyerId} wasn't found when accessing apartments.");
                return NotFound();
            }
            var ownedApartment = _buyerInfoRepository.GetApartment(buyerId, apartmentId);
            var result = Mapper.Map<ApartmentDto>(ownedApartment);
            return Ok(result);
        }

        // allows a specific buyer to buy a specific apartment (must exist)
        // by passing the apartment ID as parameter to the request
        // ex: http://localhost:5000/api/buyers/1/buyApartment?apartmentId=4043
        [HttpPost("{buyerId}/buyApartment")]
        public IActionResult BuyApartment(int buyerId, int apartmentId)
        {
            if (!_buyerInfoRepository.BuyerExists(buyerId))
            {
                return NotFound();
            }
            if (!_buyerInfoRepository.ApartmentExists(apartmentId))
            {
                return NotFound();
            }
            var apartment = _buyerInfoRepository.FindApartment(apartmentId);
            if (apartment.BuyerId != null)
            {
                return StatusCode(400, "Apartment already owned. Not for sale.");
            }
            var buyer = _buyerInfoRepository.GetBuyer(buyerId);
            if (buyer.Credits >= apartment.Price)
            {
                _buyerInfoRepository.BuyApartment(buyerId, apartment);
                buyer.Credits -= apartment.Price;            }
            else
            {
                return StatusCode(400, $"Insufficient credits.");
            }
            if (!_buyerInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            //return StatusCode(201, $"Apartment {apartmentId} purchased successfully.");
            return StatusCode(201);
        }
    }
}
