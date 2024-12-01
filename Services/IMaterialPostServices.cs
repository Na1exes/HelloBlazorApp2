using HelloBlazorApp.Data.Entities;

namespace HelloBlazorApp.Services
{
    public interface IMaterialPostServices
    {
        Task<IEnumerable<ProposalMaterial>> GetProposalMaterialsAsync(int proposalId);
        Task<ProposalMaterial?> GetProposalMaterialAsync(int id);
        Task<ProposalMaterial> CreateMaterialAsync(ProposalMaterial material);
        Task UpdateMaterialAsync(ProposalMaterial material);
        Task DeleteMaterialAsync(int id);
    }
}