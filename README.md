# DinoPlat

Mini platformer 2d mobile.

##Documentação do que foi desenvolvido.


###Código:

Foram implementados 5 pastas contendo um total de 14 classes em C#.
Todas as classes contém breve anotações no prórpio código sobre seu comportamento, bem como os principais métodos públicos.

* DinoPlat.Events

Contém classes relacionadas aos eventos lançados durante a gameplay.

_GameEvent_
Classe base representando um evento de gameplay a ser levantado, herda da classe ScriptableObject para facilitar a criação de novos eventos sem a adição de código extra.

_EventRaiserBehaviour_
Herda de Monobehaviour, dessa forma, este componente pode ser associado a um objeto em cena para disparar um evento do tipo `GameEvent`

_GameEventRaiser_ 
SubClasse de `EventRaiserBehaviour`, disparando o evendo ao entrar em contato com o player.

_RaiseEventOverTime_
Também é subclasse de `EventRaiserBehaviour`, porém dispara o evento após o tempo definido na variável `_timeToRaise` que está disponível para edição pelo inspetor da Unity.

_GameEventListener_
Componente que recebe um `GameEvent` e se registra para disparar um `UnityEvent` quando o evento for levantado. Dessa forma, podemos associar ações direto do inspetor ao disparo do evento de gameplay.

* DinoPlat.Items

_ItemBehaviour_
Subclasse de `GameEventRaiser`, idealizada para levantar o evento de item coletado, sobreescrevendo o método RaiseEvent() para desabilitar o objeto na cena.

* DinoPlat.Player

Contém classes relacionadas ao objeto do jogador.

_PlayerData_
ScriptableObject que detém os atributos do personagem controlado pelo jogador.

_PlayerHealth_
Componente que dispara a animação de player dead ao receber o evento de jogador morto, que pode ser disparado pelos objetos _Water_ na cena.

_PlayerMovementBehaviour_
Controla a movimentação e o pulo do jogador, recebendo o input através do sistema _UnityEngine.InputSystem_, aplicando fisica ao _Rigidbody2D_ do player e controlando os parâmetros da animação.

* DinoPlat.Stats

_ItemsCount_
Usada em associação com `GameEventListener`, contabiliza os items coletados pelo jogador (pelo evento de item coletado) e mostra o total ao final da partida (pelo evento de fim de jogo).

_PointsManager_
Semelhante à `ItemsCount`, usada em associação com `GameEventListener`, contabiliza a pontuação acumulada pelo jogador (pelo evento de item coletado) e mostra o total ao final da partida (pelo evento de fim de jogo).

* DinoPlat.Util

_AdsBehaviour_
Controla os UnityAds, é utilizado na cena do menu principal e expõe um `UnityEvent` para executar uma ação após a exibição do anúncio.

_SceneLoader_
Objeto reponsável por carregar as cenas do jogo, por isso, herda de ScriptableObject para ser independente delas.

_TimerUI_
Mostra na tela o tempo restante de jogo, sendo uma subclasse de `RaiseEventOverTime`, dispara o evento de fim de jogo ao final da partida. Utilizado em conjunto com `GameEventListener` para mostrar o tempo total de jogo (pelo evento de fim de jogo). 

###Tempo Gasto

Foram gastas cerca de 18 horas durante o desenvolvimento deste projeto entre os dias 22/04/2021 e 29/04/2021.

###Dificuldades

* Nunca havia utilizado o analytics, mas pude consultar vídeos no youtube e utilizar o analytics para observar o número de vezes em que a fase foi iniciada, em que o jogador morreu e em que o jogo terminou;

* Conciliar tempo com trabalho atual, hoje temnho um emprego de 8 horas diárias e por isso só pude me dedicar entre 1 e 2 horas nos dias de semana;

* Utilizar novo input system em mobile, só havia utilizado anteriormente em builds para PC com teclado ou gamepad, aprendi que existem os componentes On-ScreenStick e OnScreenButton para mapear inputs em elementos da UI;

