using LoanSimulatorApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoanSimulatorApi.Data;

public class LoanDbContext : DbContext
{
    public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options) { }
    public DbSet<Proposal> Proposals { get; set; }
    public DbSet<PaymentFlowSummary> PaymentFlowSummaries { get; set; }
}
