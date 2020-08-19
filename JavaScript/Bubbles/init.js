var layer;
var context;
var radius = 20;
var timerId = null;
var bubbleList = null;
var pushPoint = null;

window.onload = function () {
    layer = document.getElementById("layer");
    context = layer.getContext('2d');
    context.lineWidth = 1;
    context.lineStyle = "#880000";

    layer.onmousedown = mouseDown;
    layer.onmouseup = mouseUp;
    layer.onmousemove = mouseMove;

    bubbleList = new BubbleList();
    var timerId = setTimeout(update, 20);
}

function mouseDown(e) {

    pushPoint = new Vector(e.pageX - layer.offsetLeft, e.pageY - layer.offsetTop);
}

function mouseUp(e) {

    var x = e.pageX - layer.offsetLeft, y = e.pageY - layer.offsetTop;
    var bubble = new Bubble(radius, pushPoint, Vector.sub(new Vector(x, y), pushPoint));
    bubbleList.add(bubble);
}

function mouseMove(e) {

}

function update() {
    
    context.clearRect(0, 0, layer.width, layer.height);
    bubbleList.update(context);
    clearTimeout(timerId);
    timerId = setTimeout(update, 20);
}

