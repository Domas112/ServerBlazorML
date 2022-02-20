#%%
import numpy as np
from sklearn.model_selection import train_test_split
from tensorflow.keras import layers, models
import keras
from keras.datasets import mnist
# %%
(x_train, y_train), (x_test, y_test)= mnist.load_data()
# %%
x_train = np.reshape(x_train, (len(x_train),28*28))
x_test = np.reshape(x_test, (len(x_test), 28*28)) 
y_train = keras.utils.to_categorical(y_train, 10)
y_test = keras.utils.to_categorical(y_test, 10)
# %%
model = models.Sequential([
    layers.Input((28*28)),
    layers.Reshape((28,28, 1)),
    layers.Dropout(0.2),
    layers.Conv2D(32, kernel_size=(3, 3), activation="relu"),
    layers.MaxPooling2D(pool_size=(2, 2)),
    layers.Conv2D(64, kernel_size=(3, 3), activation="relu"),
    layers.MaxPooling2D(pool_size=(2, 2)),
    layers.Flatten(),
    layers.Dense(10, activation="softmax")
])

# %%
model.summary()
# %%
batch_size = 16
epochs = 2

model.compile(loss="categorical_crossentropy", optimizer="adam", metrics=["accuracy"])

model.fit(x_train, y_train, batch_size=batch_size, epochs=epochs, validation_data=(x_test,y_test))
# %%
import keras2onnx
from keras2onnx.common.data_types import FloatTensorType
initial_type = [('features', FloatTensorType([None, 28*28]))]
onnx_model = keras2onnx.convert_keras(model, model.name)

with open("digitpredictor.onnx", "wb") as f:
    f.write(onnx_model.SerializeToString())
# %%
