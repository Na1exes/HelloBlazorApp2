using HelloBlazorApp.Data.Entities;

namespace HelloBlazorApp.Services
{
    public interface IProposalPostServices
{
    Task<IEnumerable<Proposal>> GetProposalAsync();
    Task<Proposal?> GetProposalByIdAsync(int id);
    Task<Proposal> CreateProposalAsync(Proposal proposal);
    Task UpdateProposalAsync(Proposal proposal);
    Task DeleteProposalAsync(int id);
    Task ApproveProposalAsync(int id);
    Task<IEnumerable<ProposalMaterial>> GetProposalMaterialsAsync(int proposalId);
    Task<ProposalMaterial> CreateProposalMaterialAsync(ProposalMaterial material);
    Task UpdateProposalMaterialAsync(ProposalMaterial material);
    Task DeleteProposalMaterialAsync(int materialId);
}
}