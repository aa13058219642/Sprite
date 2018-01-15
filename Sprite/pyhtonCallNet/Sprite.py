import Core 
import threading  
from PIL import Image
import clr
clr.AddReference("System.Drawing")
from System.Drawing import Bitmap

def __sprite_click(sender, event):
    print("[pypyp]")


def __show(name,arg):
    core = Core.getSpriteCore();
    form = core.initMainForm()
    form.Show()

    s = form.getSprite()
    s.Click +=__sprite_click

    map = Bitmap("C:\\surface2.png")
    img = Image.open("C:\\surface2.png")
    form.setBitmap(map)

    while True:
        Core.Application.DoEvents()
    #Core.Application.Run(form)


def newForm():
    t = threading.Thread(target=__show,args=("name",0))
    t.start();

class PForm:
    def __init__(self):
        core = Core.getSpriteCore();
        form = core.initMainForm()
        form.Show()

        while True:
            Core.Application.DoEvents()

    
class PSprite:
    def __init__(self, **kwargs):
        self.form = self.__newForm()
        self.form.Show()
        return super().__init__(**kwargs)

    def __newForm(self):
        core = Core.getSpriteCore();
        form = core.initMainForm()
        return form

    def setBitmap(self,bitmap):
        self.form.setBitmap(bitmap)


