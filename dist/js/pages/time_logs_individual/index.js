$(document).ready(function () {

    $("#system_user_id").select2();

    document.getElementById("date_from").hidden = true;
    document.getElementById("date_to").hidden = true;
    document.getElementById("lblDate_From").hidden = true;
    document.getElementById("lblDate_To").hidden = true;
    document.getElementById("btnPrint").hidden = true;
    document.getElementById("lblInCharge").hidden = true;
    document.getElementById("in_charge").hidden = true;
});


$('#system_user_id').on('change', function (e) {
    e.preventDefault();

    var system_user_id = $(this).val();

    if (system_user_id > 0) {
        document.getElementById("date_from").hidden = false;
        document.getElementById("date_to").hidden = false;
        document.getElementById("lblDate_From").hidden = false;
        document.getElementById("lblDate_To").hidden = false;
        document.getElementById("btnPrint").hidden = false;
        document.getElementById("lblInCharge").hidden = false;
        document.getElementById("in_charge").hidden = false;
    } else {
        document.getElementById("date_from").hidden = true;
        document.getElementById("date_to").hidden = true;
        document.getElementById("lblDate_From").hidden = true;
        document.getElementById("lblDate_To").hidden = true;
        document.getElementById("btnPrint").hidden = true;
        document.getElementById("lblInCharge").hidden = true;
        document.getElementById("in_charge").hidden = true;
    }
});