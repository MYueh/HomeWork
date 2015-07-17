namespace HWork1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlClient;
    using System.Linq;
    
    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext )            
        {
            using (var db = new CusEntities())
            {
                var query = db.客戶聯絡人.SqlQuery(
                  "select Id,Email from [客戶聯絡人] where Id <> @id and Email='@mail'",
                   new SqlParameter("@id", Id), new SqlParameter("@mail", Email));
                if (query != null)
                {
                    yield return new ValidationResult("Email不可重覆--模型驗証", new[] { "Email" });
                }
            }
        }
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }        
        
        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string 職稱 { get; set; }
                
        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string 姓名 { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "欄位長度不得大於 250 個字元")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email輸入格式有誤!!")]        
        public string Email { get; set; }        
        
        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [RegularExpression(@"^\d{4}\-\d{6}$", ErrorMessage = "手機輸入格式有誤，請重新輸入(ex:0911-111111)。")]        
        public string 手機 { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [RegularExpression(@"^\(?\d{2}\)?[\s\-]?\d{4}\-?\d{4}$", ErrorMessage = "電話格式輸入錯誤!")]        
        public string 電話 { get; set; }

        [Required]
        public bool 是否已刪除 { get; set; }
    

        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
