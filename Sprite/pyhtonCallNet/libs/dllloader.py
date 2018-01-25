import clr  
clr.AddReference("PresentationFramework.Classic, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35")  
clr.AddReference("PresentationCore, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35")  
from System.Reflection import Assembly

#Load C# dll
#Assembly.LoadFile(r'E:\\github\\Sprite\\Sprite\\CCore\\bin\\Debug\\CCore.dll')
def loadDotNetDll(path):
    Assembly.LoadFile(path)
