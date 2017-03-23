var gulp = require('gulp'),
    rimraf = require('rimraf'),
    plugins = require('gulp-load-plugins')({
        lazy: true
    }),
    runSequence = require('run-sequence');

var paths = {
    dist: 'dist',
    catalyst: '../Catalyst.Web/',
    views: '../Catalyst.Web/views/'
};

gulp.task('clean:dist', function(done) {
    rimraf(paths.dist, done);
});

gulp.task('clean:vs-scripts', function(done) {
    rimraf(paths.catalyst + 'scripts/', done);
});

gulp.task('clean:vs-styles', function(done) {
    rimraf(paths.catalyst + 'styles/', done);
});


gulp.task('move-vs', function() {
    gulp.src(paths.dist + 'scripts/*.js')
        .pipe(gulp.dest(paths.catalyst + 'scripts/'));

    gulp.src(paths.dist + 'styles/*.css')
        .pipe(gulp.dest(paths.catalyst + 'styles/'));

    gulp.src(paths.dist + '/*.cshtml')
        .pipe(gulp.dest(paths.views))

    return;
});

gulp.task('default', function(done) {
    runSequence('clean:vs', 'build-vs', 'move-vs', done);
});
