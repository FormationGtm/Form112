$(function () {
   
    $('#idDateDepart').datepicker({
        format: "dd/mm/yyyy",
        todayBtn: "linked",
        language: "fr",
        autoclose: true,
        todayHighlight: true,
        endData: "-1d"
    });
   
    $("#idPays").change(loadPort);
    $("#idPrix").change(getTranchePrix);
    $("#idDuree").change(getDuree);
});


function loadPort() {
    var idPays = $("#idPays").val();
    var str = "";
    $.getJSON('/Search/GetJSONPort/' + idPays, function (data) {
        $.each(data, function (idx, port) {
            str += '<option value="' + port.IdPort + '">' + port.Nom + "</option>";
        })
        $("#idPort").html(str);
    });
}

function getTranchePrix() {
    var idPrix = $("#idPrix").val();
    var prixMini;
    var prixMaxi;
    switch (idPrix) {
        case "1":
            prixMini = 0;
            prixMaxi = 1000;
            break;
        case "2":
            prixMini = 1000;
            prixMaxi = 3000;
            break;
        case "3":
            prixMini = 3000;
            prixMaxi = 5000;
            break;
        case "4":
            prixMini = 5000;
            break;
    }
    $("#PrixMini").val(prixMini);
    $("#PrixMaxi").val(prixMaxi);
}

function getDuree() {
    var idDuree = $("#idDuree").val();
    var dureeMini;
    var dureeMaxi;
    switch (idDuree) {
        case "1":
            dureeMini = 1;
            dureeMaxi = 4;
            break;
        case "2":
            dureeMini = 4;
            dureeMaxi = 7;
            break;
        case "3":
            dureeMini = 7;
            dureeMaxi = 15;
            break;
        case "4":
            dureeMini = 15;
            break;
    }
    $("#DureeMini").val(dureeMini);
    $("#DureeMaxi").val(dureeMaxi);
}