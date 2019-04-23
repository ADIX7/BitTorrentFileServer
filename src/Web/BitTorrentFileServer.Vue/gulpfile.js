const { src, dest, parallel, series } = require('gulp');
const merge = require('merge-stream');
const rename = require("gulp-rename");

var sass = require('gulp-sass');

sass.compiler = require('node-sass');


function build(done) {
    var mainCSSTask = src("websrc/css/default.scss")
        .pipe(sass().on('error', sass.logError))
        .pipe(rename(function (path) {
            path.basename = "main";
          }))
        .pipe(dest('wwwroot/css/'));

    var mobileCSSTask = src("websrc/css/mobile.scss")
        .pipe(sass().on('error', sass.logError))
        .pipe(dest('wwwroot/css/'));

    return merge(mainCSSTask, mobileCSSTask);
}

exports.default = build;