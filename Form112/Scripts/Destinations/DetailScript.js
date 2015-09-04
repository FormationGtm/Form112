$(function () {
    $("#idBouttonCommentaire").click(function () {
        $("#idFormCommentaire").submit();
    });

    $(".reply-arrow").click(function () {
        $("#idReplyCommentaire").val($(this).parent().parent().parent().attr("id"));
        console.log($("#idReplyCommentaire").val());
    })
})