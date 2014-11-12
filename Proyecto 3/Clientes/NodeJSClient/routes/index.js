var express = require('express');
var iron_mq = require('iron_mq');
var https = require('https');

var token = "2aps7Lb4F3hMYwtkaVj9xadlRwo";
var id = "545413c2b72d650009000009";

var router = express.Router();
var imq = new iron_mq.Client({token: token, project_id: id, queue_name: queue});
var queue = imq.queue("inbox");
/* GET Message page */

/* GET home page. */
router.get('/', function(req, res) {
  res.render('index', { title: 'Cliente App 2' });
});

// router.post('/post', function(req, res) {
router.post('/', function(req, res) {
	var num = req.body.spnMessage;
	var iron = req.body.chkIron;
	console.log('num: '+num+', iron: '+iron);

	if(iron == 1) {
		var producer = new WorkerIron(queue, num);
		producer.process();
	}
/*
	if(terminator == 0) {
		var producer = new WorkerTerminator(queue, num, ip);
		producer.process();
	}
*/
  	res.render('index', { title: 'Cliente App 2' });
});

function WorkerIron(queue, number) {
    var self = this;
    var n = number;

    this.process = function() {
    	var date = new Date();
		var time = date.getTime();
		var message = n+'-App 2-'+getTiempo();
    	queue.post(message, function(error, body) {});
    	n--;

	    if(n > 0) {
	    	setTimeout(self.process, 500);
	    }
    }
}

function getTiempo() {
	var date = new Date();
	var time = date.getHours()+':'+
			   date.getMinutes()+':'+
			   date.getSeconds()+':'+
			   date.getMilliseconds();
	return time;
}

module.exports = router;




















/*
function WorkerTerminator(queue, number, ip) {
    var self = this;
    var n = number;

    this.process = function() {
    	var date = new Date();
		var time = date.getTime();
		var message = n+'-App 2-'+getTiempo();
    	var options = {
	    	host: ip,
			port: 3000,
			path: '/api/post?message='+message,
			method: 'GET',
  			agent: false
		};
		console.log(options);
		
		https.request(options, function(res) {
				console.log("statusCode: ", res.statusCode);
				console.log("headers: ", res.headers);
				res.on('data', function(d) {
				process.stdout.write(d);
			});
		}).end();
    	n--;

	    if(n > 0) {
        	setTimeout(self.process, 500);
        }
    }
}
*/