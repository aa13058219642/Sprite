from core import *
import threading
import time

def AppStartUp(sender, e):  
    '''
    C# main function
    '''

    g = GhostMgr.get_instance().getGhost(0)
    g.show()

def STAMain():  
    '''
    Thread of C# main loop
    '''
    app = Application()  
    app.Startup += AppStartUp  
    app.Run()  


def work():
    '''
    Thread of work
    '''
    while(True):
        if CHelpers.IsExistedFullscreen()==True:
            print("Fullscreen!!")
        pass
        
        time.sleep(0.01)
    pass
  
def main(): 
    #python thread
    t1 = threading.Thread(target = work)
    t1.setDaemon(True)
    t1.start()  

    #this Thread() from System.Threading
    t2 = Thread(ThreadStart(STAMain))  
    t2.ApartmentState = ApartmentState.STA  
    t2.Start()  
    t2.Join()  
  
if __name__ == "__main__":  
    main()  
