// Modulos de la ruta
var express = require('express');
var os = require('os');
var api = require('./api');
var data = require('./data');
var router = express.Router();

// Cola de mensajes
var queue = api.queue;

/* GET Index Page
   Carga la pagina al abrir el link
*/
router.get('/', function(req, res) {
	res.render('index', {title: 'TerminatorMQ'});
});

/* POST Index for workers
   Se ejecuta al seleccionar el submit e inicia los workers
*/
router.post('/', function(req, res) {
	var state = req.body.chkWorker;
	var numWorkers = os.cpus().length;
	
	if(state == 1) {
		for (var i = 0; i < numWorkers; i++) {
			var consumer = new Worker(queue, 'WORKER '+i);
			consumer.process();
		}
	}
	res.render('index', {title: 'TerminatorMQ'});
});

/* Funcion de cada Worker creado 
   queue: la cola de mensajes del servidor
   name: nombre del worker
*/
function Worker(queue, name) {
    var self = this;
    
    this.process = function() {
	    var message = queue.getMessageSync();
	    if (message != null) {
	    	data.save(message);
	    } 
        setTimeout(self.process, 400);
    }
}

// Variable global
module.exports = router;