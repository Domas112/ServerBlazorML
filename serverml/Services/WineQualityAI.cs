using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using serverml.Models;

namespace serverml.Services
{
    public class WineQualityAI : IWineQualityAI
    {
        private readonly InferenceSession _session;
        public WineQualityAI()
        {
            _session = new(@"PythonML/Wine/wine_randomforestclassifier.onnx");
        }
        public WineQuality Predict(Wine wine)
        {
            var features = new List<NamedOnnxValue>()
            {
                NamedOnnxValue.CreateFromTensor("features", AsTensor(wine))
            };
            
            int prediction = -1;
            using (var output = _session.Run(features))
            {
                prediction = (int)output.First().AsTensor<long>().First();
            }

            return new WineQuality() { PredictedQuality = prediction};
        }

        public Tensor<float> AsTensor(Wine wine)
        {
            float[] data = new float[]
            {
                wine.FixedAcidity,
                wine.VolatileAcidity,
                wine.CitricAcid,
                wine.Chlorides,
                wine.TotalSulfurDioxide,
                wine.Density,
                wine.Sulphates,
                wine.Alcohol
            };

            int[] dimensions = new int[] { 1, data.Length };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
