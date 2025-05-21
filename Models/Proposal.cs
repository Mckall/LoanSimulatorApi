namespace LoanSimulatorApi.Models;

public class Proposal
{
    public int Id { get; set; }
    public decimal LoanAmount { get; set; }
    public double AnnualInterestRate { get; set; }
    public int NumberOfMonths { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
