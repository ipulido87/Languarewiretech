using Languagewire.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Languagewire.Pages;
using OpenQA.Selenium.Support.UI;

namespace Languagewire.Tests
{
    [TestFixture]
    public class E2ETests
    {
        private IWebDriver driver;
        private MainPage mainPage;
        private string baseUrl = "https://demo-qa-interview-lwt.staging.lw-ml.net?token=FFfRfNG5q%2BmlzPssMTjNDsslMYtElTh4nQcYLTIiCCo%3D.eyJOb25jZSI6ICJOb25jZSIsICJVc2VySWQiOiAxLCAiRGVmYXVsdENvbXBhbnlJZCI6IDEsICJMd3RTdWJzY3JpcHRpb25JZCI6IDEsICJQZXJtaXNzaW9ucyI6IFszMDkyXSwgIkV4cGlyYXRpb25UaW1lIjogIi9EYXRlKDE3MTMwMTUxMzA2OTUpLyJ9";

        [SetUp]
        public void SetUp()
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            mainPage = new MainPage(driver);
            mainPage.OpenUrl(baseUrl); 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void Test_TextTranslation_EnglishToDanish()
        {


            mainPage.ChooseLanguageOrigin1();
            mainPage.ChooseLanguageDestination();
            mainPage.Danish();

            mainPage.EnterTextForTranslation("Today the sun shines brightly over the city, casting shadows that dance on the sidewalks  A perfect day for a leisurely walk in the park");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var textTranslated = wait.Until(d => mainPage.GetTranslationResult());
            Assert.That(textTranslated, Is.EqualTo("I dag skinner solen klart over byen og kaster skygger, der danser på fortove En perfekt dag til en afslappet gåtur i parken"));


            //mainPage.ClearTextTarea();

        }


        [Test]
        public void DocumentTranslationSimleWord()

        {
            string pathToOriginalDoc = @"/Users/ivan/Documents/Languarewire.docx";
            string downloadFolder = "/Users/ivan/Downloads";
            string downloadedFileName = "Languarewire-DA.docx";
            string expectedText = "Dette er en tekst på engelsk til oversættelse til dansk, jeg har lært en masse med denne tekniske test";
            string fullPathToDownloadedDoc = Path.Combine(downloadFolder, downloadedFileName);

            string originalDocumentContent = DocumentUtilities.ReadWordDocument(pathToOriginalDoc);


            mainPage.ChooseLanguageOrigin1();
            mainPage.ChooseLanguageDestination();
            mainPage.Danish();

            string pathToDoc = @"/Users/ivan/Documents/Languarewire.docx";
            mainPage.UploadDocument(pathToDoc);

            bool isDownloaded = DocumentUtilities.WaitForFile(fullPathToDownloadedDoc, 60);
            if (!isDownloaded)
            {
                Assert.Fail("The file was no downloaded");
            }

            string translateDocument = DocumentUtilities.ReadWordDocument(fullPathToDownloadedDoc);

            Assert.IsTrue(translateDocument.Contains(expectedText), "The expect tranlation is not the same that its expected.");


            Console.WriteLine("The  document insert  is " + originalDocumentContent);
            Console.WriteLine("The document translate is " + translateDocument);
        }


        [TearDown]
        public void TearDown() => driver.Quit();
    }
}
