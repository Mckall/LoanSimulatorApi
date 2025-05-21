using LoanSimulatorApi.Models;

namespace LoanSimulatorApi.Services
{
    public class LoanSimulationService
    {
        public LoanResponse Simulate(LoanRequest request)
        {
            double i = request.AnnualInterestRate / 12.0;
            int n = request.NumberOfMonths;
            decimal P = request.LoanAmount;

            decimal iDecimal = (decimal)i;
            decimal factor = (decimal)Math.Pow(1 + i, n);
            decimal monthlyPayment = P * iDecimal * factor / (factor - 1);
            decimal balance = P;
            decimal totalInterest = 0;
            var schedule = new List<PaymentDetail>();

            for (int month = 1; month <= n; month++)
            {
                decimal interest = balance * iDecimal;
                decimal principal = monthlyPayment - interest;
                balance -= principal;

                if (month == n) balance = 0;

                schedule.Add(new PaymentDetail
                {
                    Month = month,
                    Interest = Math.Round(interest, 2),
                    Principal = Math.Round(principal, 2),
                    Balance = Math.Round(balance, 2)
                });

                totalInterest += interest;
            }

            return new LoanResponse
            {
                MonthlyPayment = Math.Round(monthlyPayment, 2),
                TotalInterest = Math.Round(totalInterest, 2),
                TotalPayment = Math.Round(monthlyPayment * n, 2),
                PaymentSchedule = schedule
            };
        }
    }
}
