var pageSize = 10;
var pageIndex = 0;
var image = "";
function GetData() {
    $.ajax({
        type: 'GET',
        url: '/Catalogo/GetData',
        data: { "pageindex": pageIndex, "pagesize": pageSize },
        dataType: 'json',
        success: function (data) {
            if (data != null) {
                for (var i = 0; i < data.length; i++) {
                    
                    var shtml = "<ul class='media-list main-list list-group-item'>" +
			          "<li class='media'>" +
			            "<a class='pull-left' href='#'>" +
			             " <img class='media-object img-responsive' src='" + data[i].imagenRuta + "' alt='...'>" +
			            "</a>" +
			            "<div class='media-body'>" +
			                "<a class='li-head' href='#'><h4>" + data[i].cat_Titulo + "</h4></a>" +
                            "<p class='li-sub'>" + data[i].autor_nombrecompleto + "</p>" +
                            "<p class='li-sub'>" + data[i].cat_Año + "</p>" +
			          "  </div>" +
			         " </li>		" +	 
			        "</ul>";
                 $("#DivLibros").append(shtml);
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