/// <binding AfterBuild='concat' />
var gulp = require('gulp');
var bower = require('gulp-bower');
var concat = require('gulp-concat');

gulp.task('concat', function () {
    return gulp.src([
        'CommonAssets/ReadMeCommon00LauncherAppVariables.md',
        'ProjectAssets/Gimp/ReadMeCommon00ThirdPartyAppVariables.md',
        'CommonAssets/ReadMeCommon10GitHubTitle.md',
        'CommonAssets/ReadMeCommon20GitHubHeader.md',
        'CommonAssets/ReadMeCommon30VSMarketplaceHeader.md',
        'CommonAssets/ReadMeCommon40VSMarketplaceFeatures.md',
        'CommonAssets/ReadMeCommon50VSMarketplaceUseCases.md',
        'CommonAssets/ReadMeCommon60GitHubLegal.md',
        'CommonAssets/ReadMeCommon70GitHubCredits.md',
        'CommonAssets/ReadMeCommon80GitHubMiscellaneous.md',
        'CommonAssets/ReadMeCommon90GitHubFooter.md'
    ])
    .pipe(concat('ProjectAssets/Gimp/README.md'))
    .pipe(gulp.dest('.'));
});

gulp.task('default', ['concat']);
