#Steps to build a C# - nUnit - Selenium framework from scratch

1. New Project Class Library named "WebDriverProvider"
	- Classes
	- Enums
	- Interfaces
	- Configurations
	- Extensions
1. New Project Class Library named "ConfigurationProvider"
	- Classes
1. New Project NUnit named "TestSolution"
	- Features
	- StepDefinitions
	- Hooks
	- PageObjects
	- Models
	- Configurations
	- TestData
1. Install Following NuGet Packages
   - "Selenium"
   - "WebDriverManager"
   - "Microsoft.Extensions.Configuration"
   - "Microsoft.Extensions.Configuration.Json"
   - "Microsoft.Extensions.Configuration.Binder"
   - "DotNetSeleniumExtras.WaitHelpers"
	- "Specflow"
	- "SpecFlow.Tools.MsBuild.Generation"
1. For Allure Reporting
   - Install Allure.Specflow NuGet Package
   - Create a specflow.json file in the root of the testing framework
   - Create an allureConfig.json file in the root of the testing framework
   - Add this hook to your Hooks file
     ```
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            allure.CleanupResultDirectory();
        }
     ```
1. To upload Allure Reports to gh-pages
   - Create an empty branch called "gh-pages"
     ```
     	git checkout --orphan gh-pages
     	git rm -rf .
     	git commit --allow-empty -m "root commit"
     	git push origin gh-pages
     ```
   - Get Allure history
     ```
         - name: Get Allure history
           uses: actions/checkout@v2
           if: always()
     	   continue-on-error: true
     	   with:
        	ref: gh-pages
        	path: gh-pages
     ```
   - Allure Report action from marketplace
     ```
         - name: Allure Report action from marketplace
           uses: simple-elf/allure-report-action@master
           if: always()
           id: allure-report
           with:
	        allure_results: TestSolutionSpecflow/bin/Debug/net6.0/allure-results
	        gh_pages: gh-pages
	        allure_report: allure-report
	        allure_history: allure-history
     ```
   - Deploy report to Github Pages
     ```
         - name: Deploy report to Github Pages
           if: always()
           uses: peaceiris/actions-gh-pages@v2
           env:
	        PERSONAL_TOKEN: ${{ secrets.GITHUB_TOKEN }}
	        PUBLISH_BRANCH: gh-pages
	        PUBLISH_DIR: allure-history
     ```
     
Be sure to have Read and write permissions on Workflow permissions in order to sucesfully deploy the report
