var pageSize = 10;
var pageIndex = 0;

function GetData() {
    $.ajax({
        type: 'GET',
        url: '/Catalogo/GetData',
        data: { "pageindex": pageIndex, "pagesize": pageSize },
        dataType: 'json',
        success: function (data) {
            if (data != null) {
                for (var i = 0; i < data.length; i++) {

                    $("#DivLibros").append("<a href='#' class='list-group-item'>" +
                        "<h4 class='li-head'>" + data[i].cat_Titulo + "</h4>" +
                        "<p class='li-sub'>" + data[i].autor_nombrecompleto + "</p>" +
                        "<p class='li-sub'>" + data[i].cat_Año + "</p>" +
                    "</a>");
                }
                pageIndex++;
            }
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