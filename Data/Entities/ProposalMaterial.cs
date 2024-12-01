using System.ComponentModel.DataAnnotations;

namespace HelloBlazorApp.Data.Entities
{
	public enum MaterialStatus : byte
	{
		Created = 0,
		Deleted = 1
	}
	public class ProposalMaterial
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public MaterialStatus Status { get; set; }
		public string TextStatus
		{
			get
			{
				return Status switch
				{
					MaterialStatus.Created => "Создан",
					MaterialStatus.Deleted => "Удален",
					_ => "Неизвестный статус"
				};
			}
		}
		[Required]
		public string Material_Name { get; set; }
		[Required]
		[StringLength(10)]
		public string Material_Code { get; set; }
       
        [Range(1, int.MaxValue, ErrorMessage = "Количество должно быть больше 0")]
        public int Quantity { get; set; }
		[Required]
		public string? Comment { get; set; }
		[Required]
		public int ProposalId { get; set; }
		public Proposal? Proposal { get; set; }
	}
}