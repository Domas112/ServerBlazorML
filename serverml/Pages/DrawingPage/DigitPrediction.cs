using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using serverml.Services;

namespace serverml.Pages.DrawingPage
{
    public partial class DigitPrediction
    {

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        [Inject]
        private IDigitRecognitionAI _digitRecognitionAI { get; set; }

        int canvasBorderX = 28, canvasBorderY = 28;
        ElementReference canvasElement;
        float[] prediction;

        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                await JsRuntime.InvokeVoidAsync("assignCanvas", canvasElement);
                await JsRuntime.InvokeVoidAsync("initCanvas");
            }
        }


        async Task predict()
        {
            int[] response = await JsRuntime.InvokeAsync<int[]>("getCanvasPixels", canvasBorderX, canvasBorderY);

            prediction = _digitRecognitionAI.Predict(response);

        }
    }
}
