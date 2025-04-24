using Microsoft.AspNetCore.Mvc;
using paymentAPI.Models;
using paymentAPI.Services.Interfaces;

namespace paymentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        // 🔍 GET: api/payment
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await _service.GetAllAsync();
            return Ok(payments);
        }

        // 🔍 GET: api/payment/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payment = await _service.GetByIdAsync(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        // ➕ POST: api/payment
        [HttpPost]
        public async Task<IActionResult> Add(Paymentdetail payment)
        {
            await _service.AddAsync(payment);
            return CreatedAtAction(nameof(GetById), new { id = payment.PaymentDetailId }, payment);
        }

        // ✏️ PUT: api/payment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Paymentdetail payment)
        {
            if (id != payment.PaymentDetailId)
                return BadRequest("ID mismatch");

            await _service.UpdateAsync(payment);
            return NoContent();
        }

        // ❌ DELETE: api/payment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

