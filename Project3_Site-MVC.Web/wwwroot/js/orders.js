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

    url = '/OrderHistory/Search/'+search;

    $.get(url, function( data ) {
        $('#tableBody').html(data);
    });

    $('#search').focus();
}

    /*$('#btn_sendInvoices').click(function(evt){ 
    

    });*/

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
            $('.orderItem').prop('checked', false);
            $('#email').val('');
            $('#emailModal').modal('hide');
            setTimeout(function () {
                $('.alert-dismissable').fadeOut('slow');
            }, 3000);
        }
    });
});

