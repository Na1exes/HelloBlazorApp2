using System.ComponentModel.DataAnnotations;

namespace HelloBlazorApp.Data.Entities
{
    public enum ProposalStatus : byte
    {
        Created,
        InProgress,
        Completed,
        Rejected
    }
    public class Proposal
{
    [Key]
    public int ID { get; set; }

    [Required]
    public int Proposal_num { get; set; }

    [Required]
    public DateTime Creation_date { get; set; }

    [Required]
    public string Author { get; set; }

    [Required]
    public string Depart { get; set; }

    public string FullNumber
    {
        get
        {
            return $"{Creation_date:yy}/{Proposal_num:0000}";
        }
    }

    public ProposalStatus Status { get; set; }
    public string TextStatus
    {
        get
        {
            switch (Status)
            {
                case ProposalStatus.Created:
                    return "Заявка создана";
                case ProposalStatus.InProgress:
                    return "Заявка в работе";
                case ProposalStatus.Completed:
                    return "Заявка завершена";
                case ProposalStatus.Rejected:
                    return "Заявка отклонена";
                default: return "Неизвестный статус";
            }
        }
    }
}
}
