# Tech Job Portal

Tech Job Portal is a web application built using **ASP.NET Core MVC** that allows users to browse job listings and view job details. The project implements proper **routing**, a **job type dropdown**, and dynamic job details pages.

## Features

- **Job Listings Page**: Displays a list of available jobs.
- **Job Details Page**: Shows detailed information about a specific job.
- **Job Type Dropdown**: Allows users to view and select job types dynamically.
- **Responsive UI**: Designed with Bootstrap for a mobile-friendly experience.

## Technologies Used

- **ASP.NET Core MVC**
- **C#**
- **Bootstrap 5**
- **HTML/CSS**
- **JavaScript**

## Installation & Setup

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or later
- Visual Studio or VS Code

### Steps
1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo/TechJobPortal.git
   cd TechJobPortal
   ```

2. Restore dependencies:
   ```sh
   dotnet restore
   ```

3. Run the application:
   ```sh
   dotnet run
   ```

4. Open a web browser and go to:
   ```sh
   http://localhost:5000/jobs
   ```

## Routing Configuration

| Route           | Description                     |
|----------------|---------------------------------|
| `/jobs`        | Displays job listings          |
| `/jobs/list`   | Displays job listings (alt)    |
| `/jobs/{id}`   | Displays job details for ID    |

## File Structure
```
TechJobPortal/
├── Controllers/
│   ├── JobController.cs
├── Models/
│   ├── JobListing.cs
├── Views/
│   ├── Job/
│   │   ├── Index.cshtml
│   │   ├── Details.cshtml
├── wwwroot/
│   ├── css/
│   ├── js/
├── Program.cs
├── README.md
```

## JobController Implementation

```csharp
[Route("jobs")]
public class JobController : Controller
{
    private static readonly List<JobListing> JobListings = new()
    {
        new JobListing { Id = 1, Title = "UI/UX Designer", CompanyName = "Google", Location = "Jeddah", JobType = JobType.FullTime, PostedDate = DateTime.Now },
        new JobListing { Id = 2, Title = "Web Developer", CompanyName = "Elm", Location = "Riyadh", JobType = JobType.FullTime, PostedDate = DateTime.Now }
    };

    public IActionResult Index() => View(JobListings);

    public IActionResult Details(int id)
    {
        var job = JobListings.FirstOrDefault(j => j.Id == id);
        if (job == null) return NotFound();

        ViewBag.JobTypeList = Enum.GetValues(typeof(JobType))
                                  .Cast<JobType>()
                                  .Select(jt => new SelectListItem { Value = jt.ToString(), Text = jt.ToString() })
                                  .ToList();
        return View(job);
    }
}
```





