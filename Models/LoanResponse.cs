namespace LoanSimulatorApi.Models;

public class LoanResponse
{
    public decimal MonthlyPayment { get; set; }
    public decimal TotalInterest { get; set; }
    public decimal TotalPayment { get; set; }
    public List<PaymentDetail> PaymentSchedule { get; set; } = [];
}
