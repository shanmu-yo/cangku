using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 课程安排.Models
{
    public partial class classes
    {
        [Display(Name ="班主任")]
        public string teachername
        {
            get
            {
                if (!teacherid.HasValue)
                {
                    return"";
                }
             kechenganpaiEntities db = new kechenganpaiEntities();
                var teacher = db.teacher.Where(t=>t.id == teacherid.Value).FirstOrDefault();
                if (teacher == null)
                {
                    return "";
                }
                return teacher.name;
    }
        }
    }
}