/*
    NEED:
    OrbitControls
    three.js
    STLoader
    Made by Timoz Dimitri
*/

function getOffset(el) {
    var _x = 0;
    var _y = 0;
    while (el && !isNaN(el.offsetLeft) && !isNaN(el.offsetTop)) {
        _x += el.offsetLeft - el.scrollLeft;
        _y += el.offsetTop - el.scrollTop;
        el = el.offsetParent;
    }
    return { top: _y, left: _x };
}


class Visualisator3D extends HTMLElement {
    constructor(){
        super();      
    }

    updateZoom (){
        var min = (this.clientHeight > this.clientWidth)? (this.clientWidth) : this.clientHeight;
        this.camera.position.z = (this.zoom*100/min)*10;
    }

    init(){
        this.maxAngX = 3/5;
        this.maxAngY = 3.14/5;   

        var renderer = new THREE.WebGLRenderer();
        renderer.setSize(1000, 1000);
        renderer.setPixelRatio(window.devicePixelRatio);
        renderer.outputEncoding = THREE.sRGBEncoding;
        renderer.setSize(this.clientWidth, this.clientHeight);
        renderer.setClearColor(new THREE.Color(this.backgroundColor), 1.0);

        this.camera = new THREE.PerspectiveCamera(50, this.clientWidth / this.clientHeight, 0.1, 1000)
     
        this.updateZoom();
        this.appendChild(renderer.domElement);

        const scene = new THREE.Scene();
        scene.background = new THREE.Color(this.backgroundColor);

        const ambientLight = new THREE.AmbientLight( 0xffffff, 0.8);
        ambientLight.castShadow = true;
        scene.add( ambientLight );

        const dirLight = new THREE.DirectionalLight( 0xefffff, 0.5  );
        dirLight.position.set( 0, 1, 0 );
   
        scene.add( dirLight );

        const gltfLoader = new THREE.GLTFLoader();
        gltfLoader.load(this.src, (gltf) => {
            this.mesh = gltf.scene;
     
            scene.add(this.mesh);
        });

        var render = () => {   
            requestAnimationFrame(render);
            if(!this.mesh)
                return;
            this.mesh.rotation.y += 3.14/600;
          
            renderer.render(scene, this.camera);
        }

        window.addEventListener('resize', () => {
            renderer.setSize(this.clientWidth, this.clientHeight );
            this.camera.aspect = this.clientWidth / this.clientHeight;
            this.updateZoom();
            this.camera.updateProjectionMatrix();   
        });

        window.addEventListener('mousemove', (mouse)=>{
            if(!this.mesh)
                return;
            //var xR = mouse.pageX / window.innerWidth * 2;
            var yR = mouse.clientY / window.innerHeight * 2;
            
            //this.mesh.rotation.y = (xR - 1) * this.maxAngX;
            this.mesh.rotation.x = (yR - 1) * this.maxAngY;
            
        });
        render();
    }

    connectedCallback() {
        this.style.display = "block";
        this.color = this.getAttribute('color') || 0x000000,
        this.zoom = this.getAttribute('zoom') || 20,
        this.src = this.getAttribute("src") || undefined
        this.backgroundColor = this.getAttribute("background-color") || undefined;
        if(this.src == undefined)
            console.error("Error: GLB source not specified.");
        this.init();
    }   
    
}

customElements.define("object-viewer", Visualisator3D);