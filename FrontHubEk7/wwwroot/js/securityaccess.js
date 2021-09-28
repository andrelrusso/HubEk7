
function Pesquisar(url, paginaAtual) {
    var rassId = $('#Filtro_RaasID').val();
    var stsClientId = $('#Filtro_STSClientId').val();
    var endPoint = $('#Filtro_Endpoint').val();

   // if (id == '') id = 0;

    $.get(url, { rassId: rassId, stsClientId: stsClientId, endPoint: endPoint })
        .done(function (data) {
            $('#gridItems').html(data);
        }).fail(function (xhr, error, status) {
            var msg = JSON.parse(xhr.responseText);
            popupErro('SQG', msg.Message);
        });
}  