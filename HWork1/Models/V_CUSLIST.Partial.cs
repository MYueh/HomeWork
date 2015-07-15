namespace HWork1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(V_CUSLISTMetaData))]
    public partial class V_CUSLIST
    {
    }
    
    public partial class V_CUSLISTMetaData
    {
        [Required]
        public int CID { get; set; }
        [Display(Name = "客戶名稱")]
        public string CNAME { get; set; }
        public string CNO { get; set; }
        public string CMAIL { get; set; }
        public string CTEL { get; set; }
        public string CFAX { get; set; }        
        public string CADD { get; set; }
        [Display(Name = "聯絡人數量")]
        public Nullable<int> CR { get; set; }
        [Display(Name = "銀行帳戶數量")]
        public Nullable<int> BR { get; set; }
        public bool 是否已刪除 { get; set; }
    }
}
