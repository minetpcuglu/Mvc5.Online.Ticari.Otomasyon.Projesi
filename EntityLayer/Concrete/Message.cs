using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string SenderMail { get; set; } //gönderen

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ReceiverMail { get; set; } //alıcı

        [Column(TypeName = "Varchar")]
        public string Subject { get; set; }
        [Column(TypeName = "Varchar")]
        public string Content { get; set; }
        public DateTime Date { get; set; } 
    }
}
