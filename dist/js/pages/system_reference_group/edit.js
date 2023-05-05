$(document).ready(function () {

    $("#department_id").select2();
    $("#division_id").select2();

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

            var formData = $('#form').serialize();

            $.ajax({
                type: "POST",
                url: base_url + "SystemReferenceGroup/Edit",
                data: formData,
                dataType: "json",
            }).done(function (response) {

                if (response.status){
                    Toast.fire({
                        icon: 'success',
                        title: response.message
                    }).then(function () {

                        $('#btnSubmit').text("Save");
                        document.getElementById("btnSubmit").disabled = false;

                        window.location.href = base_url + "SystemReferenceGroup/Index";
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
            name: {
                required: true
            },
            code: {
                required: true
            }
        },
        messages: {
            name: {
                required: "This field is required"
            },
            code: {
                required: "This field is required"
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

$('#department_id').on('change', function (e) {
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

        $("#division_id").empty();
        $("#division_id").append("<option value='0'>--SELECT ALL--</option>");
        for (var i = 0; i < len; i++) {
            var id = response[i]['id'];
            var name = response[i]['name'];
            $("#division_id").append("<option value='" + id + "'>" + name + "</option>");

        }


    });
});