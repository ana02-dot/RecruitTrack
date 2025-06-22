using JobSeekerAPI.Dtos;
using JobSeekerAPI.Models;
using JobSeekerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobSeekerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantController : ControllerBase
{
    private readonly IApplicantService _applicantService;
    
    public ApplicantController(IApplicantService applicantService)
    {
        _applicantService = applicantService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllApplicants()
    {
        var applicants = await _applicantService.GetAllApplicantAsync();
        return Ok(applicants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetApplicantById(int id)
    {
        var applicant = await _applicantService.GetApplicantByIdAsync(id);
        return applicant == null ? NotFound() : Ok(applicant);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetApplicantByEmail(string email)
    {
        var applicant = await _applicantService.GetApplicantByEmailAsync(email);
        return applicant == null ? NotFound() : Ok(applicant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateApplicant([FromForm] ApplicantDto applicantDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var applicant = new Applicant()
        {
            FirstName = applicantDto.FirstName,
            LastName = applicantDto.LastName,
            Email = applicantDto.Email,
            UserId = applicantDto.UserId
        };

        if (applicantDto.Resume != null)
        {
            var (isValid, message) = ValidateResume(applicantDto.Resume);
            if (!isValid)
            {
                return BadRequest(new { error = message });
            }

            var resumePath = await SaveResume(applicantDto.Resume);
            applicant.ResumePath = resumePath;
        }

        var success = await _applicantService.CreateApplicantAsync(applicant);
        return success ? CreatedAtAction(nameof(GetApplicantById), new { id = applicant.Id }, applicant) : StatusCode(500);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateApplicant(int id, [FromForm] ApplicantDto applicantDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingApplicant = await _applicantService.GetApplicantByIdAsync(id);
        if (existingApplicant == null)
        {
            return NotFound();
        }

        if (applicantDto.Resume != null)
        {
            var (isValid, message) = ValidateResume(applicantDto.Resume);
            if (!isValid)
            {
                return BadRequest(new { error = message });
            }

            if (!string.IsNullOrEmpty(existingApplicant.ResumePath))
            {
                DeleteResume(existingApplicant.ResumePath);
            }
            var newResumePath = await SaveResume(applicantDto.Resume);
            existingApplicant.ResumePath = newResumePath;
        }

        existingApplicant.FirstName = applicantDto.FirstName;
        existingApplicant.LastName = applicantDto.LastName;
        existingApplicant.Email = applicantDto.Email;

        await _applicantService.UpdateApplicantAsync(existingApplicant);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApplicant(int id)
    {
        var applicant = await _applicantService.GetApplicantByIdAsync(id);
        if (applicant == null)
        {
            return NotFound();
        }

        if (!string.IsNullOrEmpty(applicant.ResumePath))
        {
            DeleteResume(applicant.ResumePath);
        }

        await _applicantService.DeleteApplicantAsync(id);
        return NoContent();
    }

    private (bool IsValid, string? ErrorMessage) ValidateResume(IFormFile resume)
    {
        if (resume.Length == 0)
        {
            return (false, "Resume file cannot be empty.");
        }

        // 5MB limit
        if (resume.Length > 5 * 1024 * 1024)
        {
            return (false, "Resume file size cannot exceed 5MB.");
        }

        var permittedExtensions = new[] { ".pdf" };
        var extension = Path.GetExtension(resume.FileName).ToLowerInvariant();

        if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
        {
            return (false, "Invalid file type. Only PDF files are allowed.");
        }

        return (true, null);
    }

    private async Task<string> SaveResume(IFormFile resume)
    {
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resumes");
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var fileName = Path.GetFileName(resume.FileName);
        var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await resume.CopyToAsync(stream);
        }

        return Path.Combine("resumes", uniqueFileName);
    }

    private void DeleteResume(string resumePath)
    {
        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", resumePath);
        if (System.IO.File.Exists(fullPath))
        {
            System.IO.File.Delete(fullPath);
        }
    }
}