$("#siguiente").click(function (e) {
    e.preventDefault();
    var url = '/gestion_check_in/M05_VerBoardingPass';
    var method = 'GET';
    var data = '';

    $.ajax(
        {
            url: url,
            type: method,
            data: data,
            success: function (data, textStatus, jqXHR) {

                $("#contenido").empty();
                $("#contenido").append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
});

$("#maleta2tb").css("display", "none");
$("#maleta2lbl").css("display", "none");
$("#maleta3tb").css("display", "none");
$("#maleta3lbl").css("display", "none");



function maletasOnChange(sel) {


    if (sel.value == "uno") {
        $("#maleta1tb").css("display", "block");
        $("#maleta1lbl").css("display", "block");
        $("#maleta2tb").css("display", "none");
        $("#maleta2lbl").css("display", "none");
        $("#maleta3tb").css("display", "none");
        $("#maleta3lbl").css("display", "none");

    } else if (sel.value == "dos") {
        $("#maleta2tb").css("display", "block");
        $("#maleta2lbl").css("display", "block");
        $("#maleta3tb").css("display", "none");
        $("#maleta3lbl").css("display", "none");

    } else if (sel.value == "tres") {

        $("#maleta2tb").css("display", "block");
        $("#maleta2lbl").css("display", "block");
        $("#maleta3tb").css("display", "block");
        $("#maleta3lbl").css("display", "block");
    }
}