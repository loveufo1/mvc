using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class customer
    {
        public int id { get; set; }
        [DisplayName("名稱")]
        [Required(ErrorMessage ="必填")]           //不要只做前端驗證 很容易出事!!
        public string name { get; set; }
        [DisplayName("電話")]
        public string phone { get; set; }
        [DisplayName("信箱")]
        public string email { get; set; }
        [DisplayName("地址")]
        public string address{ get; set; }
        public string password { get; set; }
    }
}