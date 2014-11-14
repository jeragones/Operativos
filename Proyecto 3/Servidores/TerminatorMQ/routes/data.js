// Modulos de la ruta
var mongojs = require('mongojs');

// Cloud DB
//var databaseUrl = 'mongodb://AdminDB:Admin123@ds051110.mongolab.com:51110/messagesdb';

/* Local DB */
var databaseUrl = 'mongodb://localhost:27017/messagesdb';

// Variables referentes a la base de datos
var collection = ['Message'];
var db = mongojs.connect(databaseUrl, collection);

/* Obtiene los mensajes de la base de datos */
function getMessages(callback) {
	db.Message.find({}, function(err, message) {
	  	if( err || !message) {
	  		console.log('No messages founded');
	  		callback(null);
	  	} else 
			callback(message);
	});
}

/* Guarda los mensajes en la base de datos */ 
function saveMessage(message) {
	db.Message.save(message, function(err, saved) { 
		if(err) 
			console.log('Message not inserted by DB ERROR');
	});
}

/* Elimina los mensajes de la base de datos */
function removeMessage(client) {
	db.Message.remove({message: client}, function(err, removed) {
		if(err) 
			console.log('Message not removed by DB ERROR');
	});	
}

// Variables globales
module.exports = { get : getMessages, save: saveMessage, remove : removeMessage };	