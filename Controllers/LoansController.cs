using LoanSimulatorApi.Data;
using LoanSimulatorApi.Models;
using LoanSimulatorApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LoanSimulatorApi.Controllers
{
    [ApiController]
    [Route("api/loans")]
    public class LoansController : ControllerBase
    {
        private readonly LoanSimulationService _service;
        private readonly LoanDbContext _context;

        public LoansController(LoanSimulationService service, LoanDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost("simulate")]
        public async Task<IActionResult> Simulate([FromBody] LoanRequest request)
        {
            if (request.LoanAmount <= 0 || request.AnnualInterestRate <= 0 || request.NumberOfMonths <= 0)
                return BadRequest("Parâmetros inválidos.");

            var proposal = new Proposal
            {
                LoanAmount = request.LoanAmount,
                AnnualInterestRate = request.AnnualInterestRate,
                NumberOfMonths = request.NumberOfMonths
            };

            _context.Proposals.Add(proposal);
            await _context.SaveChangesAsync();

            var result = _service.Simulate(request);

            var resumo = new PaymentFlowSummary
            {
                ProposalId = proposal.Id,
                MonthlyPayment = result.MonthlyPayment,
                TotalInterest = result.TotalInterest,
                TotalPayment = result.TotalPayment,
                PaymentScheduleJson = JsonSerializer.Serialize(result.PaymentSchedule)
            };

            _context.PaymentFlowSummaries.Add(resumo);
            await _context.SaveChangesAsync();

            return Ok(result);
        }
    }

}
