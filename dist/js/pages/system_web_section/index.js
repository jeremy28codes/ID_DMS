$(function () {
    

    $("#table").DataTable({
        "responsive": true, "lengthChange": false, "autoWidth": false,
        "buttons": ["copy", "csv", "excel", "pdf", "print"]
    }).buttons().container().appendTo('#table_wrapper .col-md-6:eq(0)');
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
                url: base_url + "SystemWebSection/Delete/" + id,
                dataType: "json",
            }).done(function (response) {

                if (response.status) {
                    Toast.fire({
                        icon: 'success',
                        title: response.message
                    }).then(function () {
                        window.location.href = base_url + "SystemWebSection/Index";
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

