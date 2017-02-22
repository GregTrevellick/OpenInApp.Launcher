/// <binding AfterBuild='concat' Clean='concat' ProjectOpened='concat' />
var gulp = require('gulp');
var bower = require('gulp-bower');
var concat = require('gulp-concat');

//gulp.task('myConcat', function () { return gulp.src(['OpenInAltovaXmlSpy/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInAltovaXmlSpy/README.md')).pipe(gulp.dest('.')); });
//gulp.task('myConcat', function () { return gulp.src(['OpenInApp.Template/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInApp.Template/README.md')).pipe(gulp.dest('.')); });
//gulp.task('myConcat', function () { return gulp.src(['OpenInGimp/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInGimp/README.md')).pipe(gulp.dest('.')); });
//gulp.task('myConcat', function () { return gulp.src(['OpenInMarkdownMonster/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInMarkdownMonster/README.md')).pipe(gulp.dest('.')); });
//gulp.task('myConcat', function () { return gulp.src(['OpenInPaintDotNet/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInPaintDotNet/README.md')).pipe(gulp.dest('.')); });
//gulp.task('myConcat', function () { return gulp.src(['OpenInVS2012/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInVS2012/README.md')).pipe(gulp.dest('.')); });
//gulp.task('myConcat', function () { return gulp.src(['OpenInVS2013/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInVS2013/README.md')).pipe(gulp.dest('.')); });
//gulp.task('myConcat', function () { return gulp.src(['OpenInVS2015/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInVS2015/README.md')).pipe(gulp.dest('.')); });
//gulp.task('myConcat', function () { return gulp.src(['OpenInVS2017Community/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInVS2017Community/README.md')).pipe(gulp.dest('.')); });
//gulp.task('myConcat', function () { return gulp.src(['OpenInVS2017Enterprise/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInVS2017Enterprise/README.md')).pipe(gulp.dest('.')); });
//gulp.task('myConcat', function () { return gulp.src(['OpenInVS2017Professional/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInVS2017Professional/README.md')).pipe(gulp.dest('.')); });

gulp.task('OpenInAltovaXmlSpy', function () { return OIAConcat('OpenInAltovaXmlSpy') });
gulp.task('OpenInApp.Template', function () { return OIAConcat('OpenInApp.Template') });
gulp.task('OpenInGimp', function () { return OIAConcat('OpenInGimp') });
gulp.task('OpenInMarkdownMonster', function () { return OIAConcat('OpenInMarkdownMonster') });
gulp.task('OpenInPaintDotNet', function () { return OIAConcat('OpenInPaintDotNet') });
gulp.task('OpenInVS2012', function () { return OIAConcat('OpenInVS2012') });
gulp.task('OpenInVS2013', function () { return OIAConcat('OpenInVS2013') });
gulp.task('OpenInVS2015', function () { return OIAConcat('OpenInVS2015') });
gulp.task('OpenInVS2017Community', function () { return OIAConcat('OpenInVS2017Community') });
gulp.task('OpenInVS2017Enterprise', function () { return OIAConcat('OpenInVS2017Enterprise') });
gulp.task('OpenInVS2017Professional', function () { return OIAConcat('OpenInVS2017Professional') });



gulp.task('default', [
  'OpenInAltovaXmlSpy'
, 'OpenInApp.Template'
, 'OpenInGimp'
, 'OpenInMarkdownMonster'
, 'OpenInPaintDotNet'
, 'OpenInVS2012'
, 'OpenInVS2013'
, 'OpenInVS2015'
, 'OpenInVS2017Community'
, 'OpenInVS2017Enterprise'
, 'OpenInVS2017Professional']);







function OIAConcat (appNam) { 
    return gulp.src([appNam+'/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat(appNam+'/README.md')).pipe(gulp.dest('.')); 
}