using Microsoft.ML.Data;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace serverml.Models
{
    public class Wine
    {
        [ColumnName("fixed acidity")]
        public float FixedAcidity { get; set; }
        [ColumnName("volatile acidity")]
        public float VolatileAcidity { get; set; }
        [ColumnName("citric acid")]
        public float CitricAcid { get; set; }
        [ColumnName("chlorides")]
        public float Chlorides { get; set; }
        [ColumnName("total sulfur dioxide")]
        public float TotalSulfurDioxide { get; set; }
        [ColumnName("density")]
        public float Density { get; set; }
        [ColumnName("sulphates")]
        public float Sulphates { get; set; }
        [ColumnName("alcohol")]
        public float Alcohol { get; set; }
    }

    public class WineQuality
    {
        public int PredictedQuality { get; set; }
    }
}
