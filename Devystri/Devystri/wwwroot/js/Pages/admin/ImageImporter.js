function previewImage(el, previewID) {
    var file = el.files;

    if (file.length > 0) {
        var fileReader = new FileReader();

        fileReader.onload = function (event) {
            document.getElementById(previewID).setAttribute("src", event.target.result);
        };

        fileReader.readAsDataURL(file[0]);
    }
}
