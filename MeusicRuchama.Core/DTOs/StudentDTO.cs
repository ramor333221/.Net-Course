using MeusicRuchama.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusicRuchama.Core.DTOs
{
    public class StudentDTO
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        //public List<Lessons> lessons { get; set; }
    }
}
