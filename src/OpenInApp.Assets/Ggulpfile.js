/// <binding AfterBuild='concat' Clean='concat' ProjectOpened='concat' />
var gulp = require('gulp');
var bower = require('gulp-bower');
var concat = require('gulp-concat');

gulp.task('concat', function () { return gulp.src(['OpenInAltovaXmlSpy/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInAltovaXmlSpy/README.md')).pipe(gulp.dest('.')); });
gulp.task('concat', function () { return gulp.src(['OpenInApp.Template/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInApp.Template/README.md')).pipe(gulp.dest('.')); });
gulp.task('concat', function () { return gulp.src(['OpenInGimp/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInGimp/README.md')).pipe(gulp.dest('.')); });
gulp.task('concat', function () { return gulp.src(['OpenInMarkdownMonster/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInMarkdownMonster/README.md')).pipe(gulp.dest('.')); });
gulp.task('concat', function () { return gulp.src(['OpenInPaintDotNet/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInPaintDotNet/README.md')).pipe(gulp.dest('.')); });
gulp.task('concat', function () { return gulp.src(['OpenInVS2012/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInVS2012/README.md')).pipe(gulp.dest('.')); });
gulp.task('concat', function () { return gulp.src(['OpenInVS2013/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInVS2013/README.md')).pipe(gulp.dest('.')); });
gulp.task('concat', function () { return gulp.src(['OpenInVS2015/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInVS2015/README.md')).pipe(gulp.dest('.')); });
gulp.task('concat', function () { return gulp.src(['OpenInVS2017Community/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInVS2017Community/README.md')).pipe(gulp.dest('.')); });
gulp.task('concat', function () { return gulp.src(['OpenInVS2017Enterprise/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInVS2017Enterprise/README.md')).pipe(gulp.dest('.')); });
gulp.task('concat', function () { return gulp.src(['OpenInVS2017Professional/ReadMeHeader.md', 'ReadMeCommon.md']).pipe(concat('OpenInVS2017Professional/README.md')).pipe(gulp.dest('.')); });

gulp.task('default', ['concat']);
