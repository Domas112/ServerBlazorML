using serverml.Models;

namespace serverml.Services
{
    public interface IWineQualityAI
    {
        public WineQuality Predict(Wine wine);
    }
}