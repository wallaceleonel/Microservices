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

        _Adapador_ - Adaptador de projeto estrutural que permite que  onjetos com interfaces imcompativeis se comunique 
        _Composto_ - Composto  é uma padrão que permite compor objetos em estruturas de árvore e depois trablhar com essas estruturas de forma informações individuais.
        _Proxy_ - Padrão estrutural  que fornce um espaço reservado ou substituto para outro objeto. Usando um proxy vc pode controlar o acesso ao objeto original, permitindo que vc faça algo antes e dps que a solicitação for entregue ao objeto original.
        _Flyweight_ - Permite encaixar objetos na RAM compartilhando partes comuns do estado entre vários objetos,em vez de manter todos os dados em cada um deles.
        _Fachada_ - Uma fachada é um padrão de objeto que fornce um interface simpliciada para uma biblioteca, uma estrutura ou qualquer outro conjunto de classes.
        _Bridge_ - Permite dividir uma classe grande ou um conjunto de classes intimament relacionadas em duas hierarquias separadas  - Abstração e implementação - que podem ser desenvolvidas independentement.
        _Decorator_ - Anexar novos componentes a objetos colocandos-os dentro de objetos wrapper especiais que contêm os novos comportamentos.