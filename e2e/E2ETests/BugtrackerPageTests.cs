using System;
using Xunit;
using Floozy;
using OpenQA.Selenium.Chrome;

namespace E2ETests
{
    public class BugtrackerPageTests
    {
        [Fact]   
        public void BannerHasCorrectText()
        {
            using(var webDriver = new ChromeDriver("c:\\chromedriver"))
            {
                webDriver
                    .Load<BugtrackerPage>("http://localhost:8080")
                    .Assert(p => p.Banner).ContainsText("Bugtracker");
            }
        }        
    }

    public class BugtrackerPage : PageModelBase
    {
        public ElementLocator Banner => FindById("banner");        
    }
}
