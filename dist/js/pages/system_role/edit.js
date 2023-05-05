$(document).ready(function () {

    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 2000
    });

    //alert(1);

    $("#ma_system_web_module_id").select2();
    $("#sa_system_web_module_id").select2();
    $("#sa_system_web_section_id").select2();

    $("#ma_table").DataTable({
        "responsive": true, "lengthChange": false, "autoWidth": false,
        "buttons": ["copy", "csv", "excel", "pdf", "print"]
    }).buttons().container().appendTo('#ma_table_wrapper .col-md-6:eq(0)');

    $("#sa_table").DataTable({
        "responsive": true, "lengthChange": false, "autoWidth": false,
        "buttons": ["copy", "csv", "excel", "pdf", "print"]
    }).buttons().container().appendTo('#sa_table_wrapper .col-md-6:eq(0)');

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
            $('#btnSubmit').text("Updating...");

            var form = document.getElementById('form');
            var formData = new FormData(form);

            $.ajax({
                type: 'POST',
                url: base_url + "SystemRole/Edit",
                data: formData,
                contentType: false,
                cache: false,
                processData: false,
                dataType: 'json'
            }).done(function (response) {

                if (response.status) {

                    $('#btnSubmit').text("Update");
                    document.getElementById("btnSubmit").disabled = false;

                    Toast.fire({
                        icon: 'success',
                        title: response.message
                    }).then(function () {

                        location.reload();

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

            $('#btnSubmit').text("Update");
            document.getElementById("btnSubmit").disabled = false;
        }
    });

    $('#form').validate({
        ignore: 'input[type=hidden], .select2-input, .select2-focusser',
        rules: {
            code: {
                required: true
            },
            name: {
                required: true
            },
        },
        messages: {
            code: {
                required: "This field is required"
            },
            name: {
                required: "This field is required"
            },
            reference_number: {
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

$(document).on('click', '#maBtnAdd', function (e) {
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 2000
    });

    e.preventDefault();

    document.getElementById("maBtnAdd").disabled = true;
    $('#maBtnAdd').text("Adding...");

    var system_role_id = $('#ma_id').val();

    var form = document.getElementById('ma_form');
    var formData = new FormData(form);

    $.ajax({
        type: 'POST',
        url: base_url + "SystemRole/AddModuleRole",
        data: formData,
        contentType: false,
        cache: false,
        processData: false,
        dataType: 'json'
    }).done(function (response) {

        if (response.status) {

            $('#maBtnAdd').text("Add");
            document.getElementById("maBtnAdd").disabled = false;

            $("#ma_table").empty();

            Toast.fire({
                icon: 'success',
                title: response.message
            }).then(function () {

                $.ajax({
                    url: base_url + 'SystemRole/UpdateModuleTable',
                    data: { 'system_role_id': system_role_id },
                    type: "GET",
                }).done(function (result) {
                    $("#ma_table").html(result);

                });
                
            });

            return;
        }

        Toast.fire({
            icon: 'error',
            title: 'An error has occured! Please try again.'
        });

        $('#maBtnAdd').text("Add");
        document.getElementById("maBtnAdd").disabled = false;
    });

    e.preventDefault();
});

$(document).on('click', '#saBtnAdd', function (e) {
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 2000
    });

    e.preventDefault();

    document.getElementById("saBtnAdd").disabled = true;
    $('#saBtnAdd').text("Adding...");

    var system_role_id = $('#sa_id').val();
    var sa_system_web_module_id = $('#sa_system_web_module_id').val();

    var form = document.getElementById('sa_form');
    var formData = new FormData(form);

    $.ajax({
        type: 'POST',
        url: base_url + "SystemRole/AddSectionRole",
        data: formData,
        contentType: false,
        cache: false,
        processData: false,
        dataType: 'json'
    }).done(function (response) {

        if (response.status) {

            $('#saBtnAdd').text("Add");
            document.getElementById("saBtnAdd").disabled = false;

            $("#sa_table").empty();

            Toast.fire({
                icon: 'success',
                title: response.message
            }).then(function () {

                $.ajax({
                    url: base_url + 'SystemRole/UpdateSectionTable',
                    data: { 'system_role_id': system_role_id, 'system_web_module_id': sa_system_web_module_id },
                    type: "GET",
                }).done(function (result) {
                    $("#sa_table").html(result);

                });

            });

            return;
        }

        Toast.fire({
            icon: 'error',
            title: 'An error has occured! Please try again.'
        });

        $('#saBtnAdd').text("Add");
        document.getElementById("saBtnAdd").disabled = false;
    });

    e.preventDefault();
});


$(document).on('click', '#ma_delete', function (e) {
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 2000
    });

    e.preventDefault();
    var id = $(this).data("id");

    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: true
    });

    swalWithBootstrapButtons.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "POST",
                url: base_url + "SystemRole/DeleteUserRole/" + id,
                dataType: "json",
            }).done(function (response) {

                //if (response.status) {
                //    Toast.fire({
                //        icon: 'success',
                //        title: response.message
                //    }).then(function () {
                //        window.location.href = base_url + "SystemRole/Index";
                //    });

                //    return;
                //}

                //Toast.fire({
                //    icon: 'error',
                //    title: 'An error has occured! Please try again.'
                //});

            });

        } else if (
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Delete cancelled. Your record is safe :)',
                'error'
            )
        }
    })

    e.preventDefault();
});


