import resolve from 'rollup-plugin-node-resolve';
import commonjs from 'rollup-plugin-commonjs';
import VuePlugin from 'rollup-plugin-vue';
import NodeGlobals from 'rollup-plugin-node-globals';

module.exports = {
    input: 'websrc/index.js',
    output: {
        file: 'wwwroot/js/bundle.js',
        format: 'cjs'
    },
    plugins: [
        resolve(),
        commonjs(),
        VuePlugin(/* VuePluginOptions */),
        NodeGlobals()
    ]
};