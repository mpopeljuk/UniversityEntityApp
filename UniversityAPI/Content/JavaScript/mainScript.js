/// <reference path="D:\SS_Projects\UniversityEntityApp\UniversityAPI\Scripts/jquery-2.1.3.intellisense.js" />
/// <reference path="D:\SS_Projects\UniversityEntityApp\UniversityAPI\Scripts/jquery-2.1.3.js" />


$(function () {
    var $studentDialog = $('#dialog-window');
    var $studentForm = $studentDialog.find('form');

    $studentDialog.dialog({
        autoOpen: false,
        modal: true,
        resizable: false,
        draggable: false
    });

    var $openDialogButton = $('#open-dialog');
    $openDialogButton.click(function () {
        $studentDialog.dialog('open');
    });
});