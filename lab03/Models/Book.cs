namespace lab03.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="ban phai nhap ten sach")]
        [StringLength(100, ErrorMessage = "tieu de khong qua 100 ky tu")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ban phai nhap ten tac gia")]
        [StringLength(30, ErrorMessage = "tac gia khong qua 30 ky tu")]

        public string Author { get; set; }

        [Required(ErrorMessage = "ban phai nhap tua de")]
        [StringLength(100,ErrorMessage = "noi dung khong qua 100 ky tu")]
        public string title { get; set; }

        [Required(ErrorMessage = "ban phai nhap hinh anh")]
        [StringLength(20)]
        public string Img { get; set; }

        [Required(ErrorMessage = "ban phai nhap gia")]
        [Range(1000,1000000,ErrorMessage = "gia phai tu 1000 den 1000000")]
        public int Price { get; set; }
    }
}
