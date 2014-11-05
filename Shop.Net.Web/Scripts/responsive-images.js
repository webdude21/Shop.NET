var alignGallery = function () {
    var $galleryContainer = $('#thumbnails');
    $galleryContainer.masonry({
        itemSelector: '.item'
    });

    $galleryContainer.find('img').load(function() {
        $galleryContainer.masonry();
    });
};

alignGallery();