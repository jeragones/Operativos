var mongojs = require('mongojs');

// Cloud DB
//var databaseUrl = 'mongodb://AdminDB:Admin123@ds051110.mongolab.com:51110/messagesdb';
// Local DB
var databaseUrl = 'mongodb://localhost:27017/messagesdb';

var collection = ['Message'];
var db = mongojs.connect(databaseUrl, collection);

function getMessages(callback) {
	db.Message.find({}, function(err, message) {
	  	if( err || !message) {
	  		console.log('No messages founded');
	  		callback(null);
	  	} else 
			callback(message);
	});
}

function saveMessage(num, client, time) {
	db.Message.save({num: num, client: client, time: time}, function(err, saved) { 
		if(err) 
			console.log('Message not inserted by DB ERROR');
		else
			console.log('insertado');
	});
}


function removeMessage(client) {
	db.Message.remove({message: client}, function(err, removed) {
		if(err) 
			console.log('Message not removed by DB ERROR');
	});	
}

module.exports = { get : getMessages, save: saveMessage, remove : removeMessage };