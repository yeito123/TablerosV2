/// <reference path="jquery-1.10.2.min.js" />
$(document).ready(function () {
    $("body").css("height", $(document).height() + "px");
    $(".cssTable001").css("left", ($(document).width() - $(".cssTable001").width()) / 2 + "px");
});

window.onresize = function () {
    $(".cssTable001").css("left", ($(document).width() - $(".cssTable001").width()) / 2 + "px");
}

function mReloj() {
    momentoActual = new Date();
    try{
    document.getElementById("nreloj").value = momentoActual.format("dd/MM/yyyy hh:mm:ss tt");
    }
    catch(e){}
    setTimeout("mReloj()", 1000)
}