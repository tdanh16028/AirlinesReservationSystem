$("#btnlogin").click(function () {
    var url = "/UserAccount/LoginPartial";
    $(".modal-body").load(url, function () {
        $(".modal-body #func-login").removeClass("mt-5 mb-5 pt-5");
        $(".modal-body #func-login-col").removeClass("col-md-4 card");
        $(".modal-body  nav").remove();
        $(".modal-body  footer").remove();
        $(".modal-body  hr").remove();
        $("#exampleModal").modal();
    });
});
$(function () {
    $('#exampleModal').on('hidden.bs.modal', function (e) {
        console.log("Modal hidden");
        $(".modal-body").html("");
    });
});
