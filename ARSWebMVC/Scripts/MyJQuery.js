$("#btnLogin").click(function () {
    var url = "/UserAccount/LoginPartial";
    $("#exampleModal .modal-content").load(url, function () {
        $("#exampleModal .modal-content > form").removeClass();
        $("#exampleModal .modal-content > form").addClass("p-3");
        //$(".modal-body #func-login").removeClass("mt-5 mb-5 pt-5");
        //$(".modal-body #func-login-col").removeClass("col-md-4 card");
        //$(".modal-body  nav").remove();
        //$(".modal-body  footer").remove();
        //$(".modal-body  hr").remove();
        $("#exampleModal").modal();
    });
});
$(function () {
    $('#exampleModal').on('hidden.bs.modal', function (e) {
        console.log("Modal hidden");
        $("#exampleModal .modal-content").html("");
    });
});
