from core import *
from sprite import *
import threading
import logging

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


def init_creat_thread():
    try:
        #work thread (python thread)
        t1 = threading.Thread(target = work)
        t1.setDaemon(True)
        t1.start()  
    except:
        logging.exception("create work thread fail")

    try:
        #this Thread() from System.Threading
        t2 = Thread(ThreadStart(STAMain))  
        t2.ApartmentState = ApartmentState.STA  
        t2.Start()  
    except:
        logging.exception("create System.Threading fail")

    t2.Join() 
  
def init_logging():
    logging.basicConfig(filename='sprite.log', level=logging.DEBUG,format='%(asctime)s %(message)s', datefmt='%Y-%m-%d %I:%M:%S')
    logging.info('=========================================================================')
    pass


def init():
    '''
    main init
    '''

    init_logging()
    init_creat_thread()
    pass


def main(): 
    init()

if __name__ == "__main__":  
    main()  
