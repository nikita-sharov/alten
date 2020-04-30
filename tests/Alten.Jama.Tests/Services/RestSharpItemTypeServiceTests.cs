using Alten.Jama.Models;
using Alten.Jama.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alten.Jama.Tests.Services
{
    [TestClass]
    public class RestSharpItemTypeServiceTests
    {
        private const int ItemTypeId = 143;

        private readonly IItemTypeService _service = RestSharpServiceFactory.Create<RestSharpItemTypeService>();

        [TestMethod]
        public async Task PostAsync()
        {
            var body = new ItemTypeRequest
            {
                TypeKey = "JOB",
                Display = "Job",
                DisplayPlural = "Jobs",
                Description = "HR",
                ////Widgets = new List<ItemTypeWidgetRequest>
                ////{
                ////    new ItemTypeWidgetRequest
                ////    {
                ////        Widget = ItemTypeWidget.Activities
                ////    }
                ////}
            };

            MetaResponse response = await _service.PostAsync(body);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetAsync()
        {
            DataResponse<ItemType> response = await _service.GetAsync(ItemTypeId);
            Assert.IsNotNull(response);
        }
    }
}
