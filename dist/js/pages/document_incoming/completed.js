$(document).ready(function () {
    GetCurrDateTime();
    
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
                url: base_url + "DocumentIncoming/Completed",
                data: formData,
                contentType: false,
                cache: false,
                processData: false,
                dataType: 'json'
            }).done(function (response) {

                if (response.status) {
                    Toast.fire({
                        icon: 'success',
                        title: response.message
                    }).then(function () {

                        $('#btnSubmit').text("Save");
                        document.getElementById("btnSubmit").disabled = false;

                        window.location.href = base_url + "DocumentIncoming/Index";
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
