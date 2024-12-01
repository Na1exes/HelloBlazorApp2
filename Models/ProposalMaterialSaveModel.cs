using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace HelloBlazorApp.Models
{
	public enum MaterialStatus : byte
	{
		Created = 0,
		Deleted = 1
	}
	public class ProposalMaterialSaveModel
	{
        [Key]
        public int ID { get; set; }
        [Required]
        public MaterialStatus Status { get; set; }
        public string TextStatus => Status.ToString();
        [Required]
        public string Material_Name { get; set; }
        [Required]
        public string Material_Code { get; set; }
    
        public int Quantity { get; set; }
        [Required]
        public string? Comment { get; set; }
        [Required]
        public int ProposalId { get; set; }

        public ProposalMaterial ToProposalMaterialEntity() =>
			new()
			{
				ID = ID,
				Material_Name = Material_Name,
				Material_Code = Material_Code,
				Quantity = Quantity,
				Comment = Comment,
				ProposalId = ProposalId
			};

		public ProposalMaterial Merge(ProposalMaterial entity)
		{
			entity.ID = ID;
			entity.Material_Name = Material_Name;
			entity.Material_Code = Material_Code;
			entity.Quantity = Quantity;
			entity.Comment = Comment;
			entity.ProposalId = ProposalId;

			return entity;
		}
		public static Expression<Func<ProposalMaterial, ProposalMaterialSaveModel>> Selector =>
			bp => new ProposalMaterialSaveModel
			{
				ID = bp.ID,
				Material_Name = bp.Material_Name,
				Material_Code = bp.Material_Code,
				Quantity = bp.Quantity,
				Comment = bp.Comment,
				ProposalId = bp.ProposalId
			};
	}
}