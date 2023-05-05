


$(document).ready(function () {

    try {

        // switch the password field to text, then back to password to see if it supports
        // changing the field type (IE9+, and all other browsers do). then switch it back.
        var password = document.getElementById('password');
        password.type = 'text';
        password.type = 'password';

        // if it does support changing the field type then add the event handler and make
        // the button visible. if the browser doesn't support it, then this is bypassed
        // and code execution continues in the catch() section below
        var togglePasswordField = document.getElementById('chk_show_passwords');
        togglePasswordField.addEventListener('click', togglePasswordFieldClicked, false);
        togglePasswordField.style.display = 'inline';

    }
    catch (err) {
        var err = err;
    }

    $("#system_department_id").select2();
    $("#system_division_id").select2();
    $("#system_unit_id").select2();
    $("#rgv_sex_id").select2();

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

            var id = $("#id").val();

            $.ajax({
                type: 'POST',
                url: base_url + "SystemUser/Edit",
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

                        window.location = base_url + "SystemUser/Details/" + id;
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

$('#system_department_id').on('change', function (e) {
    e.preventDefault();
    var division_id = $("#system_unit_id").val();
    var department_id = $(this).val();
    $.ajax({
        url: base_url + 'SystemDivision/ListByDepartmentID',
        data: { 'department_id': department_id },
        type: "POST",
        cache: false,
        dataType: 'json'
    }).done(function (response) {
        var len = response.length;

        $("#system_division_id").empty();
        $("#system_division_id").append("<option value='0'>--NO SELECTION--</option>");
        for (var i = 0; i < len; i++) {
            var id = response[i]['id'];
            var name = response[i]['name'];
            $("#system_division_id").append("<option value='" + id + "'>" + name + "</option>");
        }
    });

    $.ajax({
        url: base_url + 'SystemUnit/ListByDepartmentDivisionID',
        data: { 'department_id': department_id, 'division_id': division_id },
        type: "POST",
        cache: false,
        dataType: 'json'
    }).done(function (response) {
        var len = response.length;

        $("#system_unit_id").empty();
        $("#system_unit_id").append("<option value='0'>--NO SELECTION--</option>");
        for (var i = 0; i < len; i++) {
            var id = response[i]['id'];
            var name = response[i]['name'];
            $("#system_unit_id").append("<option value='" + id + "'>" + name + "</option>");
        }
    });
});

$('#system_division_id').on('change', function (e) {
    e.preventDefault();
    var department_id = $("#system_department_id").val();
    var division_id = $(this).val();

    $.ajax({
        url: base_url + 'SystemUnit/ListByDepartmentDivisionID',
        data: { 'department_id': department_id, 'division_id': division_id },
        type: "POST",
        cache: false,
        dataType: 'json'
    }).done(function (response) {
        var len = response.length;

        $("#system_unit_id").empty();
        $("#system_unit_id").append("<option value='0'>--NO SELECTION--</option>");
        for (var i = 0; i < len; i++) {
            var id = response[i]['id'];
            var name = response[i]['name'];
            $("#system_unit_id").append("<option value='" + id + "'>" + name + "</option>");
        }
    });
});

function togglePasswordFieldClicked() {

    var password = document.getElementById('password');
    var new_password = document.getElementById('new_password');
    var confirm_new_password = document.getElementById('confirm_new_password');
    var password_value = password.value;
    var new_password_value = new_password.value;
    var confirm_new_password_value = confirm_new_password.value;

    if (password.type == 'password') {
        password.type = 'text';
        new_password.type = 'text';
        confirm_new_password.type = 'text';
    }
    else {
        password.type = 'password';
        new_password.type = 'password';
        confirm_new_password.type = 'password';
    }
    
    password.value = password_value;
    new_password.value = new_password_value;
    confirm_new_password.value = confirm_new_password_value;

}

$("#btnChange").on('click', (function (e) {
    event.preventDefault();

    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 2000
    });

    document.getElementById("btnChange").disabled = true;
    $('#btnChange').text("Changing...");

    const new_password = document.querySelector("#new_password")
    const confirm_new_password = document.querySelector("#confirm_new_password")

    if (new_password.value === confirm_new_password.value) {

        var form = document.getElementById('form_UserPass');
        var formData = new FormData(form);

        console.log(formData);

        var id = $("#user_id").val();

        $.ajax({
            type: 'POST',
            url: base_url + "SystemUser/UpdatePassword",
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

                    $('#btnChange').text("Change");
                    document.getElementById("btnChange").disabled = false;

                    window.location = base_url + "SystemUser/Details/" + id;
                });

                return;
            }

            Toast.fire({
                icon: 'error',
                title: 'An error has occured! Please try again.'
            });

            $('#btnChange').text("Change");
            document.getElementById("btnChange").disabled = false;

        });

    } else {

        Toast.fire({
            icon: 'error',
            title: 'Password did not match.'
        });

        $('#btnChange').text("Change");
        document.getElementById("btnChange").disabled = false;
    }
}));
