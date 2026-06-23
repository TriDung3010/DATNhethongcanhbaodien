const http = require('http');
const fs = require('fs');
const path = require('path');

const PORT = 3000;
const DIR = __dirname;

const MIME = {
    '.html': 'text/html; charset=utf-8',
    '.css': 'text/css',
    '.js': 'application/javascript',
    '.json': 'application/json',
    '.png': 'image/png',
    '.jpg': 'image/jpeg',
    '.svg': 'image/svg+xml',
    '.ico': 'image/x-icon',
    '.wav': 'audio/wav',
    '.mp3': 'audio/mpeg',
};

http.createServer((req, res) => {
    let filePath = req.url === '/' ? '/index.html' : req.url;
    const fullPath = path.join(DIR, filePath);
    const ext = path.extname(filePath);

    fs.readFile(fullPath, (err, data) => {
        if (err) {
            res.writeHead(404, { 'Content-Type': 'text/html; charset=utf-8' });
            res.end('<h1>404 - Khong tim thay file</h1>');
            return;
        }
        res.writeHead(200, {
            'Content-Type': MIME[ext] || 'text/plain',
            'Access-Control-Allow-Origin': '*',
        });
        res.end(data);
    });
}).listen(PORT, () => {
    console.log('Frontend chay tai: http://localhost:' + PORT);
    console.log('Nhan Ctrl+C de dung');
});
