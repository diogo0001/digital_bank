using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank.DataAcesss.Entities
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        
        [Required]
        public int AccountNumber { get; set; }

        [Required]
        public int AccountValue { get; set; }

        public User User { get; set; }
    }
}
