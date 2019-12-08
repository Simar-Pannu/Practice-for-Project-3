// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// document.getElementById("wow").addEventListener("click", function() {

// });
// document.getElementById("cool").innerHTML = "Hello World";
var url = "http://localhost:5000/Home/Add/2";

$("#wow").on("click", function() {
  $("#cool").append("How are you?");
  $.getJSON(url, (data) => {
    $('#counter').html(data.counter);

    // console.log(data);
  });
});

function anotherFunction() {
  setInterval( () => {
    var refreshPage = "http://localhost:5000/Home/Add";
    $.get(refreshPage, (data) => {
      $('#counter').html(data.counter);
    });
  }, 1500);
}
anotherFunction();