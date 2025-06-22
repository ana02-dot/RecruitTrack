using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace JobSeekerAPI.Dtos;

public class ApplicantDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    [JsonIgnore]
    public int UserId { get; set; }
    public IFormFile? Resume { get; set; }
}