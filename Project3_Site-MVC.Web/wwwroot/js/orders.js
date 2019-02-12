$('#search').focus();

$('#searchOrdersForm').submit(function(evt){ 
    evt.preventDefault();
    searchFunction();
});
$('#submitSearchOrdersForm').click(function(evt){ 
    evt.preventDefault();   
    searchFunction();
});

function searchFunction()
{
    search = $('#search').val();
    column = $('#sortColumn').val();
    order = $('#sortOrder').val();

    performSearch(column, order, search);

    $('#search').focus();
}

$('.sortColumnTable').click(function () {
    columnClick = $(this).data('column');
    column = $('#columnSorted').val();
    order = $('#orderSorted').val();
    search = $('#search').val();

    //Invert order
    if (columnClick == column) {
        if (order == 'asc') {
            order = 'desc';
        }
        else {
            order = 'asc';
        }
    }
    //Different Sort
    else {
        column = columnClick;
        order = 'asc';
    }

    $('#orderSorted').val(order);
    $('#columnSorted').val(column);

    performSearch(column, order, search);
});

function performSearch(column, order, search)
{
    url = '/OrderHistory/Search/' + column + '/' + order + '/' + search;

    $.get(url, function (data) {
        $('#tableBody').html(data);
    });
}

$('#selectAllInvoices').change(function(e)
{
    checked = $(this).is(':checked');
    
    $('.orderItem').prop('checked', checked);
});


$('#emailModal').on('shown.bs.modal', function () {
    ids = [];
    $.each($(".orderItem:checked"), function () {
        ids.push($(this).val());
    });

    $('#invoicedInput').val(ids);

    //alert($('#invoicedInput').val());
});

$('#modalButonSendMail').click(function () {
    $('#messageEmailSending').show();

    dataPost = {
        invoices: $('#invoicedInput').val()
    };

    $.post("/Email/Send", dataPost, function (emailBody) {
        try {
            Email.send({
                SecureToken: "28c42bac-7143-426d-a37d-cb6414a8e115",
                To: $('#email').val(),
                From: "no-reply@polyglots.com",
                Subject: "Invoices",
                Body: emailBody
            }).then(
                $('#returnMessage').html('<div class="alert alert-success alert-dismissable"><p>E-mail send succesfully</p></div>')
            );
        }
        catch (ex) {
            $('#returnMessage').html('<div class="alert alert-danger alert-dismissable"><p>Fail to send e-mail</p></div>')
        }
        finally
        {
            $('#emailModal').modal('hide');
            setTimeout(function () {
                $('.alert-dismissable').fadeOut('slow');
            }, 3000);
            $('#messageEmailSending').hide();
            $('.orderItem').prop('checked', false);
            $('#email').val('');
        }
    });
});

$('#messageEmailSending').hide();