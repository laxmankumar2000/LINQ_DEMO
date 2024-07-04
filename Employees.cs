using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace EMS1.DAL
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }

        public int DepartmentId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
