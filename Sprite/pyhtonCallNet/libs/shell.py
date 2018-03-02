from core import *
#Load C# Class
from System.Drawing import Bitmap


import os
import time



class Shell:
    def __init__(self, rootpath):
        self.cshell = CShell()
        self.bmps = []
        self.rootpath=rootpath #root path of this shell
        self.loadShell()

    def loadShell(self):
        print("Shell.loadShell")
        #fileloader.load_configfile(self.rootpath)
        #self.loadShell("C:\\surface.png")

        #self.bmps.append(Bitmap(path))
        print(os.getcwd())
        print(os.listdir(os.getcwd()+"\\Ghosts\\default\\shells"))
        #print(os.listdir("\\Ghosts"))
        #os.chdir('E:\\')
        time.sleep(10000)
        pass

    def changeFace(self,index):
        self.cshell.SetBitmap(self.bmps[index])
        pass

    def show(self):
        self.cshell.Show()

    def hide(self):
        self.cshell.Hide()
