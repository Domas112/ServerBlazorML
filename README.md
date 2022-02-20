 Both models were created and trained using <a href="https://www.python.org/" target="_blank">Python</a>.
The wine quality prediction algorithm is taken from the <a href="https://scikit-learn.org/stable/index.html" target="_blank">Scikit-Learn</a> machine learning library 
Digit prediction model was implemented using <a href="https://keras.io/" target="_blank">Keras</a> interface for <a href="https://www.tensorflow.org/" target="_blank">Tensorflow</a>.

<a href="https://onnx.ai/" target="_blank">ONNX</a> format was used to access both models in .NET. 
Once trained, the models were converted to the ONNX format in Python and later consumed in this server side Blazor web app through the ONNX runtime. With the same API calls and a bit of parameter tweaking, models from both Scikit-Learn and Keras can be used in .NET!

        
Training data was taken from <a href="https://www.kaggle.com/yasserh/wine-quality-dataset" target="_blank"> Kaggle </a>, while the digit prediction model was trained on the MNIST dataset, local to the Keras library. 
 
