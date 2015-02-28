using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityWeb.Models.Subjects
{
    public class SubjectDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<GroupToSubject> Groups { get; set; }
    }
}