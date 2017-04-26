# Change log

These are the changes to each version that has been released in the Visual Studio Marketplace.

## 1.1.1 
**2017-04-26** 
- [x] Add context menu command to Code Editor window
- [x] Remove context menu command from Solution node in solution explorer
- [x] Remove context menu command from Project node in solution explorer
- [x] Save all files before opening in external application
- [x] Consolidate separate code repositories into a single code repository

# Historic Change log

These are the changes to each version that has been released in the Visual Studio Marketplace, prior to consolidation into a single code repository.

## Altova Xml Spy
### 1.0.148
**2017-01-24** 
- [x] Bug fix for Tools > Options conflicts with other ["Open In" VS extensions](https://marketplace.visualstudio.com/search?term=trevellick&target=VS&sortBy=Relevance).
### 1.0.137
**2017-01-18** 
- [x] Enable wildcard as file type in options
- [x] Bug fix for typical file types being case-sensitive
### 1.0.0
**2016-12-20** 
- [x] Initial release

## GIMP
### 1.0.47
**2017-01-24** 
- [x] Bug fix for Tools > Options conflicts with other ["Open In" VS extensions](https://marketplace.visualstudio.com/search?term=trevellick&target=VS&sortBy=Relevance).
### 1.0.11
**2017-01-11**
- [x] Initial release

## Markdown Monster
### 1.0.60
**2017-01-24** 
- [x] Bug fix for Tools > Options conflicts with other ["Open In" VS extensions](https://marketplace.visualstudio.com/search?term=trevellick&target=VS&sortBy=Relevance).
### 1.0.49
**2017-01-18** 
- [x] Asterisk as wildcard for typical files types
### 1.0.24
**2017-01-10** 
- [x] Initial release

## Paint Dot Net 
### 1.0.59
**2017-01-24**
- [x] Bug fix for Tools > Options conflicts with other ["Open In" VS extensions](https://marketplace.visualstudio.com/search?term=trevellick&target=VS&sortBy=Relevance).
### 1.0.27
**2017-01-09**
- [x] Initial release

## Visual Studio 2012 
### 1.0.0
**2017-01-30** 
- [x] Initial release

## Visual Studio 2013 
### 1.0.0
**2017-01-30** 
- [x] Initial release

## Visual Studio 2015
### 1.0.0
**2017-01-30** 
- [x] Initial release

## Visual Studio 2013 Community
### 1.0.3
**2017-02-04** 
- [x] Update logos
### 1.0.2
**2017-01-31** 
- [x] Initial release

## Visual Studio 2017 Enterprise
### 1.0.2
**2017-02-04** 
- [x] Update logos
### 1.0.1
**2017-01-31** 
- [x] Initial release

## Visual Studio 2017 Professional
### 1.0.2
**2017-02-04** 
- [x] Update logos
### 1.0.1
**2017-01-31** 
- [x] Initial release





<!--

NEW 3RD PARTY APP / BUILD PROCESS
=================================
Clone OpenInApp.Template as a new project

Find replace all "gregtgregt" to the be the new app

Copy an existing ReadMeScreenShot_ContextMenu.png (e.g. in OpenInApp.Assets\OpenInApp.Template) into the new folder, & update the wording for the new app

Add new app to Gulpfile.js - this merges ReadMeHeader.md (which has app specific variables) & ReadMeCommon.md (the generic readme for each vsix, located in OpenInApp.Assets\ReadMeCommon.md) into ReadMe.md inside the app folder in OpenInApp.Template project - this app specific ReadMe.md isn't for the GitHub landing page of OIA.Launcher, but the content is for copy/pasting into the VSMP page for the app itself

Build solution - this will create/populate a folder for the app inside the OpenInApp.Assets project & create (e.g) C:\Users\greg\Source\Repos\OpenInApp.Launcher\src\OpenInGimp\bin\Debug\OpenInAppGimp.vsix for subsequent uploading

Publish the new project as a vsix in the usual manner - takes a few minutes 

specify the new vsix as C:\Users\greg\Source\Repos\OpenInApp.Launcher\Src\OpenInGimp\bin\Debug\OpenInAppGimp.vsix

ensure vsmp has the repo url as "https://github.com/GregTrevellick/OpenInApp.Launcher" not "https://github.com/GregTrevellick/OpenInGimp"

rename "https://github.com/GregTrevellick/OpenInGimp" to have a "Z" prefix

retire "https://ci.appveyor.com/project/GregTrevellick/openingimp"

update the VSMP extension description from "https://github.com/GregTrevellick/OpenInApp.Launcher/blob/master/src/OpenInApp.Assets/OpenInGimp/README.md" (not from Visual Studio IDE)


FUTURE 
======

integrate with coverall.io & add unit test code coverage badge    
http://ngeor.net/2016/03/code-coverage-for-open-source-net-with-appveyor-and-coveralls/    
https://cetus.io/tim/Digging-in/    
https://coding.abel.nu/2016/06/code-coverage-on-github-prs-with-coveralls-io/    
https://refwarlockprog.wordpress.com/2015/10/17/my-experience-with-coverall-net-with-appveyor-ci/    
http://www.blog.ryanbartsch.com/2016/11/Code-coverage-with-Appveyor-and-Coveralls/    
https://coveralls.zendesk.com/hc/en-us/articles/203488029    
https://github.com/csmacnz/coveralls.net    
https://github.com/jdeering/coveralls.net

hide buttons based on file type (no gimp/pdn for txt files for example)

close down old repos, appveyor defns, nuget pkgs

vs2017 upgrade

-->