using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 课程安排.Models
{
    public partial class coursemenagements
    {
        public string Classname
        {
            get
            {
                if (classid==0)
                {
                    return "";
                }
                kechenganpaiEntities db = new kechenganpaiEntities();
                var classs = db.classes.Where(classes => classid == classid).FirstOrDefault();
                return classs.name;
            }

        }
        public string Coursename
        {
            get
            {
                if (courseid == 0)
                {
                    return "";
                }
                kechenganpaiEntities db = new kechenganpaiEntities();
                var course = db.kebiao.Where(kebiao => kebiao.Id == courseid).FirstOrDefault();
                return course.name;
            }
        }
        public string Teachername
        {
            get
            {
                if (teacherid == 0)
                {
                    return "";
                }
                kechenganpaiEntities db = new kechenganpaiEntities();
                var teacher = db.teacher.Where(teachers => teacherid == teacherid).FirstOrDefault();
                return teacher.name;
            }
        } 
    }
}