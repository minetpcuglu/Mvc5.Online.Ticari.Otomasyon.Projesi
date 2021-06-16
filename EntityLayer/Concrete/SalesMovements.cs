using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrete
{
    public class SalesMovements
    {
        [Key]
        public int SalesMovementsId { get; set; } //satış hareketleri
        public DateTime Date { get; set; }
        public int Piece { get; set; }  //adet
        public decimal Price { get; set; }  //fiyat
        public decimal TotelPrice { get; set; }  //toplam fiyat



        //ilişkiler
        public  int ProductId { get; set; }  //ürün 
        public  virtual Product Product { get; set; }

        public int  CurrentId { get; set; }
        public virtual Current  Current { get; set; } //cari

        public int EmployeeId { get; set; }
        public virtual Employee  Employee { get; set; } //personel

    }
}