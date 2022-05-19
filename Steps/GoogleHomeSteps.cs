using TechTalk.SpecFlow;
using PageObject;
using chrome_specflow.Drivers;

namespace DPX.StepsDefinitions
{
    [Binding]
    public class GoogleHomeSteps
    {
        private readonly GoogleHomePage googleHomePage;

        public GoogleHomeSteps(Driver driver)
        {
            this.googleHomePage = new GoogleHomePage(driver.Current);
        }
        [Given("I search \"(.*)\" in google home page")]
        public void GivenIsearchInHomePage(string search)
        {
            this.googleHomePage.Search(search);
        }

    }
}
