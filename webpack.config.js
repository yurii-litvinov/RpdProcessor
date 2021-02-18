const path = require('path');

module.exports = {
    mode: 'development',
    entry: './scripts/app.js',
    output: {
        path: path.resolve(__dirname, './WebRoot'),
        filename: 'bundle.js', 
        library: 'Scripts',
        libraryTarget: 'var'
    }
};