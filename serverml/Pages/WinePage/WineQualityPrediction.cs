using Microsoft.AspNetCore.Components;
using serverml.Models;
using serverml.Services;

namespace serverml.Pages.WinePage
{
    public partial class WineQualityPrediction
    {
        [Inject]
        private IWineQualityAI _wineQualityAI { get; set; }

        private Wine wine = new();

        private WineQuality wineQuality { get; set; }
        private void handleSubmit()
        {
            Console.WriteLine("Submitted");
            wineQuality = _wineQualityAI.Predict(wine);
        }
    }
}
