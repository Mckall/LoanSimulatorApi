namespace LoanSimulatorApi.Models;

public class PaymentFlowSummary
{
    public int Id { get; set; }
    public int ProposalId { get; set; }
    public decimal MonthlyPayment { get; set; }
    public decimal TotalInterest { get; set; }
    public decimal TotalPayment { get; set; }
    public string PaymentScheduleJson { get; set; } = string.Empty;
}
