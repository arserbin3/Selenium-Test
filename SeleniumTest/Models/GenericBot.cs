namespace SeleniumTest.Models
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Remote;

    public class GenericBot
    {
        public GenericBot(BrowserType browserType)
        {
            Browser = browserType;
            Driver = GetDriver(browserType);
        }

        public BrowserType Browser { get; set; }

        public IWebDriver Driver { get; set; }

        /// <summary>
        /// Initialize a driver for the desired browser type, with default settings.
        /// </summary>
        /// <param name="browserType"></param>
        /// <returns></returns>
        public static IWebDriver GetDriver(BrowserType browserType)
        {
            IWebDriver driver = null;

            switch (browserType)
            {
                case BrowserType.Firefox:
                    var profile = new FirefoxProfile();
                    //profile.SetPreference("network.automatic-ntlm-auth.trusted-uris", url);
                    driver = new FirefoxDriver(profile);
                    break;

                case BrowserType.InternetExplorer:
                    var options = new InternetExplorerOptions
                    {
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true
                    };
                    var capabilities = new DesiredCapabilities();
                    capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    driver = new InternetExplorerDriver(options);
                    break;

                case BrowserType.Chrome:
                    // TODO: implement this
                    //driver = new ChromeDriver();
                    break;

                // NOTE: this is intentionally unimplemented, as it requires some advanced setup. Email if needed.
                /*
            case BrowserType.TorBrowser:
                // close any already open Tor Browser instances. Only one is allowed at a time, it seems
                WindowApi.FindWindowsWithText("Tor Browser").ForEach(x => WindowApi.Close(x));
                WindowApi.FindWindowsWithText("Tor Status").ForEach(x => WindowApi.Close(x));
                WindowApi.FindWindowsWithText("Tor Launcher").ForEach(x => WindowApi.Close(x));

                const string TorPath = "C:\\Users\\arserbin\\Desktop\\Tor Browser\\Start Tor Browser.exe";
                const string ProfilePath = "C:\\Users\\arserbin\\Desktop\\Tor Browser\\Data\\Browser\\profile.default";
                var torProfile = new FirefoxProfile(ProfilePath);//ProfilePath);
                torProfile.SetPreference("extensions.checkCompatibility.24.6", false);
                torProfile.SetPreference("extensions.checkCompatibility", false);
                var binary = new FirefoxBinary(TorPath);
                driver = new FirefoxDriver(binary, torProfile);

                // close any 'Profile Missing' error messages
                WindowApi.FindWindowsWithText("Profile Missing").ForEach(x => WindowApi.Close(x));
                break;

                case BrowserType.FirefoxWithTor:
                    //var profile = new FirefoxProfile();
                    //profile.SetPreference("network.automatic-ntlm-auth.trusted-uris", url);
                    //driver = new FirefoxDriver(profile);
                    break;
                    */

                case BrowserType.None:
                    break;
            }

            return driver;
        }

        /// <summary>
        /// Cleanly closes the browser.
        /// </summary>
        public void Close()
        {
            // close the Driver
            Driver.Close();
        }
    }

    public enum BrowserType
    {
        None,
        Firefox,
        InternetExplorer,
        Chrome,
        TorBrowser,
        FirefoxWithTor
    }
}