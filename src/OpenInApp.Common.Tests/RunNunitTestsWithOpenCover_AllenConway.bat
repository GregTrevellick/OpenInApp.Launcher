REM http://www.allenconway.net/2015/06/using-opencover-and-reportgenerator-to.html

REM Create a 'CodeCoverageReports' folder if it does not exist
if not exist "%~dp0CodeCoverageReports" mkdir "%~dp0CodeCoverageReports"
 
REM Remove any previous test execution files to prevent issues overwriting (ms test)
REM IF EXIST "%~dp0BowlingSPAService.trx" del "%~dp0BowlingSPAService.trx%"
 
REM Remove any previously created test output directories
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"
 
REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics
 
REM Generate the report output based on the test results
if %errorlevel% equ 0 (
 call :RunReportGeneratorOutput
)
 
REM Launch the report
if %errorlevel% equ 0 (
 call :RunLaunchReport
)
exit /b %errorlevel%
 
:RunOpenCoverUnitTestMetrics
REM -filter:"+[BowlingSPAService*]* -[BowlingSPAService.Tests]* -[*]BowlingSPAService.RouteConfig" ^  will add anything in the 'BowlingSPAService' namespace, but also removing code in the 'BowlingSPAService.Tests' namespace 
REM Use 'mergebyhash' to merge results loaded from multiple assemblies
REM Use 'skipautoprops' to skip .NET 'AutoProperties' from being analyzed (basic getters and setters don't require unit tests and thus shouldn't be reported on the output)
"%~dp0..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"..\..\..\packages\NUnit.Runners.2.6.3\tools\nunit-console.exe" ^
-targetargs:"/nologo \"%~dp0..\OpenInApp.Common.Tests\bin\Debug\OpenInApp.Common.Tests.dll\" /noshadow"  ^
-filter:"+[OpenInApp.Common*]* -[OpenInApp.Common.Tests]*" ^
-mergebyhash ^
-skipautoprops ^
-excludebyattribute:"System.CodeDom.Compiler.GeneratedCodeAttribute" ^
-output:"%~dp0\CodeCoverageReports\CodeCoverageReport.xml"
exit /b %errorlevel%
 
:RunReportGeneratorOutput
"%~dp0..\packages\ReportGenerator.2.5.9\tools\ReportGenerator.exe" ^
-reports:"%~dp0\CodeCoverageReports\CodeCoverageReport.xml" ^
-targetdir:"%~dp0\CodeCoverageReports\ReportGeneratorOutput"
exit /b %errorlevel%
 
:RunLaunchReport
start "report" "%~dp0\CodeCoverageReports\ReportGeneratorOutput\index.htm"
exit /b %errorlevel%





