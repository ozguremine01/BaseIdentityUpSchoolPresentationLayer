using System.ComponentModel.DataAnnotations;

namespace BaseIdentityUpSchoolPresentationLayer.Models
{
    //Fluent Validation'da yine modeller olacak onlarıda temizlemek için DTO (Data Transfer Object) katmanı kullanılır.
    //DTO -> Objeleri eşleştirecek
    public class AppUserRegisterViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Ad boş geçilemez.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad boş geçilemez.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Mail boş geçilemez.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar boş geçilemez.")]
        public string ConfirmPassword { get; set; }

        //confirmpassword attribute'u şifrelerin eşleşip eşleşmediğini kontrol eder.
    }
}
