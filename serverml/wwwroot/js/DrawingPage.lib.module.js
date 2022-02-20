var canvas;
var ctx;
var isDrawing = false;

function interopTest() {
    alert("testing");
}

function assignCanvas(canvasElement) {
    canvas = canvasElement;
    canvas.addEventListener("mousedown", beginDrawing);
    canvas.addEventListener("mousemove", draw);
    canvas.addEventListener("mouseup", stopDrawing);
    ctx = canvas.getContext("2d");

}

function initCanvas() {
    canvas.style.background = 'black'
    ctx.lineCap = 'round';
    ctx.strokeStyle = 'white';
    ctx.lineWidth = 0.5;
    
}

function beginDrawing(e)
{
    ctx.beginPath();
    ctx.moveTo(e.offsetX / 10, e.offsetY / 10);

    isDrawing = true;
}

function draw(e)
{
    if (isDrawing) {
        ctx.lineTo(e.offsetX / 10, e.offsetY / 10);
        ctx.stroke();
    }
}

function stopDrawing()
{
    ctx.closePath();
    isDrawing = false;
}

function getCanvasPixels(canvasBorderX, canvasBorderY) {
    let pixelsClamped = ctx.getImageData(0, 0, canvasBorderX, canvasBorderY).data;
    

    let pixelsFiltered = pixelsClamped.filter((val, indx) => {
        return (indx + 1) % 4 === 0;
    })

    let response = Array.from(pixelsFiltered);

    for (let i = 0; i < response.length; i++) {

    }

    console.log(response);
    return response;

}