//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HWork1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class 客戶銀行資訊
    {
        public int Id { get; set; }
        public int 客戶Id { get; set; }

        [Required]
        public string 銀行名稱 { get; set; }
        [Required(ErrorMessage = "銀行代碼長度不可小於3碼!")]
        [StringLength(3), MinLength(3) ]
        public string 銀行代碼 { get; set; }
        [Required(ErrorMessage = "分行代碼長度不可小於4碼!")]
        [StringLength(4), MinLength(4)]
        public string 分行代碼 { get; set; }
        [Required]
        public string 帳戶名稱 { get; set; }
        [Required]
        public string 帳戶號碼 { get; set; }
        public bool 是否已刪除 { get; set; }

        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
