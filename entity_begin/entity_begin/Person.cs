using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_begin
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
    public class Collaborator : Person
    {
        public int CollaboratorId { get; set; }
        public string ManagerCode { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
