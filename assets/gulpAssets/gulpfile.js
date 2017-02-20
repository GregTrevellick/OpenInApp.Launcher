/// <binding AfterBuild='concat' />
var gulp = require('gulp');
var bower = require('gulp-bower');
var concat = require('gulp-concat');

gulp.task('concat', function () {
    return gulp.src(['README_Header.md', '../../src/OpenInAltovaXmlSpy/Assets/CHANGELOG.md', 'README_Footer.md'])
    .pipe(concat('../../src/OpenInAltovaXmlSpy/Assets/README_COMBINED.md'))
    .pipe(gulp.dest('.'));
});

gulp.task('default', ['concat']);