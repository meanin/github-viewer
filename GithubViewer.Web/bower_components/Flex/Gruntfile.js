module.exports = function (grunt) {
  grunt.initConfig({
    sass: {
      options: {
        precision: 2
      },
      dist: {
        files: {
          'dist/flex.css': 'src/main.scss'
        }
      }
    },
    cssmin: {
      options: {
        shorthandCompacting: false,
        roundingPrecision: -1
      },
      target: {
        files: {
          'dist/flex.min.css': 'dist/flex.css'
        }
      }
    },
    watch: {
      styles: {
        files: ['src/**/*.scss'],
        tasks: ['build'],
        options: {
          spawn: false
        }
      }
    }
  });

  grunt.loadNpmTasks('grunt-sass');
  grunt.loadNpmTasks('grunt-contrib-watch');
  grunt.loadNpmTasks('grunt-contrib-cssmin');

  grunt.registerTask('build', ['sass', 'cssmin']);
};
