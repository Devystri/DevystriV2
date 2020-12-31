
class DeviceViewer extends HTMLElement {
    constructor(){
        super();
    }

    GetFormat(){
        var imageReg = /.(gif|jpg|jpeg|tiff|png)$/i;
        var videoReg = /.(mp4|mkv|gif|avi|m4v)$/i;
        var src = this.src.toLowerCase();

        
        if(imageReg.test(src)){
            this.isPicture = true;
        }else if(videoReg.test(src)){
            this.isVideo = true;
        }
    }

    macCreate(){
        if(this.isVideo){
            var video = document.createElement("video");
            video.src = this.src;
            video.autoplay = true;
            video.loop = true;
            video.muted = true;
            this.macStyleSetup(video);
        }else if(this.isPicture){
            var img = document.createElement("img");
            img.src = this.src;
            img.style.height = "auto !important";
            this.macStyleSetup(img);
        }
        
    }

    macStyleSetup(el){
       
        var div = document.createElement("div");
    
        this.style.backgroundImage = "url(" + this.macSrc + ")";
        this.style.backgroundPosition = "center";
        this.style.backgroundRepeat = "no-repeat";
        this.style.position = "relative";
        this.style.backgroundSize = "contain";
        
        el.style.position = "absolute";
        el.style.top = "50%";
        el.style.width = "76.8%";
        
        el.style.left = "50%";
        el.style.transform = "translate(-49.744%, -52.5%)";
        
       

        this.append(el);

      
    }
    render() {
        if(this.mac)
            this.macCreate();
    }
    connectedCallback() {
        this.style.display = "block";
        this.src = this.getAttribute("src") || undefined
        this.macSrc = this.getAttribute("macbook-src") || undefined
        this.iphoneSrc = this.getAttribute("iphone-src") || undefined

        if(this.src == undefined)
            console.error("Error: source not specified.");
        if(!this.macSrc && !this.iphoneSrc )
            console.error("Error: frame source not specified.");
        if(!this.macSrc)
            this.mac = false;
        else
            this.mac = true;
        this.GetFormat();
        this.render();
    }

}
customElements.define("device-viewer", DeviceViewer);

