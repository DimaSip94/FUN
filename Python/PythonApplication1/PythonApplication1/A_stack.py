_stack=[]

def push(x):
    _stack.append(x)

def pop():
    return _stack.pop()

def clear():
    _stack.clear()

def is_empty():
    return True if len(_stack)==0 else False
