var pageSize = 10;
var pageIndex = 0;
var filtrado = false;
var nivel;

function GetData() {
    if (filtrado == false)
        CargarCatalogo();
    else
        CargarCatalogoFiltrado();

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
        },
        complete: function () {
            $("#progress").hide();
        },
        error: function (request, status, error) {
            alert("ha ocurrido algo. Intenta de nuevo. " + request.responseText + error);
        }
    });
}


function CargarCatalogoFiltrado(elementoA, filtroMenu) {
    if (filtrado == false || filtroMenu) {
        pageIndex = 0; $("#searchText").val("");
    }

    var niveles = (elementoA != undefined) ? $(elementoA).attr("level") : nivel;
    if (nivel != niveles)
    { $("#DivLibros").html(''); pageIndex = 0; nivel = niveles; }

    var searchText = $("#searchText").val();
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
    var searchText = $("#searchText").val();
    if (searchText == "")
        filtrado = false;
    else
        filtrado = true;
}
