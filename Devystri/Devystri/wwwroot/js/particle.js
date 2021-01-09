class Particle{
    constructor(x, y, vx, vy, size, img){
        this.object = img
        this.x = x;
        this.y = y;
        this.scale = ( (1 - (Math.random()*2)) * 0.004 * size + size );
        this.width = this.object.naturalWidth * this.scale;
        this.height = this.object.naturalHeight * this.scale;
        this.lastVx = 0;
        this.lastVy = 0;
        this.vx = vx;
        this.vy = Math.random() * vy +0.5;
        this.size = size;
        this.color = '#ffffff';
        this.object.data = this.color;
    }
    update(){
        this.height = this.height * this.scale;
        this.width = this.width * this.scale;
        this.y -= this.vy;
        this.x += this.vx;
    }
    draw(ctx){
        ctx.drawImage(this.object, this.x, this.y, this.width, this.height )
    }
}
class Particles{
   
    constructor(particlesSrc, amout, speed, size){
        this.particlesSrc = particlesSrc;
        this.particles = [];
        this.particlesImg = [];
        this.speed = speed;
        this.size = size;
        this.amount = amout;
        this.rest = 0;
        this.render();
        this.loadParticles();
        this.particlesImg[this.particlesImg.length-1].onload = ()=>{
            this.create();
            this.draw = ()=>{
                this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);
                for(var i = 0; i < this.particles.length; i++){
                    if(this.particles[i] != 0){
                        this.particles[i].update();
                        this.particles[i].draw(this.ctx);
                        if(this.particles[i].y < 0 - this.particles[i].height || this.particles[i].height > window.innerHeight || this.particles[i].height < window.innerHeight*0.001){
                            this.particles[i] = 0; 
                            this.rest += 1;
                        }
                    }
                    
                }
                if(this.rest >= this.amount*0.85){
                    this.ctx.globalAlpha -= 0.01;
                    if(this.rest > this.amount*0.95){
                        this.clean();
                        return;
                    }
                }
                
                window.requestAnimationFrame(this.draw);
            }
            this.draw();
        }

        
    }
    
    create(){
        for(var i = 0; i < this.amount; i++){
            var x = Math.random() * this.canvas.width;
            var y = this.canvas.height +  Math.random() * 1000;
            var index = Math.floor(Math.random()*(this.particlesImg.length-1));
            var p = new Particle(x, y, 0, this.speed, this.size, this.particlesImg[index])
            this.particles.push(p);
        }
    }
    
    loadParticles(){
        this.particlesSrc.forEach(src => {
            var img = new Image();
            img.src = src;
            this.particlesImg.push(img);
        });
    }
    render(){
        this.canvas = document.createElement('canvas');
        this.canvas.height = window.innerHeight;
        this.canvas.width = window.innerWidth;
        this.canvas.style.position = "fixed";
        this.canvas.style.top = '0px';
        this.canvas.style.left = '0px';
        this.canvas.style.zIndex = 99999
        this.canvas.style.pointerEvents = "none";
     
        document.body.appendChild(this.canvas);
        document.onresize = ()=>{
            this.canvas.height = window.innerHeight;
            this.canvas.width = window.innerWidth;
        }
        this.ctx = this.canvas.getContext("2d");
    }

    clean(){
        this.canvas = null;
        this.particles = [];
        this.particlesImg = [];
        this.rest = 0;
    }

    
}
//var src = ["balloon/Red.svg", "balloon/Blue.svg", "balloon/Green.svg", "balloon/Pink.svg", "balloon/Yellow.svg"];
//var p = new Particles(src, 100, 10, 1); 