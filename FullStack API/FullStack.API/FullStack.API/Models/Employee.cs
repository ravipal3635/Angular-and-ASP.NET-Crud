namespace FullStack.API.Models
{
    public class Employee
    {
        //Angular application has 5 Property
        public Guid Id { get; set; } //This is the unique identifier for the employee
        public string Name { get; set; } 
        public string Email { get; set; }
        public long Phone { get; set; }
        public long Salary { get; set; }
        public string Department { get; set; }  
    }

}
