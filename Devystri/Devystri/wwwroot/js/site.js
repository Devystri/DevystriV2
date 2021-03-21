//Padding B of nav fold
var SizeOfNavFold = 58
//Padding B of nav unfold
var SizeOfNavUnfold = document.getElementById("nav-location").offsetHeight + 110

function menuStateChanhed() {
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
$(window).resize(function () {
    if ((window.innerWidth >= 1000) && ($('input[name=menu-btn]').is(':checked'))) {
        $('#header').animate({ height: SizeOfNavUnfold });
        $("#menu-btn").prop("checked", false);
    }
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

