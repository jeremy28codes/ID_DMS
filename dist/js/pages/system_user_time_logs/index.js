$(document).ready(function () {
    $("#Employee_Name").select2();

    [].forEach.call(document.querySelectorAll('.dates'), function (el) {
        el.style.visibility = 'hidden';
    });
});

$("#Employee_Name").on("change", function () {
    var val = $(this).val();

    if (val.length > 0) {
        [].forEach.call(document.querySelectorAll('.dates'), function (el) {
            el.style.visibility = '';
        });
    } else {
        [].forEach.call(document.querySelectorAll('.dates'), function (el) {
            el.style.visibility = 'hidden';
        });
    }
});