$(document).ready(function () {
    GetCurrDateTime();

    $("#from_system_department_id").select2();
    $("#from_system_division_id").select2();
    $("#rgv_document_type_id").select2();
    $("#rgv_document_status_id").select2();

    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 2000
    });

    $.validator.addMethod("ddl_required", function (value) {
        return value != '0';
    }, "This field is required");

    $.validator.setDefaults({
        submitHandler: function () {
            const swalWithBootstrapButtons = Swal.mixin({
                        customClass: {
                            confirmButton: 'btn btn-success',
                            cancelButton: 'btn btn-danger'
                        },
                        buttonsStyling: true
                    });

            document.getElementById("btnSubmit").disabled = true;
            $('#btnSubmit').text("Saving...");

            var form = document.getElementById('form');
            var formData = new FormData(form);
            // Read selected files
            var totalfiles = document.getElementById('attachments').files.length;
            for (var index = 0; index < totalfiles; index++) {
                formData.append("attachments[]", document.getElementById('attachments').files[index]);
            }

            $.ajax({
                type: 'POST',
                url: base_url + "DocumentIncoming/Create",
                data: formData,
                contentType: false,
                cache: false,
                processData: false,
                dataType: 'json'
            }).done(function (response) {

                if (response.status) {

                    $('#btnSubmit').text("Save");
                    document.getElementById("btnSubmit").disabled = false;

                    swalWithBootstrapButtons.fire({
                        title: 'Success!',
                        text: "Your reference number is: " + response.reference_number + ". Do you want to add another one?",
                        icon: 'success',
                        showCancelButton: true,
                        confirmButtonText: 'Yes',
                        cancelButtonText: 'No, cancel!',
                        reverseButtons: true
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location = base_url + "DocumentIncoming/Create";
                        } else if (
                            result.dismiss === Swal.DismissReason.cancel
                        ) {
                            window.location = base_url + "DocumentIncoming/Edit/" + response.document_id;
                        }
                    });

                    return;
                }

                Toast.fire({
                    icon: 'error',
                    title: 'An error has occured! Please try again.'
                });

                $('#btnSubmit').text("Save");
                document.getElementById("btnSubmit").disabled = false;
            });

        }
    });

    $('#form').validate({
        ignore: 'input[type=hidden], .select2-input, .select2-focusser',
        rules: {
            route_date: {
                required: true
            },
            route_time: {
                required: true
            },
            title: {
                required: true
            },
            from_name: {
                required: true
            },
            from_system_department_id: {
                ddl_required: true
            },
            from_system_division_id: {
                ddl_required: true
            },
            rgv_document_type_id: {
                ddl_required: true
            },
            rgv_document_status_id: {
                ddl_required: true
            }
        },
        messages: {
            route_date: {
                required: "This field is required"
            },
            route_time: {
                required: "This field is required"
            },
            title: {
                required: "This field is required"
            },
            from_name: {
                required: "This field is required"
            },
            from_system_department_id: {
                ddl_required: "This field is required"
            },
            from_system_division_id: {
                ddl_required: "This field is required"
            },
            rgv_document_type_id: {
                ddl_required: "This field is required"
            },
            rgv_document_status_id: {
                ddl_required: "This field is required"
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.input-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });



});

$('#from_system_department_id').on('change', function (e) {
    e.preventDefault();

    var department_id = $(this).val();
    $.ajax({
        url: base_url + 'SystemDivision/ListByDepartmentID',
        data: { 'department_id': department_id },
        type: "POST",
        cache: false,
        dataType: 'json'
    }).done(function (response) {
        var len = response.length;

        $("#from_system_division_id").empty();
        $("#from_system_division_id").append("<option value='0'>--NO SELECTION--</option>");
        for (var i = 0; i < len; i++) {
            var id = response[i]['id'];
            var name = response[i]['name'];
            $("#from_system_division_id").append("<option value='" + id + "'>" + name + "</option>");

        }


    });
});

function GetCurrDateTime() {
    let currentDate = new Date();
    let cDay = currentDate.getDate();
    let cMonth = currentDate.getMonth() + 1;
    let cYear = currentDate.getFullYear();

    let curDate = cYear + "-" + (cMonth >= 10 ? cMonth : "0" + cMonth) + "-" + (cDay >= 10 ? cDay : "0" + cDay);
    document.getElementById("route_date").value = curDate;
    let curTime = (currentDate.getHours() >= 10 ? currentDate.getHours() : "0" + currentDate.getHours()) + ":" + (currentDate.getMinutes() >= 10 ? currentDate.getMinutes() : "0" + currentDate.getMinutes());
    document.getElementById("route_time").value = curTime;
}
