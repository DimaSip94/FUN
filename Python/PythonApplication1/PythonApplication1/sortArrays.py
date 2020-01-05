#СОРТИРОВКИ
#КВАДРАТИЧНЫЕ СОРТИРОВКИ
#O(N**2) сложность


def sort_inserts(a:list):
    """
    1. вставками
    """
    n = len(a)
    for top in range(1, n):
        k = top
        while k > 0 and a[k-1] > a[k]:
            a[k], a[k-1] = a[k-1], a[k]
            k -= 1

    return a

def sort_choise(a:list):
    """
    2. выбором
    """
    n = len(a)
    for x in range(0, n-1):
        for y in range(x+1, n):
            if a[y] < a[x]:
                a[x], a[y] = a[y], a[x]
    return a

def sort_bubble(a:list):
    """
    3. пузырек
    """
    n = len(a)
    for x in range(1,n-1):
        for y in range(0, n-x):
            if a[y]>a[y+1]:
                a[y],a[y+1]=a[y+1],a[y]
    return a
 

def test_sort_inserts():
    t1=[4,2,5,1,3]
    t2=[4,2,5,1,3]
    t3=[4,2,5,1,3]

    if sort_inserts(t1)==[1,2,3,4,5]:
        print("sort_inserts SUCCESS")
    else:
        print("sort_inserts FAIL")

    if sort_choise(t2)==[1,2,3,4,5]:
        print("sort_choise SUCCESS")
    else:
        print("sort_choise FAIL")

    if sort_bubble(t3)==[1,2,3,4,5]:
        print("sort_bubble SUCCESS")
    else:
        print("sort_bubble FAIL")

#=======================================
def merge(A:list, B:list):
    """
    слияние массивов
    """
    C = [0]*(len(A)+len(B))
    i = k = n = 0
    while(i < len(A)) and (k < len(B)):
        if A[i] <= B[k]:
            C[n] = A[i]
            n += 1
            i += 1
        else:
            C[n] = B[k]
            n += 1
            k += 1
    while i < len(A):
        C[n] = A[i]
        i += 1
        n += 1
    while k < len(B):
        C[n] = B[k]
        k += 1
        n += 1
    return C
#======================================================
#Сортировка Хора
#W(N*logN)
#4,2,5,1,6,3,4
#разбиваем на группы относительно первого
#2,1,3   4,4     5,6
#и так далее
def hoara_sort(A:list):
    """
    сортировка Хора массива A
    """
    if len(A) <= 1:
        return
    barrier = A[0]
    L = []
    M = []
    R = []
    for x in A:
        if x < barrier:
            L.append(x)
        elif x == barrier:
            M.append(x)
        else:
            R.append(x)
    k = 0
    hoara_sort(L)
    hoara_sort(R)
    for x in L+M+R:
        A[k] = x
        k += 1
#=====================================================
#Сортировка слиянием
#O(N*logN)
#4,2,5,1,6,3,4
#1 часть массива от 0 до N\2 не вкл.    2,4,5
#2 часть от N\2 вкл. до N не вкл.       1,3,4,6
#затем делаем слияние по элементно
def merge_sort(A:list):
    """
    сортировка слиянием массива A
    """
    if len(A) <= 1:
        return
    middle = len(A) // 2
    L = [A[i] for i in range(0, middle)]
    R = [A[i] for i in range(middle, len(A))]
    merge_sort(L)
    merge_sort(R)
    C = merge(L,R)
    for x in range(len(A)):
        A[x] = C[x]

#===================================================
def is_sort_array(A, ascending=True):
    """
    отсортирован массив A или нет
    ascending - возрастанию или убыванию
    """
    flag = True
    s = 2*int(ascending)-1
    for i in range(0, len(A)-1):
        if s*A[i] > s*A[i+1]:
            flag = False
            break
    return flag  

#================================================
#бинарный поиск в массиве
#МАССИВ ДОЛЖЕН БЫТЬ ОТСОРТИРОВАН
def left_bound(A:list, key:int):
    """
    поиск левой границы
    """
    left = -1
    right = len(A)
    while right-left>1:
        middle = (left+right)//2
        if A[middle] < key:
            left = middle
        else:
            right = middle
    return left

def right_bound(A:list, key:int):
    """
    поиск правой границы
    """
    left = -1
    right = len(A)
    while right-left>1:
        middle = (left+right)//2
        if A[middle] <= key:
            left = middle
        else:
            right = middle
    return right

def is_exists_key_in_array(A:list, key:int):
    """
    вернет True - если элемент есть в коллекции и False - если его там нет
    """
    left = left_bound(A,key)
    right = right_bound(A,key)
    if right-left>1:
        return True
    return False
