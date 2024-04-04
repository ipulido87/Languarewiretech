using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Languagewire.Pages
{
    public class MainPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
       

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

       // private readonly string clearTextTarea = "/html/body/lw-languagewire-translate/lw-home/div/div/lw-translation/div/section[1]/lw-translation-input/lw-source-text/button/span[3]";


        public void OpenUrl(string url) => driver.Navigate().GoToUrl(url);

        public void ChooseLanguageOrigin1() => ClickElement("//lw-language-select-bar//lw-language-select[1]//button[2]/span[2]");
        public void ChooseLanguageDestination() => ClickElement("//lw-language-select-bar//lw-language-select[2]//button[3]/span[2]");
        public void Danish() => ClickElement("//span[contains(text(), 'Danish')]");

        public void EnterTextForTranslation(string text)
        {
            var inputTextField = driver.FindElement(By.XPath("//textarea"));
            inputTextField.Clear();
            inputTextField.SendKeys(text);
        }

        public string GetTranslationResult()
        {
            var translationResultElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'lw-output-text__text')]//div[contains(@class, 'ng-star-inserted')]")));
            return translationResultElement.Text;
        }


        public void UploadDocument(string filePath)
        {


            var uploadInput = driver.FindElement(By.CssSelector("input[type='file']"));
            uploadInput.SendKeys(filePath);

           
            var translateButton = driver.FindElement(By.XPath("//span[contains(@class, 'lw-source-document__translate-document-button-text')]"));
            translateButton.Click();

        }

        
        private void ClickElement(string xpath)
        {
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".loading-spinner")));

            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            element.Click();
        }

        //public void ClearTextTarea()
        //{

        //    var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(clearTextTarea)));
        //    element.Click();
        //}
    }
}
