using Microsoft.EntityFrameworkCore;
using HelloBlazorApp.Data;
using HelloBlazorApp.Data.Entities;
using HelloBlazorApp.Models;
using MaterialStatus = HelloBlazorApp.Data.Entities.MaterialStatus;

namespace HelloBlazorApp.Services
{
    public class ProposalPostServices : IProposalPostServices
    {
        private readonly IDbContextFactory<PurchaseContext> _contextFactory;

        public ProposalPostServices(IDbContextFactory<PurchaseContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Proposal>> GetProposalAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Proposals
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Proposal?> GetProposalByIdAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Proposals
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<Proposal> CreateProposalAsync(Proposal proposal)
        {
            try
            {
                using var context = await _contextFactory.CreateDbContextAsync();
                
                // Устанавливаем начальные значения
                proposal.Status = ProposalStatus.Created;
                proposal.Creation_date = DateTime.UtcNow;  // Используем UTC время
                
                // Генерируем номер заявки
                var currentYear = DateTime.UtcNow.Year % 100;
                var lastProposal = await context.Proposals
                    .Where(p => p.Creation_date.Year == DateTime.UtcNow.Year)
                    .OrderByDescending(p => p.Proposal_num)
                    .FirstOrDefaultAsync();
                
                proposal.Proposal_num = (lastProposal?.Proposal_num ?? 0) + 1;
                
                Console.WriteLine($"Creating proposal: Author={proposal.Author}, Department={proposal.Depart}, Number={proposal.Proposal_num}");
                
                context.Proposals.Add(proposal);
                await context.SaveChangesAsync();
                
                Console.WriteLine($"Proposal created successfully with ID={proposal.ID}");
                
                return proposal;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateProposalAsync: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateProposalAsync(Proposal proposal)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.Entry(proposal).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteProposalAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var proposal = await context.Proposals.FindAsync(id);
            if (proposal != null)
            {
                context.Proposals.Remove(proposal);
                await context.SaveChangesAsync();
            }
        }

        public async Task ApproveProposalAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var proposal = await context.Proposals.FirstOrDefaultAsync(p => p.ID == id);
            if (proposal != null)
            {
                proposal.Status = ProposalStatus.InProgress;  // Меняем статус на InProgress
                context.Proposals.Update(proposal);  // Явно указываем, что сущность изменена
                await context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<ProposalMaterial>> GetProposalMaterialsAsync(int proposalId)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.ProposalMaterials
                .AsNoTracking()
                .Where(m => m.ProposalId == proposalId && m.Status != MaterialStatus.Deleted)
                .ToListAsync();
        }

        public async Task<ProposalMaterial> CreateProposalMaterialAsync(ProposalMaterial material)
        {
                using var context = await _contextFactory.CreateDbContextAsync();
                material.Status = MaterialStatus.Created;
                context.ProposalMaterials.Add(material);
                await context.SaveChangesAsync();
                return material;
        }

        public async Task UpdateProposalMaterialAsync(ProposalMaterial material)
        {
                using var context = await _contextFactory.CreateDbContextAsync();
                context.Entry(material).State = EntityState.Modified;
                await context.SaveChangesAsync();
        }

        public async Task DeleteProposalMaterialAsync(int materialId)
        {
                using var context = await _contextFactory.CreateDbContextAsync();
                var material = await context.ProposalMaterials.FindAsync(materialId);
                if (material != null)
                {
                    material.Status = MaterialStatus.Deleted;
                    await context.SaveChangesAsync();
                }
        }
    }
}