from core import *
from libs import ghost_manager 

def AppStartUp(sender, e):  
    g = GhostMgr.get_instance().getGhost(0)
    g.show()
    #shell.Show()
  
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
