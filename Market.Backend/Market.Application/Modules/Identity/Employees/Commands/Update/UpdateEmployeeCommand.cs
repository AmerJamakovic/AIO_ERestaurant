using System.Text.Json.Serialization;
using Market.Domain.Common;

namespace Market.Application.Modules.Identity.Employees.Commands.Update
{
    public class UpdateEmployeeCommand : IRequest<Employee>
    {
        [JsonIgnore]
        public string Id { get; set; } = string.Empty;
        public JobTitleEnum JobTitle { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public int YearsOfExperience { get; set; } = 0;
    }
}
