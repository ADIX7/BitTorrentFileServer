const { src, dest, parallel, series } = require('gulp');
var sass = require('gulp-sass');

sass.compiler = require('node-sass');


function build(done) {
    return src("websrc/css/*.scss")
        .pipe(sass().on('error', sass.logError))
        .pipe(dest('wwwroot/css/'));
}

exports.default = build;