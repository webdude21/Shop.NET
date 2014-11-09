$(document).ready(function () {
    $('#add-input-file').on('click', function () {
        var form = $('#form-upload');

        var count = form.find('input[type="file"]').length;

        var $divContainer = $('<div class="form-group">');
        var $inputContainer = $('<div class="col-md-10">');
        var $label = $('<label for="file_' + count + '" class="control-label col-md-2">Filename: </label>');
        var inputTypeFile = $('<input class="form-control" type="file" name="file' + count + '" id="file_' + count + '" />');

        $inputContainer.append(inputTypeFile);
        $divContainer.append($label);
        $inputContainer.insertAfter($label);

        form.append($divContainer);
    });
});