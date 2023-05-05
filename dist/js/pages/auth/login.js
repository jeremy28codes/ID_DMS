$(document).ready(function () {

    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
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
            $('#btnSubmit').text("Logging In...");

            var formData = $('#form').serialize();

            $.ajax({
                type: "POST",
                url: base_url + "Auth/Login",
                data: formData,
                dataType: "json",
            }).done(function (response) {

                if (response.status) {
                    Toast.fire({
                        icon: 'success',
                        title: response.message
                    }).then(function () {

                        $('#btnSubmit').text("Login");
                        document.getElementById("btnSubmit").disabled = false;

                        window.location.href = base_url + "SystemUser/Details/" + response.user_id;
                    });

                    return;
                }

                Toast.fire({
                    icon: 'error',
                    title: response.message
                });

                $('#btnSubmit').text("Login");
                document.getElementById("btnSubmit").disabled = false;
            });
        }
    });

    $('#form').validate({
        rules: {
            username: {
                required: true
            },
            password: {
                required: true
            }
        },
        messages: {
            name: {
                required: "This field is required"
            },
            password: {
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


