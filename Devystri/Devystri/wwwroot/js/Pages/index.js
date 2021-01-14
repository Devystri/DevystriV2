
const scroll = new LocomotiveScroll();

scroll.on('scroll', (args) => {
    // Get all current elements : args.currentElements
    if (typeof args.currentElements['title'] === 'object') {
        let progress = args.currentElements['title'].progress - 0.4;
        let blur = parseInt(progress * 20);
        let el = $("#homepage-big-title")[0];
        el.style = "filter: blur(" + blur + "px);";
        console.log(blur);
     
    }
});
