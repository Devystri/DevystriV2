﻿//Animation library
document.onreadystatechange = function () {
    if (document.readyState === 'complete') {
        AOS.init();
    }
}

document.querySelectorAll('img')
    .forEach((img) =>
        img.addEventListener('load', () =>
            AOS.refresh()
        )
    );


//Padding B of nav fold
var SizeOfNavFold = 71

function menuStateChanhed() {
    //Padding B of nav unfold
    var SizeOfNavUnfold = document.getElementById("nav-location").offsetHeight + 110
    if (!$('#header').is(':animated')) {
        if ($('input[name=menu-btn]').is(':checked')) {
            //Unfold the nav
            $('#header').animate({ height: SizeOfNavUnfold });
        } else {
            //Fold the nav
            $('#header').animate({ height: SizeOfNavFold });
        }
    }
}
// Closes the nav when the width of the page is greater than

$(function () {
    $(window).resize(function () {
        if ((window.innerWidth >= 1000) && ($('input[name=menu-btn]').is(':checked'))) {
            $('#header').animate({ height: SizeOfNavFold });
            $("#menu-btn").prop("checked", false);
        }
    });
});


// Scroll main page

$(function () {
    $(".down-arrow, .légal-button").on("click", function (event) {
        event.preventDefault();
        var hash = this.hash;
        $('body,html').animate({ scrollTop: $(hash).offset().top }, 900, function () { window.location.hash = hash; })
    });

})

divInfo = document.getElementById('#user-admin-box')

$('#user-admin').click(function () {
    if ($("#user-admin-box").is(":hidden")) {
        $("#user-admin-box").css("display", "flex");
    }
    else {
        $("#user-admin-box").css("display", "none");
    }
});
$('main').click(function () {
    if ($("#user-admin-box").is(":visible")) {
        $("#user-admin-box").css("display", "none");
    }
});


// Scroll for header


$(function () {
    var headerSize = $('#header').height()

    $(window).scroll(function () {
        if ($(window).scrollTop() <= 300 && $('input[name=menu-btn]').is(':unchecked')) {
            var headerSize = $('#header').height()
            //$('#header').animate({ height: sizeOfSmallHeader }, 200);
            $("#header").css("height", 71 - document.documentElement.scrollTop / 11);
            $("#header").css("fontSize", headerSize / 4);
        }
    });
});