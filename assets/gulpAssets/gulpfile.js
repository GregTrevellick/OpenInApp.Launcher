/// <binding AfterBuild='concat' />
var gulp = require('gulp');
var bower = require('gulp-bower');
var concat = require('gulp-concat');

gulp.task('concat', function () {
    return gulp.src(['Assets/README_Header.md', 'Assets/README_Footer.md'])
    .pipe(concat('Assets/README_COMBINED.md'))
    .pipe(gulp.dest('.'));
});

gulp.task('default', ['concat']);