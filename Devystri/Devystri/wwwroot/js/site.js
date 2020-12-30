//Padding B of nav fold
var SizeOfNavFold = 0
//Padding B of nav unfold
var SizeOfNavUnfold = 137

function menuStateChanhed() {
    if (!$('#header').is(':animated')) {
        if ($('input[name=menu-btn]').is(':checked')) {
            //Unfold the nav
            $('#header').animate({ paddingBottom: SizeOfNavUnfold });
        } else {
            //Fold the nav
            $('#header').animate({ paddingBottom: SizeOfNavFold });
        }
    }
}
// Closes the nav when the width of the page is greater than 
$(window).resize(function () {
    if ((window.innerWidth >= 1000) && ($('input[name=menu-btn]').is(':checked'))) {
        $('#header').animate({ paddingBottom: SizeOfNavFold });
        $("#menu-btn").prop("checked", false);
    }
});



