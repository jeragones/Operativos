var express = require('express');
var api = require('./api');
var data = require('./data');

var router = express.Router();
var queue = api.queue;

//var consumer1 = new Consumer(queue, 'First Consumer', consumer1);
//var consumer2 = new Consumer(queue, 'Second Consumer', consumer1);

/* GET Index Page*/
router.get('/', function(req, res) {
	res.render('index', {title: 'TerminatorMQ'});
});

router.post('/worker', function(req, res) {
	var state = req.body.chkWorker;
	var numWorkers = req.body.numWorker;
	if(state == 1) {
		if(numWorkers < 1)
			numWorkers = 1;
		for(var i=1; i <= numWorkers; i++) {
			var consumer = new Worker(queue, 'WORKER '+i);
			consumer.process();
		}
	}
	res.render('index', {title: 'TerminatorMQ'});
});

function Worker(queue, name) {
    var self = this;
    
    this.process = function() {
	    var message = queue.getMessageSync();
	    if (message != null) {
	    	data.save(message);
	        console.log(name + ' >> ' + message.num+' - '+message.client);
	    }
        setTimeout(self.process, 500);
    }
}

/* POST Index Page Inicia los workers */
router.post('/', function(req, res) {
	var workers = req.body.selWorkers;
	while(workers > 0) {

	}
/*
	if(queue.length > 0) {
		var maxWorkers = req.body.selWorkers;
		data.save(queue, maxWorkers);
	}
	*/
	res.render('index', {title: 'TerminatorMQ'});
});

/* GET Lleva el estado del servidor de mensajes */
router.get('/refresh', function(req, res) {
	var size = queue.length;
	average = Math.abs(size - average);
	res.send({size:size, average:average, total:sizes});
});

module.exports = router;