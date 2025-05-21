namespace LoanSimulatorApi.Models;

public class PaymentDetail
{
    public int Month { get; set; }
    public decimal Principal { get; set; }
    public decimal Interest { get; set; }
    public decimal Balance { get; set; }
}
