using AutoMapper;
using DBModels;
using DBModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            Mapper.CreateMap<GroupDTO, Group>();
            Mapper.CreateMap<Group, GroupDTO>();

            Mapper.CreateMap<StudentDTO, Student>();
            Mapper.CreateMap<Student, StudentDTO>();

            Mapper.CreateMap<SubjectDTO, Subject>();
            Mapper.CreateMap<Subject, SubjectDTO>();
        }
    }
}
