from core import *
#Load C# Class
from System.Drawing import Bitmap

import os
import time
import re

import loader

class Shell:
    def __init__(self, rootpath):
        self.cshell = CShell()
        self.bmps = []
        self.rootpath=rootpath #root path of this shell
        self.surfaces=[]

        self.loadShell()


    def loadShell(self):
        ##load descript.txt
        descript_path = self.rootpath +"\\descript.txt"
        descript_config =  loader.load_configfile(descript_path)
        #print(descript_config)
        
        ##load surfaces.txt
        surfaces_path = self.rootpath +"\\surfaces.txt"
        surfaces_config =  loader.load_surfaces(surfaces_path)
        #print(surfaces_config)
        
        for key,values in surfaces_config.items():
            sur = Surface(key,values)
            self.surfaces.append(sur)
            #print(key+":"+str(values)+"\n")

        print(len(surfaces_config.keys()))

        #print(os.getcwd())
        #print(os.listdir(os.getcwd()+"\\Ghosts\\default\\shells"))
        #print(os.listdir("\\Ghosts"))
        #os.chdir('E:\\')
        #self.loadShell("C:\\surface.png")
        #self.bmps.append(Bitmap("C:\\surface.png"))
        time.sleep(10000)
        return



    def changeFace(self,index):
        self.cshell.SetBitmap(self.bmps[index])
        return

    def show(self):
        self.cshell.Show()

    def hide(self):
        self.cshell.Hide()

class Surface:
    def __init__(self,name, values):
        self.name=name
        self.elements={}
        self.animations={}
        self.collisionexs={}
        
        self.load_surface(values)
        pass


    def load_surface(self,values):

        for line in values:
            regElement = re.match("^element(\\d+),(base|overlay|overlayfast|replace|interpolate|asis|move|bind|add|reduce|insert),(\\w+.png),(\\d+),(\\d+)$",line)
            regInterval = re.match("^(\\d+)interval,(sometimes|rarely|random,\\d+|periodic,\\d+|always|runonce|never|yen-e|talk,\\d+|bind)$",line)
            regPattern = re.match("^(\\d+)pattern(\\d+),(\\-?\\d+),(\\d+),(base|overlay|overlayfast|replace|interpolate|asis|move|bind|add|reduce|insert,\\d+|start,\\d+|stop,\\d+),(\\d+),(\\d+)$",line)
            regPattern2 = re.match("^(\\d+)pattern(\\d+),(\\-?\\d+),(\\d+),(alternativestart),\\[((?:\\d+\\.)*\\d+)\\]$",line)
            
            params = None
            #Element
            if regElement!=None :
                params = regElement.groups()
                if int(params[0] not in self.elements):
                    self.elements[params[0]]=1
                    print("111")

            #Animation Interval
            if regInterval!=None :
                params = regInterval.groups()
                if params[0] not in self.animations:
                    self.animations[params[0]]=Animation()
                self.animations[params[0]].interval=params[1]

            #Animation Pattern
            if regPattern!=None :
                params = regPattern.groups()
                animationsID = params[0]
                if animationsID not in self.animations:
                    self.animations[params[0]]=Animation()

                pattern = Pattern()
                pattern.surfaceID = int(params[2])
                pattern.interval = params[3]
                pattern.methodType = params[4]
                pattern.left = int(params[5])
                pattern.top = int(params[6])

                self.animations[animationsID].patterns.append(pattern)

            #Animation Pattern2
            if regPattern2!=None :
                params = regPattern2.groups()
                animationsID = params[0]
                if animationsID not in self.animations:
                    self.animations[animationsID]=Animation()

                pattern = Pattern()
                pattern.surfaceID = int(params[2])
                pattern.interval = params[3]
                pattern.methodType = params[4]

                self.animations[animationsID].patterns.append(pattern)


                sli = params[5].split('.') 
                nli=[]
                for x in sli:
                    nli.append(int(x))
                self.animations[animationsID].alternativestart = nli


            #if params!=None:
            #    print(str(len(params)) +":"+ str(params))
            #else:
            #    print(line)

            #li = line.split(',')

        print(self.animations)
        time.sleep(10000)



        pass

class Animation:
    def __init__(self):
        #self.ID = 0
        self.interval = 0
        self.patterns = []
        self.options = []
        self.collisions = []
        pass


    def __str__(self):
        return '姓名:%s年龄:%d' %(self.__name,self.__age) 


class Point:
    def __init__(self, x=0,y=0):
        self.x = x
        self.y = y




class Shape:
    def __init__(self, type=0,points=[]):
        self.type = type 
        self.points = points


class Pattern:
    def __init__(self, **kwargs):
        self.methodType = ""
        self.surfaceID = 0
        self.interval = 0
        self.top = 0 
        self.left = 0





















