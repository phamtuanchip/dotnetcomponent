using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Collaborator> Collaborators { get; set; }
    }
}
