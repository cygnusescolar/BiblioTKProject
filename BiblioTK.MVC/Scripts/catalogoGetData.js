var pageSize = 10;
var pageIndex = 0;
 
function GetData() {
    $.ajax({
        type: 'POST',
        url: '/Catalogo/GetData',
        data: { "pageindex": pageIndex, "pagesize": pageSize },
        dataType: 'html',
        success: function (result) {
            $("#DivLibros").append(result);
            pageIndex++;
        },
        beforeSend: function () {
            $("#progress").show();
        },
        complete: function () {
            $("#progress").hide();
        },
        error: function (request, status, error) {
            alert("ha ocurrido algo. Intenta de nuevo. " + request.responseText + error);
        }
    });
}