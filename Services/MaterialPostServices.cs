using Microsoft.EntityFrameworkCore;
using HelloBlazorApp.Data;
using HelloBlazorApp.Data.Entities;
using HelloBlazorApp.Models;

namespace HelloBlazorApp.Services
{
    public class MaterialPostServices : IMaterialPostServices
    {
        private readonly IDbContextFactory<PurchaseContext> _contextFactory;

        public MaterialPostServices(IDbContextFactory<PurchaseContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<ProposalMaterial>> GetProposalMaterialsAsync(int proposalId)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.ProposalMaterials
                .Where(m => m.ProposalId == proposalId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProposalMaterial?> GetProposalMaterialAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.ProposalMaterials
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task<ProposalMaterial> CreateMaterialAsync(ProposalMaterial material)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.ProposalMaterials.Add(material);
            await context.SaveChangesAsync();
            return material;
        }

        public async Task UpdateMaterialAsync(ProposalMaterial material)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.Entry(material).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteMaterialAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var material = await context.ProposalMaterials.FindAsync(id);
            if (material != null)
            {
                context.ProposalMaterials.Remove(material);
                await context.SaveChangesAsync();
            }
        }
    }
}