
document.body.onload = function (event) {
    var loader = document.getElementsByTagName("loader-element")[0];
    loader.loaded();
    

}; 

class LoaderElement extends HTMLElement {
    constructor() {
        document.body.style.overflow = "hidden";
        super();
        this.IsLoaded = false;
        this.loadRequested = false;
    }
    loaded() {
        this.style.display = "none";
        var link = document.getElementById("links");
        var script = document.getElementById("scripts");
        document.head.innerHTML += link.innerHTML;
        //document.body.innerHTML += script.innerHTML;
        link.innerHTML = "";
       // script.innerHTML = "";
        document.body.style.overflow = "auto";
        this.loadRequested = true;
    }
    connectedCallback() {
        setTimeout(()=> {
            if (!this.inited) {

                var loadscreen = document.getElementById("loadscreen");
                if (!loadscreen)
                    return;
                loadscreen.style.top = "0px";
                loadscreen.style.left = "0px";
                loadscreen.style.zIndex = 999;
                loadscreen.style.position = "fixed";
                loadscreen.style.height = "100%";
                loadscreen.style.width = "100%";
                this.inited = true;
                clearTimeout();
            }
         

        }, 100);

      }

}
customElements.define("loader-element", LoaderElement);

