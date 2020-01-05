def dfs(vertex, G, used):
    """
    алгоритм обхода в глубину
    """
    used.add(vertex)
    for neighbr in G[vertex]:
        if neighbr not in used:
            dfs(neighbr, G, used)

def get_count_components(G):
    """
    поиска кол-ва компонентв графе
    """
    used = set()
    N = 0
    for vertex in G:
        if vertex not in used:
            dfs(vertex, G, used)
            N+=1
    return N



def bfs(G):
    """
    обход в ширину
    вовзращает список расстояний от 0 вершины до всех остальных
    """
    distance = [None]*N
    start_vertex = 0
    distance[start_vertex]=0
    q = []
    q.append(start_vertex)
    while q:
        current=q.pop(0)
        for neigh in G[current]:
            if distance[neigh] is None:
                distance[neigh]=distance[current]+1
                q.append(neigh)

    return distance
#N=6
#G = {
#    0:[1,3], # 0
#    1:[0,3,4,5], # 1
#    2:[4,5], # 2
#    3:[0,1,5], # 3
#    4:[1,2], # 4
#    5:[1,2,3] # 5
#  }

#print(bfs(G))



