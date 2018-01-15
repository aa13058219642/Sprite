#import clr
#import sys

#clr.AddReference("System.Reflection")
#clr.AddReference("System.Windows.Forms")
#from System.Reflection import Assembly
#from System.Windows.Forms import Application

#Assembly.LoadFile(r'E:\\projects\\python\\Sprite\\Sprite_core\\bin\\Debug\\Core.dll')
#import SpriteSpace

##import DllTestNS
##import System;
##import System.Collections.Generic;
##import System.Linq;
##import System.Threading.Tasks;
##import System.Windows.Forms;
##import System.Drawing


#def getSpriteCore():
#    return SpriteSpace.Core.GetInstance();

#__core = getSpriteCore()



#def bitmapTest():
#    global __core




#import clr
#import sys
#clr.AddReference("System.Threading")
#from System.Threading import Thread
#Thread.CurrentThread.SetApartmentState(SystemError.Threading.ApartmentState.STA)
##clr.AddReference("System.Windows")
##clr.AddReference("System.Windows.Controls")
##clr.AddReference("System.Windows.Media.Imaging")
##import WpfTest


import clr  
clr.AddReference("PresentationFramework.Classic, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35")  
clr.AddReference("PresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35")  
  
from System.Reflection import Assembly
from System.Windows import Application  
from System.Windows import Window  
from System.Threading import Thread  
from System.Threading import ApartmentState  
from System.Threading import ThreadStart  
Assembly.LoadFile(r'D:\\Project\\B\\BigProject\\Sprite\\Sprite\\WpfTest\\bin\\Debug\\WpfTest.dll')

import WpfTest

def AppStartUp(sender, e):  
    mainWnd = Window()  
    mainWnd.Title = "WPF From PythonNet!"  
    mainWnd.Show()  

    WpfTest.MainWindow().Show()


  
def STAMain():  
    app = Application()  
    app.Startup += AppStartUp  
    app.Run()  
  
def main():  
    t = Thread(ThreadStart(STAMain))  
    t.ApartmentState = ApartmentState.STA  
    t.Start()  
    t.Join()  
  
if __name__ == "__main__":  
    main()  















