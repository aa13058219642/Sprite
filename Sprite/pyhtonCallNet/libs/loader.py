import os
import logging

def load_configfile(path):
    
    print("load_configfile:" + path)
    logging.info("load:"+path)

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

    return config


