**Hacker News Viewer Application**
==================================

This project is a full-stack solution for viewing the newest stories from the Hacker News API. It consists of an **Angular** front-end and an **ASP.NET Core** back-end combined into one solution.

**Features**
------------

*   **Frontend**: Built using Angular to provide a responsive and dynamic UI.
    
    *   View the latest stories from Hacker News.
        
    *   Search for stories by title.
        
    *   Pagination for easier navigation.
        
    *   Handles stories with and without URLs.
        
*   **Backend**: Built using ASP.NET Core Web API.
    
    *   Fetches stories from the Hacker News API.
        
    *   Implements caching for optimized performance.
        
    *   Dependency injection for better maintainability.
        
    *   Provides endpoints for story retrieval and search.
        
*   **Testing**:
    
    *   Jasmine/Karma unit tests for Angular front-end.
        
    *   xUnit tests for the .NET back-end.
        

**Technologies Used**
---------------------

### **Frontend**

*   Angular
    
*   Angular CLI
    
*   Ngx-Pagination
    
*   Bootstrap (optional for styling)
    
*   Jasmine/Karma for unit testing
    

### **Backend**

*   ASP.NET Core 8 Web API
    
*   Dependency Injection
    
*   In-Memory Caching
    
*   HttpClient
    
*   xUnit for unit testing
    

**Getting Started**
-------------------

### **Prerequisites**

*   Node.js (v20 LTS)
    
*   Angular CLI (v19)
    
*   .NET SDK (8.0 core)
    

### **Setup Instructions**

1.  git clone cd
    
2.  **Install Dependencies**
    
    *   cd hacker-news-web-appnpm installcd ..
        
3.  **Configure the Backend**
    
    *   Ensure the back-end API is set to listen on https://localhost:7264.
        
    *   Add any additional API configurations in the appsettings.json file of the ASP.NET Core project.
        
4.  **Run the Backend**
    
    *   dotnet run
        
5.  **Run the Frontend**
    
    *   cd hacker-news-web-appng serve
        
    *   Open your browser and navigate to http://localhost:4200.
        

### **Backend API Endpoints**

1.  **Get Newest Stories**
    
    *   GET /api/stories
        
    *   Fetches the newest stories from Hacker News.
        
2.  **Search Stories**
    
    *   GET /api/stories/search?query={query}
        
    *   Returns stories filtered by the provided search query.
        

**Testing**
-----------

### **Backend Testing**

Run xUnit tests for the back-end:

Plain textANTLR4BashCC#CSSCoffeeScriptCMakeDartDjangoDockerEJSErlangGitGoGraphQLGroovyHTMLJavaJavaScriptJSONJSXKotlinLaTeXLessLuaMakefileMarkdownMATLABMarkupObjective-CPerlPHPPowerShell.propertiesProtocol BuffersPythonRRubySass (Sass)Sass (Scss)SchemeSQLShellSwiftSVGTSXTypeScriptWebAssemblyYAMLXML`   dotnet test   `

### **Frontend Testing**

Run Jasmine tests for the front-end:

Plain textANTLR4BashCC#CSSCoffeeScriptCMakeDartDjangoDockerEJSErlangGitGoGraphQLGroovyHTMLJavaJavaScriptJSONJSXKotlinLaTeXLessLuaMakefileMarkdownMATLABMarkupObjective-CPerlPHPPowerShell.propertiesProtocol BuffersPythonRRubySass (Sass)Sass (Scss)SchemeSQLShellSwiftSVGTSXTypeScriptWebAssemblyYAMLXML`   cd ClientApp  ng test   `

**Folder Structure**
--------------------

Plain textANTLR4BashCC#CSSCoffeeScriptCMakeDartDjangoDockerEJSErlangGitGoGraphQLGroovyHTMLJavaJavaScriptJSONJSXKotlinLaTeXLessLuaMakefileMarkdownMATLABMarkupObjective-CPerlPHPPowerShell.propertiesProtocol BuffersPythonRRubySass (Sass)Sass (Scss)SchemeSQLShellSwiftSVGTSXTypeScriptWebAssemblyYAMLXML`   HackerNewsWebAppSolution/  ├── HackerNewsWebAPI/  │   ├── Controllers/  │   │   └── StoriesController.cs  │   ├── Services/  │   │   └── HackerNewsService.cs  │   ├── Models/  │   │   └── Story.cs  │   ├── appsettings.json  │   └── Program.cs├── HackerNewsWebAPI.Tests/  │   ├── Extentions/│   │   └── HttpMessageHandlerExtensions.cs│   ├── Services/  │   │   └── HackerNewsServiceTests.cs  ├── hacker-news-web-app/  │   ├── src/  │   │   ├── app/  │   │   │   ├── components/  │   │   │   │   ├── home/  │   │   │   │   │   ├── home.component.ts  │   │   │   │   │   ├── home.component.html  │   │   │   │   │   └── home.component.css  │   │   │   ├── services/  │   │   │   │   └── api.service.ts│   │   │   ├── app.component.html│   │   │   ├── app.component.css│   │   │   ├── app.component.ts│   │   │   ├── app.component.spec.ts  │   │   │   ├── main.ts  │   ├── angular.json  │   ├── package.json  │   └── README.md   `