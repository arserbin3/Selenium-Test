namespace SeleniumTest.Helpers
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;

    public static class SeleniumHelpers
    {
        /// <summary>
        /// Simplifies code for waiting until an element exists.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to wait.</param>
        /// <param name="by">The locator used to find the element.</param>
        /// <param name="timeoutSeconds">Maximum seconds to wait. Defaults to 90.</param>
        /// <remarks>This does not necessarily mean that the element is visible.</remarks>
        public static IWebElement WaitUntilExists(this IWebDriver driver, By by, int timeoutSeconds = 90)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds))
                .Until(ExpectedConditions.ElementExists(by));
        }

        /// <summary>
        /// Simplifies code for waiting until an element exists.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to wait.</param>
        /// <param name="by">The locator used to find the element.</param>
        /// <param name="timeoutSeconds">Maximum seconds to wait. Defaults to 90.</param>
        /// <param name="webElement">The element that was found to exist.</param>
        /// <returns>False if the element doesn't exist or any error was thrown (like a timeout exception).</returns>
        /// <remarks>This does not necessarily mean that the element is visible.</remarks>
        public static bool TryWaitUntilExists(this IWebDriver driver, By by, int timeoutSeconds, out IWebElement webElement)
        {
            try
            {
                webElement =
                    new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds)).Until(
                        ExpectedConditions.ElementExists(by));
            }
            catch
            {
                webElement = null;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Simplifies code for waiting until an element exists.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to wait.</param>
        /// <param name="by">The locator used to find the element.</param>
        /// <param name="webElement">The element that was found to exist.</param>
        /// <returns>False if the element doesn't exist or any error was thrown (like a timeout exception).</returns>
        /// <remarks>This does not necessarily mean that the element is visible.</remarks>
        public static bool TryWaitUntilExists(this IWebDriver driver, By by, out IWebElement webElement)
        {
            return TryWaitUntilExists(driver, by, 90, out webElement);
        }
    }
}