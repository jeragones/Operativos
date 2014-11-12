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

router.post('/post', function(req, res) {
	console.log("mijo");
	var num = req.body.mensajes;
	var iron = req.body.iron;
	var terminator = req.body.terminator;

	if(iron == 1) {
		var producer = new WorkerIron(queue, num);
		producer.process();
	}

	if(terminator == 1) {
		var producer = new WorkerTerminator(queue, num);
		producer.process();
	}

  	res.render('index', { title: 'Cliente App 2' });
});

function WorkerIron(queue, number) {
    var self = this;
    var n = number;

    this.process = function() {
	    if(n > 0) {
	    	var date = new Date();
			var time = date.getTime();
			var message = n+'-App 2-'+time.getHours()+':'+time.getMinutes()+':'+time.getSeconds()+':'+time.getMilliseconds();
	    	queue.post(message, function(error, body) {});
	    	n--;
	    }
        setTimeout(self.process, 500);
    }
}

function WorkerTerminator(queue, number, ip) {
    var self = this;
    var n = number;

    this.process = function() {
	    if(n > 0) {
	    	var date = new Date();
			var time = date.getTime();
			var message = n+'-App 2-'+time.getHours()+':'+time.getMinutes()+':'+time.getSeconds()+':'+time.getMilliseconds();
	    	var options = {
		    	hostname: ip,
				port: 3000,
				path: '/api/post?message='+message,
				method: 'GET'
			};

			var req = https.request(options, function(res) { });
			req.end();
	    	n--;
	    }
        setTimeout(self.process, 500);
    }
}

module.exports = router;