using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{

    //Aşağıdaki property'ler tüm tablolarda ortak kulladıldığı için bir sınıf içinde yazılıp buradan miras alıp kullanılabilecek.
    public class BaseEntity
    {

        public int ID { get; set; }

        private DateTime _adddate = DateTime.Now;
        public DateTime AddDate
        {
            get { return _adddate; }
            set { _adddate=value; }
        }

        private bool isDelted = false;
         public bool IsDeleted {
            get { return isDelted; }
            set { isDelted = value; }
        }

        public DateTime? DeleteDate { get; set; }

    }
}