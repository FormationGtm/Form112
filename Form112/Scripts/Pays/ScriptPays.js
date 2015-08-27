$(function () {
    var idPort = $('#idPortSelector').val();
    $.getJSON('/Home/ListePortDestinations/' + idPort, function (data) {
        var count = 0;
        $.each(data, function (idx, crs) {
            var currency = "* <span class=\"currency-fr\">€</span>";
           
            var id = "wrapperDest" + count;
            $("#idTemplateCroisiere").clone().appendTo("#placeHolderCroisiere").attr("id",id);
            $("#id1").attr("id", crs.IdCroisiere);
            $("#id2").attr("src", "~/Uploads/Croisieres/" + crs.photo).removeAttr("id");
            $("#id3").append(crs.Ports.Pays.Nom).removeAttr("id");
            $("#id4").append(crs.Prix + currency).removeAttr("id");
            $("#id5").append(crs.Promos.Reduction).removeAttr("id");

            $(id).removeAttr("visibility");
            count++;
        });

    });
})