using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HelloBlazorApp.Models
{
	public class ProposalSaveModel
    {
		public class Proposal
		{
			[Key]
			public int ID { get; set; }

			[Required]
			public ProposalStatus Status { get; set; }


			[Required]
			public string Depart { get; set; }

			[Required]
			public string Author { get; set; }

			public Proposal ToProposal() =>
				new()
				{
					ID = ID,
					Status = Status,
					Depart = Depart,
					Author = Author
				};
		}
	}
}

