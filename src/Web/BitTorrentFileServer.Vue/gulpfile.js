const { src, dest, parallel, series } = require('gulp');
const browserify = require('browserify');
const source = require('vinyl-source-stream');
const babelify = require('babelify');
const merge = require('merge-stream');
const vueify = require('vueify');


function build(done) {
    var jsTask = browserify({
        entries: ['websrc/index.js']
    })
        .transform(vueify)
        .transform(babelify.configure({
            presets: ["@babel/preset-env"]
        }))
        .bundle()
        .pipe(source('bundle.js'))
        .pipe(dest('wwwroot/js'));

    var htmlTask = src("websrc/*.html")
        .pipe(dest("wwwroot"));

    return merge(jsTask, htmlTask);
}

exports.default = build;