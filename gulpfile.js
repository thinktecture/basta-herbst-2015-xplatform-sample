'use strict';

var gulp = require('gulp'),
    del = require('del'),
    sh = require('shelljs');

gulp.task('clean', function (done) {
    del(['app/cordova/www', 'app/cordova/platforms', 'app/cordova/plugins'])
        .then(function () {
            done();
        });
});

gulp.task('copy-source', ['clean'], function () {
    return gulp.src([
        'app/**/*.*',
        '!app/cordova/**/*.*'
    ])
        .pipe(gulp.dest('app/cordova/www'));
});

gulp.task('build:cordova', ['clean', 'copy-source'], function (done) {
    sh.cd('app/cordova');
    sh.exec('cordova platform add ios');
    sh.exec('cordova platform add android');
    sh.exec('cordova platform add windows');
    sh.exec('cordova plugin add org.apache.cordova.statusbar');
    sh.exec('cordova build');
    done();
});

gulp.task('default', ['clean', 'copy-source', 'build:cordova']);