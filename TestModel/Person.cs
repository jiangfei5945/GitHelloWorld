using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using  System.ComponentModel.DataAnnotations;

namespace TestModel
{
    public class Person
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        public bool  IsMale { get; set; }

        public double Height { get; set; }
    }
}
