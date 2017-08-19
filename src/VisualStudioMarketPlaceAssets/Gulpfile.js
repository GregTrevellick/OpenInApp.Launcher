/// <binding AfterBuild='default' ProjectOpened='default' />
var gulp = require('gulp');
var bower = require('gulp-bower');
var concat = require('gulp-concat');
var replace = require('gulp-replace');

gulp.task('OpenInAbracadabra', function () { return OIAConcat('OpenInAbracadabra', 'Abracadabra') });
gulp.task('OpenInAltovaXmlSpy', function () { return OIAConcat('OpenInAltovaXmlSpy', 'Altova XMLSpy XML Editor') });
gulp.task('OpenInAndroidStudio', function () { return OIAConcat('OpenInAndroidStudio', 'Android Studio') });
gulp.task('OpenInAtom', function () { return OIAConcat('OpenInAtom', 'Atom') });
gulp.task('OpenInChromeCanary', function () { return OIAConcat('OpenInChromeCanary', 'Chrome Canary') });
gulp.task('OpenInEmacs', function () { return OIAConcat('OpenInEmacs', 'Emacs') });
gulp.task('OpenInFirefoxDeveloperEdition', function () { return OIAConcat('OpenInFirefoxDeveloperEdition', 'Firefox Developer Edition') });
gulp.task('OpenInGimp', function () { return OIAConcat('OpenInGimp', 'GIMP') });
gulp.task('OpenInMSPaint', function () { return OIAConcat('OpenInMSPaint', 'MS Paint') });
gulp.task('OpenInMarkdownMonster', function () { return OIAConcat('OpenInMarkdownMonster', 'Markdown Monster') });
gulp.task('OpenInOpera', function () { return OIAConcat('OpenInOpera', 'Opera') });
gulp.task('OpenInOperaDeveloper', function () { return OIAConcat('OpenInOperaDeveloper', 'Opera Developer') });
gulp.task('OpenInPaintDotNet', function () { return OIAConcat('OpenInPaintDotNet', 'paint.net') });
gulp.task('OpenInSQLServerManagementStudio', function () { return OIAConcat('OpenInSQLServerManagementStudio', 'Sequel Server Management Studio') });
gulp.task('OpenInTreeSizeFree', function () { return OIAConcat('OpenInTreeSizeFree', 'TreeSize Free') });
gulp.task('OpenInTreeSizeProfessional', function () { return OIAConcat('OpenInTreeSizeProfessional', 'TreeSize Professional') });
gulp.task('OpenInVivaldi', function () { return OIAConcat('OpenInVivaldi', 'Vivaldi Web Browser') });
gulp.task('OpenInVS2012', function () { return OIAConcat('OpenInVS2012', 'Visual Studio 2012') });
gulp.task('OpenInVS2013', function () { return OIAConcat('OpenInVS2013', 'Visual Studio 2013') });
gulp.task('OpenInVS2015', function () { return OIAConcat('OpenInVS2015', 'Visual Studio 2015') });
gulp.task('OpenInVS2017Community', function () { return OIAConcat('OpenInVS2017Community', 'Visual Studio 2017 Community Edition') });
gulp.task('OpenInVS2017Enterprise', function () { return OIAConcat('OpenInVS2017Enterprise', 'Visual Studio 2017 Enterprise Edition') });
gulp.task('OpenInVS2017Professional', function () { return OIAConcat('OpenInVS2017Professional', 'Visual Studio 2017 Professional Edition') });
gulp.task('OpenInWinDirStat', function () { return OIAConcat('OpenInWinDirStat', 'WinDirStat') });
gulp.task('OpenInXamarinStudio', function () { return OIAConcat('OpenInXamarinStudio', 'Xamarin Studio') });

gulp.task('default',
    ['OpenInAbracadabra'
    , 'OpenInAltovaXmlSpy'
    , 'OpenInAndroidStudio'
    , 'OpenInAtom'
    , 'OpenInChromeCanary'
    , 'OpenInEmacs'
    , 'OpenInFirefoxDeveloperEdition'
    , 'OpenInGimp'
    , 'OpenInMarkdownMonster'
    , 'OpenInMSPaint'
    , 'OpenInOpera'
    , 'OpenInOperaDeveloper'
    , 'OpenInPaintDotNet'
    , 'OpenInSQLServerManagementStudio'
    , 'OpenInTreeSizeFree'
    , 'OpenInTreeSizeProfessional'
    , 'OpenInVivaldi'
    , 'OpenInVS2012'
    , 'OpenInVS2013'
    , 'OpenInVS2015'
    , 'OpenInVS2017Community'
    , 'OpenInVS2017Enterprise'
    , 'OpenInVS2017Professional'
    , 'OpenInWinDirStat'
    , 'OpenInXamarinStudio']);

function OIAConcat (appNam, appDesc) { 

    var filesToConcat = [appNam + '/0_Variables.md'];

    var appType = GetAppType(appNam);
    
    if (appType === 'FilesOnly') {
        filesToConcat.push(
            '1_Introduction_Files.md',
            '2_FreeReviews.md',
            '3_Features_Files.md',
            '4_FileTypeWarnings.md',
            '4b_FileQuantityWarnings.md',
            '5_UseCases_Files.md',
            '6_Links.md'
        );
    }

    if (appType === 'FilesAndFolders') {
        filesToConcat.push(
            '1_Introduction_FilesAndFolders.md',
            '2_FreeReviews.md',
            '3_Features_FilesAndFolders.md',
            '4_FileTypeWarnings.md',
            '4b_FileQuantityWarnings.md',
            '5_UseCases_Files.md',
            '6_Links.md'
        );
    }

    return gulp
        .src(filesToConcat)
        .pipe(concat(appNam + '/README.md'))
        .pipe(replace('[ThirdPartyApp]', '[' + appDesc + ']'))
        .pipe(gulp.dest('.'));
} 

//TODO add qunit tests for this function
function GetAppType(appNam) {

    var appType = "Undefined";

    if (appNam === 'OpenInChromeCanary' ||
        appNam === 'OpenInFirefoxDeveloperEdition' ||
        appNam === 'OpenInOpera' ||
        appNam === 'OpenInOperaDeveloper' ||
        appNam === 'OpenInSQLServerManagementStudio' ||
        appNam === 'OpenInVivaldi') {
            appType = 'FilesOnly'
    }

    if (appNam === 'OpenInAltovaXmlSpy' ||
        appNam === 'OpenInAndroidStudio' ||
        appNam === 'OpenInAtom' ||
        appNam === 'OpenInEmacs' ||
        appNam === 'OpenInGimp' ||
        appNam === 'OpenInMarkdownMonster' ||
        appNam === 'OpenInMSPaint' ||
        appNam === 'OpenInPaintDotNet' ||
        appNam === 'OpenInTreeSizeFree' ||
        appNam === 'OpenInTreeSizeProfessional' ||
        appNam === 'OpenInVS2012' ||
        appNam === 'OpenInVS2013' ||
        appNam === 'OpenInVS2015' ||
        appNam === 'OpenInVS2017Community' ||
        appNam === 'OpenInVS2017Enterprise' ||
        appNam === 'OpenInVS2017Professional' ||
        appNam === 'OpenInWinDirStat' ||
        appNam === 'OpenInXamarinStudio') {
            appType = 'FilesAndFolders'
    }

    return appType;
}
