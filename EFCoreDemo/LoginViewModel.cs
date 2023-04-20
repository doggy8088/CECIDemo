using System.ComponentModel.DataAnnotations;

namespace EFCoreDemo
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "帳號必填")]
        [StringLength(16, ErrorMessage = "帳號不能超過 {1} 個字元")]
        [MinLength(3, ErrorMessage = "帳號不可小於 {1} 個字元")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "密碼必填")]
        [StringLength(32, ErrorMessage = "密碼不能超過 {1} 個字元")]
        [MinLength(3, ErrorMessage = "密碼不可小於 {1} 個字元")]
        public string Password { get; set; } = null!;
    }
}
