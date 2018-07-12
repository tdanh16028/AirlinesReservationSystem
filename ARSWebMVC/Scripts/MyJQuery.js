$("#btnlogin").click(function () {
    var url = "/UserAccount/Login";
    $(".modal-body").load(url, function () {
        $(".modal-body .func-login #func-login-col ").removeClass("col-md-4 card mt-5 mb-5");
        $(".modal-body nav , footer , hr  ").remove();
        $("#exampleModal").modal("show");
    });
});