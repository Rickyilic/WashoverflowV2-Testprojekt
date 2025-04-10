using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace WashOverflowV2.SpecFlowTests.E2ETests
{
    [Binding]
    public class PlaywrightHooks
    {
        public static IPlaywright PlaywrightInstance;
        public static IBrowser BrowserInstance;

        [BeforeTestRun]
        public static async Task BeforeTestRun()
        {
            PlaywrightInstance = await Playwright.CreateAsync();
            BrowserInstance = await PlaywrightInstance.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
        }

        [AfterTestRun]
        public static async Task AfterTestRun()
        {
            await BrowserInstance.CloseAsync();
            PlaywrightInstance.Dispose();
        }
    }
}
