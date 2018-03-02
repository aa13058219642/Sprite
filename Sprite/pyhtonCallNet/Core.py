import sys
sys.path.append(sys.path[0]+"\\libs")

import time
import logging
import loader

#Load clr
import clr  
clr.AddReference("PresentationFramework.Classic, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35")  
clr.AddReference("PresentationCore, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35")  
from System.Reflection import Assembly

#Load C# std namespace
import System
from System import *  
from System.Windows import *  
from System.Windows.Threading import *
from System.Threading import *
#from System.Delegate  import *

#Load dll namespace 
Assembly.LoadFile(r'E:\\github\\Sprite\\Sprite\\CCore\\bin\\Debug\\CCore.dll')
from CCore import CShell,CDialog
from Helper import CHelpers,CWinapi,CBitmapHelper

#Load libs
from ghost import *

class Core:
    _instance = None

    def __init__(self, **kwargs):
        raise SyntaxError('can not instance, please use get_instance')

    def init(self):
        self.gm = GhostMgr.get_instance()
        self.isfullscreen = False
        pass

    def get_instance():
        if Core._instance is None:
            Core._instance = object.__new__(Core)
            Core._instance.init()
        return Core._instance

    def start(self):
        self.gm.getGhost(0)
        self.gm.show()
        pass

    #def run(self):
    #    while(True):
    #        if CHelpers.IsExistedFullscreen()!=self.isfullscreen:
    #            self.isfullscreen = not self.isfullscreen
    #            if(self.isfullscreen):
    #                print("isfullscreen1")
    #                #Threading.Dispatcher.Invoke(Action())
    #                GhostMgr.get_instance().hide()
                    
    #                #Application.Current.Dispatcher.Invoke(d)
    #                print("isfullscreen2")
    #                pass
    #            else:
    #                GhostMgr.get_instance().show()
    #                #AppDomain.CurrentDomain.AssemblyLoad += d
    #                pass
    #        pass
        
    #        time.sleep(0.01)












