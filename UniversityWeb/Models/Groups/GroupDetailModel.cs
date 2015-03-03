using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DTO;
using DBModels;

namespace UniversityWeb.Models.Groups
{
    public class GroupDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<GroupToSubject> Subjects { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}