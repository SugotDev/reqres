# Reqres

## Project Overview
This project contains API tests for the [reqres.in](https://reqres.in/) application.
It is implemented in C# using RestSharp and NUnit, with Allure for reporting.

The project is organized as follows:

- **API**:  
  Contains API client classes that wrap HTTP operations (e.g., GET, POST, PATCH, DELETE) and interact with ReqRes endpoints.

- **TestData**:  
  Contains static JSON files used as input or expected output for test assertions (e.g., predefined users, expected response data).

- **Models**:  
  Contains strongly-typed data models used for request and response serialization (e.g., CreateUserRequest, CreateUserResponse, UserResponse).

- **Tests**:  
  Contains NUnit test classes grouped by functionality, such as GetUserTests and CreateUserTests. These validate API behavior, response codes, and returned payloads.
---

## Technical Decisions
### Test Framework
NUnit was chosen for its simplicity, strong integration with C#, and compatibility with Visual Studio and CI/CD pipelines. Its rich feature set (attributes, assertions, test lifecycle management) makes it ideal for structuring automated tests.

### API Tool
RestSharp was chosen for performing API tests. RestSharp allows:
  - Simplified HTTP requests with support for GET, POST, PUT, PATCH, DELETE methods.
  - Easy serialization and deserialization of JSON payloads into C# objects.
  - Support for adding headers, query parameters, and authentication.
  - Asynchronous request execution for faster and more reliable tests.
  - Clean and maintainable API wrappers, making tests easier to read and maintain.

### Test Reporting
Allure was chosen for generating detailed and interactive reports. Allure allows:
   - Step-by-step tracking of test execution.
   - Attaching screenshots, videos, and other artifacts.
   - Parameterized test reporting for better clarity.
   - Clear visualization of test failures and execution trends over time.

### Project Structure
The project follows a layered architecture for clear separation of concerns:
  - API: Contains wrappers for API calls (e.g., GET, POST) and encapsulates endpoints logic.
  - Tests: Contains test scenarios organized by feature, such as GetUserTests and CreateUserTests.
  - TestData: Holds static data used in assertions to avoid hardcoding values in tests, such as user first name, last name, email, etc.
  - Models: Contains reusable data models (e.g., CreateUserRequest, CreateUserResponse) for passing structured data between layers.
   
### Test Data Management
Test data is centralized in JSON files and corresponding classes to ensure:
   - Reusability across multiple API tests.
   - Easy maintenance when user or endpoint data changes.
   - Improved readability and clarity in test scenarios.
   - Separation of test data from test logic, reducing hardcoded values.

### Performance & Reliability Considerations
  - Asynchronous programming (async/await) is used consistently to ensure tests are reliable and non-blocking.

## Getting Started

### Prerequisites
- .NET 8.0 SDK or later
- Visual Studio 2022 (or later)
- NUnit
- RestSharp
- Allure Report

### Installing Dependencies
```powershell
dotnet restore
dotnet add package RestSharp
```

### Running Tests

1. Using Visual Studio Test Explorer
  - Open the solution in Visual Studio.
  - Navigate to Test Explorer.
  - Run all tests or select individual tests to run.

2. Using Command Line (PowerShell / Terminal)
Run all tests:
```powershell
dotnet test
```
Run a single test:
```powershell
dotnet test --filter "TestName"
```

### Generating Allure Reports

After running tests, you can generate and view the Allure report.  
**Note:** To use Allure commands (`allure serve`, `allure generate`, `allure open`), Allure CLI must be installed on your local machine.
To install Allure, follow the instructions on the official website: [https://allurereport.org/docs/install/](https://allurereport.org/docs/install/)

To serve the report interactively:

```powershell
allure serve bin/Debug/net8.0/allure-results
```
This command will:
  - Start a local server
  - Open an interactive Allure report in your default browser
  - Display test results, steps, attachments (screenshots, videos), and parameters

Alternatively, you can generate a static report and open it manually:
```powershell
allure generate bin/Debug/net8.0/allure-results -o allure-report
allure open allure-report
```

Example report:

<img width="2555" height="1272" alt="image" src="https://github.com/user-attachments/assets/a9399d95-b8fc-45c7-8b4a-5529dd6c74ba" />



