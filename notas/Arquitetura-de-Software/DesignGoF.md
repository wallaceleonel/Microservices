 - _Padrôes de design GoF para resolver problemas em design de software_

    " Um design  que não leva em consideração as mudanças corre o risco de uma grande reformulação no futuro "

    No projeto orientado a objetos, os padrões são soluções típicas para problemas comuns.
    Padrôes são como blueprints pré-fabricados durante o processo que se pode personalizar para resolver problemas recorrentes no codigo-fonte.Um padrão não e um bloco de codigo fixo mas sim uma idea de como desenvolver blocos de codigos especificos para cada problema.

    - _Classificação de padrões de projeto_

        Os padrões de design se dividem em três categorias principais:

        _Padrões de criação_ - Eles fornecem mecanismos de criação de objetos que aumentam a flexibilidade e a reutilização de código existente.

        _Padrões estruturais_ - Eles explicam como montar objetos e classes em  estruturas maiores, mantendo as estruturas flexíveis e eficientes.

        _Padrões comportamentais_ - Eles cuidam da comunicação eficaz e da atribuição de responsabilidades entre os objetos.

        img<src"\Microservices\notas\Arquitetura-de-Software\Gof.PNG" alling itens="center" margin="50px">

    - _Padrões de projeto estrutural_

        Um padrão de projeto estrutural mostra como montar objetos e classes em estruturas maiores, mantendo-os flexíveis e eficientes.

        Existem 7 padrões definidos pelo GoF:

        _Adapter_ - Adaptador de projeto estrutural que permite que  onjetos com interfaces imcompativeis se comunique 
        _Composite_ - Composto  é uma padrão que permite compor objetos em estruturas de árvore e depois trablhar com essas estruturas de forma informações individuais.
        _Proxy_ - Padrão estrutural  que fornce um espaço reservado ou substituto para outro objeto. Usando um proxy vc pode controlar o acesso ao objeto original, permitindo que vc faça algo antes e dps que a solicitação for entregue ao objeto original.
        _Flyweight_ - Permite encaixar objetos na RAM compartilhando partes comuns do estado entre vários objetos,em vez de manter todos os dados em cada um deles.
        _Facade_ - Uma fachada é um padrão de objeto que fornce um interface simpliciada para uma biblioteca, uma estrutura ou qualquer outro conjunto de classes.
        _Bridge_ - Permite dividir uma classe grande ou um conjunto de classes intimament relacionadas em duas hierarquias separadas  - Abstração e implementação - que podem ser desenvolvidas independentement.
        _Decorator_ - Anexar novos componentes a objetos colocandos-os dentro de objetos wrapper especiais que contêm os novos comportamentos.

    - _Padrões de design comportamental_

        Padrões comportamentais envolvem algoritmos e atribuição de responsabilidade entre objetos.

        Ecistem 11 padrões de design comportamentais definidos nos padrões de design GoF : 

        _Template method_ - Um método de modelo é um padrão de design comportamental que define o esqueleto de um algoritmo na superclasse, mas permite que as subclasses substituam etapas específicas sem modificar sua estrutua.
        _Mediador_ - Usando o mediador, vc pode reduzir dependências caóticas entre objetos. O padrão restinge a comunicação direta entre os objetos e os força a colaborar apenas por meio de um mediador.
        _Chain of Responsibility_ - As cadeias de responsabilidade permitem qu vc passe solictações, cada manipulador decide se deve processar a solicitação ou passá-la para o próximo manipulador de cadeia.
        _Observer_ - O padrãp de observador permite que vc defina um mecanismo para modificar vários objetos sobre eventos que ocorrem no objeto que es~tao oberservando.
        _Strategy_ - Usando a estratégia, vc pode definir uma familía de algoritmos, colocá-los em diferentes classes e tornar seus objetos intercambiáveis.
        _Command_ - Command é um padrão de design comportamental que transforma solicitações em objetos autônomos contendo todas as informações sobre eles. Com esssta transformação, vc pode parametrizar métodos com várias solicitações, atrasar ou enfileirar a execução de uma solicitação e oferecer suporte a operações reversíveis.
        _State_ - Como um padrão de design comportamental, o estado permite que um objeto mude seu comportamento qundo seu estado interno muda.
        Parece que o objeto mudou de classe.
        _Visitor_ - Usando o pradão de visitante, vc pode separar algoritimos dos objetos nos quais eles operam.
        _Interpreter_ - O intéprete é um padrão de design comportamental que define uma representação gramatical para uma linguagem e forncece um intérprete para lidar com essa gramática.
        _Iterador_ - Um padrão de design comportamental chamado interador permite percorrer elementos de uma coleção sem expor sua represenação subjacente.
        _Memento_ - O memento é um padrão de design comportamentaç que permite salvar erestaurar o estado anterior de um objeto sem revelar seus detalhes de implementação 