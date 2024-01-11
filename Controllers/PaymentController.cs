using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PositronAPI.Interfaces;
using PositronAPI.Models.Payment;

namespace PositronAPI.Controllers;

public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    [Route("/payment")]
    public async Task<IActionResult> CreatePayment([FromBody][Required] PaymentImportDTO paymentImportDto)
    {
        var payment = await _paymentService.CreatePayment(paymentImportDto);

        return Created(String.Empty, payment);
    }
}