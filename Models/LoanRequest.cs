namespace LoanSimulatorApi.Models;

public class LoanRequest
{
    public decimal LoanAmount { get; set; }
    public double AnnualInterestRate { get; set; }
    public int NumberOfMonths { get; set; }
}
