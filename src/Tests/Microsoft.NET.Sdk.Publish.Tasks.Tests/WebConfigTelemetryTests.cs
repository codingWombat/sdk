using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.NET.Sdk.Publish.Tasks;
using Xunit;

namespace Microsoft.NET.Sdk.Publish.Tasks.Tests
{
    public class WebConfigTelemetryTests
    {

        public const string SolutionProjectGuid = "{E4ED9184-8FE6-43CF-8BB6-D708CC720748}";

        [Theory(Skip = "Test few tests")]
        [InlineData(SolutionProjectGuid)]
        public void WebConfigTelemetry_DoesNotSetProjectGuidIfOptedOut_ThroughIgnoreProjectGuid(string projectGuid)
        {
            // Arrange
            XDocument transformedWebConfig = WebConfigTransform.Transform(null, "test.exe", configureForAzure: false, useAppHost: true, extension: ".exe", aspNetCoreModuleName: null, aspNetCoreHostingModel:null, environmentName: null, projectFullPath: null);
            Assert.True(XNode.DeepEquals(WebConfigTransformTemplates.WebConfigTemplate, transformedWebConfig));

            //Act
            XDocument output= WebConfigTelemetry.AddTelemetry(transformedWebConfig, projectGuid, true, null, null);

            // Assert
            Assert.True(XNode.DeepEquals(WebConfigTransformTemplates.WebConfigTemplate, output));
        }
    }
}