$(document).on('click', '#sa_delete', function (e) {
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 2000
    });

    e.preventDefault();
    var id = $(this).data("id");

    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: true
    });

    swalWithBootstrapButtons.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "POST",
                url: base_url + "SystemRole/DeleteUserRole/" + id,
                dataType: "json",
            }).done(function (response) {

                //if (response.status) {
                //    Toast.fire({
                //        icon: 'success',
                //        title: response.message
                //    }).then(function () {
                //        window.location.href = base_url + "SystemRole/Index";
                //    });

                //    return;
                //}

                //Toast.fire({
                //    icon: 'error',
                //    title: 'An error has occured! Please try again.'
                //});

            });

        } else if (
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Delete cancelled. Your record is safe :)',
                'error'
            )
        }
    })

    e.preventDefault();
});




$('#sa_system_web_module_id').on('change', function (e) {
    e.preventDefault();

    var sa_system_web_module_id = $(this).val();
    var system_role_id = $('#sa_id').val();

    $("#sa_table").empty();

    $.ajax({
        url: base_url + 'SystemRole/UpdateSectionTable',
        data: { 'system_role_id': system_role_id, 'system_web_module_id': sa_system_web_module_id },
        type: "GET",
    }).done(function (result) {
        $("#sa_table").html(result);

    });
    
    $.ajax({
        url: base_url + 'SystemWebSection/ListByModuleRoleIDNotExists',
        data: { 'system_role_id': system_role_id, 'system_web_module_id': sa_system_web_module_id },
        type: "POST",
        cache: false,
        dataType: 'json'
    }).done(function (response) {
        var len = response.length;

        $("#sa_system_web_section_id").empty();

        if (len > 0) {

            document.getElementById("saBtnAdd").hidden = false;
            
            $("#sa_system_web_section_id").append("<option value='0'>--SELECT ALL--</option>");
            for (var i = 0; i < len; i++) {
                var id = response[i]['id'];
                var name = response[i]['name'];
                $("#sa_system_web_section_id").append("<option value='" + id + "'>" + name + "</option>");
            }
        } else {
            document.getElementById("saBtnAdd").hidden = true;
        }
    });
});


    
//$(document).on('click', '#maBtnAdd', function (e) {
//    var Toast = Swal.mixin({
//        toast: true,
//        position: 'top-end',
//        showConfirmButton: false,
//        timer: 2000
//    });

//    e.preventDefault();

//    document.getElementById("maBtnAdd").disabled = true;
//    $('#maBtnAdd').text("Adding...");

//    var system_role_id = $('#ma_id').val();

//    var form = document.getElementById('ma_form');
//    var formData = new FormData(form);

//    $.ajax({
//        type: 'POST',
//        url: base_url + "SystemRole/AddModuleRole",
//        data: formData,
//        contentType: false,
//        cache: false,
//        processData: false,
//        dataType: 'json'
//    }).done(function (response) {

//        if (response.status) {

//            $('#maBtnAdd').text("Add");
//            document.getElementById("maBtnAdd").disabled = false;

//            $("#ma_table").empty();

//            Toast.fire({
//                icon: 'success',
//                title: response.message
//            }).then(function () {

//                $.ajax({
//                    url: base_url + 'SystemRole/UpdateModuleTable',
//                    data: { 'system_role_id': system_role_id },
//                    type: "GET",
//                }).done(function (result) {
//                    $("#ma_table").html(result);

//                });

//            });

//            return;
//        }

//        Toast.fire({
//            icon: 'error',
//            title: 'An error has occured! Please try again.'
//        });

//        $('#maBtnAdd').text("Add");
//        document.getElementById("maBtnAdd").disabled = false;
//    });

//    e.preventDefault();
//});