from core import *
#from CCore import *
from libs import shell

def get_instance():
    return GhostMgr.get_instance()

class GhostMgr:
    _instance = None

    def __init__(self):
        raise SyntaxError('can not instance, please use get_instance')

    def init(self):
        self.ghosts = []
        self.ghosts.append(Ghost())

    def getGhost(self,index):
        return self.ghosts[index]

    def get_instance():
        if GhostMgr._instance is None:
            GhostMgr._instance = object.__new__(GhostMgr)
            GhostMgr._instance.init()
        return GhostMgr._instance






class Ghost:
    def __init__(self):
        self.shells = []                
        self.dialogs = []
        self.shells.append(shell.Shell())
        pass


    def show(self):
        for s in self.shells:
            s.changeFace(0)
            s.show()
        pass

