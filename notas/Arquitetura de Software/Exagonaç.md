- Funcionamento de arquitetura Exagonal 

Antes de introduzir este assunto,é necessario reforçar alguns pontos que é importante possuir 
um conhecimento previo;
**Domínio e o Pincipio da Inversão de Dependência**

-Domínio 
        forma logica de se refetir a toda logica do negocio seja regras ou processos.

-Principio da Inversão de dependencia ( inversão de controle )
        Este principio nos orienta e diz que devemos depender de abstrações,e não de implementações.
        Na pratica este conceito diz que em orientação a objtos, devemos fazer com que nossa classe ultilize intergaces para receber suas dependencias, e não classes.


 ***INVERSÃO NÃO É A MESMA COISA QUE INJEÇÃO DE DEPENDENCIA***

 Em um exemplo apresentado, verificamos dois casos em questão;

 - o primeiro caso apresenta dois erros pois viola os principios da inversão de dependencia,no exemplo apresentado o desenvolvendor atrela ao codigo o banco de dados, impossibilitando que o mesmo techo possa ser usado em outro momento pois naquela situação ele carrega uma dependencia, neste caso o banco 

 - O segunado caso apresenta o uso da pratica correta onde ao inves de declarar o banco de dados o desenvolvedor declara uma string de conexão, possibilitando então o uso do codigo em outro momento pois o mesmo não possui depedencias.


 **Arquitetura Exagonal**

 Também chamada de Ports and Adapters, a arquitetura hexagonal e uma forma de organizar o codigo em camadas, cada qual com a sua responsabilidade, seu objetivo principal e isolar a logica da aplicação do mundo externo.Esse processo e feito por meio de portas adaptadoras (Ports and Adapters), onde as portas são interfaçes que as camadas de baixo nivel expõe, e adaptadores as implementações para as interfaces em questão(ou seja inversão de dependencia).
img<>
 Isolamento da aplicação deve acontecer na entrada de dados  na saida o mesmo se aplica aos mecanismos de persistencia,envio de notificações e etc.
img<> 
 Pensando em uma situação problema que pode ocorrer com uma certa frequencia que é a migração de serviços para uma nova tecnologia ou o acrescimo de mais funcionalidades para a entrada de novos recursos, ou seja qual e o custo de modificações nos sistemas que não foram planejados para suprir necessidades de mudanças tecnologicas ? 
img<>
 Um sistema de software bem desehado pode ser responsavel por mais de 70% de todo o esforço de uma organização, de contra partida um software mal desenhado gera mais codigo para fazer as mesmas coisas.Um ponto importante a ser evitado para não ter esse tipo de atrito é a replicação de codigo,a importancia dessa pratica recai sobre futuras modificações.
 Um sistema hexagonal possui multiplas frentes podendo ter Adapters primarios e secundarios.
 img<>

 ***Arquitetura na pratica***

 Considerando um sitema de pedidos onde, a aplicação recebe requisições via HTTP e armazene em um banco de dados via ORM.
 Conforme apresentado, uma arquitetura hexagonal se ultiliza de portas e adaptadores tanto na entrada quanto na saida.

    -Entrada de dados 
        As requisições são recebidas no controller, e para que elas caiam na controller e necessario uma configuração nas rotas, configuração usada no exemplo foi route PHP 

        img <>

        no exemplo acima é mostrada a coniguração da porta HTTP, rotas e os objetos OrderService, que é injetada e ultilizada nessa solicitação 

        Se a requisição ultilizasse um protocolo difetente, a forma de entender e recuperar informações seriam diferentes 


    -Saída de dados 
        
        Considere domo porta uma interface de OrderRepository dornecida pela camada de domínio, e Adaptador a implementação da mesma.
        Utilizando como exemplo o método fromId, na linha 16 de OrderRepository: é importante que um identificador do tipo int seja enviado para o método, e uma instância da entidade Order seja devolvida. A forma como isso acontece não é relevante para o domínio, e deve ficar a cargo da infraestrutura do sistema. No nosso caso, utilizamos o Doctrine, que possui seu mapeamento de classe e métodos de manipulação de banco de dados, porém poderíamos ter utilizado um RedisOrderRepository, e consultado as informações deste banco in-memory, criando a instância de Order de outra forma.
        A abordagem de Portas e Adaptadores facilita uma troca futura de tecnologia, já que poderíamos fazer uso de um Service Provider para sempre devolver uma instância de DoctrineOrderRepository quando injetada a interface OrderRepository, e em uma eventual troca de tecnologia, só o Service Provider precisaria ser atualizado.



    ***Quando não usar***

        Como se pode ver a aquitetura exagonal possui diversos beneficios,porem não é em todos os casos que a mesma possui beneficios como foi dito acima.
        Em sistemas pequenos ou em estruturas que não serão modificadas ou dificilmente.
        Como em todo caso deve ser feito uma analise de viabilidade para resolver um problema, aquiteturas exagonais são uma forma de resolver problemas.