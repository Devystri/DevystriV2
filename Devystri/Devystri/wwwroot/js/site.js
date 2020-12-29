//Size of nav fold
var SizeOfNavFold = 71
//Size of nav unfold
var SizeOfNavUnfold = 200

$("#menu-btn").click(function () {
    if (!$('#header').is(':animated')) {
        if ($('input[name=menu-btn]').is(':checked')) {
            //Unfold the nav
            $('#header').animate({ height: SizeOfNavUnfold });
        } else {
            //Fold the nav
            $('#header').animate({ height: SizeOfNavFold });
        }
    }
});


//// NAV Animation

//// Size of nav in load
//var heightNav = 71;
//// Size of nav fold
//var navFold = 71;
//// Size of nav Unfold
//var navUnfold = 350;
//// With limit fold system
//var withLimit = 1050;

//var navUnfolded = true;

//function FlodOrUnfold() {
//    if (!$('#header').is(':animated')) {
//        if (navUnfolded) {
//            // unfolds the nav
//            $('#header').animate({ height: navUnfold });
//            $('#nav-unfold-button').css("display", "none");
//            $('#nav-close-button').css("display", "block");
//            heightNav = navUnfold;
//        }
//        else {
//            // folds the nav
//            $('#header').animate({ height: navFold });
//            $('#nav-close-button').css("display", "none");
//            $('#nav-unfold-button').css("display", "block");
//            heightNav = navFold;
//        }
//        navUnfolded = !navUnfolded;
//    }
//}

//$(function () {
//    $('#head').css({ "height": heightNav });
//    $("#menu-btn").click(FlodOrUnfold);

//    $(window).resize(function () {
//        if (window.innerWidth > withLimit) {
//            $('.nav-button').hide();
//            if (!navUnfolded) {
//                FlodOrUnfold()
//            }
//        }
//        else if (window.innerWidth <= withLimit) {
//            $('.nav-button').show();
//            if (navUnfolded) {
//                $('#nav-unfold-button').css("display", "block");
//                $('#nav-close-button').css("display", "none");

//            } else {
//                $('#nav-unfold-button').css("display", "none");
//                $('#nav-close-button').css("display", "block");
//            }

//        }

//        $(function () {
//            if ($('input[name=menu-btn]').is(':checked')) {
//                alert("jQuery c'est super");
//            } else {
//                alert("jQuery c'est autre chose");
//            }
//        });

