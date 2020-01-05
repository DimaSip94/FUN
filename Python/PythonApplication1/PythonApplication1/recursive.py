import graphics as gr
import turtle as trt

#матрешка
def matryoshka(n):
    if n==1:
        print("Матрешечка")
    else:
        print("Верх матрешки n=",n)
        matryoshka(n-1)
        print("Низ матрешки n=",n)

#matryoshka(5)
#================================================

#вложенные квадраты
#window = gr.GraphWin("Test", 600, 600)
alpha=0.2
def fraqtal_rectangle(A, B, C, D, deep=10):
    """
    A,B,C,D - точки начального, парные кортежи
    deep- требуемая глубина
    """
    if deep<1:
        return
    #gr.Line(gr.Point(*A), gr.Point(*B)).draw(window) ##*A разворачивает кортеж из 2х парамтеров A[0] и A[1]
    #gr.Line(gr.Point(*B), gr.Point(*C)).draw(window)
    #gr.Line(gr.Point(*C), gr.Point(*D)).draw(window)
    #gr.Line(gr.Point(*D), gr.Point(*A)).draw(window)
    for M,N in (A,B), (B,C), (C,D), (D,A):
        gr.Line(gr.Point(*M), gr.Point(*N)).draw(window)
    A1=(A[0]*(1-alpha)+B[0]*alpha, A[1]*(1-alpha)+B[1]*alpha)
    B1=(B[0]*(1-alpha)+C[0]*alpha, B[1]*(1-alpha)+C[1]*alpha)
    C1=(C[0]*(1-alpha)+D[0]*alpha, C[1]*(1-alpha)+D[1]*alpha)
    D1=(D[0]*(1-alpha)+A[0]*alpha, D[1]*(1-alpha)+A[1]*alpha)
    fraqtal_rectangle(A1,B1,C1,D1,deep-1)
 
#fraqtal_rectangle((100,100), (500,100), (500,500), (100,500), 100)
#================================================

#Черепаха
def turt_rectangle(deep=10):
    step=30
    if deep<1:
        return

    trt.forward((deep*step))
    trt.left(90)
    trt.forward((deep*step))
    trt.left(90)
    trt.forward((deep*step))
    trt.left(90)
    trt.forward((deep*step))

    

    trt.penup()
    #сдвигаем черепаху
    trt.left(90)
    trt.forward(step/2)
    trt.left(90)
    trt.forward(step/2)
    trt.right(90)
    trt.pendown()

    turt_rectangle(deep-1)

#trt.shape('turtle')
#turt_rectangle()
#================================================

#алгоритм Евклида
#алгоритм нахождение НОД
def gcd(a,b):
    if a==b:
        return a
    elif a>b:
        return gcd(a-b,b)
    else:
        return gcd(a,b-a)
#================================================

#генерация всех перестановок
def generate_numbers(N:int, M:int, prefix=None):
    """
    генерация всех чисел от 0 до N-1
    N-система счисления
    M-штук цифр
    """
    prefix=prefix or []
    if M==0:
        print(prefix)
        return
    for digit in range(N):
        prefix.append(digit)
        generate_numbers(N, M-1, prefix)
        prefix.pop()

def find(number:int, A:list):
    """
    ищет x в A и возвращает True если такой есть, иначе - False
    """
    for x in A:
        if number == x:
            return True
    return False

def generate_permutations(N:int, M:int=-1, prefix=None):
    """
    генерация всех N чисел в M позициях  без ПОВТОРЕНИЙ 
    N-система счисления
    M-штук цифр
    """
    M = M if M != -1 else N
    prefix = prefix or []
    if M == 0:
        print(*prefix, sep="")
        return
    for number in range(1, N+1):
        if find(number, prefix):
            continue
        prefix.append(number)
        generate_permutations(N, M-1, prefix)
        prefix.pop()

#====================================================
def get_number_fibonachi(n:int):
    """
    вычисляет n-ное число Фибоначчи  
    """
    numbers = [0,1]+[0]*(n-1)
    for x in range(2, n+1):
        numbers[x] = numbers[x-1]+numbers[x-2]
    return numbers[n]

def get_fib(n:int):
    """
    вычисляет n-ное число Фибоначчи
    ЭТО ОЧЕНЬ ФИГОВЫЙ АГОРИТМ!!!!!
    Первый намного быстрее и менее напряжен для памяти
    """
    if n <= 1:
        return n
    return get_fib(n-1)+get_fib(n-2)

  


     

