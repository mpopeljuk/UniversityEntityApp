/// <reference path="D:\MikeP_Ch-028\UniversityEntityApp\UniversityAPI\Scripts/jquery-2.1.3.intellisense.js" />
/// <reference path="D:\MikeP_Ch-028\UniversityEntityApp\UniversityAPI\Scripts/jquery-2.1.3.js" />
/// <reference path="D:\MikeP_Ch-028\UniversityEntityApp\UniversityAPI\Scripts/jquery-ui-1.11.3.js" />

function Visibility(f) {
    if (f) {
        $('#container').removeClass('low-opacity');
    }
    else {
        $('#container').addClass('low-opacity');
    }
}

function InitDialog($studentDialog) {
    var $studentForm = $studentDialog.find('form');
    $studentDialog.dialog({
        autoOpen: false,
        modal: true,
        resizable: false,
        draggable: false,
        close: function () {
            $authForm[0].reset();
        },
        buttons: {
            'Save': {
                text: 'Save',
                id: 'save-student',
                class: 'btn btn-default'
            }
        },
        close: function () {
            $studentForm.data('id', '');
            $studentForm[0].reset();
        }
    });

    $('.ui-dialog-titlebar-close').addClass('btn btn-default');
}

function InitAuthDialog($authDialog) {
    var $authForm = $authDialog.find('form');
    $authDialog.dialog({
        autoOpen: false,
        modal: true,
        resizable: false,
        draggable: false,
        buttons: {
            'Confirm': {
                text: 'Confirm',
                id: 'auth-confirm',
                class: 'btn btn-default',
                click: function () { OAuth($authDialog); }
            }
        },
        close: function () {
            $authForm[0].reset();
        },
        open: function () {
            if ($(this).data('dialogType') == "login") {
                $authForm.find(".confirm-password-block").hide();
                $authForm.find(".birthdate-block").hide();
                $authForm.find(".email-block").hide();
            }
            else if ($(this).data('dialogType') == "register") {
                $authForm.find(".confirm-password-block").show();
                $authForm.find(".birthdate-block").show();
                $authForm.find(".email-block").show();
            }
        }
    });

    $('.ui-dialog-titlebar-close').addClass('btn btn-default');
}

function OAuth($authDialog) {
    $.ajax({
        url: apiUrl + '/token',
        type: 'POST',
        contentType: "application/x-www-form-urlencoded",
        data: {
            grant_type: 'password',
            username: $authDialog.find('#username').val(),
            password: $authDialog.find('#password').val()
        },
        success: function (data) {
            console.log(data);
            token = data.access_token;
            $('#auth-dialog').dialog('close');
        },
        error: function (err) {
            console.log("ERROR AFTER REQ");
            console.log(err);
        }
    });
}

var apiUrl = 'http://localhost:51056';

var token = '';
var getHeaders = function () {
    if (token) {
        return { "Authorization": "Bearer " + token };
    }
};



$(function () {
    //api manager
    var $studentDialog = $('#dialog-window');
    var $authDialog = $('#auth-dialog');

    InitDialog($studentDialog);
    InitAuthDialog($authDialog);

    var $openDialogButton = $('#open-dialog');
    $openDialogButton.click(function () {
        $studentDialog.dialog('open');
    });

    var $openLoginDialogButton = $('#open-login');
    $openLoginDialogButton.click(function () {
        $authDialog.data('dialogType', 'login').dialog('open');
    });

    var $openRegisterDialogButton = $('#open-register');
    $openRegisterDialogButton.click(function () {
        $authDialog.data('dialogType', 'register').dialog('open');
    });

    var $getStudentsButton = $('#get-students-btn');
    $getStudentsButton.click(function () {
        $.ajax({
            url: apiUrl + '/api/groups',
            type: 'GET',
            headers: getHeaders(),
            success: function (data) {
                console.log(data);
            },
            error: function (err) {
                console.log("ERROR");
                console.log(err);
            }
        });
    });
});