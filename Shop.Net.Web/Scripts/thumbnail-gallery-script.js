var initGallery = function() {
    var $selectedImage = $("#selected-image");
    var $imageGallery = $(".image-gallery");
    var $thumbs = $imageGallery.find(".gallery-thumbnail");

    var resetSelected = function () {
        $thumbs.removeClass("selected");
    }

    var selectImage = function ($image) {
        resetSelected();
        $selectedImage.attr("src", $image.attr("src"));
        $selectedImage.attr("alt", $image.attr("alt"));
        $image.addClass("selected");
    }

    $imageGallery.on("click", ".gallery-thumbnail", function (ev) {
        var $this = $(this);
        selectImage($this);
    });

    selectImage($thumbs.first());

}

$(document).ready(function () {
    initGallery();
});