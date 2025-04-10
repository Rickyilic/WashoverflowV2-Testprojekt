using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WashOverflowV2.SpecFlowTests.E2ETests;

namespace WashOverflowV2.SpecFlowTests.Steps
{
    [Binding]
    public class BookingPlaywrightSteps
    {
        private IPage _page;

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            var context = await PlaywrightHooks.BrowserInstance.NewContextAsync();
            _page = await context.NewPageAsync();

            await _page.GotoAsync("http://localhost:5041/Identity/Account/Login");

            await _page.FillAsync("#Input_Email", "user1@test.se");
            await _page.FillAsync("#Input_Password", "User123!");
            await _page.ClickAsync("button[type='submit']");

            await _page.WaitForURLAsync("**/");
        }

        [Given(@"att användaren öppnar bokningssidan")]
        public async Task GivenAnvandarenOppnarBokningssidan()
        {
            await _page.GotoAsync("http://localhost:5041/BookPage");
        }

        [When(@"användaren fyller i bokningsformuläret")]
        public async Task WhenAnvandarenFyllerIFormularet()
        {
            
            await _page.WaitForSelectorAsync("#Station");
            await _page.SelectOptionAsync("#Station", "1");
            //await _page.EvaluateAsync(@"() => {
            //const event = new Event('change', { bubbles: true });
            //document.querySelector('#Station').dispatchEvent(event);
            //}");


            await _page.WaitForFunctionAsync(@"() => { 
            const select = document.querySelector('#package');
            if (!select) return false;
            return Array.from(select.options).some(opt => opt.textContent.trim() !== '' && opt.value !== '');
            }");

            await _page.SelectOptionAsync("#package", "1");

            await _page.SelectOptionAsync("#month", "April");
            await _page.SelectOptionAsync("#day", "15");
            await _page.SelectOptionAsync("#time", "10:00");

            await _page.FillAsync("#regNumber", "ABC123");
        }

        [When("användaren klickar på boka")]
        public async Task WhenAnvandarenKlickarPaBoka()
        {

            await _page.ClickAsync("input[type='submit']");

            
        }

        [Then(@"ska användaren se en bekräftelse")]
        public async Task ThenAnvandarenSerEnBekraftelse()
        {
            
            await _page.WaitForSelectorAsync("#successModal", new() { State = WaitForSelectorState.Visible });
            var confirmationText = await _page.InnerTextAsync("#successModal p");
            Assert.Contains("Your booking was successful!", confirmationText);

        }
    }
}
