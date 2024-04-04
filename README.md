# LanguageWire Test Automation Project
This project includes a suite of end-to-end (E2E) automated tests for the LanguageWire application, focusing on UI testing with Selenium WebDriver in C#. The tests cover several key functionalities, including text translation, document translation, and language swap features.


## Project Structure

     Languarewire/
        ├── Pages/
        │   └── MainPage.cs # Page object model for the main page
        │
        ├── Tests/
        │   └── E2ETests.cs  # Test suite for E2E testing
        │
        └── Utilities/
            └── DocumentUtilities.cs  # Helper functions for document-related operations

## Key Features Tested

Text Translation: Verifies that text can be correctly translated from English to Danish.
Document Translation: Checks the translation of .docx files from English to Danish, ensuring the translated document matches expected output.
Language Swap: Tests the functionality of swapping source and destination languages.

Markdown is a lightweight markup language based on the formatting conventions
that people naturally use in email.
As [John Gruber] writes on the [Markdown site][df1]

## Setup
To run these tests, you'll need:

 - Visual Studio or any compatible IDE
 - NET Core SDK
 - Selenium WebDriver
 - ChromeDriver (or any compatible driver for your browser of choice)


## Execution


```

dotnet test
```
## E2ETests.cs

E2ETests.cs contains the test cases utilizing the MainPage class to simulate user interactions and verify the application's behavior against expected outcomes.


## DocumentUtilities.cs
DocumentUtilities.cs offers utility functions for reading Word documents and waiting for file downloads, supporting the validation of document translation tests.




