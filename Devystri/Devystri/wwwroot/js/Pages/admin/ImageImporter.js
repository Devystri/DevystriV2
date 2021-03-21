

// Function for logo image

function previewLogo() {
    var file = document.getElementById("fileLogo").files;
    if (file.length > 0) {
        var fileReader = new FileReader();

        fileReader.onload = function (event) {
            document.getElementById("previewLogoAdd").setAttribute("src", event.target.result);
        };

        fileReader.readAsDataURL(file[0]);
    }
}

// Function for "image de la page application"

function previewImageApp() {
    var file = document.getElementById("file").files;
    if (file.length > 0) {
        var fileReader = new FileReader();

        fileReader.onload = function (event) {
            document.getElementById("previewApp").setAttribute("src", event.target.result);
        };

        fileReader.readAsDataURL(file[0]);
    }
}

// Function for "Images qui entoure la fiche technique de l'application"

function previewImage() {
    var file = document.getElementById("file1").files;
    if (file.length > 0) {
        var fileReader = new FileReader();

        fileReader.onload = function (event) {
            document.getElementById("preview").setAttribute("src", event.target.result);
        };

        fileReader.readAsDataURL(file[0]);
    }
}

function previewImage2() {
    var file = document.getElementById("file2").files;
    if (file.length > 0) {
        var fileReader = new FileReader();

        fileReader.onload = function (event) {
            document.getElementById("preview2").setAttribute("src", event.target.result);
        };

        fileReader.readAsDataURL(file[0]);
    }
}