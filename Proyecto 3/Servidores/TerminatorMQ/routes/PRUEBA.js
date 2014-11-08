var express = require('express');
var Parallel = require('paralleljs');
var router = express.Router();

router.get('/', function(req, res) {
	var p = new Parallel([40, 41, 42], {maxWorkers: 1});
    var log = function () { console.log(arguments); };
	p.map(fib).then(log);

	var process = new Parallel([{id:"1",msg:"hola"},{id:"2",msg:"hola2"},{id:"3",msg:"hola3"},{id:"3",msg:"hola3"}]);
	res.send(process);
});


function fib(n) {
	return n < 2 ? 1 : fib(n - 1) + fib(n - 2);
};

module.exports = router;