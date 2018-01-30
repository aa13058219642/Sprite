from core import *
from sprite import *
import threading

def AppStartUp(sender, e):  
    '''
    C# main function
    '''
    Core.get_instance().start()
    # get the dispatcher for the current thread
    dispatcher = Dispatcher.CurrentDispatcher
    Sprite.get_instance().setDispatcher(dispatcher)




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
    time.sleep(3)
    Sprite.get_instance().run()

  
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
