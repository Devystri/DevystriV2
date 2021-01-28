var html = `
<div id="popup-comfirm" style="display: block;">
    <div id="pop-up"">
        <p id="confirm-title">Êtes-vous sûr de votre choix ?</p>
        <p id="confirm-text">Toute action confirmée ne pourra pas être annulée !</p>
        <div id="button">
            <button id="cancel">Annuler</button>
            <button id="confirm">Confirmer</button>
        </div>
    </div>
</div>
`
var css = `
*{
    padding: 0;
    margin: 0px;
}
#popup-comfirm{
    display: block;
    position: fixed;
    z-index: 2;
    top: 0px;
    right: 0px;
    height: 100%;
    width: 100%;
    backdrop-filter: blur(0.5em);
    background-color: rgba(0, 0, 0, 0.65);

}

#pop-up{
    display: block;
    position: fixed;
    top: 30%;
    left: 50%;
    transform: translate(-50%, -50%);
    background-color: var(--white-background);
    width: 30%;
    min-width: 500px;
    height: 200px;
    border-radius: 20px;
    
}

p{
    padding-top: 15px;
    padding-left: 20px;
    font-family: Helvetica, Arial, sans-serif;
    color: var(--dark-blue);
}

#confirm-title{
    font-weight: bold;
    border-bottom: 1px solid #434658;
    padding-bottom: 11px;
    font-size: 17px;
}

#confirm-text{
    height: 34%;
}

button{
    height: 50px;
    min-width: 100px;
    width: 40% ;
    border: none;
    border-radius: 30px ;
    outline: none ;
    margin-left: 10px ;
    margin-right: 10px ;
    font-size: 20px ;
    font-family: 'Roboto', 'Righteous' ;
    font-weight: bold;
    cursor: pointer;
}

#button{
    text-align: center;
    background: var(--dark-blue);;
    padding-top: 10px;
    padding-bottom: 14px;
    border-radius: 0 0 23px 23px;
}

#cancel{
    background-color: #C3CED9;
}


#confirm{
    background-color: #626ED4;
    color: white;
}
`

function popupDelete(){
    $("#popup-comfirm").css("display", "none");
    var div = document.getElementById("popup-content");
    div.remove();
}   

function popup(title, message){
    document.getElementsByTagName("body")[0].innerHTML += "<div id='popup-content'>" + html + "<style>" + css + "</style> </div>";
    $("#confirm-title").text(title);
    $("#confirm-text").text(message);
    $("#popup-comfirm").css("display", "block");
    $("#cancel").click(function (e) { 
        e.preventDefault();
        popupDelete();
        return false;   
        
    });
    $("#confirm").click(function (e) { 
        e.preventDefault();
        popupDelete();
        return true;
    });
}

