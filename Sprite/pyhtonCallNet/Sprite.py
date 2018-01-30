from core import *
import time

def ttest(isshow):
    print("isshow="+str(isshow))

class Sprite:
    _instance = None

    def __init__(self, **kwargs):
        raise SyntaxError('can not instance, please use get_instance')

    def init(self):
        #self.gm = GhostMgr.get_instance()
        self.isfullscreen = False
        self.dispatcher = None
        pass

    def get_instance():
        if Sprite._instance is None:
            Sprite._instance = object.__new__(Sprite)
            Sprite._instance.init()
        return Sprite._instance

    def start(self):
        #self.gm.getGhost(0)
        #self.gm.show()
        pass

    def test(self,isshow):
        print("isshow="+str(isshow))
        if isshow == True:
            GhostMgr.get_instance().show()
        else:
            GhostMgr.get_instance().hide()

    def setDispatcher(self, dispatcher):
        self.dispatcher = dispatcher

    def run(self):

        while(True):
            if CHelpers.IsExistedFullscreen()!=self.isfullscreen:
                self.isfullscreen = not self.isfullscreen
                if(self.isfullscreen):
                    #deligate = System.Action(self.test)
                    #self.dispatcher.Invoke(deligate)

                    #The generic's name in Python.NET is Action`1 (in general: 
                    #Action`N with N being the number of generic arguments).
                    #We can get the wrapper object by using getattr on the module:
                    #src:https://stackoverflow.com/questions/30659933/python3-pythonnet-generic-delegates
                    
                    #get class System.Action<T>
                    Action = getattr(System, "Action`1")  
                    
                    #System.Action<bool>
                    action = Action[System.Boolean](self.test)  

                    #call Dispatcher module: 
                    #  public object Invoke(Delegate method, params object[] args);
                    self.dispatcher.Invoke(action,[False])      
                    pass
                else:
                    Action = getattr(System, "Action`1")
                    action = Action[System.Boolean](self.test)
                    self.dispatcher.Invoke(action,[True])
                    pass
            pass
        
            time.sleep(0.01)

        #this.Dispatcher.Invoke(new Action(() =>
        #{
        #    this.Hide();
        #}));
        #System.Windows.Threading.Dispatcher
        #System.Action



        pass








