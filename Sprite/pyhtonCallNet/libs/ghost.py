#from core import *
from shell import *

import os
import logging

def get_instance():
    return GhostMgr.get_instance()

class GhostMgr:
    _instance = None

    def __init__(self):
        raise SyntaxError('can not instance, please use get_instance')

    def init(self):
        self.ghosts = []
        self.scan_ghosts()
        #self.ghosts.append(Ghost())

    def scan_ghosts(self):
        ghosts_path = os.getcwd()+"\\Ghosts\\"
        if(False == os.path.exists(ghosts_path)):
            logging.error("directory [%s] NOT found!", ghosts_path)
            raise SyntaxError('directory NOT found!')
        
        for ghost_name in os.listdir(ghosts_path):
            new_ghost = Ghost(ghosts_path + ghost_name)
            self.ghosts.append(new_ghost)

        pass


    def getGhost(self,index):
        return self.ghosts[index]

    def hide(self):
        for g in self.ghosts:
            g.hide()

    def show(self):
        for g in self.ghosts:
            g.show()

    def get_instance():
        if GhostMgr._instance is None:
            GhostMgr._instance = object.__new__(GhostMgr)
            GhostMgr._instance.init()
        return GhostMgr._instance




class Ghost:
    def __init__(self,rootpath):
        self.shells = []                
        self.dialogs = []
        self.rootpath=rootpath #root path of this ghost 

        self.scan_shell()
        self.used_shell = self.shells[0] # default
        pass

    def show(self):
        for s in self.shells:
            s.changeFace(0)
            s.show()
        pass

    def hide(self):
        for s in self.shells:
            s.changeFace(0)
            s.hide()
        pass

    def scan_shell(self):
        shells_path = self.rootpath+"\\shells\\"
        if(False == os.path.exists(shells_path)):
            logging.error("directory [%s] NOT found!", shells_path)
            raise SyntaxError('directory NOT found!')

        for dir in os.listdir(shells_path):
            shell = Shell(shells_path + dir)
            self.shells.append(shell)
        pass
























