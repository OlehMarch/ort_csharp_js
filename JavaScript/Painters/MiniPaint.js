var canvas = document.getElementById("canvas");
var context = canvas.getContext("2d");
var isMouseDown = false;
var mouseX = 0;
var mouseY = 0;

canvas.setAttribute("height", document.documentElement.clientHeight - 130);
canvas.setAttribute("width", document.documentElement.clientWidth - 20);

context.strokeStyle = "#000000";
context.lineWidth = 1;

function SetWidth(width){
    context.lineWidth = width;
}

function SetColor(color) {
    context.strokeStyle = color;
}

function SaveFile() {
    var result = prompt("Set image name", "image");
    var path = result + ".png";
    canvas.toBlob(function (blob) { saveAs(blob, path); });
}

function LoadFile() {
    var path = prompt("Set image path", "image.png");
    ImageCreation(path);
}

function ImageCreation(path)
{
    var image = new Image();
    image.src = path;
    image.onload = function () {
        context.drawImage(image, 0, 0, image.width, image.height);
    }
}

// when the user presses their mouse down on the canvas.
canvas.addEventListener("mousedown", function (evt) {
    isMouseDown = true;

    mouseX = evt.offsetX;
    mouseY = evt.offsetY;

    context.beginPath();
    context.moveTo(mouseX, mouseY);
});

// when the user lifts their mouse up anywhere on the screen.
window.addEventListener("mouseup", function (evt) {
    isMouseDown = false;
});

// as the user moves the mouse around.
canvas.addEventListener("mousemove", function (evt) {
    if (isMouseDown) {
        mouseX = evt.offsetX;
        mouseY = evt.offsetY;

        context.lineTo(mouseX, mouseY);
        context.stroke();
    }
});