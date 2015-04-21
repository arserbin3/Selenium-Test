namespace SeleniumTest.Controllers
{
    using Models;
    using OpenQA.Selenium;
    using System;
    using System.Web.Mvc;

    public class SeleniumController : Controller
    {
        // GET: Selenium
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Navigates to google and searches for Hello World like a user.
        /// </summary>
        public ActionResult HelloWorld()
        {
            try
            {
                // create a Selenium instance using IE
                var bot = new GenericBot(BrowserType.InternetExplorer);

                // navigate to Google
                bot.Driver.Navigate().GoToUrl("https://www.google.com/");

                // search for Hello World
                bot.Driver.FindElement(By.Name("q")).SendKeys("Hello World");

                // click submit
                bot.Driver.FindElement(By.Name("btnK")).Click();

                // close the browser
                bot.Close();

                // return success
                return Content("Success");
            }
            catch (Exception e)
            {
                return Content("Failure: " + e.Message);
            }
        }
    }
}