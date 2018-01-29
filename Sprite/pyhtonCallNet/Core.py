from libs.dllloader import *

#Load C# std namespace
from System.Windows import *  
from System.Threading import *




#Load dll namespace 
loadDotNetDll(r'E:\\github\\Sprite\\Sprite\\CCore\\bin\\Debug\\CCore.dll')
from CCore import CShell,CDialog
from Helper import CHelpers,CWinapi,CBitmapHelper

#
from libs.ghost import *
from libs.shell import *













