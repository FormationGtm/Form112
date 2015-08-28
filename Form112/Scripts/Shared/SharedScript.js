$(function(){
    $(".destination-panel").mouseenter(function () {
        $(this).addClass('shadow');//.css({ "margin-bottom": "5px" });
    });
    $(".destination-panel").mouseleave(function () {
        $(this).removeClass('shadow');//.css({ "margin-bottom": "10px" });
    });

    $(".destination-panel").click(function () {
        var idClicked = this.id;
        console.log(idClicked);
        $("#idCroisiereChoice").val(idClicked);
        console.log( $("#idCroisiereChoice").val());
        $("#idFormDestination").submit();
    });
});