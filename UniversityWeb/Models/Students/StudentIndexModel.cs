using BLL.DTO;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityWeb.Models.Students
{
    public class StudentIndexModel
    {
        public IEnumerable<StudentDTO> Students { get; set; }

        public IEnumerable<GroupDTO> Groups { get; set; }
    }
}