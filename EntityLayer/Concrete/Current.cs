using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrete
{
    public class Current
    {
        [Key]
        public int CurrentId { get; set; }   //Cari

        [Column(TypeName = "Varchar")]
        [StringLength(30/*,ErrorMessage="En Fazla 30 Karakter Yazılabilir"*/ )] //validation yazı rengi kırmızı olması için validation controller 13 dakika 
        public string CurrentName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CurrentSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string CurrentMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CurrentCity { get; set; }
        public bool CurrentStatus { get; set; }


        //ilişkiler
        public ICollection<SalesMovements> Sales { get; set; }

    }
}