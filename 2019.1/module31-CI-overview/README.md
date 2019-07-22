CI Concept
- Draw CI diagram
- Quality Gates: Analyzers, Unit Tests, Integration Tests
- Automatization
- Continious
- Must Have:
	- Version Control
	- Build Automation
	- Test Automation
	- Often Commits
	- Build on Change
- Continious Delivery => No manual QA

How to use Jenkins
- Explain UI
- Create a simple job (echo Hello World)


Create Build Job
- Retrieve from Git
- Build Trigger on Git
	- Explain Cron
- Build application
```
cd 2019.1/module31-CI-overview/AppTests
dotnet test
```
- Add compile error and commit
- Show Workspace
- Archive artifacts: 2019.1/module31-CI-overview/TestApp/bin/Release/netcoreapp2.2/publish/*
	- Last Successful Artifact permalink
- Parameters
	- It is an environment variable
	- Show Jenkins default variables
	- Explain default parameters
```
cd 2019.1/module31-CI-overview/AppTests
if %run_tests%==true dotnet test
```

Mention Plugins

How to install Jenkins
- Use Docker
- Plugins
- Password
- Global Tool Configuration