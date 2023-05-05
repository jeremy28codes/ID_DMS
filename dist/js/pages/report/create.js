const isRequired = value => value === '' ? false : true;
var ft_ctr = document.getElementById('ft_ctr').value;
var s_ctr = document.getElementById('s_ctr').value;

$(document).ready(function () {

    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 2000
    });

    var is_in_behalf_of_business = $('#is_in_behalf_of_business').val();

    if (parseInt(is_in_behalf_of_business) == 0) {
        $("#business_name").attr('readonly', true);
        $("#business_name").addClass("is-read-only");
        $("#is_impacting_business_operations").attr('readonly', true);
        $("#is_impacting_business_operations").addClass("is-read-only");
    } else {
        $("#business_name").attr('readonly', false);
        $("#business_name").removeClass("is-read-only");
        $("#is_impacting_business_operations").attr('readonly', false);
        $("#is_impacting_business_operations").removeClass("is-read-only");
    }

    var country = $("#country_id");
    populateCountry(country);
    var province = $("#province_id");
    populateProvince(province);
    var city = $("#city_id");
    populateCity(city, 0);

    $("#ft_add").click(function () {
        document.getElementById('ft_ctr').value = ft_ctr++;
        $('#ft_ctr').val(ft_ctr);
        $("#ft_table").append('<tr>' +
            '<td style="border-bottom: 2px solid black; padding-bottom: 10px; padding-top: 10px;"> ' +
            '<div class="row">' +
            '<div class="col-md-12"><button type="button" class="btn btn-danger mb-3 ft-remove-tr"><i class="fas fa-minus"></i> Remove</button></div>' +
            '</div>' +
            '<div class="row">' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_rgv_transaction_type_id_' + ft_ctr + '">Transaction Type <code>* </code></label>' +
            '<select id="ft_rgv_transaction_type_id_' + ft_ctr + '" name="ft_rgv_transaction_type_id_' + ft_ctr + '" class="form-control isRequired" style="width: 100%;">' +
            '</select>' +
            '<small></small>' +
            '</div>' +
            '<div class="col-md-8 pb-2 form-field">' +
            '<label class="form-label" for="ft_others_' + ft_ctr + '">If other, please specify <code id="req_ft_others_' + ft_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="ft_others_' + ft_ctr + '" name="ft_others_' + ft_ctr + '" class="form-control" placeholder="Please Specify">' +
            '<small></small>' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_transaction_date_' + ft_ctr + '">Date <code id="req_ft_transaction_date_' + ft_ctr + '" hidden>* </code></label>' +
            '<input type="date" id="ft_transaction_date_' + ft_ctr + '" name="ft_transaction_date_' + ft_ctr + '" class="form-control">' +
            '<small></small>' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_amount_' + ft_ctr + '">Amount <code id="req_ft_amount_' + ft_ctr + '" hidden>* </code></label>' +
            '<input type="number" min="0" max="999999999" step="0.01" pattern="^\d+(?:\.\d{1,2})?$" id="ft_amount_' + ft_ctr + '" name="ft_amount_' + ft_ctr + '" class="form-control" placeholder="00.00">' +
            '<small></small>' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_is_sent_' + ft_ctr + '">Was the money sent? <code id="req_ft_is_sent_' + ft_ctr + '" hidden>* </code></label>' +
            '<select id="ft_is_sent_' + ft_ctr + '" name="ft_is_sent_' + ft_ctr + '" class="form-control" style="width: 100%;">' +
            '<option value="1">Yes</option>' +
            '<option value="0">No</option>' +
            '</select>' +
            '</div>' +
            '</div>' +
            '<br />' +
            '<br />' +
            '<div class="row">' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_victim_bank_name_' + ft_ctr + '">Victim Bank Name <code id="req_ft_victim_bank_name_' + ft_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="ft_victim_bank_name_' + ft_ctr + '" name="ft_victim_bank_name_' + ft_ctr + '" class="form-control" placeholder="Enter bank name here">' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_victim_account_name_' + ft_ctr + '">Victim Name on Account <code id="req_ft_victim_account_name_' + ft_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="ft_victim_account_name_' + ft_ctr + '" name="ft_victim_account_name_' + ft_ctr + '" class="form-control" placeholder="Enter account name here">' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_victim_account_number_' + ft_ctr + '">Victim Account Number <code id="req_ft_victim_account_number_' + ft_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="ft_victim_account_number_' + ft_ctr + '" name="ft_victim_account_number_' + ft_ctr + '" class="form-control" placeholder="Enter account number here">' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_victim_bank_country_id_' + ft_ctr + '">Victim Bank Country <code id="req_ft_victim_bank_country_id_' + ft_ctr + '" hidden>* </code></label>' +
            '<select id="ft_victim_bank_country_id_' + ft_ctr + '" name="ft_victim_bank_country_id_' + ft_ctr + '" class="form-control" style="width: 100%;">' +
            '<option value="0">- - PLEASE SELECT ONE - -</option>' +
            '</select>' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_victim_bank_province_id_' + ft_ctr + '">Victim Bank Province <code id="req_ft_victim_bank_province_id_' + ft_ctr + '" hidden>* </code></label>' +
            '<select id="ft_victim_bank_province_id_' + ft_ctr + '" name="ft_victim_bank_province_id_' + ft_ctr + '" class="form-control" style="width: 100%;">' +
            '<option value="0">- - PLEASE SELECT ONE - -</option>' +
            '</select>' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_victim_bank_city_id_' + ft_ctr + '">Victim Bank City <code id="req_ft_victim_bank_city_id_' + ft_ctr + '" hidden>* </code></label>' +
            '<select id="ft_victim_bank_city_id_' + ft_ctr + '" name="ft_victim_bank_city_id_' + ft_ctr + '" class="form-control" style="width: 100%;">' +
            '<option value="0">- - PLEASE SELECT ONE - -</option>' +
            '</select>' +
            '</div>' +
            '<div class="col-md-9 pb-2 form-field">' +
            '<label class="form-label" for="ft_victim_bank_address_' + ft_ctr + '">Victim Bank Address <code id="req_ft_victim_bank_address_' + ft_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="ft_victim_bank_address_' + ft_ctr + '" name="ft_victim_bank_address_' + ft_ctr + '" class="form-control" placeholder="Enter address here">' +
            '</div>' +
            '<div class="col-md-3 pb-2 form-field">' +
            '<label class="form-label" for="ft_victim_bank_zip_code_' + ft_ctr + '">Victim Bank Zip Code <code id="req_ft_victim_bank_zip_code_' + ft_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="ft_victim_bank_zip_code_' + ft_ctr + '" name="ft_victim_bank_zip_code_' + ft_ctr + '" class="form-control" placeholder="Enter zip code here">' +
            '</div>' +
            '</div>' +
            '<br />' +
            '<br />' +
            '<div class="row">' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_receipient_bank_name_' + ft_ctr + '">Receipient Bank Name <code id="req_ft_receipient_bank_name_' + ft_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="ft_receipient_bank_name_' + ft_ctr + '" name="ft_receipient_bank_name_' + ft_ctr + '" class="form-control" placeholder="Enter bank name here">' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_receipient_account_name_' + ft_ctr + '">Receipient Name on Account <code id="req_ft_receipient_account_name_' + ft_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="ft_receipient_account_name_' + ft_ctr + '" name="ft_receipient_account_name_' + ft_ctr + '" class="form-control" placeholder="Enter account name here">' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_receipient_account_number_' + ft_ctr + '">Receipient Account Number <code id="req_ft_receipient_account_number_' + ft_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="ft_receipient_account_number_' + ft_ctr + '" name="ft_receipient_account_number_' + ft_ctr + '" class="form-control" placeholder="Enter account number here">' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_receipient_bank_country_id_' + ft_ctr + '">Receipient Bank Country <code id="req_ft_receipient_bank_country_id_' + ft_ctr + '" hidden>* </code></label>' +
            '<select id="ft_receipient_bank_country_id_' + ft_ctr + '" name="ft_receipient_bank_country_id_' + ft_ctr + '" class="form-control" style="width: 100%;">' +
            '<option value="0">- - PLEASE SELECT ONE - -</option>' +
            '</select>' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_receipient_bank_province_id_' + ft_ctr + '">Receipient Bank Province <code id="req_ft_receipient_bank_province_id_' + ft_ctr + '" hidden>* </code></label>' +
            '<select id="ft_receipient_bank_province_id_' + ft_ctr + '" name="ft_receipient_bank_province_id_' + ft_ctr + '" class="form-control" style="width: 100%;">' +
            '<option value="0">- - PLEASE SELECT ONE - -</option>' +
            '</select>' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="ft_receipient_bank_city_id_' + ft_ctr + '">Receipient Bank City <code id="req_ft_receipient_bank_city_id_' + ft_ctr + '" hidden>* </code></label>' +
            '<select id="ft_receipient_bank_city_id_' + ft_ctr + '" name="ft_receipient_bank_city_id_' + ft_ctr + '" class="form-control" style="width: 100%;">' +
            '<option value="0">- - PLEASE SELECT ONE - -</option>' +
            '</select>' +
            '</div>' +
            '<div class="col-md-9 pb-2 form-field">' +
            '<label class="form-label" for="ft_receipient_bank_address_' + ft_ctr + '">Receipient Bank Address <code id="req_ft_receipient_bank_address_' + ft_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="ft_receipient_bank_address_' + ft_ctr + '" name="ft_receipient_bank_address_' + ft_ctr + '" class="form-control" placeholder="Enter address here">' +
            '</div>' +
            '<div class="col-md-3 pb-2 form-field">' +
            '<label class="form-label" for="ft_receipient_bank_zip_code_' + ft_ctr + '">Receipient Bank Zip Code <code id="req_ft_receipient_bank_zip_code_' + ft_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="ft_receipient_bank_zip_code_' + ft_ctr + '" name="ft_receipient_bank_zip_code_' + ft_ctr + '" class="form-control" placeholder="Enter zip code here">' +
            '</div>' +
            '</div>' +
            '</td>' +
            '</tr>');

        var v_country = $('#ft_victim_bank_country_id_' + ft_ctr);
        var r_country = $('#ft_receipient_bank_country_id_' + ft_ctr);
        populateCountry(v_country);
        populateCountry(r_country);


        var v_province = $("#ft_victim_bank_province_id_" + ft_ctr);
        var r_province = $('#ft_receipient_bank_province_id_' + ft_ctr);
        populateProvince(v_province);
        populateProvince(r_province);

        var v_city = $("#ft_victim_bank_city_id_" + ft_ctr);
        var r_city = $('#ft_receipient_bank_city_id_' + ft_ctr);
        populateCity(v_city, 0);
        populateCity(r_city, 0);

        onProvinceChanged(v_province, v_city);
        onProvinceChanged(r_province, r_city);

        var rgv_transaction_type = $('#ft_rgv_transaction_type_id_' + ft_ctr);
        populateDDL(rgv_transaction_type, 'Transaction Types');


        onTransactionTypeChanged(ft_ctr);
        $('#ft_ctr').val(ft_ctr);
    });

    $("#s_add").click(function () {
        document.getElementById('s_ctr').value = s_ctr++;
        $('#s_ctr').val(s_ctr);

        $("#s_table").append('<tr>' +
            '<td style="border-bottom: 2px solid black; padding-bottom: 10px; padding-top: 10px;"> ' +
            '<div class="row">' +
            '<div class="col-md-12"><button type="button" class="btn btn-danger mb-3 s-remove-tr"><i class="fas fa-minus"></i> Remove</button></div>' +
            '</div>' +
            '<div class="row">' +
            '<div class="col-md-6 pb-2 form-field">' +
            '<label class="form-label" for="s_full_name_' + s_ctr + '">Name <code id="req_s_full_name_' + s_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="s_full_name_' + s_ctr + '" name="s_full_name_' + s_ctr + '" class="form-control" placeholder="Please enter name here">' +
            '</div>' +
            '<div class="col-md-6 pb-2 form-field">' +
            '<label class="form-label" for="s_business_name_' + s_ctr + '">Business Name <code id="req_s_business_name_' + s_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="s_business_name_' + s_ctr + '" name="s_business_name_' + s_ctr + '" class="form-control" placeholder="Please enter business name here">' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="s_country_id_' + s_ctr + '">Country <code id="req_s_country_id_' + s_ctr + '" hidden>* </code></label>' +
            '<select id="s_country_id_' + s_ctr + '" name="s_country_id_' + s_ctr + '" class="form-control" style="width: 100%;">' +
            '<option value="0">- - PLEASE SELECT ONE - -</option>' +
            '</select>' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="s_province_id_' + s_ctr + '">Province <code id="req_s_province_id_' + s_ctr + '" hidden>* </code></label>' +
            '<select id="s_province_id_' + s_ctr + '" name="s_province_id_' + s_ctr + '" class="form-control" style="width: 100%;">' +
            '<option value="0">- - PLEASE SELECT ONE - -</option>' +
            '</select>' +
            '</div>' +
            '<div class="col-md-4 pb-2 form-field">' +
            '<label class="form-label" for="s_city_id_' + s_ctr + '">City <code id="req_s_city_id_' + s_ctr + '" hidden>* </code></label>' +
            '<select id="s_city_id_' + s_ctr + '" name="s_city_id_' + s_ctr + '" class="form-control" style="width: 100%;">' +
            '<option value="0">- - PLEASE SELECT ONE - -</option>' +
            '</select>' +
            '</div>' +
            '<div class="col-md-9 pb-2 form-field">' +
            '<label class="form-label" for="s_address_' + s_ctr + '">Address <code id="req_s_address_' + s_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="s_address_' + s_ctr + '" name="s_address_' + s_ctr + '" class="form-control" placeholder="Enter address here">' +
            '</div>' +
            '<div class="col-md-3 pb-2 form-field">' +
            '<label class="form-label" for="s_zip_code_' + s_ctr + '">Receipient Bank Zip Code <code id="req_s_zip_code_' + s_ctr + '" hidden>* </code></label>' +
            '<input type="text" id="s_zip_code_' + s_ctr + '" name="s_zip_code_' + s_ctr + '" class="form-control" placeholder="Enter zip code here">' +
            '</div>' +
            '<div class="col-md-6 pb-2 form-field">' +
            '<label class="form-label" for="s_mobile_number_' + s_ctr + '">Mobile Number <code>(numbers only)</code> <code id="req_s_mobile_number_' + s_ctr + '" hidden> * </code></label>' +
            '<input type="number" id="s_mobile_number_' + s_ctr + '" name="s_mobile_number_' + s_ctr + '" min="0" class="form-control" placeholder="09XXXXXXXXX">' +
            '</div>' +
            '<div class="col-md-6 pb-2 form-field">' +
            '<label class="form-label" for="s_email_' + s_ctr + '">Email Address <code>janedoe@email.com</code></label>' +
            '<input type="email" id="s_email_' + s_ctr + '" name="s_email_' + s_ctr + '" class="form-control" placeholder="Enter email address here">' +
            '</div>' +
            '<div class="col-md-5 pb-2 form-field">' +
            '<label class="form-label" for="s_ip_address_' + s_ctr + '">IP Address </label>' +
            '<input type="text" id="s_ip_address_' + s_ctr + '" name="s_ip_address_' + s_ctr + '" class="form-control" placeholder="123.45.67.89 or 2001:abc::1234">' +
            '</div>' +
            '<div class="col-md-7 pb-2 form-field">' +
            '<label class="form-label" for="s_website_link_' + s_ctr + '">Website </label>' +
            '<input type="text" id="s_website_link_' + s_ctr + '" name="s_website_link_' + s_ctr + '" class="form-control" placeholder="http://www.example.com/">' +
            '</div>' +
            '</div>' +
            '</td>' +
            '</tr>');

        var country = $('#s_country_id_' + s_ctr);
        populateCountry(country);

        var province = $("#s_province_id_" + s_ctr);
        populateProvince(province);

        var city = $("#s_city_id_" + s_ctr);
        populateCity(city, 0);

        onProvinceChanged(province, city);

    });

    $(document).on('click', '.ft-remove-tr', function () {
        $(this).parents('tr').remove();

        document.getElementById('ft_ctr').value = ft_ctr--;
        $('#ft_ctr').val(ft_ctr);
    });

    $(document).on('click', '.s-remove-tr', function () {
        $(this).parents('tr').remove();

        document.getElementById('s_ctr').value = s_ctr--;
        $('#s_ctr').val(s_ctr);
    });

    const form = document.querySelector('#form');

    form.addEventListener('submit', function (e) {
        // prevent the form from submitting
        e.preventDefault();

        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: true
        });

        document.getElementById("btnSubmit").disabled = true;
        $('#btnSubmit').text("Saving ...");

        let isInputValid = true;

        $('.isRequired').each(function () {

            var input_id = $(this).attr('id');
            const input = document.querySelector('#' + input_id);

            if (!checkInputValue(input)) {
                isInputValid = false;
            };

        });

        let isFormValid = isInputValid;

        // submit to the server if the form is valid
        if (isFormValid) {

            var formData = new FormData(form);

            $.ajax({
                type: 'POST',
                url: base_url + "Report/Create",
                data: formData,
                contentType: false,
                cache: false,
                processData: false,
                dataType: 'json'
            }).done(function (response) {

                if (response.status) {

                    swalWithBootstrapButtons.fire({
                        title: 'Success!',
                        text: "You have successfully filed a complaint!",
                        icon: 'success',
                        confirmButtonText: 'Ok',
                    }).then(() => {

                        location.reload();

                        document.getElementById("btnSubmit").disabled = false;
                        $('#btnSubmit').text("Save");
                    });

                    return;
                }

                Toast.fire({
                    icon: 'error',
                    title: 'An error has occured! Please try again.'
                }).then(() => {
                    document.getElementById("btnSubmit").disabled = false;
                    $('#btnSubmit').text("Save");
                });
            });

        } else {
            swalWithBootstrapButtons.fire({
                title: 'Error!',
                text: "Please fill up the required fields first!",
                icon: 'error',
                confirmButtonText: 'Ok',
            }).then(() => {
                document.getElementById("btnSubmit").disabled = false;
                $('#btnSubmit').text("Save");
            });
        }
    });

    const checkInputValue = (input) => {

        let valid = false;

        const inputVal = input.value.trim();

        if (!isRequired(inputVal) || inputVal <= 0) {
            showError(input, 'This field is required.');
        } else {
            showSuccess(input);
            valid = true;
        }
        return valid;
    }

    const showError = (input, message) => {
        // get the form-field element
        const formField = input.parentElement;
        // add the error class
        formField.classList.remove('success');
        formField.classList.add('error');

        // show the error message
        const error = formField.querySelector('small');
        error.textContent = message;
    };

    const showSuccess = (input) => {
        // get the form-field element
        const formField = input.parentElement;

        // remove the error class
        formField.classList.remove('error');
        formField.classList.add('success');

        // hide the error message
        const error = formField.querySelector('small');
        error.textContent = '';
    }

    function populateCountry(input) {

        $.ajax({
            url: base_url + 'SystemReferenceCountry/List_All',
            type: "POST",
            cache: false,
            dataType: 'json'
        }).done(function (response) {
            var len = response.length;

            $(input).empty();
            $(input).append("<option value='0'>- - PLEASE SELECT ONE - -</option>");
            for (var i = 0; i < len; i++) {
                var id = response[i]['id'];
                var name = response[i]['name'];

                if (name == "Philippines") {
                    $(input).append("<option value='" + id + "' selected>" + name + "</option>");
                }
                $(input).append("<option value='" + id + "'>" + name + "</option>");
            }
        });

        input.select2();
    }

    function populateProvince(input) {

        $.ajax({
            url: base_url + 'SystemReferenceProvince/List_All',
            type: "POST",
            cache: false,
            dataType: 'json'
        }).done(function (response) {
            var len = response.length;

            $(input).empty();
            $(input).append("<option value='0'>- - PLEASE SELECT ONE - -</option>");
            for (var i = 0; i < len; i++) {
                var id = response[i]['id'];
                var name = response[i]['name'];
                $(input).append("<option value='" + id + "'>" + name + "</option>");
            }
        });

        input.select2();
    }

    function populateCity(input, province_id) {

        $.ajax({
            url: base_url + 'SystemReferenceCity/ListBy_RegionIDProvinceID',
            data: { 'reference_region_id': 0, 'reference_province_id': province_id },
            type: "POST",
            cache: false,
            dataType: 'json'
        }).done(function (response) {
            var len = response.length;

            $(input).empty();
            $(input).append("<option value='0'>- - PLEASE SELECT ONE - -</option>");
            for (var i = 0; i < len; i++) {
                var id = response[i]['id'];
                var name = response[i]['name'];
                $(input).append("<option value='" + id + "'>" + name + "</option>");

            }

        });

        input.select2();
    }

    function populateDDL(input, group_code) {

        $.ajax({
            url: base_url + 'SystemReferenceGroupValue/ListBy_GroupCodeDepartmentDivisionID',
            data: { 'reference_group_code': group_code, 'department_id': 0, 'division_id': 0 },
            type: "POST",
            cache: false,
            dataType: 'json'
        }).done(function (response) {
            var len = response.length;

            $(input).empty();
            $(input).append("<option value='0'>- - PLEASE SELECT ONE - -</option>");
            for (var i = 0; i < len; i++) {
                var id = response[i]['id'];
                var name = response[i]['name'];
                $(input).append("<option value='" + id + "'>" + name + "</option>");

            }

        });

        input.select2();
    }

    function onProvinceChanged(province, city) {

        $(province).on('change', function (e) {
            e.preventDefault();
            var province_id = $(this).val();

            populateCity(city, province_id);
        });

    }

    function fieldStatus(field_name, ctr, viewFlag, requireFlag, enableFlag) {
        if (viewFlag) {
            document.getElementById('ft_' + field_name + '_' + ctr).hidden = false;
        } else {
            document.getElementById('ft_' + field_name + '_' + ctr).hidden = true;
        }
        if (requireFlag) {
            document.getElementById('req_ft_' + field_name + '_' + ctr).hidden = false;
            document.getElementById('ft_' + field_name + '_' + ctr).classList.add("isRequired");
        } else {
            document.getElementById('req_ft_' + field_name + '_' + ctr).hidden = true;
            document.getElementById('ft_' + field_name + '_' + ctr).classList.remove("isRequired");
        }
        if (enableFlag) {
            if (field_name == "victim_bank_country_id" || field_name == "victim_bank_province_id" || field_name == "victim_bank_city_id" || field_name == "receipient_bank_country_id" || field_name == "receipient_bank_province_id" || field_name == "receipient_bank_city_id") {
                $('#ft_' + field_name + '_' + ctr).select2({ disabled: '' });
            } else {
                $('#ft_' + field_name + '_' + ctr).attr('readonly', false);
            }
            $('#ft_' + field_name + '_' + ctr).removeClass("is-read-only");

        } else {
            if (field_name == "victim_bank_country_id" || field_name == "victim_bank_province_id" || field_name == "victim_bank_city_id" || field_name == "receipient_bank_country_id" || field_name == "receipient_bank_province_id" || field_name == "receipient_bank_city_id") {
                $('#ft_' + field_name + '_' + ctr).select2({ disabled: 'readonly' });
            } else {
                $('#ft_' + field_name + '_' + ctr).attr('readonly', true);
            }
            $('#ft_' + field_name + '_' + ctr).addClass("is-read-only");
        }
    }

    function onTransactionTypeChanged(ctr) {

        transaction_type_no_selected(ctr);
        //transaction_type_others(ctr, false);


        $('#ft_rgv_transaction_type_id_' + ctr).on('change', function (e) {
            e.preventDefault();
            var rgv_transaction_type_id = $(this).val();

            if (rgv_transaction_type_id == 0) {
                transaction_type_no_selected(ctr);
            } else if (rgv_transaction_type_id == 55) {
                transaction_type_others(ctr);
            } else {
                transaction_type_all(ctr);
            }
        });
    }

    function transaction_type_others(ctr) {
        fieldStatus('others', ctr, true, true, true);
        fieldStatus('transaction_date', ctr, true, true, true);
        fieldStatus('amount', ctr, true, true, true);
        fieldStatus('is_sent', ctr, true, false, true);
        fieldStatus('victim_bank_name', ctr, true, false, true);
        fieldStatus('victim_account_name', ctr, true, false, true);
        fieldStatus('victim_account_number', ctr, true, false, true);
        fieldStatus('victim_bank_country_id', ctr, true, false, true);
        fieldStatus('victim_bank_province_id', ctr, true, false, true);
        fieldStatus('victim_bank_city_id', ctr, true, false, true);
        fieldStatus('victim_bank_address', ctr, true, false, true);
        fieldStatus('victim_bank_zip_code', ctr, true, false, true);
        fieldStatus('receipient_bank_name', ctr, true, false, true);
        fieldStatus('receipient_account_name', ctr, true, false, true);
        fieldStatus('receipient_account_number', ctr, true, false, true);
        fieldStatus('receipient_bank_country_id', ctr, true, false, true);
        fieldStatus('receipient_bank_province_id', ctr, true, false, true);
        fieldStatus('receipient_bank_city_id', ctr, true, false, true);
        fieldStatus('receipient_bank_address', ctr, true, false, true);
        fieldStatus('receipient_bank_zip_code', ctr, true, false, true);
    }

    function transaction_type_no_selected(ctr) {
        fieldStatus('others', ctr, true, false, false);
        fieldStatus('transaction_date', ctr, true, false, false);
        fieldStatus('amount', ctr, true, false, false);
        fieldStatus('is_sent', ctr, true, false, false);
        fieldStatus('victim_bank_name', ctr, true, false, false);
        fieldStatus('victim_account_name', ctr, true, false, false);
        fieldStatus('victim_account_number', ctr, true, false, false);
        fieldStatus('victim_bank_country_id', ctr, true, false, false);
        fieldStatus('victim_bank_province_id', ctr, true, false, false);
        fieldStatus('victim_bank_city_id', ctr, true, false, false);
        fieldStatus('victim_bank_address', ctr, true, false, false);
        fieldStatus('victim_bank_zip_code', ctr, true, false, false);
        fieldStatus('receipient_bank_name', ctr, true, false, false);
        fieldStatus('receipient_account_name', ctr, true, false, false);
        fieldStatus('receipient_account_number', ctr, true, false, false);
        fieldStatus('receipient_bank_country_id', ctr, true, false, false);
        fieldStatus('receipient_bank_province_id', ctr, true, false, false);
        fieldStatus('receipient_bank_city_id', ctr, true, false, false);
        fieldStatus('receipient_bank_address', ctr, true, false, false);
        fieldStatus('receipient_bank_zip_code', ctr, true, false, false);
    }

    function transaction_type_all(ctr) {
        fieldStatus('others', ctr, true, false, false);
        fieldStatus('transaction_date', ctr, true, true, true);
        fieldStatus('amount', ctr, true, true, true);
        fieldStatus('is_sent', ctr, true, false, true);
        fieldStatus('victim_bank_name', ctr, true, false, true);
        fieldStatus('victim_account_name', ctr, true, false, true);
        fieldStatus('victim_account_number', ctr, true, false, true);
        fieldStatus('victim_bank_country_id', ctr, true, false, true);
        fieldStatus('victim_bank_province_id', ctr, true, false, true);
        fieldStatus('victim_bank_city_id', ctr, true, false, true);
        fieldStatus('victim_bank_address', ctr, true, false, true);
        fieldStatus('victim_bank_zip_code', ctr, true, false, true);
        fieldStatus('receipient_bank_name', ctr, true, false, true);
        fieldStatus('receipient_account_name', ctr, true, false, true);
        fieldStatus('receipient_account_number', ctr, true, false, true);
        fieldStatus('receipient_bank_country_id', ctr, true, false, true);
        fieldStatus('receipient_bank_province_id', ctr, true, false, true);
        fieldStatus('receipient_bank_city_id', ctr, true, false, true);
        fieldStatus('receipient_bank_address', ctr, true, false, true);
        fieldStatus('receipient_bank_zip_code', ctr, true, false, true);
    }

    function onDDLChanged(input_name, target_input, ctr) {

        document.getElementById('ft_' + target_input + '_' + ctr).classList.remove("isRequired");
        document.getElementById('req_ft_' + target_input + '_' + ctr).hidden = true;
        $('#ft_' + target_input + '_' + ctr).attr('readonly', true);
        $('#ft_' + target_input + '_' + ctr).addClass("is-read-only");

        $('#ft_' + input_name + '_' + ctr).on('change', function (e) {
            e.preventDefault();
            var input_name_id = $(this).val();


            if (input_name_id == 55) {
                document.getElementById('ft_' + target_input + '_' + ctr).classList.add("isRequired");
                document.getElementById('req_ft_' + target_input + '_' + ctr).hidden = false;
                $('#ft_' + target_input + '_' + ctr).attr('readonly', false);
                $('#ft_' + target_input + '_' + ctr).removeClass("is-read-only");
            } else {
                document.getElementById('ft_' + target_input + '_' + ctr).classList.remove("isRequired");
                document.getElementById('req_ft_' + target_input + '_' + ctr).hidden = true;
                $('#ft_' + target_input + '_' + ctr).attr('readonly', true);
                $('#ft_' + target_input + '_' + ctr).addClass("is-read-only");
            }
            //if (rgv_transaction_type == 55) {

            //}
        });

    }


    $('#is_in_behalf_of_business').on('change', function (e) {
        e.preventDefault();
        var is_in_behalf_of_business = $(this).val();

        const business_name = document.getElementById("business_name");

        if (parseInt(is_in_behalf_of_business) == 0) {
            $("#business_name").attr('readonly', true);
            $("#business_name").addClass("is-read-only");
            $("#is_impacting_business_operations").attr('readonly', true);
            $("#is_impacting_business_operations").addClass("is-read-only");
            business_name.classList.remove("isRequired");
        } else {
            $("#business_name").attr('readonly', false);
            $("#business_name").removeClass("is-read-only");
            $("#is_impacting_business_operations").attr('readonly', false);
            $("#is_impacting_business_operations").removeClass("is-read-only");
            business_name.classList.add("isRequired");
        }
    });

    $('#province_id').on('change', function (e) {
        e.preventDefault();
        var province_id = $(this).val();

        var city = $("#city_id");
        populateCity(city, province_id);
    });

    $('#is_in_behalf_of_business').on('change', function (e) {
        e.preventDefault();

        var is_in_behalf_of_business = $(this).val();

        if (is_in_behalf_of_business == 0) {
            document.getElementById('req_impacting_business_operations').hidden = true
            document.getElementById('req_business_name').hidden = true
        } else {
            document.getElementById('req_impacting_business_operations').hidden = false
            document.getElementById('req_business_name').hidden = false
        }
    });

});


