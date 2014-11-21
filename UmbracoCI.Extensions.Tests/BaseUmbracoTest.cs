using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Moq;
using NUnit.Framework;
using Umbraco.Core;
using Umbraco.Core.Configuration.UmbracoSettings;
using Umbraco.Tests.PublishedContent;
using Umbraco.Tests.TestHelpers;
using Umbraco.Web;

namespace UmbracoCI.Extensions.Tests
{
    [TestFixture, ExcludeFromCodeCoverage]
    public abstract class BaseCustomUmbracoTest : PublishedContentTestBase
    {
        private IUmbracoSettingsSection _umbracoSettings;

        public override void Initialize() {
            
            _umbracoSettings = SettingsForTests.GenerateMockSettings();
            SettingsForTests.ConfigureSettings(_umbracoSettings);
            // SettingsForTests.Reset()

            var appCtx = new ApplicationContext(CacheHelper.CreateDisabledCacheHelper());
            ApplicationContext.EnsureContext(appCtx, false);
            UmbracoContext.EnsureContext(new Mock<HttpContextBase>().Object, appCtx, true);

            // var routingContext = GetRoutingContext("/umbraco/CardManagement/CardApi/Cards");

            base.Initialize();
            
            // ServiceLocator.SetLocatorProvider(new ServiceLocatorProvider(() => new UnityServiceLocator(Bootstrapper.Initialise())));
            // DoctypeMappings.RegisterMappings();
        }

        protected override string GetXmlContent(int templateId)
        {
            var currentDir = new DirectoryInfo(this.GetType().Assembly.Location);
            // First parent = "bin", second = current project (ProjectDir), third = solution, fourth = ?
            return File.ReadAllText(String.Format("{0}\\MyTesco.Admin.UI\\App_Data\\umbraco.config", currentDir.Parent.Parent.Parent.Parent.FullName));
            // return base.GetXmlContent(templateId);
        }

        protected override string GetDbConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;
        }

        protected override string GetDbProviderName()
        {
            return ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ProviderName;
        }
    }
}
