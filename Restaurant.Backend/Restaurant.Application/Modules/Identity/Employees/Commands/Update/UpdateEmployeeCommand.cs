using Restaurant.Domain.Common;
using System.Text.Json.Serialization;

namespace Restaurant.Application.Modules.Identity.Employees.Commands.Update
{
    public class UpdateEmployeeCommand : IRequest<Employee>
    {
        [JsonIgnore]
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public JobTitleEnum JobTitle { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public int YearsOfExperience { get; set; } = 0;
    }
}
