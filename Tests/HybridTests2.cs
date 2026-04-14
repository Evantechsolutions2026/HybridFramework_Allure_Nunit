
using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Framework.API;
using Framework.Base;
using Framework.Pages;
using Framework.Utils;
using NUnit.Framework;
using System.Collections.Generic;

namespace Framework.Tests
{
    public class Class2 : BaseTest
    {

        [Category("Regression")]
        [AllureFeature("Login")]
        [AllureStory("Hybrid API + UI Login Flow")]
        [AllureSeverity(SeverityLevel.critical)]
        [Description("ValidateloginwithInvalidcredentials")]
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetData), new object[] { "Login.csv" })]
        public void ValidateLoginwithInvalidcredentials_NEW(Dictionary<string, string> data)
        {

            AllureApi.Step("Step 1: UI Login and verify", () =>
            {
                var page = new LoginPage(driver);
                AllureApi.Step("Enter Username", () =>
                {
                    string username = data["username"];
                    string password = data["password"];

                    page.Login(username, password);
                });

                AllureApi.Step("Assertion", () =>
                {
                    Assert.That(driver.Title, Does.Contain("OrangeHRM"),
                            "Should redirect to dashboard after login");
                });
            });
        }
    }
}
