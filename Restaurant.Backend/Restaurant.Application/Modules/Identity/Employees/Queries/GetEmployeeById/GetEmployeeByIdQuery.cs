namespace Restaurant.Application.Modules.Identity.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery : IRequest<GetEmployeeByIdQueryDto>
    {
        public string Id { get; set; }
    }
}
