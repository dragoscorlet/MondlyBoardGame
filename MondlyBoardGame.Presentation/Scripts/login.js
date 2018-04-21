var baseurl = "";
// Get the modal
var modal = document.getElementById('id01');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

function loginUser() {
    var postData = JSON.stringify({
        "username": $("#username").val(),
        "password": $("#password").val()
    });
    $.ajax({
        type: "POST",
        url: "LoginPageForLearn.cs/MyMethod",
        data: postData,
        contentType: "application/json; charset=utf-8",
        success: callbackfunction,
        error: function (msg) { alert(msg); }
    });
}

//function callbackfunction(result) {
//    if (result.test) {
//        location.href = baseurl + "board.html?test=" + result.test;
//    }
//}