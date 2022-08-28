using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using Xunit.Abstractions;



// NOTE:
// Add the following NuGet PACKAGES:
//      FluentAssertions                            (latest version)
//      Moq                                         (latest version)
//      Microsoft.EntityFrameworkCore.InMemory      (same version as EFCore in the LMS.Web project
// Also add REFERENCE to the LMS.Web Project

namespace InsurancePortal.xUnitTestProject
{
    public partial class PolicyCategoriesApiTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public PolicyCategoriesApiTests(
            ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

    }
}