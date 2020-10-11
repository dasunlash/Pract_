$(document).ready(function () {
});

var form = {
    
    createObject: function () {
        return {
            username: $('#txtUserName').val(),
            password: $('#txtPassword').val()
        }
    },

    saveOtGridSuccess: function (data) {

        if (data !=null) {
            location.replace('/Home/Index');
        }
    },

    sendRequestGet: function (json, successMethod, errorMethod, url) {
        $.ajax({
            type: 'GET',
            headers: { "Authorization": localStorage.getItem('token') },
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            url: url,
            data: json,
            success: successMethod,
            error: errorMethod
        });
    },
    sendRequestPost: function (json, successMethod, errorMethod, url) {
        $.ajax({
            type: 'POST',
            headers: { "Authorization": localStorage.getItem('token') },
            dataType: 'json',
            contentType: 'application/json;charset=UTF-8',
            accept: 'application/json, text/plain, */*',
            url: url,
            data: JSON.stringify(json),
            success: successMethod,
            error: errorMethod
        });
    },
}

function login_Click() {
    debugger
    form.save();
}
function save () {
    debugger
    var url = '../Login/Login';
    form.sendRequestPost(form.createObject(), form.saveOtGridSuccess, form.handleError, url);
}

