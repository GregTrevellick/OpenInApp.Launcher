/// <binding AfterBuild='concat' />
var gulp = require('gulp');
var bower = require('gulp-bower');
var concat = require('gulp-concat');

gulp.task('concat', function () {
    return gulp.src([
        '../../assets/ReadMeCommon00LauncherAppVariables.md',
        'Assets/ReadMeCommon00ThirdPartyAppVariables.md',
        '../../assets/ReadMeCommon10GitHubTitle.md',
        '../../assets/ReadMeCommon20GitHubHeader.md',
        '../../assets/ReadMeCommon30VSMarketplaceHeader.md',
        '../../assets/ReadMeCommon40VSMarketplaceFeatures.md',
        '../../assets/ReadMeCommon50VSMarketplaceUseCases.md',
        '../../assets/ReadMeCommon60GitHubLegal.md',
        '../../assets/ReadMeCommon70GitHubCredits.md',
        '../../assets/ReadMeCommon80GitHubMiscellaneous.md',
        '../../assets/ReadMeCommon90GitHubFooter.md'
    ])
    .pipe(concat('Assets/README.md'))
    .pipe(gulp.dest('.'));
});

gulp.task('default', ['concat']);
