# RPD Processor

RPD Processor — a tool for automating some tasks related to editing of methodical documentation in St. Petersburg State University. It allows to look up discipline information in working plans, get a list of competences and other information about discipline.

## How to build and run a project

You will need [NPM package manager](https://www.npmjs.com/) and [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) (we recommend using [Chocolatey](https://chocolatey.org/) to manage software on Windows, see [https://chocolatey.org/packages/nodejs.install] and [https://chocolatey.org/packages/dotnet-5.0-sdk] for required tools).

Clone the repository, run
```
git submodule init
git submodule update
npm install
dotnet build
```

If everything went right, you can run the program with `dotnet run` command. Find something like `Now listening on: http://localhost:62071` in its output (initialization may take several seconds) and point your browser to this link.

You can also open RpdProcessor.sln in Visual Studio.