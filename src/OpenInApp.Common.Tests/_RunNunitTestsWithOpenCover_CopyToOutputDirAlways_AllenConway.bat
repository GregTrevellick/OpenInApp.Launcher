REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"
 
REM Remove any previous test execution files to prevent issues overwriting
IF EXIST "%~dp0BowlingSPAService.trx" del "%~dp0BowlingSPAService.trx%"
 
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
"%~dp0..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS120COMNTOOLS%\..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0..\BowlingSPAService.Tests\bin\Debug\BowlingSPAService.Tests.dll\" /resultsfile:\"%~dp0BowlingSPAService.trx\"" ^
-filter:"+[BowlingSPAService*]* -[BowlingSPAService.Tests]* -[*]BowlingSPAService.RouteConfig" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0\GeneratedReports\BowlingSPAServiceReport.xml"
exit /b %errorlevel%
 
:RunReportGeneratorOutput
"%~dp0..\packages\ReportGenerator.2.1.5.0\ReportGenerator.exe" ^
-reports:"%~dp0\GeneratedReports\BowlingSPAServiceReport.xml" ^
-targetdir:"%~dp0\GeneratedReports\ReportGenerator Output"
exit /b %errorlevel%
 
:RunLaunchReport
start "report" "%~dp0\GeneratedReports\ReportGenerator Output\index.htm"
exit /b %errorlevel%

