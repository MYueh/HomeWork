namespace HWork1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶資料MetaData))]
    public partial class 客戶資料
    {
    }
    
    public partial class 客戶資料MetaData
    {
        [Required]
        public int Id { get; set; }        
        
        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string 客戶名稱 { get; set; }

        [Required(ErrorMessage = "統一編號長度為8碼!")]
        [StringLength(8), MinLength(8)]        
        public string 統一編號 { get; set; }

        [Required]
        [RegularExpression(@"^\(?\d{2}\)?[\s\-]?\d{4}\-?\d{4}$", ErrorMessage = "電話格式輸入錯誤!")]        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]        
        public string 電話 { get; set; }

        [Required]
        [RegularExpression(@"^\(?\d{2}\)?[\s\-]?\d{4}\-?\d{4}$", ErrorMessage = "電話格式輸入錯誤!")]        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 傳真 { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string 地址 { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email輸入格式有誤!!")]        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        public string Email { get; set; }
        
        [Required]
        public bool 是否已刪除 { get; set; }
    
        public virtual ICollection<客戶聯絡人> 客戶聯絡人 { get; set; }
        public virtual ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
    }
}
