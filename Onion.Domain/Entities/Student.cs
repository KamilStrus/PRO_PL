
namespace Onion.Domain.Entities
{
    public class Student
    {
        public Student( /*string nid*/ string firstName, string lastName)
        {
            //  ID = nid;

            FirstName = firstName;
            LastName = lastName;
        }

        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
