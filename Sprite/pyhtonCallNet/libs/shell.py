from core import *
#Load C# Class
from System.Drawing import Bitmap

import os
import time
import loader

class Shell:
    def __init__(self, rootpath):
        self.cshell = CShell()
        self.bmps = []
        self.rootpath=rootpath #root path of this shell
        self.loadShell()

    def loadShell(self):
        print("Shell.loadShell")

        descript_path = self.rootpath +"\\descript.txt"
        descript_config =  loader.load_configfile(descript_path)
        #self.loadShell("C:\\surface.png")
        print(descript_config)
        
        #print(os.getcwd())
        #print(os.listdir(os.getcwd()+"\\Ghosts\\default\\shells"))
        #print(os.listdir("\\Ghosts"))
        #os.chdir('E:\\')
        #self.bmps.append(Bitmap("C:\\surface.png"))
        time.sleep(10000)
        return

    def changeFace(self,index):
        self.cshell.SetBitmap(self.bmps[index])
        return

    def show(self):
        self.cshell.Show()

    def hide(self):
        self.cshell.Hide()
