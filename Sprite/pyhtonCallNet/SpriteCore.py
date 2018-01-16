#import sys
#sys.path.append('E:\\projects\\python\\Sprite\\Sprite_core\\bin\\Debug')
#import Core
#print(test1.add(3,4))

import Core 
import Sprite

def __main():
    SpriteCore.MainForm().Show()
    while True:
        Application.DoEvents()


def newForm():
    core = Core.getSpriteCore();
    t = threading.Thread(target=threadfun,args=(1,6))
    t.start();

#t = threading.Thread(target=self.__main,args=("main",0))
#t.start();

#c =Core.getSpriteCore()
#s = Sprite.newForm()
ss = Sprite.PSprite()
Core.Application.Run()
print("end")

bmp = Bitmap("C:\\surface2.png")
img = Image.open("C:\\surface2.png")

##DllTestNS.Class1().ShowMessage()


#SpriteCore.Application.EnableVisualStyles();
#SpriteCore.Application.SetCompatibleTextRenderingDefault(false);
    
#app = SpriteCore.Application()
#app.Run(SpriteCore.MainForm())



