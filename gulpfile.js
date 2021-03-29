var gulp = require('gulp');
var del = require('del');

var paths = {
    bootstrapJs: {
        src: 'node_modules/bootstrap/dist/js/*.js',
        dest: 'wwwroot/lib/bootstrap/dist/js/'
    },
    bootstrapCss: {
        src: 'node_modules/bootstrap/dist/css/*.css',
        dest: 'wwwroot/lib/bootstrap/dist/css/'
    },
    jquery: {
        src: 'node_modules/jquery/dist/jquery.min.js',
        dest: 'wwwroot/lib/jquery/dist/'
    },
    jqueryValidation: {
        src: 'node_modules/jquery-validation/dist/jquery.validate.min.js',
        dest: 'wwwroot/lib/jquery-validation/dist/'
    },
    jqueryValidationUnobtrusive: {
        src: 'node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js',
        dest: 'wwwroot/lib/jquery-validation-unobtrusive/dist/'
    }
};

function clean() {
    // You can use multiple globbing patterns as you would with `gulp.src`,
    // for example if you are using del 2.0 or above, return its promise
    return del(['wwwroot/lib']);
}

function bootstrapJs() {
    return gulp.src(paths.bootstrapJs.src, { sourcemaps: true })
        .pipe(gulp.dest(paths.bootstrapJs.dest));
}

function bootstrapCss() {
    return gulp.src(paths.bootstrapCss.src, { sourcemaps: true })
        .pipe(gulp.dest(paths.bootstrapCss.dest));
}

function jquery() {
    return gulp.src(paths.jquery.src, { sourcemaps: true })
        .pipe(gulp.dest(paths.jquery.dest));
}

function jqueryValidation() {
    return gulp.src(paths.jqueryValidation.src, { sourcemaps: true })
        .pipe(gulp.dest(paths.jqueryValidation.dest));
}

function jqueryValidationUnobtrusive() {
    return gulp.src(paths.jqueryValidationUnobtrusive.src, { sourcemaps: true })
        .pipe(gulp.dest(paths.jqueryValidationUnobtrusive.dest));
}

var build = gulp.series(clean, gulp.parallel(bootstrapJs, bootstrapCss, jquery, jqueryValidation, jqueryValidationUnobtrusive));

/*
 * You can use CommonJS `exports` module notation to declare tasks
 */
exports.clean = clean;

/*
 * Define default task that can be called by just running `gulp` from cli
 */
exports.default = build;