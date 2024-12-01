using Microsoft.EntityFrameworkCore;
using HelloBlazorApp.Data.Entities;

namespace HelloBlazorApp.Data
{
    public class PurchaseContext : DbContext
    {
        // DbSet-свойства добавляем после описания наших табличных классов, сейчас не нужно
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<ProposalMaterial> ProposalMaterials { get; set; }
        public PurchaseContext(DbContextOptions<PurchaseContext> options) : base(options)
        { }
    }
}
