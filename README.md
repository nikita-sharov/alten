# ALTEN

```csharp
0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789
public static readonly JobViewModel YourJob = new JobViewModel
{
    ReferenceNumber = 3461,
    Title = "Software Developer (m/f/d) C#",
    Location = "Graz",
    ApplicationAreas = ApplicationAreas.SoftwareDevelopment,
    BusinessBranches = BusinessBranches.SemiconductorTechnology,
    EntryLevels = EntryLevels.ExperiencedProfessionals,
    Tasks = new List<string>
    {
        "As a Software Developer (m/f/d) C# you are responsible for programming software using C# and .NET in the semiconductor industry",
        "In the course of this you stabilize the TCE architecture and you provide the connection to JAMA",
        "You are responsible for providing advanced functions collecting within user surveys"
    },
    Profile = new List<string>
    {
        "You have a completed technical education (University/University of Applied Sciences) in software development, computer science or equivalent",
        "Relevant professional experience with C#, preferably with v7+, as well as solid knowledge in DI and IoC and NuGet package management are required for this position",
        "You also have Git experience (at least all basic operations) and understand the importance of feature branches",
        "Moreover, you have a solid WPF knowledge (control- & data templates, styles, trigger, bindings) as well as experience with MVVM pattern",
        "Fluent English and basic German skills complete your profile"
    },
    MonthlySalaryInEuros = 3_400,
    ContactPerson = new EmployeeViewModel
    {
        FirstName = "Barbara",
        LastName = "Stankovic",
        JobTitle = "Recruiting Manager",
        Phone = "+43 664 39 85 200",
        Email = "+43 664 39 85 200"
    }
};
```


