using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace soludevabp.Companies
{
    public class CreateUpdateCompanyDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreteadDate { get; set; } = DateTime.Now;

    }
}
