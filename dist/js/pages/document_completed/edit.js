$(function () {

    $("#table").DataTable({
        "responsive": true, "lengthChange": false, "autoWidth": false,
        "buttons": ["copy", "csv", "excel", "pdf", "print"]
    }).buttons().container().appendTo('#table_wrapper .col-md-6:eq(0)');
});


$(document).ready(function () {

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
                type: "POST",
                url: base_url + "DocumentCompleted/Edit",
                data: formData,
                contentType: false,
                cache: false,
                processData: false,
                dataType: 'json'
            }).done(function (response) {

                
                if (response.status){
                    Toast.fire({
                        icon: 'success',
                        title: response.message
                    }).then(function () {

                        $('#btnSubmit').text("Save");
                        document.getElementById("btnSubmit").disabled = false;

                        window.location.href = base_url + "DocumentCompleted/Index";
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



$(document).on('click', '#delete', function (e) {
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 2000
    });

    e.preventDefault();
    var id = $(this).data("id");
    var document_id = $('#id').val();

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
                url: base_url + "DocumentAttachments/Delete/" + id,
                dataType: "json",
            }).done(function (response) {

                if (response.status) {
                    Toast.fire({
                        icon: 'success',
                        title: response.message
                    }).then(function () {
                        window.location.href = base_url + "DocumentCompleted/Edit/" + document_id;
                    });

                    return;
                }

                Toast.fire({
                    icon: 'error',
                    title: 'An error has occured! Please try again.'
                });

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

