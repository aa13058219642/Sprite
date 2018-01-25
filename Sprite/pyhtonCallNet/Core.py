#import sys
#sys.path.append("..")
#sys.path.append("core/")
from libs import dllloader  
  

#Load C# std namespace
from System.Windows import *  
from System.Threading import *


#Load C# Class
from System.Drawing import Bitmap


#Load dll namespace 
dllloader.loadDotNetDll(r'E:\\github\\Sprite\\Sprite\\CCore\\bin\\Debug\\CCore.dll')
from CCore import *

#
from libs import ghost_manager
from libs import shell













