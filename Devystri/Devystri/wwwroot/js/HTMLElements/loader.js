
document.body.onload = function (event) {
    var loader = document.getElementsByTagName("loader-element")[0];
    loader.loaded();
    

}; 

class LoaderElement extends HTMLElement {
    constructor(){
        super();
        this.IsLoaded = false;
        this.loadRequested = false;
    }
    loaded() {
        this.style.display = "none";
        var link = document.getElementById("links");
        var script = document.getElementById("scripts");
        document.head.innerHTML += link.innerHTML;
        document.body.innerHTML += script.innerHTML;
        link.innerHTML = "";
        script.innerHTML = "";
        this.loadRequested = true;
    }
    connectedCallback() {
        setTimeout(function(){
            if (!this.loadRequested) {

                var loadscreen = document.getElementById("loadscreen");
                loadscreen.style.top = "0px";
                loadscreen.style.left = "0px";
                loadscreen.style.zIndex = 999;
                loadscreen.style.position = "fixed";
                loadscreen.style.height = "100%";
                loadscreen.style.width = "100%";
                document.body.style.overflow = "hidden";
         
                 
            }
            
        });

      }

}
customElements.define("loader-element", LoaderElement);

