/// <reference path="D:\MikeP_Ch-028\UniversityEntityApp\UniversityAPI\Scripts/jquery-2.1.3.intellisense.js" />
/// <reference path="D:\MikeP_Ch-028\UniversityEntityApp\UniversityAPI\Scripts/jquery-2.1.3.js" />
/// <reference path="D:\MikeP_Ch-028\UniversityEntityApp\UniversityAPI\Scripts/jquery-ui-1.11.3.js" />

function InitDialog($studentDialog) {
    var $studentForm = $studentDialog.find('form');
    $studentDialog.dialog({
        autoOpen: false,
        modal: true,
        resizable: false,
        draggable: false,
        beforeClose: function () {
            $('#container').removeClass('low-opacity');
        },
        close: {
            class: 'btn btn-default'
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

$(function () {
    //api manager
    var $studentDialog = $('#dialog-window');
    
    InitDialog($studentDialog);

    var $openDialogButton = $('#open-dialog');
    $openDialogButton.click(function () {
        $studentDialog.dialog('open');
        $('#container').addClass('low-opacity');
    });
});