$(function () {
    var idPort = $('#idPortSelector').val();
    $.getJSON('/Home/ListePortDestinations/' + idPort, function (data) {
        $.each(data, function (idx, crs) {
            var currency = "* <span class=\"currency-fr\">€</span>";
            $("#idTemplateCroisiere").clone().appendTo("#placeHolderCroisiere").removeAttr("id");
            $("#id1").attr("id", crs.idCrs);
            $("#id2").attr("src", "").removeAttr("id");
            $("#id3").html(crs.PaysName).removeAttr("id");
            $("#id4").html(crs.Prix + currency).removeAttr("id");
            $("#id5").html("- " + crs.Reduc + " %").removeAttr("id");
        });
        manageShadow();
    });

    $("#idPortSelector").change(function () {
        $("#placeHolderCroisiere").empty();
        var idPort = $('#idPortSelector').val();
        $.getJSON('/Home/ListePortDestinations/' + idPort, function (data) {
            var count = 1;
            $.each(data, function (idx, crs) {
                var currency = "* <span class=\"currency-fr\">€</span>";
                $("#idTemplateCroisiere").clone().appendTo("#placeHolderCroisiere").removeAttr("id");
                $("#id1").attr("id", crs.idCrs);
                $("#id2").attr("src", "").removeAttr("id");
                $("#id3").html(crs.PaysName).removeAttr("id");
                $("#id4").html(crs.Prix + currency).removeAttr("id");
                $("#id5").html("- " + crs.Reduc + " %").removeAttr("id");
            });
            manageShadow();
        });
    });
})
