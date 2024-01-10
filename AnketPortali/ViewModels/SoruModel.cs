using System.ComponentModel.DataAnnotations;

namespace AnketPortali.ViewModels
{
    public class SoruModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Soruyu Giriniz!")]
        public string Question { get; set; }




        [Required(ErrorMessage = "Cevabı Giriniz!")]
        public string Description { get; set; }



    }
}
