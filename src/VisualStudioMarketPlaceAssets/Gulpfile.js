/// <binding AfterBuild='default' ProjectOpened='default' />
var gulp = require('gulp');
var bower = require('gulp-bower');
var concat = require('gulp-concat');
var replace = require('gulp-replace');

gulp.task('OpenInAbracadabra', function () { return OIAConcat('OpenInAbracadabra', 'Abracadabra') });
gulp.task('OpenInAltovaXmlSpy', function () { return OIAConcat('OpenInAltovaXmlSpy', 'Altova XMLSpy XML Editor') });
gulp.task('OpenInChromeCanary', function () { return OIAConcat('OpenInChromeCanary', 'Chrome Canary') });
gulp.task('OpenInEmacs', function () { return OIAConcat('OpenInEmacs', 'Emacs') });
gulp.task('OpenInFirefoxDeveloperEdition', function () { return OIAConcat('OpenInFirefoxDeveloperEdition', 'Firefox Developer Edition') });
gulp.task('OpenInGimp', function () { return OIAConcat('OpenInGimp', 'GIMP') });
gulp.task('OpenInMSPaint', function () { return OIAConcat('OpenInMSPaint', 'MS Paint') });
gulp.task('OpenInMarkdownMonster', function () { return OIAConcat('OpenInMarkdownMonster', 'Markdown Monster') });
gulp.task('OpenInOpera', function () { return OIAConcat('OpenInOpera', 'Opera') });
gulp.task('OpenInOperaDeveloper', function () { return OIAConcat('OpenInOperaDeveloper', 'Opera Developer') });
gulp.task('OpenInPaintDotNet', function () { return OIAConcat('OpenInPaintDotNet', 'paint.net') });
gulp.task('OpenInVivaldi', function () { return OIAConcat('OpenInVivaldi', 'Vivaldi Web Browser') });
gulp.task('OpenInVS2012', function () { return OIAConcat('OpenInVS2012', 'Visual Studio 2012') });
gulp.task('OpenInVS2013', function () { return OIAConcat('OpenInVS2013', 'Visual Studio 2013') });
gulp.task('OpenInVS2015', function () { return OIAConcat('OpenInVS2015', 'Visual Studio 2015') });
gulp.task('OpenInVS2017Community', function () { return OIAConcat('OpenInVS2017Community', 'Visual Studio 2017 Community Edition') });
gulp.task('OpenInVS2017Enterprise', function () { return OIAConcat('OpenInVS2017Enterprise', 'Visual Studio 2017 Enterprise Edition') });
gulp.task('OpenInVS2017Professional', function () { return OIAConcat('OpenInVS2017Professional', 'Visual Studio 2017 Professional Edition') });
gulp.task('OpenInXamarinStudio', function () { return OIAConcat('OpenInXamarinStudio', 'Xamarin Studio') });

gulp.task('default',
    [ 'OpenInAbracadabra'
    , 'OpenInAltovaXmlSpy'
    , 'OpenInChromeCanary'
    , 'OpenInEmacs'
    , 'OpenInFirefoxDeveloperEdition'
    , 'OpenInGimp'
    , 'OpenInMarkdownMonster'
    , 'OpenInMSPaint'
    , 'OpenInOpera'
    , 'OpenInOperaDeveloper'
    , 'OpenInPaintDotNet'
    , 'OpenInVivaldi'
    , 'OpenInVS2012'
    , 'OpenInVS2013'
    , 'OpenInVS2015'
    , 'OpenInVS2017Community'
    , 'OpenInVS2017Enterprise'
    , 'OpenInVS2017Professional'
    , 'OpenInXamarinStudio']);

function OIAConcat (appNam, appDesc) { 
    return gulp
        .src([appNam + '/ReadMeHeader.md', 'VsmpCommonDescription.md'])
        .pipe(concat(appNam + '/README.md'))
        .pipe(replace('[ThirdPartyApp]', '[' + appDesc + ']'))
        .pipe(gulp.dest('.'));
} 
 