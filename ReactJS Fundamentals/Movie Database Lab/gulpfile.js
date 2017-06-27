let gulp = require('gulp');
let gutil = require('gulp-util');
let gulpif = require('gulp-if');
let autoprefixer = require('gulp-autoprefixer');
let cssmin = require('gulp-cssmin');
let less = require('gulp-less');
let concat = require('gulp-concat');
let plumber = require('gulp-plumber');
let buffer = require('vinyl-buffer');
let source = require('vinyl-source-stream');
let babelify = require('babelify');
let browserify = require('browserify');
let watchify = require('watchify');
let uglify = require('gulp-uglify');
let sourcemaps = require('gulp-sourcemaps');

let production = process.env.NODE_ENV === 'production';

let dependencies = [
    'react',
    'react-dom',
    'react-router',
    'underscore'
];

/*
 |--------------------------------------------------------------------------
 | Combine all JS libraries into a single file for fewer HTTP requests.
 |--------------------------------------------------------------------------
 */
gulp.task('vendor', function () {
    return gulp.src([
        'bower_components/jquery/dist/jquery.js',
        'bower_components/bootstrap/dist/scripts/bootstrap.js',
        'bower_components/magnific-popup/dist/jquery.magnific-popup.js',
        'bower_components/toastr/toastr.js',
        'bower_components/bootstrap-star-rating/star-rating.min.js'
    ]).pipe(concat('vendor.js'))
        .pipe(gulpif(production, uglify({mangle: false})))
        .pipe(gulp.dest('public/scripts'));
});

/*
 |--------------------------------------------------------------------------
 | Compile third-party dependencies separately for faster performance.
 |--------------------------------------------------------------------------
 */
gulp.task('browserify-vendor', function () {
    return browserify()
        .require(dependencies)
        .bundle()
        .pipe(source('vendor.bundle.js'))
        .pipe(buffer())
        .pipe(gulpif(production, uglify({mangle: false})))
        .pipe(gulp.dest('public/scripts'));
});

/*
 |--------------------------------------------------------------------------
 | Compile only project files, excluding all third-party dependencies.
 |--------------------------------------------------------------------------
 */
gulp.task('browserify', ['browserify-vendor'], function () {
    return browserify({entries: 'source/client/main.js', debug: true})
        .external(dependencies)
        .transform(babelify, {presets: ['es2015', 'react']})
        .bundle()
        .pipe(source('bundle.js'))
        .pipe(buffer())
        .pipe(sourcemaps.init({loadMaps: true}))
        .pipe(gulpif(production, uglify({mangle: false})))
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest('public/scripts'));
});

/*
 |--------------------------------------------------------------------------
 | Same as browserify task, but will also watch for changes and re-compile.
 |--------------------------------------------------------------------------
 */
gulp.task('browserify-watch', ['browserify-vendor'], function () {
    let bundler = watchify(browserify({entries: 'source/client/main.js', debug: true}, watchify.args));
    bundler.external(dependencies);
    bundler.transform(babelify, {presets: ['es2015', 'react']});
    bundler.on('update', rebundle);
    return rebundle();

    function rebundle() {
        let start = Date.now();
        return bundler.bundle()
            .on('error', function (err) {
                gutil.log(gutil.colors.red(err.toString()));
            })
            .on('end', function () {
                gutil.log(gutil.colors.green('Finished rebundling in', (Date.now() - start) + 'ms.'));
            })
            .pipe(source('bundle.js'))
            .pipe(buffer())
            .pipe(sourcemaps.init({loadMaps: true}))
            .pipe(sourcemaps.write('.'))
            .pipe(gulp.dest('public/scripts/'));
    }
});

/*
 |--------------------------------------------------------------------------
 | Compile LESS styles.
 |--------------------------------------------------------------------------
 */
gulp.task('styles', function () {
    return gulp.src('source/client/styles/main.less')
        .pipe(plumber())
        .pipe(less())
        .pipe(autoprefixer())
        .pipe(gulpif(production, cssmin()))
        .pipe(gulp.dest('public/styles'));
});

gulp.task('watch', function () {
    gulp.watch('source/client/styles/**/*.less', ['styles']);
});

gulp.task('default', ['styles', 'vendor', 'browserify-watch', 'watch']);
gulp.task('build', ['styles', 'vendor', 'browserify']);