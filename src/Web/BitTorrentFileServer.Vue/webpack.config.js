const path = require('path');
const VueLoaderPlugin = require('vue-loader/lib/plugin');
const CopyPlugin = require('copy-webpack-plugin');

module.exports = {
  entry: './websrc/index.js',
  output: {
    filename: 'wwwroot/js/bundle.js',
    path: __dirname
  },
  mode: 'development',
  module: {
    rules: [
      { test: /\.js$/, use: { loader: 'babel-loader', options: { presets: ['@babel/preset-env'] } } },
      { test: /\.vue$/, loader: 'vue-loader' },
      { test: /\.css$/, use: ['vue-style-loader', 'css-loader'] }
    ]
  },
  plugins: [
    new VueLoaderPlugin(),
    new CopyPlugin([
      { from: '**/*.html', to: 'wwwroot/' },
      { from: 'favicon.ico', to: 'wwwroot/' }
    ],
      {
        context: 'websrc',
        logLevel: 'info'
      })
  ]
};