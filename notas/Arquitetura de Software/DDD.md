*DDD
 domain driven design* 


- DOMINIO

  Dominio e o coração do negocio que voce esta trabalhando, é baseado em conjunto de ideias conhecimento e processo de negocio, esse e o caração do negocio o motivo real do projeto existir ou seja DOMINO é a razado de um software existir.

 - Exploração de modelos criativos
    DDD  preza que os desenvolvedores façam parte do negocio, entender todo processo em seus mais diferços modelos ao inves de intrevistar especialistas ou seja o desenvolvedor tem que ser a peça que entende no negocio e que esta a no ciclo desses especialistar para evitar problemas de comunicação.
    *Geralmente não se usa DDD em aplicações simples pois não a diversas frentes ou diversos contextos de relações de negocio. 
    
 - Definir e falar a linguagem Ubiqua 
    Linguagem falada no dia dia, linguagem que usa as terminologias da empresa ou seja e a linguagem falada no dia dia da empresa. 


    - iniciado em 2003.
    - usado para comunicações complexas.
    - facil de entender.
    - dificil de aplicar.
    - ultiliza diversos padrões de projeto.

    ** 3 Pilares 

    -linguagem Ubiqua 
    -Bounded  Contexts (até a onde vai a responsabilidade de cada parte do sistema)
    -Context Maps(uma vez delimitado os contextos e possivel criar um mapa de relação de contextos)


    ***Linguagem Ubiqua*** 

        devs -- ----------
                          | -linguagem ubiqua 
        experts no        |
        negocio ----------
    
    Criar um manual de cominicação, escrito de facil acesso por todos para não ter confuções de comunicação durante o desenvolvimento do porjeto um glossário com terminologias do sistema que esta sendo modelado.

    ***Bounded Contexts***

    Os bounded Contexts ou contextos delimitados, delimita funções dentro de uma aplicação ou seja ate que ponto tal serviço e responsavel por alguma parte dentro do software. Responsabilidades como essas que são definidas de forma mais clara na linguagem ubiqua onde identifica fatores de comunicação chave ao se falar de tal serviço ou projeto dentro do negocio 
    Uma boa forma de identificar esses Bounded e criando uma historia doe projeto, funcionamento aplicação recursos e etc 
    Exemplo : simulação de entrada em um site como por exemplo netflix, acessar conta, acessar sessão de catalogos, olhar catalogo e escolher o player ou seja o filme.
     recursos como modelagem para dividir setores e conseguir vizuliar esses processo de forma idependnete como por exemplo o player de video com relação ao cadastro de login 
     aplicações destintas dentro do mesmo software.

     ***Context Map***

     O ultimo pilar se trata do mapa da nossa aplicação, ter definido um bom Bounded context é capaz de ver onde a aplicação começa como funciona e vonversa entre si com todos os processo e a onde e finalizada.
     Em nosso exemplo da galeria de filmes e possivel ver onde aplicações se iniciam como cadastro e login e a onde finalizam para que possa surgir novas, como catalogo de filmes e um filtro onde os organiza por sessão e logo após ter feito a escolha o player de filme que assume sendo esse o carro chefe da aplicação. 

     Percebmos em estruturas complexas e possivel criar uma mapara para se guiar dentro dos processo fornecidos pelo Software. 
