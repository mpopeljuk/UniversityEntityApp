using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityWeb.Models.Students
{
    public class StudentAddEditModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public int GroupId { get; set; }

        public IEnumerable<GroupDTO> Groups { get; set; }
    }
}