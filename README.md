# ALTENative application

[![GitHub top language](https://img.shields.io/github/languages/top/nikita-sharov/alten?style=for-the-badge)](https://github.com/search?q=repo%3Anikita-sharov%2Falten+language%3AC%23&type=Code&ref=advsearch&l=C%23)

This **Git** repository having [multiple branches](branches) showcases: 

- a modeling ([Model](src/Alten.Career/Models)-View-[ViewModel](src/Alten.Career/ViewModels)) sample  based around creation of [job offerings](https://www.alten.at/en/career/jobs.html) and [job applications](https://www.alten.at/en/speculative-application.html) for  [ALTEN Austria](https://www.alten.at/en)
- a [sample implementation](docs/jama.md) of an [Jama REST API](https://dev.jamasoftware.com/) client, utilizing **C#** v7+ language features, and [DI](tests/Alten.Tests/Jama/Services/RestSharpServiceFactory.cs) / [IoC](src/Alten.Jama.RestSharp/Services) patterns / principles
- [feedback](docs/online-application-form.md) on the [job application form](https://www.alten.at/en/career/application.html?ad_id=3461), considered to be a user survey

## Career

```csharp
internal static class JobViewModelPool
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
            "As a Software Developer (m/f/d) C# you are responsible for programming software [...]",
            "In the course of this you [...] provide the connection to JAMA",
            "You are responsible for providing advanced functions collecting within user surveys"
        },
        Profile = new List<string>
        {
            "You have a completed technical education in software development [...] or equivalent",
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

    static JobViewModelPool() => Assert.That.IsValid(YourJob);
}
```

![Job](docs/media/job-view-model.png)

```csharp
internal static class JobApplicationPool
{
    public static readonly JobApplication MyJobApplication = new JobApplication
    {
        JobId = JobViewModelPool.YourJob.Id,
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
        }
    };

    private static readonly IFormatProvider FormatProvider = new CultureInfo("de");

    static JobApplicationPool() => Assert.That.IsValid(MyJobApplication);
}
```

![JobApplication](docs/media/job-application.png)

```csharp
[TestClass]
public class JobApplicationViewModelCreate
{
    [TestMethod]
    public void ImpliesPrivacyNoteWasAccepted()
    {
        var viewModel = JobApplicationViewModel.Create(JobApplicationPool.MyJobApplication);
        Assert.IsTrue(viewModel.PrivacyNoteAccepted);
    }
}
```
