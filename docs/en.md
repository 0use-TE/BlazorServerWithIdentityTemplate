👋 English Introduction

Hi, I’m Ouse. Welcome to this repository!

This repository provides a Blazor Server project template that includes:

🛠 Web API integration

🔐 Identity authentication

🗄 EF Core with SQLite

🎨 UI styled with MudBlazor

🔑 Basic login and logout functionality

❓ Why integrate Web API?

Blazor Server is based on SignalR real-time communication, so all component interactions happen via SignalR. There is no traditional HTTP request-response model, which makes setting cookies and handling login/logout challenging.

There are two solutions:

Integrate Web API: Blazor Server can use NavigationManager or JS calls to send requests, and the API sets the cookie.

Integrate Razor Pages: Authentication pages are handled by Razor Pages, while Blazor Server handles the business interface.

The second approach is less elegant and increases complexity, so this template uses the first approach.

⚡ English Usage

Open a terminal/command prompt

Install the template:
``` bash
dotnet new install BlazorServerWithIdentityTemplate
```

Create a new project:
``` bash
dotnet new blazorserverwithidentity -n YourProjectName
```
Navigate to the project directory:
```bash 
cd YourProjectName
```

Run the project:
```bash
dotnet run
```
📝 English Notes

This project uses Server-side global interactions by default. You can adjust this according to your needs.

The default database is SQLite, but you can switch to other databases by modifying the ApplicationDbContext configuration.