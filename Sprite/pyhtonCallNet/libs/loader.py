import os
import logging


def file_exits(path):
    print("file_exits:" + path)
    logging.info("load:"+path)

    if(os.path.isfile(path)==False):
        logging.error("file [%s] NOT exist",path)
        raise RuntimeError("file NOT exist")
    return True


def load_configfile(path):
    if file_exits(path)!=True:
        return None
        
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


def load_surfaces(path):
    if file_exits(path)!=True:
        return None

    config = {}
    is_load_key = True
    key=''

    f = open(path, 'r')
    for line in f:
        line=line.replace("\n","")
        if line == '':
            continue
        line=line.strip(' ')

        if line=='{':
            is_load_key=False
            continue
        elif line == '}':
            is_load_key=True
            continue
        
        if is_load_key == True:
            #load key
            key = line
            config[key]=[]
        else:
            #load value
            config[key].append(line)

    return config
