namespace serverml.Services
{
    public interface IDigitRecognitionAI
    {
        public float[] Predict(int[] digitPixels);
    }
}
