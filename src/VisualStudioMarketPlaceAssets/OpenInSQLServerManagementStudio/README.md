[ThirdPartyAppHomePage]: https://www.microsoft.com/en-us/sql-server/

Open multiple files simultaneously in [Sequel Server Management Studio][ThirdPartyAppHomePage] directly from [Visual Studio's][VisualStudioURL] Code Editor window and / or Solution Explorer.


 - *If you like this ***free*** tool please take a few seconds out to give a star rating below*.

Similar "Open In" VS extensions can be found [here](https://marketplace.visualstudio.com/search?term=trevellick&target=VS&sortBy=Relevance).

[![][ThirdPartyAppOfficialLogo]][ThirdPartyAppHomePage]

![](ThirdPartyScreenShot.png)

## Features

- Open multiple files simultaneously in [Sequel Server Management Studio][ThirdPartyAppHomePage].

- Within the code editor window

  ![](ReadMeScreenShot_CodeEditorWindow.png)

- From solution explorer at item level
 
  ![](ReadMeScreenShot_ContextMenu.png)

- Warning if attempting to open a large quantity of files. The quantity is configurable in Tools > Options.

  ![](../Generic_ReadMeScreenShot_WarningLargeQuantity.png)


- Warning if attempting to open one or more file types whose extension is not typically associated with [Sequel Server Management Studio][ThirdPartyAppHomePage]. The list of typical file extensions is configurable in Tools > Options.

  ![](../Generic_ReadMeScreenShot_WarningNonTypical.png)

- Option to supress the warning message if attempting to open a file whose extension is not typically associated with [Sequel Server Management Studio][ThirdPartyAppHomePage].

  ![](../Generic_ReadMeScreenShot_OptionsGeneral.png)


## Use Cases

The [Visual Studio IDE][VisualStudioURL] has an outstanding and feature-rich editor for a wide range of file types, even in the free "Community" editions, which can be overridden to open a third-party application.

That said, there may be times when you wish to edit a file in an alternative editor/application without overriding the default [Visual Studio][VisualStudioURL] editor, for example:-

- You only occasionally wish to use a specific alternative editor.

- You have overriden the default [Visual Studio][VisualStudioURL] editor to a particular application, but need easy IDE access to a second particular editor.

- Certain files (e.g. gigantic size files, or files with complex content) may be better suited in an alternative editor.

- Pair programming scenarios where each developer has different preferred editor.

- You are more familiar with a certain editor's features, or simply have a favourite editor.


[ThirdPartyAppOfficialLogo]: ThirdPartyLogo.png
[VisualStudioURL]: https://www.visualstudio.com/