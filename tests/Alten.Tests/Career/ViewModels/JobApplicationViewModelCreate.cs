using Alten.Career.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alten.Career.ViewModels
{
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
}
