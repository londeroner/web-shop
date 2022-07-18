using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(ILogger<BasketController> logger, 
            IBasketRepository basketRepository, IMapper mapper)
        {
            _logger = logger;
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDTO basket)
        {
            var updatedBasket = await _basketRepository.UpdateBasketAsync(_mapper.Map<CustomerBasketDTO, CustomerBasket>(basket));

            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }
    }
}