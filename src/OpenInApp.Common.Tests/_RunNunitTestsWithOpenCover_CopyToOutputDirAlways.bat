..\..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe

"..\..\..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" -target:"..\..\..\packages\NUnit.Runners.2.6.3\tools\nunit-console.exe" -targetargs:"/nologo OpenInApp.Common.Tests.dll /noshadow" -filter:"+[OpenInApp.Common.Tests]OpenInApp.Common.Tests*" -excludebyattribute:"System.CodeDom.Compiler.GeneratedCodeAttribute" -register:user -output:"_CodeCoverageResult7.xml"



"..\..\..\packages\ReportGenerator.2.5.9\tools\ReportGenerator.exe" "-reports:_CodeCoverageResult7.xml" "-targetdir:_CodeCoverageReport7"
REM target:"..\..\..\packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe"
