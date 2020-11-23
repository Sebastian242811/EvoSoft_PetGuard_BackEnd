using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetGuard.Domain.Models;
using PetGuard.Domain.Services;
using PetGuard.Extensions;
using PetGuard.Resources;
using PetGuard.Resources.Saves;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetGuard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IMapper mapper, IPaymentService paymentService)
        {
            _mapper = mapper;
            _paymentService = paymentService;
        }



        // GET: api/<PaymentController>
        [HttpGet]
        public async Task<IEnumerable<PaymentResource>> GetAllAsync()
        {
            var cities = await _paymentService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(cities);

            return resource;
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public async Task<PaymentResource> Getcitybyid(int id)
        {
            var cities = await _paymentService.FindPaymentById(id);
            var Paymentre = cities.Resource;
            var resource = _mapper.Map<Payment, PaymentResource>(Paymentre);

            return resource;
        }

        // POST api/<PaymentController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePaymentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var Payment = _mapper.Map<SavePaymentResource, Payment>(resource);
            // TODO: Implement Response Logic
            var result = await _paymentService.SaveAsync(Payment);

            if (!result.Succes)
                return BadRequest(result.Message);

            var PaymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

            return Ok(PaymentResource);
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePaymentResource resource)
        {
            var Payment = _mapper.Map<SavePaymentResource, Payment>(resource);
            var result = await _paymentService.UpdateAsync(id, Payment);

            if (result == null)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Payment, PaymentResource>(result.Resource);
            return Ok(categoryResource);
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _paymentService.DeleteAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            return Ok("Delete");
        }
    }
}
