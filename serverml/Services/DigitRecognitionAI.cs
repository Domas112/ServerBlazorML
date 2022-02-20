using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace serverml.Services
{
    public class DigitRecognitionAI : IDigitRecognitionAI
    {
        private readonly InferenceSession _session;
        public DigitRecognitionAI()
        {
            _session = new InferenceSession(@"PythonML/Digits/digitpredictor.onnx");
        }

        public float[] Predict(int[] digitPixels)
        {
            var features = new List<NamedOnnxValue>() {
                NamedOnnxValue.CreateFromTensor("input_10", AsTensor(digitPixels))
            };

            float[] prediction = new float[] {0,0,0,0,0,0,0,0,0,0};
            using (var output = _session.Run(features))
            {
                prediction = output.ToList()[0].AsTensor<float>().ToArray<float>();
                
            }
            return prediction;
        }

        private Tensor<float> AsTensor(int[] pixels)
        {
            float[] convertedPixels = new float[pixels.Length];

            for(int i = 0; i < pixels.Length; i++)
            {
                convertedPixels[i] = (float) pixels[i];
            }

            int[] dimensions = new int[] {1, convertedPixels.Length };
            return new DenseTensor<float>(convertedPixels, dimensions);
        }
    }
}
