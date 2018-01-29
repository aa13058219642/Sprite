from core import *

#Load C# Class
from System.Drawing import Bitmap


class Shell:
    def __init__(self, **kwargs):
        self.cshell = CShell()
        self.bmps = []
        self.loadShell("C:\\surface.png")

    def loadShell(self,path):
        self.bmps.append(Bitmap(path))
        pass

    def changeFace(self,index):
        self.cshell.SetBitmap(self.bmps[index])
        pass

    def show(self):
        self.cshell.Show()

    def hide(self):
        self.cshell.Hide()
