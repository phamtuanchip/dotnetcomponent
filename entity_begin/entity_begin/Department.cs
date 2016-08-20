namespace entity_begin
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Collaborator> Collaborators { get; set; }
    }
}