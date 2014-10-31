/*jslint browser:true, devel:true, white:true, vars:true, eqeq:true */
/*global console: false, sessionStorage:false, intel:false, alert:false, document:false, $:false
*/
var init = function () {
    var b1= document.getElementById("submit");
    b1.addEventListener("touchstart", translate,false);
};

window.addEventListener("load", init, false);  

//  Prevent Default Scrolling  
var preventDefaultScroll = function(event) 
{
    // Prevent scrolling on this element
    event.preventDefault();
    window.scroll(0,0);
    return false;
};
window.document.addEventListener("touchmove", preventDefaultScroll, false);

// Runs after the Intel XDK device API has initialized
var onDeviceReady = function(){                             // called when Cordova is ready
   if( window.Cordova && navigator.splashscreen ) {     // Cordova API detected
        navigator.splashscreen.hide() ;                 // hide splash screen
        bindSelect();
    }
};
document.addEventListener("deviceready", onDeviceReady, false) ;

var bindSelect = function() {
    var culture = {
        "en-GB": "English",
        "fr-FR": "French",
        "de-DE": "German",
        "pt-PT": "Portuguese",
        "es-ES": "Spanish"
    };
    var source = document.getElementById("sourceLanguage");
    var dest = document.getElementById("destLanguage");
    var index;
    for(index in culture) {
        source.options[source.options.length] = new Option(culture[index], index);
        dest.options[dest.options.length] = new Option(culture[index], index);
    }
};

function translate() {
    var translaionURI = "http://mymemory.translated.net/api/get?q=";
    var langQS = "&langpair=";
    var from = document.getElementById("sourceLanguage").value; 
    var to = document.getElementById("destLanguage").value;
    var text =document.getElementById("translateText").value;
    var qsVal = langQS + from + '|' + to;
    var fullURI = translaionURI + text + qsVal;
    $.getJSON(fullURI, function (data) {
                document.getElementById("translatedText").value = data.responseData.translatedText.toLowerCase();
            });
}