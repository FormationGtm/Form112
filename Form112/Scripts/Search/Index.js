$(function () {
   
    $('#idDateDepart').datepicker({
        format: "dd/mm/yyyy",
        todayBtn: "linked",
        language: "fr",
        autoclose: true,
        todayHighlight: true,
        endDate: "+1y +6m",
        startDate: "+1d"
        
    });
   
    $("#idPays").change(loadPort);
    $("#idPrix").change(getTranchePrix);
    $("#idDuree").change(getDuree);
});


function loadPort() {
    var idPays = $("#idPays").val();
    var str = '<option value="" selected>Choisir le port</option>';
    $.getJSON('/Search/GetJSONPort/' + idPays, function (data) {
        $.each(data, function (idx, port) {
            str += '<option value="' + port.IdPort + '">' + port.Nom + "</option>";
        })
        $("#idPort").html(str);
    });
}

