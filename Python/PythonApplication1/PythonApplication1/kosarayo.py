def main():
    or_graph = {
        'a': {'b'},
        'b': {'c', 'd'},
        'c': {'a'},
        'd': {'e'},
        'e': {'f'},
        'f': {'d'},
        'g': {'f', 'h'},
        'h': {'i'},
        'i': {'j'},
        'j': {'g'},
        'k': {'j'}
    }
    stack = dfs_returns_stack(or_graph)
    print(stack)
    strong_connected = dfs_revers(or_graph, stack)
    print(strong_connected)


def dfs_returns_stack(or_graph):
    """
    Обход графа в грлубину.
    Возвращыет очередь компоненты связности в формате list.
    """
    stack = []
    used = set()
    for vertex in or_graph:
        if vertex not in used:
            dfs_comp_returns_stack(vertex, or_graph, used, stack)
    return stack


def dfs_comp_returns_stack(vertex, graph, used, stack):
    """
    Обход компоненты свзяности в грлубину.
    Пополняет очередь stack вершинами компоненты связности.
    """
    used.add(vertex)
    for neighbor in graph[vertex]:
        if neighbor not in used:
            dfs_comp_returns_stack(neighbor, graph, used, stack)
    stack.append(vertex)


def dfs_revers(or_graph, stack):
    """
    Обратный обход графа в глубину по стэку (stack).
    Возвращает list с множествами сильных компанент связности.
    """
    strong = []
    used = set()
    reversed_or_graph = revers_or_graph(or_graph)
    while stack:
        vertex = stack.pop()
        if vertex not in used:
            strong.append(dfs_returns_strong(vertex, reversed_or_graph,
                                             used))
    return strong


def revers_or_graph(or_graph):
    """
    Возвращает обратный орграф.
    """
    reversed_graph = {vertex: set() for vertex in or_graph}
    for vertex in or_graph:
        for neighbor in or_graph[vertex]:
            reversed_graph[neighbor].add(vertex)
    return reversed_graph


def dfs_returns_strong(vertex, graph, used, strong=None):
    """
    Обход компоненты в грлубину.
    Возвращает сильную компаненту.
    """
    used.add(vertex)
    strong = strong or set()
    strong.add(vertex)
    for neighbor in graph[vertex]:
        if neighbor not in used:
            dfs_returns_strong(neighbor, graph, used, strong)
    return strong


if __name__ == "__main__":
    main()
