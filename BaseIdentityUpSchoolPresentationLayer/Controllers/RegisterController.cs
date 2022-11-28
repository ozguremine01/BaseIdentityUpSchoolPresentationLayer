using BaseIdentityUpSchoolEntityLayer.Concrete;
using BaseIdentityUpSchoolPresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseIdentityUpSchoolPresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        //HttpGet metodu default olarak algılanır.
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterViewModel p)
        {
            //Buna else yazmaya gerek var mı? Gerek yok!!!!
            // Hatalar tanımlanan Required attribute larındaki Errormessage'dan gelir.
            if (ModelState.IsValid)
            {
                //Buraya AppUser'daki propertyler gelir. Ayrıca bu sınıfı Identity'den kalıttığımız için Identity metotları da gelir.
                AppUser appUser = new AppUser()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email= p.Mail,
                    UserName = p.Username

                };
                if(p.Password == p.ConfirmPassword)
                {
                    var result= await _userManager.CreateAsync(appUser,p.Password);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index","Login");
                    }
                    //Result'ta ne olursa hata olur?
                    //Identity'nin kendi kurallarına uymazsa
                    //Örneğin şifre en az 6 karakter uzunluğunda ve içinde en az 1 sayı, 1 küçük harf, 1 büyük harf ve 1 sembol bulunmalı
                    //Duplicate kullanıcı adı hatası -> Bu kullanıcı adı daha önceden alınmış hatası
                    //Verilen değer veritabanında tanımlanan uzunluk değerinin dışına çıkarsa da hata olur.
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            //Burada description Identity'den geliyor.
                            ModelState.AddModelError("",item.Description);
                        }
                    }
                }
                
                else
                {
                    //ModelState key değerinin boş olması ve boş olmamasını araştır.
                    ModelState.AddModelError("","Şifreler birbiriyle uyuşmuyor.");
                }
            }
            return View();
        }
        //Model üzerinden çalışmanın avantajı -> Her veriyi kullanmamak için -> Sadece istediğimiz verileri kullanmak için model kullanılır.
    }
}
