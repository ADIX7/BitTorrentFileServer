const path = require('path');
const VueLoaderPlugin = require('vue-loader/lib/plugin');
const CopyPlugin = require('copy-webpack-plugin');

module.exports = {
  entry: {
    main: './websrc/index.js'
  },
  output: {
    filename: 'wwwroot/js/bundle.js',
    path: __dirname,
    publicPath: "/js/"
  },
  mode: 'development',
  devServer: {
    hot: true
  },
  module: {
    rules: [
      { test: /\.js$/, use: { loader: 'babel-loader', options: { presets: ['@babel/preset-env'] } } },
      { test: /\.vue$/, loader: 'vue-loader' },
      { test: /\.css$/, use: ['vue-style-loader', 'css-loader'] },
      {
        test: /\.scss$/,
        use: [
          "style-loader", // creates style nodes from JS strings
          "css-loader", // translates CSS into CommonJS
          "sass-loader" // compiles Sass to CSS, using Node Sass by default
        ]
      }
    ]
  },
  plugins: [
    new VueLoaderPlugin(),
    new CopyPlugin([
      { from: '**/*.html', to: 'wwwroot/', ignore: 'components/**/*.html' },
      { from: 'favicon.ico', to: 'wwwroot/' }
    ],
      {
        context: 'websrc',
        logLevel: 'info'
      })
  ]
};