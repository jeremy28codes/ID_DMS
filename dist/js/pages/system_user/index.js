$(document).ready(function () {

    $("#system_department_id").select2();
    $("#system_division_id").select2();

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
                url: base_url + "SystemUser/Delete/" + id,
                dataType: "json",
            }).done(function (response) {

                if (response.status) {
                    Toast.fire({
                        icon: 'success',
                        title: response.message
                    }).then(function () {
                        window.location.href = base_url + "SystemUser/Index";
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


$('#system_department_id').on('change', function (e) {
    e.preventDefault();

    var department_id = $(this).val();
    var division_id = $("#system_division_id").val();

    
    updateTableList(department_id, division_id);

    $.ajax({
        url: base_url + 'SystemDivision/ListByDepartmentID',
        data: { 'department_id': department_id },
        type: "POST",
        cache: false,
        dataType: 'json'
    }).done(function (response) {
        var len = response.length;

        $("#system_division_id").empty();
        $("#system_division_id").append("<option value='0'>--SELECT ALL--</option>");
        for (var i = 0; i < len; i++) {
            var id = response[i]['id'];
            var name = response[i]['name'];
            $("#system_division_id").append("<option value='" + id + "'>" + name + "</option>");

        }
    });
});

$('#system_division_id').on('change', function (e) {
    e.preventDefault();

    var department_id = $("#system_department_id").val();
    var division_id = $(this).val();

    updateTableList(department_id, division_id);
});

function updateTableList(system_department_id, system_division_id) {
    $("#table").empty();
    $.ajax({
        url: base_url + 'SystemUser/UpdateTableList',
        data: { 'system_department_id': system_department_id, 'system_division_id': system_division_id },
        type: "GET",
    }).done(function (result) {
        $("#table").html(result);
    });

}