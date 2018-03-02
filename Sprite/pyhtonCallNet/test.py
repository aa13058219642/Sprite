import os
import logging

def test():
    return 


    path = "E:\\github\\Sprite\\Sprite\\pyhtonCallNet\\Ghosts\\default\\shells\\little_devil\\descript.txt"

    print("load_configfile:" + path)

    if(os.path.isfile(path)==False):
        logging.error("file [%s] NOT exist",path)
        raise RuntimeError("file NOT exist")
        
    config = {}

    f = open(path, 'r')
    for line in f:
        line=line.replace("\n","")
        
        if line == '':
            continue
        
        line=line.strip(' ')
        index = line.index(',')


        key = line[0:index]
        value = line[index+1:]
        
        config[key]=value

        print(key + "="+config[key]+";")

    return config
    pass


















    pass




