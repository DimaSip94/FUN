import A_stack
def check_braces_sequance(S):
    A_stack.clear()
    """
    проверка скобочной последовательности
    ((([[[]]]))) - True
    ([)[ - False
    (() - False
    (()) - True
    """
    for brace in S:
        if brace not in "()[]":
            continue
        if brace in "([":
            A_stack.push(brace)
        else:
            assert brace in ")]", "Ожидалась закрывающая скобка! "+str(brace)
            if A_stack.is_empty():
                return False
            left=A_stack.pop()
            assert left in "([", "Ожидалась открывающая скобка! "+str(left)
            right=")" if left=="(" else "]"
            if right!=brace:
                return False
    return True if A_stack.is_empty() else False

print(check_braces_sequance("(())"))