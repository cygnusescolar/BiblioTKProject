var pageSize = 10;
var pageIndex = 0;
var filtrado = false;
var nivel;
var filtro;
 
function GetData() {
    if (filtrado == false) {
        CargarCatalogo();
    }
    else {
        if (filtro)
            ListarPorTipo(filtro);
        else
            CargarCatalogoFiltrado();
    }

}

function CargarCatalogo() {
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
            $('#divCatalogoRecarga').hide();
        },
        complete: function () {
            $("#progress").hide();
        },
        error: function (request, status, error) {
            $('#divCatalogoRecarga').show();

        }
    });
}

function CargarCatalogoFiltrado(elementoA, filtroMenu) {
    if (filtrado == false || filtroMenu) {
        pageIndex = 0; $("#searchText").val("");
    }

    var niveles = (elementoA != undefined) ? $(elementoA).attr("level") : nivel;
    if(nivel != niveles)
    { $("#DivLibros").html(''); pageIndex = 0; nivel = niveles; }
    
    var searchText = ($("#searchText").val()) ? $("#searchText").val() : $(".inputBusqueda").val();
    if (searchText == "" || searchText == undefined) {
        $.ajax({
        type: 'POST',
        url: '/Catalogo/CargarCatalogoFiltrado',
        data: { "level": niveles, "pagesize": pageSize, "pageindex": pageIndex },
        dataType: 'html',
        success: function (result) {
            /*var htotalLibros = $($.parseHTML(result)).filter("#htotalLibros");
            var total = htotalLibros.val();
            $('#h4Librosencontrados').text(total);*/

            $("#DivLibros").append(result);
            pageIndex++;
            filtrado = true;
        },
        beforeSend: function () {
            if(pageIndex == 0)
            {   $("#DivLibros").html('');}
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
    else { 
        $.ajax({
            type: 'POST',
            url: '/Catalogo/BuscarPorTitulo',
            data: { "searchText": searchText, "pagesize": pageSize, "pageindex": pageIndex },
            dataType: 'html',
            success: function (result) {
                /*var htotalLibros = $($.parseHTML(result)).filter("#htotalLibros");
                var total = htotalLibros.val();
                $('#h4Librosencontrados').text(total);*/

                $("#DivLibros").append(result);
                pageIndex++;
                filtrado = true;
            },
            beforeSend: function () {
                if (pageIndex == 0)
                { $("#DivLibros").html(''); }
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
}

function onSubmitFeedbackBegin(context) {
     pageIndex = 1; $(window).scrollTop(0);
 }

function onSuccess(context) {    
    var searchText = ($("#searchText").val()) ? $("#searchText").val() : $(".inputBusqueda").val();
    if (searchText == "") 
        filtrado = false;
    else
        filtrado = true;
}
 

function ListarPorTipo(tipo, fromTab) {

    if (fromTab)
    { $("#DivLibros").html(''); pageIndex = 0; $("#searchText").val(""); $(".inputBusqueda").val(""); }
    if(tipo == undefined) tipo = filtro
    $.ajax({
        type: 'POST',
        url: '/Catalogo/ListarPorTipo',
        data: { "Tipo": tipo, "pageindex": pageIndex, "pagesize": pageSize },
        dataType: 'html',
        success: function (result) {
            $("#DivLibros").append(result);
            pageIndex++;
            
            filtrado = true;
        },
        beforeSend: function () {
            $("#progress").show();
            $('#divCatalogoRecarga').hide();
        },
        complete: function () {
            $("#progress").hide();
            filtro = tipo;
        },
        error: function (request, textStatus, error) {
            if (request.readyState == 4) {
                // HTTP error (can be checked by XMLHttpRequest.status and XMLHttpRequest.statusText)
                alert("ha ocurrido algo. Intenta de nuevo. " + request.responseText + error + " \nStatusText: " + textStatus);
                $('#divCatalogoRecarga').show();

            }
            else if (request.readyState == 0) {
                // Network error (i.e. connection refused, access denied due to CORS, etc.)
                //alert("Parece que has perdido la conexion. Intenta de nuevo. " + request.responseText + error + " \nStatusText: " + textStatus);
                $('#divCatalogoRecarga').show();
            }
            else {
                // something weird is happening
            }
        }
         
    });
}


function ListarTodos() {

    $("#DivLibros").html('');
    $("#searchText").val("");
    pageIndex = 0;
    filtrado = false;
    CargarCatalogo();

 }

function recargarMenuLeft() {

    $.ajax({
        type: 'POST',
        url: '/Catalogo/recargarMenuLeft',
         dataType: 'html',
         success: function (result) {

            $("#divMenuLeft").html('');
            $("#divMenuLeft").append(result);
         },
        beforeSend: function () {
            $("#divItemRecarga").hide();
            $("#progressMenuGif").show();
            
        },
        complete: function () {
            $("#progressMenuGif").hide();
        },
        error: function (request, status, error) {
            $("#divMenuLeft").append("ha ocurrido algo. Intenta de nuevo. ");
            $("#divItemRecarga").show();
        }
    });
}