import random
from colorama import Fore, Style

def jogar():
    nipes = ['paus','ouro','espadas','copas']
    classes = {1: 'as', 2: 'dois', 3: 'tres', 4: 'quatro', 5: 'cinco', 6: 'seis', 7: 'sete', 8: 'valete', 9: 'dama', 10: 'rei', 11: 'coringa'}
    baralhos = [1, 2]
    qtdeMao = 3
    maos = {'mao1':[], 'mao2':[], 'mao3':[], 'mao4':[]}
    nos = eles = False
    qtdeNos = qtdeEles = 0
    vez = 0
    
    while qtdeEles < 12 and qtdeNos < 12:
        maos = DarCartas(maos, nipes, classes, qtdeMao)
        while nos==False or eles==False:
          if vez <= 1:
              vez = len(maos)
          pontos = rodada(maos, vez, nipes, classes)
          qtdeEles += pontos
          vez -= 1
    vencedor = ''
    return vencedor
        
        
        
def DarCartas(maos, nipes, classes, qtdeMao):
    baralho = embaralhar(nipes, classes)
    for i in range(qtdeMao):
        for mao in maos:
            maolist = maos[mao]
            maolist.append(baralho[len(baralho)])
            baralho.popitem()
            maos[mao] = maolist
    return maos

def embaralhar(nipes, classes):
    cartas = []
    baralho = {}
    for classe in classes:
        for nipe in nipes:
            carta = (classe, nipe)
            cartas.append(carta)
    random.shuffle(cartas)                  
    i=1        
    for carta in cartas:
        baralho[i] = carta
        i+=1     
    return baralho


def rodada(maos, vez, nipes, classes):
  cartasRodada=[]
  cartasMaisFortes=()
  isEmpache=False
  isTruco=False
  for i, mao in enumerate(maos):
      if i == vez-1:
        carta = None
        nos = True
        while carta==None:
          carta = jogarCarta(maos[mao])
        cartaRodada = (nos, maos[mao][carta-1])
      else:
        cartaRodada = (True, maos[mao][1]) #Temporario ---> mudar para função que faz a requisição para IA
      if cartasRodada==[]:
        cartasRodada.append(cartaRodada[1])
        continue
      cartaMaisForte = calcularCartaMaisForte(cartasRodada, cartaRodada, nipes, classes)
      cartasRodada.append(cartaRodada[1])
  calcularPontos(cartaMaisForte, isEmpache, isTruco)
  pontos = 3
  return pontos

def jogarCarta(cartas):
  escolha = escolheCarta(cartas)

  # Verifica se a escolha é válida (dentro do intervalo de cartas ou Truco/Correr)
  if 1 <= escolha <= len(cartas):
    return escolha
  elif escolha == len(cartas) + 1:
    return -1  # Truco
  elif escolha == len(cartas) + 2:
    return -2  # Correr
  else:
    print("Opção inválida. Por favor, escolha uma carta válida.")
    return None
    
def escolheCarta(cartas):
  print(Fore.YELLOW + Style.BRIGHT + "  É SUA VEZ  " + Style.RESET_ALL)  # Título colorido
  print("-" * 40)
  print("  MENU DE CARTAS  ")
  print("-" * 40)

  print("Cartas disponíveis:")
  for i, carta in enumerate(cartas, start=1):
    print(f"  [{i}] {carta[0]} de {carta[1]}")

  print("-" * 40)  # Separador entre cartas e opções

  print("  ", end="")  # Alinhamento para opções
  print(f"[{len(cartas) + 1}] Truco", end="  ")
  print(f"[{len(cartas) + 2}] Correr")

  print("-" * 40)
  escolha = int(input("Digite o número da carta desejada: "))
  return escolha
    
def calcularPontos(cartasRodada):
  teste = ''
  
def calcularCartaMaisForte(cartasRodada, cartaRodada, nipes, classes):
  cartaMaisForte = isCartaMaisForte(cartasRodada, cartaRodada, nipes, classes)
  if cartaMaisForte==0:
    return 0
  return cartaMaisForte
  
def isCartaMaisForte(cartasRodada, cartaRodada, nipes, classes):
  classeForte = {'coringa':1,'tres':2,'dois':3,'as':4,'rei':5,'valete':6,'dama':7,'sete':8,'seis':9,'cinco':10,'quatro':11}
  nipeForte = {'ouro':1,'espadas':2,'copas':3,'paus':4}
  cartaMaisForte=None
  #Pega a carta atual e a ultima jogada com base na sequencia de classes e nipes
  cartaAtual = (classeForte[classes[cartaRodada[1][0]]], nipeForte[cartaRodada[1][1]]) 
  cartaAnterior = (classeForte[classes[cartasRodada[len(cartasRodada)-1][0]]], nipeForte[cartasRodada[len(cartasRodada)-1][1]])
  
  if cartaAtual[0]<cartaAnterior[0]:                               #Carta jogada mais forte que a anterior
    cartaMaisForte = cartaRodada 
  elif cartaAtual[0]==cartaAnterior[0]:                            #Carta jogada mesma classe que a anterior
    if cartaAtual[0] == 1:                                         #Se for coringa verifica nipe
      if cartaAtual[1]<cartaAnterior[1]:
        cartaMaisForte=cartaRodada
      elif cartaAnterior[1]<cartaAtual[1]:
        cartaMaisForte=cartasRodada[len(cartasRodada)-1]
    elif cartaAtual[0] != 1:                                       #Se não for coringa empacha
      cartaMaisForte=0
  elif cartaAnterior[0]<cartaAtual[0]:
    cartaMaisForte=cartasRodada[len(cartasRodada)-1]
  
  return cartaMaisForte
  
  
   
vencedor = ''

print('vamos jogar')
print('============================================================\n')


vencedor = jogar()
jogarNovamente = '' #str(input('Time: {vencedor} vence!! Jogar novamente?(S/N): '))
if jogarNovamente in 'Nn':
    print('fim de jogo')
 


        
            
        