# ALTEN

[![GitHub top language](https://img.shields.io/github/languages/top/nikita-sharov/alten?style=for-the-badge)](https://github.com/search?q=repo%3Anikita-sharov%2Falten+language%3AC%23&type=Code&ref=advsearch&l=C%23)

This **Git** repository showcases a sample based around creation of [job offerings](https://www.alten.at/en/career/jobs.html) and [job applications](https://www.alten.at/en/speculative-application.html) for  [ALTEN Austria](https://www.alten.at/en).

## MVVM

`Job.cd`

![Job](media/job.png)

`JobViewModelPool.cs`

```csharp
public static class JobViewModelPool
{
    public static readonly JobViewModel YourJob = new JobViewModel
    {
        Id = 3461,
        Title = "Software Developer (m/f/d) C#",
        Location = "Graz",
        ApplicationAreas = ApplicationAreas.SoftwareDevelopment,
        BusinessBranches = BusinessBranches.SemiconductorTechnology,
        EntryLevels = EntryLevels.ExperiencedProfessionals,
        Tasks = new List<string>
        {
            "As a Software Developer (m/f/d) C# you are responsible for programming software using C# and .NET",
            "In the course of this you stabilize the TCE architecture and you provide the connection to JAMA",
            "You are responsible for providing advanced functions collecting within user surveys"
        },
        Profile = new List<string>
        {
            "You have a completed technical education in software development, computer science or equivalent",
            "Relevant professional experience with C# are required for this position",
            "You also have Git experience (at least all basic operations)",
            "Moreover, you have a solid WPF knowledge as well as experience with MVVM pattern",
            "Fluent English and basic German skills complete your profile"
        },
        MonthlySalaryInEuros = 3_400,
        ContactPerson = new EmployeeViewModel
        {
            FirstName = "Barbara",
            LastName = "Stankovic",
            JobTitle = "Recruiting Manager",
            Phone = "+43 664 39 85 200",
            Email = "career@alten.at"
        }
    };

    static JobViewModelPool()
    {
        Assert.That.IsValid(YourJob);
    }
}
```

`JobApplicationViewModel.cd`

![JobApplication](media/job-view-model.png)

`AssertExtensions.cs`

```csharp
// See: https://github.com/microsoft/testfx-docs/blob/master/RFCs/002-Framework-Extensibility-Custom-Assertions.md
[SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Predefined")]
public static class AssertExtensions
{
    public static void IsValid(this Assert assert, object instance)
    {
        var context = new ValidationContext(instance);
        var results = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(instance, context, results, validateAllProperties: true);
        Assert.IsTrue(isValid);
    }
}
```

`JobApplication.cd`

![JobApplication](media/job-application.png)

`JobApplicationViewModelPool.cs`

```csharp
public static readonly JobApplicationViewModel MyJobApplication = new JobApplicationViewModel
{
    Salutation = Salutation.Mr,
    FirstName = "Nikita",
    LastName = "Sharov",
    Citizenship = "Russian Federation",
    Address = "Mariatroster Straße 172/4",
    PostalCode = "8044",
    Location = "Graz",
    DateOfBirth = DateTime.Parse("14.09.1982", FormatProvider),
    Email = "nikita.sharov@235u.net",
    PrimaryPhone = "+43 664 182 22 83",
    StartingDate = DateTime.Parse("01.06.2020", FormatProvider),
    YearlySalaryInEuros = JobViewModelPool.YourJob.MonthlySalaryInEuros * 14,
    RegisteredAsUnemployed = false,
    Attachments = new List<JobApplicationAttachment>
    {
        new JobApplicationAttachment
        {
            Content = Encoding.UTF8.GetBytes("..."),
            ContentType = MediaTypeNames.Text.Plain,
            FileName = "README.md"
        }
    },
    PrivacyNoteAccepted = true
};
```
