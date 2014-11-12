$("document").on("load", function(e) {
    var $counter = $("order-count");
    $.get("ajax/test.html", function (data) {
        $(".result").html(data);
        alert("Load was performed.");
    });
})