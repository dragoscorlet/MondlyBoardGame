function updateBoard() {

    $.ajax({
        type: "GET",
        url: "http://localhost:51994/game/board",
        contentType: "application/json; charset=utf-8",
        success: callbackfunction,
        error: function (msg) { alert(msg); }
    });
}

function getQuestionData() {
    var postData = JSON.stringify({
        "DiceValue": $("#username").val(),
        "QuestionType": $("#password").val()
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
