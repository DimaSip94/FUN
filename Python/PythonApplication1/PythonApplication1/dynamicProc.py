def count_trajectories(N:int, allowed:list):
    """
    реализация кузнечика
    прыгает на +1,+2,+3
    некоторые клетки посешать нельзя
    сколько вариантов допрагыть до N
    """
    K = [0,1, int(allowed[2]+[0]*(N-3))]
    for i in range(3, N+1):
        if allowed[i]:
            K[i]=K[i-1]+K[i-2]+K[i-3]


def count_min_trajectories_cost(N:int, price:list):
    """
    реализация кузнечика
    прыгает на +1,+2,+3
    сколько вариантов допрагыть до N
    price - цена за шаги
    теперь нужно найти самую минимальную траекторию
    """
    С = [None, price[1], price[1]+price[2]]+[0]*(N-2)
    for i in range(3,  N+1):
        C[i] = price[i]+min(C[i-1], C[i-2])
    return C[N]

#==================================================
#наибольшая общая подпоследовательность
def get_common_subarrays(A:list, B:list):
    """
    возвращает длину наибольшей общей подпоследовательности
    """
    F = [[0]*(len(B)+1) for i in range(len(A)+1)]
    for i in range(1, len(A)+1):
        for j in range(1, len(B)+1):
            if A[i-1]==B[j-1]:
                F[i][j]=1+F[i-1][j-1]
            else:
                F[i][j]=max(F[i-1][j], F[i][j-1])
    return F[-1][-1]#последний элемент

#наибольшая возрастающая подпоследовательность
def get_increasing_subarrays(A:list):
    """
    возвращает длину наибольшей возраст. подпоследовательности
    """
    f = [0]*len(A)
    for i in range(len(A)):
        m = 0
        for j in range(i):
            if A[i] > A[j] and f[j] > m:
                m = f[j]
        f[i] = m + 1
    return f[-1]
#==============================================
def levenstein(A, B):
    """
    алгоритм Ливенштейна
    наименьшее редакционное расстояние между строками
    """
    F=[[(i+j) if i*j==0 else 0 for j in range(len(B)+1)] for i in range(len(A)+1)]
    for i in range(1, len(A)+1):
        for j in range(1, len(B)+1):
            if A[i-1]==B[j-1]:
                F[i][j] = F[i-1][j-1]
            else:
                F[i][j]=1+min(F[i][j-1], F[i-1][j], F[i-1][j-1])
    return F[len(A)][len(B)]
#print(levenstein("kolokol","moloko"))

#=========================================================
def equal(A,B):
    """
    равны ли строки
    """
    if len(A)!=len(B):
        return False
    for i in range(len(A)):
        if A[i]!=B[i]:
            return False
    return True
#print(equal("kolokol","kolokol"))

#==========================================================
def search_substring(S, sub):
    """
    поиск подстроки в строке
    """
    for i in range(0, len(S)-len(sub)):
        if equal(S[i:i+len(sub)], sub):
            print(i)
#print(search_substring("moloko","lok"))

#============================================
def prefix_func(S):
    """
    префикс функция
    """
    p=[0]*len(S)
    for i in range(1, len(S)):
        k=p[i-1]
        while k>0 and S[i]!=S[k]:
            k=p[k-1]
        if S[i]==S[k]:
            k+=1
        p[i]=k
    return p
#print(prefix_func("abcdabcabcdabcdab"))