import math
def copy_array():
    """
    копирование массивов
    """
    print("Select size array")
    N = int(input())
    A = [0]*N
    B = [0]*N
    for k in range(N):
        print("Select A[{}]".format(k))
        A[k]=int(input())
    for k in range(N):
        B[k] = A[k]
    print(A)
    print(B)
    C = A.copy()
    D = list(A)

def array_search(A:list, N:int, x:int):
    """
    поиск в массиве линейный, от 0 до N-1 включительно
    возвращает местоположение этого элменета X если найден и -1 если нет
    если несколько одинаковых элементов ранвых x, то вернуть индекс первого
    A - список
    N - размер
    x - искомое число
    """
    for k in range(N):
        if A[k]==x:
            return k
    return -1

def test_array_search():
    A=[1,2,3,4,5,5]
    m=array_search(A,6,3)
    m1=array_search(A,6,8)
    m2=array_search(A,6,5)
    if m==2:
        print("Test1 - success")
    else:
        print("Test1 - fail")
    if m1==-1:
        print("Test2 - success")
    else:
        print("Test2 - fail")
    if m2==4:
        print("Test3 - success")
    else:
        print("Test3 - fail")
#===============================================================
def inverse_array(A:list):
    """
    инвертирование массива
    берет входящий массив и возвращает его инверсированную версию
    """
    #1й способо
    #B = [0]*len(A)
    #for k in range(len(A)):
    #    B[k]=A[len(A)-1-k]
    #return B
    #2й способ
    for k in range(len(A)//2):
        A[k], A[len(A)-1-k] = A[len(A)-1-k], A[k]
    return A

def tets_inverse_array():
    A = [1,2,3]
    if inverse_array(A)==[3,2,1]:
        print("Test1 - success")
    else:
        print("Test1 - fail")
#==================================================================
#циклические сдвиги влево
def step_left_array(A:list):
    """
    сдвиг влево
    """
    N=len(A)
    temp=A[0]
    for k in range(N-1):
        A[k]=A[k+1]
    A[N-1] = temp
    return A

def tets_step_left_array():
    A = [0,1,2,3]
    if step_left_array(A)==[1,2,3,0]:
        print("Test1 - success")
    else:
        print("Test1 - fail")

def step_right_array(A:list):
    """
    сдвиг вправо
    """
    N=len(A)
    temp=A[N-1]
    for k in range(N-2, -1, -1):
        A[k+1]=A[k]
    A[0] = temp
    return A

def tets_step_right_array():
    A = [0,1,2,3]
    if step_right_array(A)==[3,0,1,2]:
        print("Test1 - success")
    else:
        print("Test1 - fail")
#==============================================================
#Решето Эратосфена
def sieve_eratosthenes(N:int):
    """
    Решето Эратосфена нахождения всех простых чисел до некоторого целого числа N 
    """
    A = [True]*N
    for k in range(2, N):
        if A[k]:
            for m in range(2*k, N, k):
                A[m]=False
    for k in range(N):
        print(k,"-","prime" if A[k] else "composite")
    return A


def test_sieve_eratosthenes():
    test1=6
    T1A = sieve_eratosthenes(test1)
    if T1A == [True, True, True, True, False, True]:
        print("Test1-success")
    else:
        print("Test1-fail")

    test1=4
    T2A = sieve_eratosthenes(test1)
    if T2A == [True, True, True, True]:
        print("Test2-success")
    else:
        print("Test2-fail")
#====================================================================