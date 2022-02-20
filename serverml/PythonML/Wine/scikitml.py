#%%
from sklearn.ensemble import RandomForestClassifier
from sklearn.linear_model import LinearRegression, LogisticRegression, Lasso
from sklearn.model_selection import train_test_split
from sklearn.svm import SVC
from sklearn.pipeline import make_pipeline
from sklearn.preprocessing import StandardScaler
import pandas as pd
import numpy as np
import seaborn as sns
import matplotlib.pyplot as plt

# %%
df = pd.read_csv('WineQT.csv')

# %%
df.head()
# %%
for i, col in enumerate(df.columns):
    print(df[col].describe())
# %%
df.isna().sum()
# %%
df.drop("Id", axis=1, inplace=True)
# %%
sns.heatmap(df.corr(), cmap="coolwarm", vmax=1, vmin=-1,
        annot=True,    
        fmt=".1")
# %%
x = df.drop(["quality", "pH", "free sulfur dioxide", "residual sugar"], axis=1)
y = df["quality"]
x_train, x_test, y_train, y_test = train_test_split(x,y, test_size=0.15, random_state=42)
#%%
model = make_pipeline(StandardScaler(), RandomForestClassifier(criterion="entropy",random_state=35))
model.fit(x_train,y_train)
model.score(x_test,y_test)

# %%
from skl2onnx import convert_sklearn
from skl2onnx.common.data_types import FloatTensorType

initial_type = [('features', FloatTensorType([None, 8]))]
onx = convert_sklearn(model, initial_types=initial_type)
with open("wine_randomforestclassifier.onnx", "wb") as f:
    f.write(onx.SerializeToString())
# %%
from sklearn.datasets import load_iris

iris = load_iris()
x,y = iris.data, iris.target
# %%
