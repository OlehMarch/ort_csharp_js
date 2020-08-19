var canvas = document.getElementById("svg");
var path = document.getElementById("path");
var isMouseDown = false;
var mouseX = 0;
var mouseY = 0;

function SetWidth(width) {
    path.setAttribute("stroke-width", width);
}

function SetColor(color) {
    path.setAttribute("stroke", color);
}

function SaveFile() {
    var result = prompt("Set image name", "image");
    var imgName = result + ".svg";
    saveAs(new Blob([canvas.innerHTML], { type: "application/svg+xml" }), imgName)
}

document.getElementById('Load').addEventListener('change', readSingleFile, false);
function readSingleFile(evt) {
    var f = evt.target.files[0];

    if (f) {
        var r = new FileReader();
        r.onload = function (e) {
            var contents = e.target.result;
            canvas.innerHTML = contents;
        }
        r.readAsText(f);
    } else {
        alert("Failed to load file");
    }
}

canvas.addEventListener("mousedown", function (evt) {
	isMouseDown = true;

	mouseX = evt.offsetX;
	mouseY = evt.offsetY;

	path.setAttribute("d", path.getAttribute("d") + "M" + mouseX + "," + mouseY);
});
window.addEventListener("mouseup", function (evt) {
	isMouseDown = false;
});
canvas.addEventListener("mousemove", function (evt) {
	if (isMouseDown) {
		mouseX = evt.offsetX;
		mouseY = evt.offsetY;

		path.setAttribute("d", path.getAttribute("d") + "L" + mouseX + "," + mouseY);
	}
});