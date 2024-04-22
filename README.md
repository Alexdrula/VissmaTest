Overview

This automated test suite is designed to test the functionality of the Ghost website using SpecFlow and Selenium WebDriver. The test suite covers various scenarios to ensure the website's features work as expected under different conditions.

Requirements

Development Environment

Visual Studio IDE
.NET Framework
NuGet Package Manager

Dependencies

SpecFlow: Framework for writing acceptance tests in Gherkin language.
NUnit: Unit testing framework for .NET applications.
Selenium WebDriver: Framework for automating web browser interactions.

WebDriver Configuration

ChromeDriver: WebDriver for Chrome browser.

Setup

Clone Repository: Clone this repository to your local machine.
Install Dependencies: Use NuGet Package Manager to install SpecFlow, NUnit, and Selenium WebDriver.
WebDriver Configuration: Download and configure ChromeDriver according to your operating system and browser version.
Build Solution: Build the solution in Visual Studio to ensure all dependencies are resolved.

Running Tests

Test Execution: Execute the tests using Visual Studio's built-in test runner or any other compatible test runner.
WebDriver Initialization: Ensure that the WebDriver is initialized and the website is accessible before running the tests.

Test Coverage

Given-When-Then Scenarios: Test scenarios are structured using the Given-When-Then format to ensure clarity and maintainability.
Boundary Testing: Test cases cover boundary conditions to ensure the website handles edge cases appropriately.
Error Handling: Test cases include error scenarios to verify proper error handling and messaging.
