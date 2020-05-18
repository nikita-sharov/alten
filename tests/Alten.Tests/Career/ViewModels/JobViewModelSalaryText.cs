using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Alten.Career.ViewModels
{
    [TestClass]
    public sealed class JobViewModelSalaryText
    {
        [TestMethod]
        public void IsProperlyFormatted()
        {
            var job = new JobViewModel
            {
                MonthlySalaryInEuros = 3_400
            };

            Assert.IsTrue(job.SalaryText.Contains("3.400,-- € gross per month", StringComparison.InvariantCulture));
        }
    }
}
