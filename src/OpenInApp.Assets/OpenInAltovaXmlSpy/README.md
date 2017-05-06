[ThirdPartyAppHomePage]: http://www.altova.com/xml-editor/
<!-- Logo source = http://www.altova.com/images/linktoaltova/xmlspy.png -->
[VersionNumberBadgeURL]: https://vsmarketplacebadge.apphb.com/version/GregTrevellick.OpenInAltovaXmlSpy.svg
[VSMarketplaceUrl]: https://marketplace.visualstudio.com/items?itemName=GregTrevellick.OpenInAltovaXmlSpy
[VSMarketplaceReviewsUrl]: https://marketplace.visualstudio.com/items?itemName=GregTrevellick.OpenInAltovaXmlSpy#review-details

# Open In Altova XmlSpy

[![License](https://img.shields.io/github/license/gittools/gitlink.svg)](/LICENSE.txt)
[![Build status][AppVeyorProjectBuildStatusBadgeSvg]][AppVeyorProjectUrl]
[![][VersionNumberBadgeURL]][VSMarketplaceUrl]

This [Visual Studio][VisualStudioURL] extension is officially available at the [Visual Studio Marketplace][VSMarketplaceUrl].

---------------------------------------

<!-- COPY START FOR VS GALLERY -->

![](../Generic_ReadMeAnimatedUsage.gif)

Open multiple files simultaneously in [Altova XMLSpy XML Editor][ThirdPartyAppHomePage] directly from [Visual Studio's][VisualStudioURL] Code Editor window and / or Solution Explorer.

If you like this ***free*** extension, please give it a [review][VSMarketplaceReviewsUrl].

Similar "Open In" VS extensions can be found [here](https://marketplace.visualstudio.com/search?term=trevellick&target=VS&sortBy=Relevance).

[![][ThirdPartyAppOfficialLogo]][ThirdPartyAppHomePage]

## Features

- Open multiple files simultaneously in [Altova XMLSpy XML Editor][ThirdPartyAppHomePage] with VS2012, VS2013 and VS2015.

  ![](ReadMeScreenShot_ContextMenu.png)

- Warning if attempting to open a large quantity of files. The quantity is configurable in Tools > Options.

  ![](../Generic_ReadMeScreenShot_WarningLargeQuantity.png)

- Warning if attempting to open one or more file types whose extension is not typically associated with [Altova XMLSpy XML Editor][ThirdPartyAppHomePage]. The list of typical file extensions is configurable in Tools > Options.

  ![](../Generic_ReadMeScreenShot_WarningNonTypical.png)

- Option to supress the warning message if attempting to open a file whose extension is not typically associated with [Altova XMLSpy XML Editor][ThirdPartyAppHomePage].

  ![](../Generic_ReadMeScreenShot_OptionsGeneral.png)

## Use Cases

The [Visual Studio IDE][VisualStudioURL] has an outstanding and feature-rich editor for a wide range of file types, even in the free "Community" editions, which can be overridden to open a third-party application.

That said, there may be times when you wish to edit a file in an alternative editor/application without overriding the default [Visual Studio][VisualStudioURL] editor, for example:-

- You only occasionally wish to use a specific alternative editor.

- You have overriden the default [Visual Studio][VisualStudioURL] editor to a particular application, but need easy IDE access to a second particular editor.

- Certain files (e.g. gigantic size files, or files with complex content) may be better suited in an alternative editor.

- Pair programming scenarios where each developer has different preferred editor.

- You are more familiar with a certain editor's features, or simply have a favourite editor.

<!-- COPY END FOR VS GALLERY -->

## Legal

The [owner](https://github.com/GregTrevellick) of this [GitHub repository / software][GitHubRepoURL] is not affiliated, associated, authorized, endorsed by, employed by, sponsored by, or in any way officially connected with [Altova XMLSpy XML Editor][ThirdPartyAppHomePage] or any of its subsidiaries or its affiliates.

Nor has [this][GitHubRepoURL] software been authorised, approved, verified or in anyway assessed by [Altova XMLSpy XML Editor][ThirdPartyAppHomePage], or any of its subsidiaries or its affiliates, either as [raw source code][GitHubRepoURL] on [GitHub.com](https://github.com/) or as a [Visual Studio Extension][VSMarketplaceUrl] in the [Visual Studio Marketplace](https://marketplace.visualstudio.com/vs).

All Trademark, intellectual property rights, and other rights belonging to [Altova XMLSpy XML Editor][ThirdPartyAppHomePage] as described in [here][ThirdPartyAppHomePage] apply.

All [Altova XMLSpy XML Editor][ThirdPartyAppHomePage] logos and [Altova XMLSpy XML Editor][ThirdPartyAppHomePage] links belong to [Altova XMLSpy XML Editor][ThirdPartyAppHomePage] and their use here and any associated goodwill inures to [Altova XMLSpy XML Editor][ThirdPartyAppHomePage].

In no event shall [Altova XMLSpy XML Editor][ThirdPartyAppHomePage] be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the software or the use or dealings in the software.

## Credits

Inspired and adapted from these original code repositories

- [Mads Kristensen](https://github.com/madskristensen) 
  - [Open in Sublime Text](https://github.com/madskristensen/OpenInSublimeText/ "Open in Sublime Text")
  - [Open in Visual Studio Code](https://github.com/madskristensen/OpenInVsCode "Open in Visual Studio Code")
- [Calvin Allen](https://github.com/CalvinAllen) 
  - [Open in NotePad++](https://github.com/CalvinAllen/OpenInNotepadPlusPlus  "Open in NotePad++") 
- [Cem Yabansu](https://github.com/cemyabansu) 
  - [Publish In Crm](https://github.com/cemyabansu/PublishInCrm "Publish In Crm")

Special thanks to the following educational resources

- [Carlos Quintero](http://www.visualstudioextensibility.com/)
- [Visual Studio Extensibility code samples](https://github.com/visualstudioextensibility/VSX-Samples)
- [Build 2016 Conference](https://channel9.msdn.com/Events/Build/2016/B886) 
- [Visual Studio Toolbox](https://channel9.msdn.com/Shows/Visual-Studio-Toolbox/Extensions-by-Mads-Kristensen)

Additional thanks to 
- [Screen To Gif](http://www.screentogif.com/) 
- [Paint Dot Net](http://www.getpaint.net/)  
- [Altova XMLSpy XML Editor][ThirdPartyAppHomePage] 

## Miscellaneous

Contributions to this project are welcome by raising an [Issue][GitHubRepoIssuesURL] or submitting a [Pull Request][GitHubRepoPullRequestsURL].

See the [change log](CHANGELOG.md) for release history.

Bugs can be logged [here][GitHubRepoIssuesURL].

[Software License](/LICENSE.txt).

[![](chart.png)][GitHubPagesURL]

[AppVeyorProjectUrl]: https://ci.appveyor.com/project/GregTrevellick/openinapp-launcher
[AppVeyorProjectBuildStatusBadgeSvg]: https://ci.appveyor.com/api/projects/status/0vwmtcboontemltq?svg=true
[GitHubPagesURL]: https://gregtrevellick.github.io/OpenInApp.Launcher/
[GitHubRepoURL]: https://github.com/GregTrevellick/OpenInApp.Launcher
[GitHubRepoIssuesURL]: https://github.com/GregTrevellick/OpenInApp.Launcher/issues
[GitHubRepoPullRequestsURL]: https://github.com/GregTrevellick/OpenInApp.Launcher/pulls
[ThirdPartyAppOfficialLogo]: ThirdPartyLogo.png
[VisualStudioURL]: https://www.visualstudio.com/
