
document.body.onload = function (event) {
    document.getElementsByTagName("loader-element")[0].remove();

}; 

class LoaderElement extends HTMLElement {
    constructor(){
        super();
        this.IsLoaded = false;
        this.loadRequested = false;
    }
    connectedCallback() {
        setTimeout(function(){
            if (!this.loadRequested) {

                var loadscreen = document.getElementById("loadscreen");
                loadscreen.style.top = "0px";
                loadscreen.style.left = "0px";
                loadscreen.style.zIndex = 1;
                loadscreen.style.position = "fixed";
                loadscreen.style.height = "100%";
                loadscreen.style.width = "100%";
                document.body.style.overflow = "hidden";
                var link = document.getElementById("links");
                var script = document.getElementById("scripts");
                document.head.appendChild(link);
                document.body.appendChild(script);
                link.innerHTML = ""; 
                script.innerHTML = ""; 
                this.loadRequested = true;
                
                 
            }
            
        });

      }

}
customElements.define("loader-element", LoaderElement);

