$(document).ready(function () {

    $("#system_department_id").select2();
    $("#system_division_id").select2();

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

            document.getElementById("btnPrint").disabled = true;
            $('#btnPrint').text("Printing ...");

            var formData = $('#form').serialize();

            $.ajax({
                type: "POST",
                url: base_url + "TimeLogsByDepartment/Print",
                data: formData,
                dataType: "json",
            }).done(function (response) {

                if (response.status){
                    Toast.fire({
                        icon: 'success',
                        title: response.message
                    }).then(function () {

                        $('#btnPrint').text("Print");
                        document.getElementById("btnPrint").disabled = false;

                        window.location.href = base_url + "SystemReferenceGroup/Index";
                    });

                    return;
                }

                Toast.fire({
                    icon: 'error',
                    title: 'An error has occured! Please try again.'
                });

                $('#btnPrint').text("Print");
                document.getElementById("btnPrint").disabled = false;

            });
        }
    });

    $('#form').validate({
        ignore: 'input[type=hidden], .select2-input, .select2-focusser',
        rules: {
            system_department_id: {
                ddl_required: true
            },
            system_division_id: {
                ddl_required: true
            },
            date_from: {
                required: true
            },
            date_to: {
                required: true
            },
        },
        messages: {
            system_department_id: {
                ddl_required: "This field is required"
            },
            system_division_id: {
                ddl_required: "This field is required"
            },
            date_from: {
                required: "This field is required"
            },
            date_to: {
                required: "This field is required"
            },
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
});