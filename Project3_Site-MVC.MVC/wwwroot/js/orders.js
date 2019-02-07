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

    url = '/orders/search/'+search;

    $.get(url, function( data ) {
        $('#tableBody').html(data);
    });

    $('#search').focus();
}

$('#btn_sendInvoices').click(function(evt){ 
    $('#sendMailForm').submit();
});

$('#selectAllInvoices').change(function(e)
{
    checked = $(this).is(':checked');
    
    $('.orderItem').prop('checked', checked);
});
