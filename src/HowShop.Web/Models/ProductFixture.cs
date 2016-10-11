using System.Collections.Generic;

namespace HowShop.Web.Models
{
    public class ProductFixture
    {
        public static Product CreateTelefone()
        {
            return new Product
            {
                Id = "Telefone",
                Sold = true,
                Title = "Telefone fixo com fio Intelbras",
                Price = 10,
                LocalThumbnail = "IMG_1374",
                RemoteImages = new List<string>() { "hfXnaOB", "5hX2Ha1" },
                RemoteThumbnail = "t2XYFE2",
                Description = @"
ESTADO:
Quase novo. Foi muito pouco usado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Podemos combinar.
No horário comercial fico na Asa Norte ao lado do Conjunto Nacional no horário comercial, nos outros horários no Guará I.
",
            };
        }

        public static Product CreateCama()
        {
            return new Product
            {
                Id = "Cama",
                Sold = true,
                Title = "Cama de Casal Box Com Base e Colchão",
                Price = 430,
                RemoteThumbnail = "07RZrE9",
                RemoteImages = new List<string> { "m9ZgCC7", "VlhfyQ1", "x5Vi3sh", "rdIyDK4", "d9Oj06Z" },
                LocalThumbnail = "IMG_1287",
                Description = @"
Kit Conjunto Box

* Base + Colchão
* Modelo Luckspuma Pocket New Luck Spring
* Tamanho 138x188
* Molas ensacadas tipo barril 
* Acompanha Nota Fiscal

Se o comprador quiser posso dar os travesseiros também.

ESTADO:
Dono único. Está bem conservado, com dois pequenos desgaste no colchão.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateSofa()
        {
            return new Product
            {
                Id = "Sofa",
                Sold = true,
                Title = "Sofá de 2 Lugares",
                Price = 270,
                LocalThumbnail = "IMG_1309",
                RemoteImages = new List<string> { "c95VvXx", "yMNMIhC", "YmNaDeZ", "2jqr2Wk", "SlSTVQx" },
                RemoteThumbnail = "1cv4vvj",
                Description = @"
Sofá de 2 Lugares. Acompanha 5 almofadas da Etna.

Acompanha Nota Fiscal

ESTADO:
Dono único e 6 anos de uso. Está bem conservado. O ziper de uma das almofadas está estragado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateFogao()
        {
            return new Product
            {
                Id = "Fogao",
                Sold = true,
                Title = "Fogão Atlas Tropical 4 Bocas + Gás",
                Price = 170,
                LocalThumbnail = "IMG_1293",
                RemoteImages = new List<string> { "aVeDlCZ", "vQrMjug", "DJDwU66", "qn96hm7"},
                RemoteThumbnail = "YsjvstC",
                Description = @"
Fogão Atlas Tropical 4 Bocas

* Elétrico
* Forno
* Válvula de segurança para ligar o Forno
* Acompanha Mangueira do Gás
* Acompanha Gás (deve estar no final)
* Nota Fiscal
* Manual

ESTADO:
Dono único e 6 anos de pouco uso. Está bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateGeladeira()
        {
            return new Product
            {
                Id = "Geladeira",
                Sold = true,
                Title = "Geladeira Consul 240",
                Price = 330,
                LocalThumbnail = "IMG_1298",
                RemoteImages = new List<string>() { "PY0kITz", "8rEemhS", "IYEYvy3", "bHhrbnp", "" },
                RemoteThumbnail = "WOsoaco",
                Description = @"
DISPONÍVEL:
A partir de 15/04

Geladeira Consul 240

240 litros

* 220v
* Freezer

ESTADO:
Está bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateLavadora()
        {
            return new Product
            {
                Id = "Lavadora",
                Sold = true,
                Title = "Máquina de Lavar Roupa Brastemp 9Kg",
                Price = 530,
                LocalThumbnail = "IMG_1304",
                RemoteImages = new List<string>() { "qHTDiyH", "Vx4UsCZ", "PRkxBye", "LyhAs1f", "pOxiOXN" },
                RemoteThumbnail = "gb56w15",
                Description = @"
DISPONÍVEL:
A partir de 15/04

Máquina de Lavar Roupa Brastemp 9Kg

Modelo Brastemp bwl09 9kg

* 220v
* Modo de Centrifugar
* Mecânica
* Acompanha Nota Fiscal
* Acompanha Manual

ESTADO:
Está bem conservado. 

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateAmplificador()
        {
            return new Product
            {
                Id = "Amp",
                Sold = true,
                Title = "Amplificador de Baixo Meteoro",
                Price = 330,
                LocalThumbnail = "IMG_1313",
                RemoteImages = new List<string> { "8H8Aj3B", "x3CXyON", "ILfj2JD", "IDEIS4Y" },
                RemoteThumbnail = "8Amhf2h",
                Description = @"
Amplificador de Baixo Meteoro

* Modelo Meteoro QX 200 Two Reverb 200w
* Entrada Low/High
* Reverb
* Chave manual para trocar 110v/220v

ESTADO:
O som está bom. A alça está sem um parafuso. Alguns botões de regulagem estão sem capa como você pode ver nas fotos, mas as regulagens estão funcionando.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateBota()
        {
            return new Product
            {
                Id = "Bota",
                Sold = true,
                Title = "Bota Imobilizadora Mercur G",
                Price = 40,
                LocalThumbnail = "IMG_1379",
                RemoteImages = new List<string> { "GOgOdlP", "MDuyIk3", "XXHwC9D", "bhtPPoT" },
                RemoteThumbnail = "hzXTLtf",
                Description = @"
Bota Imobilizadora Mercur

Tamanho Grande

ESTADO:
Bem conservado. Usado durante 20 dias.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateConjuntoCha()
        {
            return new Product
            {
                Id = "Cha",
                Sold = true,
                Title = "Conjunto de Chá da Turquia (Chay)",
                Price = 15,
                LocalThumbnail = "IMG_1370",
                RemoteImages = new List<string> { "8pI5BsM", "Ms9e40v", "JAjFdqz", "NPhP764" },
                RemoteThumbnail = "j14eBpD",
                Description = @"
Conjunto de Chá da Turquia (Chay)

* Contém 6 xicaras
* Comprado na Turquia (Istambul)

ESTADO:
Na caixa. Nunca foi usado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateCriadoGrande()
        {
            return new Product
            {
                Id = "CriadoGrande",
                Sold = true,
                Title = "Criado Mudo/Estante",
                Price = 70,
                LocalThumbnail = "IMG_1341",
                RemoteImages = new List<string> { "zIdQnUA", "HsIjyM5", "QWOjiiT", "rNF3hSf" },
                RemoteThumbnail = "9UmJB3G",
                Description = @"
Criado Mudo/Estante de madeira

ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateCriadoPequeno()
        {
            return new Product
            {
                Id = "CriadoPequeno",
                Sold = true,
                Title = "Criado Mudo/Estante Pequena",
                Price = 55,
                LocalThumbnail = "IMG_1345",
                RemoteImages = new List<string> { "BM20NCC", "GATZR7U", "sO1wP7a", "" },
                RemoteThumbnail = "OP6GSSQ",
                Description = @"
Criado Mudo/Estante Pequena

ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateEstante()
        {
            return new Product
            {
                Id = "Estante",
                Sold = true,
                Title = "Estante Para Livros Etna",
                Price = 120,
                LocalThumbnail = "IMG_1338",
                RemoteImages = new List<string> { "ijGEXvf", "SzADl3M", "TZICBRv" },
                RemoteThumbnail = "ein6r3l",
                Description = @"
Estante Para Livros da Etna

ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateLine6()
        {
            return new Product
            {
                Id = "Line6",
                Sold = true,
                Title = "Placa de Som/Gravador Digital Line 6 POD Ux1",
                Price = 170,
                LocalThumbnail = "IMG_1376",
                RemoteImages = new List<string>() { "glBKkzg", "3pOU8jF", "Kp9GXeM" },
                RemoteThumbnail = "RjPshAp",
                Description = @"
Placa de Som/Gravador Digital Line 6 POD Ux1

Interface USB com 1 entrada mic XLR, 1 entrada para guitarra e baixo, entrada de linha 1 e 2, 1 entrada de monitor estéreo, 1 saída para fones de ouvido, saída analógica 1 e 2, USB powered, conversores 24 Bit A/D & D/A, compatível com ASIO, WDM, Mac OS X, 44.1 & 48 KHz, 16 & 24 Bit na gravação, 96 KHz taxa de amostragem para conversão interna para entradas e saídas.

Acompanha CD do POD Farm 2 é o seu kit de equipamentos de estúdio virtual, possuindo as mesmas modelagens de amps e efeitos para guitarras, baixos e vocais de primeira linha do PODxt® 

ESTADO:

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateMemoria()
        {
            return new Product
            {
                Id = "Memoria",
                Sold = true,
                Title = "2 Pentes de Memória de 2GB Cada",
                Price = 50,
                LocalThumbnail = "IMG_1355",
                RemoteThumbnail = "DU3Mm6C",
                RemoteImages = new List<string>() { "xfIOSrH", "eEQWG5G"},
                Description = @"
2 pentes de Memória 2GB para Notebook da marca SMART

Vieram instaladas de fábrica em um notebook da DELL.

ESTADO:
Funcionando normalmente.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateMesa()
        {
            return new Product
            {
                Id = "Mesa",
                Sold = true,
                Title = "Mesa de Jantar com 4 Cadeiras",
                Price = 390,
                LocalThumbnail = "IMG_1349",
                RemoteThumbnail = "ESBy5N3",
                RemoteImages = new List<string>() { "Gurugqz", "NFFWqVp", "rsUqLNX", "DMFW08B", "O6GSdcj" },
                Description = @"
Mesa de jantar Rebeca/Bianca Capri 130x80 Tabaco

* Aproximadamente 130x80
* Tampo de vidro fosco
* 4 Cadeiras acolchoadas
* Acompanha Nota Fiscal

ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateNotebook()
        {
            return new Product
            {
                Id = "Notebook",
                Sold = true,
                Title = "Notebook Acer",
                Price = 320,
                LocalThumbnail = "IMG_1359",
                RemoteImages = new List<string>() { "r2tAmpJ", "1pJann8", "3gMjCbF", "zVDtfWV", "9qL5CCP", "YOXqfIx", "P21mp64", "1zHlIOX" },
                RemoteThumbnail = "DAy14yU",
                Description = @"
Notebook Acer Aspire 5100 

* Processador AMD Turion 64 x2 1.5 GHz
* HD de 260 GB (na foto aparece 120 GB mas foi trocada)
* Memória de 2 GB (na foto aparece 1 GB mas foi trocada)
* Wifi
* DVD

ESTADO:
Está funcionando normalmente. No Windows XP/Vista estava aparecendo umas manchas na tela de vez em quando. Hoje está rodando Linux (Lubuntu), e está perfeito.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateRack()
        {
            return new Product
            {
                Id = "Rack",
                Sold = true,
                Title = "Rack Provinci Torino Tabaco/Branco",
                Price = 110,
                LocalThumbnail = "IMG_1318",
                RemoteThumbnail = "Wu86RUM",
                RemoteImages = new List<string>() { "dI2e9Eg", "HZ9Pjgp", "fcsag0p" },
                Description = @"
DISPONÍVEL:
A partir de 15/04

Rack Provinci Torino Tabaco/Branco

Acompanha Nota Fiscal


ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateSuporteViolao()
        {
            return new Product
            {
                Id = "SuporteViolao",
                Sold = true,
                Title = "Suporte Para Violão/Guitarra/Baixo",
                Price = 50,
                LocalThumbnail = "IMG_1335",
                RemoteImages = new List<string>() { "rxY2mL3", "alLFy1C", "I8GzE6A" },
                RemoteThumbnail = "YPJqBiO",
                Description = @"
Suporte Para Violão/Guitarra/Baixo

ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateViolaoAco()
        {
            return new Product
            {
                Id = "ViolaoAco",
                Sold = true,
                Title = "Violão de Aço",
                Price = 140,
                LocalThumbnail = "IMG_1329",
                RemoteImages = new List<string>() { "NpsYr5M", "iey97J5", "S3hXdSo", "zAvGGJv" },
                RemoteThumbnail = "Dv8UWxa",
                Description = @"
Violão de Aço Tagima

* Cordas de aço
* Elétrico
* Acompanha Capa

ESTADO:
As cordas estão antigas. Tirando isso, o Violão está bom.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateRoteadorWifi()
        {
            return new Product
            {
                Id = "Wifi",
                Sold = true,
                Title = "Roteador Wifi Siroco",
                Price = 30,
                LocalThumbnail = "IMG_1366",
                RemoteImages = new List<string>() { "gGArOvp", "wTHxFNy", "ljsOR4T" },
                RemoteThumbnail = "NPoQUVM",
                Description = @"
Roteador Wifi Siroco

* Roteador Wireless
* 4 Portas Ethernet
* Fonte Bivolt
* Acompanha Manual
* Acompanha Nota Fiscal

ESTADO:
Bem conservado. Foi pouco usado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial.
",
            };
        }

        public static Product CreateArteDevAgil()
        {
            return new Product
            {
                Id = "Arte-Agil",
                Title = "A Arte Do Desenvolvimento Ágil",
                Price = 15,
                LocalThumbnail = "IMG_1366",
                RemoteImages = new List<string>() { "1BRewAq" },
                RemoteThumbnail = "UeYbRfK",
                Description = @"
“Deixarei uma cópia deste livro com cada equipe que eu visitar.”
—Brian Marick, Consultor de Padrões

Um guia prático para qualquer pessoa que esteja utilizando o desenvolvimento ágil para construir um software valioso, este livro descreve o que é o desenvolvimento ágil e por que ele ajuda os projetos de software a serem bem sucedidos. Combina informações para desenvolvedores, gerentes, testadores e clientes em um único pacote que pode ser diretamente aplicado.

A Arte do Desenvolvimento Ágil oferece uma visão completa do processo ágil, inclusive conselhos diretos sobre planejamento, desenvolvimento, entrega e gerenciamento baseados nos anos de experiência dos autores com Programação Extrema (XP). Este livro fornece práticas aplicadas para desenvolvedores e testadores, bem como informações para leitores não-técnicos. Os autores também tratam de um aspecto difícil do desenvolvimento ágil: desenvolver a cooperação e a confi ança entre os membros da equipe.

A Arte do Desenvolvimento Ágil fornece respostas claras para perguntas como:

* Como podemos adotar o desenvolvimento ágil?
* Precisamos, realmente, fazer programação em pares?
* Quais métricas devemos reportar?
* Como podemos fazer para que os clientes participem?
* Quanta documentação deve ser escrita?
* Quando projetar e arquitetar?
* Como não-desenvolvedor, como eu poderia trabalhar com uma equipe ágil?
* Onde está o roadmap do meu produto?
* Onde se encaixa a Garantia de Qualidade?
* Se você já faz parte de uma equipe ágil ou se está apenas interessado no desenvolvimento ágil, este livro traz as dicas práticas de que você precisa. Explica como adotar as práticas XP, descreve cada uma delas e discute princípios que permitem a você modifi car e criar seu método XP. Este livro crescerá com você, conforme você adquire experiência, primeiro ensinando as regras, depois, como quebrá-las e, fi nalmente, como abandonar as regras conforme você se aperfeiçoa na arte do desenvolvimento ágil.

ESTADO:
Bem conservado. Foi pouco usado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.
",
            };
        }

        public static Product CreateNaoMeFacaPensar()
        {
            return new Product
            {
                Id = "Nao-Me-Faca",
                Sold = true,
                Title = "Não Me Faça Pensar - Usabilidade na Web",
                Price = 10,
                RemoteImages = new List<string>() { "l1eIk2c" },
                RemoteThumbnail = "H2Ckdct",
                Description = @"
Livro - Não Me faça Pensar - Usabilidade na Web - 2ºed. - 100% colorido

Uma Abordagem de Bom Senso à Usabilidade na Web. Cinco anos e mais de 100 mil exemplares após ter sido publicado pela primeira vez, é difícil imaginar alguém trabalhando em projeto Web que não tenha lido o 'clássico instantâneo' de Steve Krug sobre usabilidade na Web; contudo, as pessoas ainda o estão descobrindo todos os dias. Nesta segunda edição, Steve acrescenta três novos capítulos no mesmo estilo do original: divertido e interessante, mas, ainda assim, cheio de informações e conselhos práticos, tanto para novatos quanto para veteranos. Não fique surpreso se ele mudar completamente a forma pela qual você pensa em projeto para Web.

ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.
",
            };
        }

        public static Product CreateMusicaNoCerebro()
        {
            return new Product
            {
                Id = "Musica-No-Cerebro",
                Title = "A Música no Seu Cerebro, A Ciência de Uma Obsessão Humana",
                Price = 10,
                RemoteImages = new List<string>() { "wMp31Rt" },
                RemoteThumbnail = "WPogY8P",
                Description = @"
Autor: Daniel J. Levitin

'A música no seu cérebro' pretende apresentar um estudo sobre a maneira como os seres humanos vivenciam os sons cotidianos e os motivos que fazem a música desempenhar um papel visto como importante. Com base em pesquisas sobre a relação cérebro e música, o autor busca mostrar uma compreensão do papel da música na evolução da espécie humana e como as preferências musicais começam a ser formadas antes do nascimento.

ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.
",
            };
        }

        public static Product ExtremeProgrammingKent()
        {
            return new Product
            {
                Id = "Extreme-Programming-Kent",
                Title = "Programação Extrema (XP) Explicada",
                Price = 10,
                RemoteImages = new List<string>() { "5G8A61H" },
                RemoteThumbnail = "ORb036R",
                Description = @"
ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Autor: 
Kent Beck

Amando ou odiando a XP, obra indispensável para desenvolvedores de software, pois lança um olhar diferente sobre a forma como o trabalho é desenvolvido. Concebida para abordar as necessidades específicas do desenvolvimento de software conduzido por equipes pequenas diante de requisitos vagos e instáveis.

Seção I
O Problema

Capítulo 1
Risco: O problema básico

Capítulo 2
Um episódio de desenvolvimento

Capítulo 3
A economia no desenvolvimento de software

Capítulo 4
Quatro variáveis

Capítulo 5
O custo das modificações

Capítulo 6
Aprendendo a dirigir

Capítulo 7
Quatro valores 

Capítulo 8
Princípios básicos

Capítulo 9
De volta ao básico


Seção II
A solução

Capítulo 10
Uma rápida visão geral

Capítulo 11
Como isso poderia dar certo?

Capítulo 12
Estratégias de gerenciamento

Capítulo 13
Estratégia de ambiente de trabalho

Capítulo 14
Dividindo as responsabilidades técnicas e de negócios

Capítulo 15
Estratégia de planejamento

Capítulo 16
Estratégia de desenvolvimento

Capítulo 17
Estratégia de projeto

Capítulo 18
Estratégia de testes



Seção III
Implementando a XP

Capítulo 19
Adotando a XP

Capítulo 20
Ajustando a XP

Capítulo 21
Ciclo de vida de um projeto XP ideal

Capítulo 22
Papéis para pessoas

Capítulo 23
A regra 20-80

Capítulo 24
O que torna a XP difícil

Capítulo 25
Quando você não deveria usar a XP

Capítulo 26
A XP em ação

Capítulo 27
Conclusão
",
            };
        }

        public static Product Beatlemania()
        {
            return new Product
            {
                Id = "Beatlemania",
                Sold = true,
                Title = "Beatlemania",
                Price = 15,
                RemoteImages = new List<string>() { "7K41jqs" },
                RemoteThumbnail = "pchYchh",
                Description = @"
ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

The Beatles: os rapazes de Liverpool que mudaram a história da música e, não por acaso, foram chamados de “Os Quatro Fabulosos” (The Fab Four) formaram a maior banda de rock de todos os tempos. John, Paul, George e Ringo protagonizaram uma evolução de comportamento social e musical jamais vista. George Martin, o lendário produtor dos Beatles, escreveu especialmente o prefácio deste livro. 'Beatlemania' não é uma biografia sobre os Beatles, mas um passeio histórico pela carreira do grupo, com fatos marcantes, curiosidades e histórias nunca antes reveladas.
",
            };
        }

        public static Product Discos()
        {
            return new Product
            {
                Id = "1001-Discos",
                Title = "1001 Discos para Ouvir Antes de Morrer",
                Price = 15,
                RemoteImages = new List<string>() { "I5zt2T2" },
                RemoteThumbnail = "tSdlFG4",
                Description = @"
ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Em '1001 discos para ouvir antes de morrer', 90 jornalistas e críticos de música apresentam uma seleção de álbuns que abrangem desde as origens do rock'n roll nos anos 50 aos sucessos contemporâneos. Cada álbum citado é contextualizado historicamente e os comentários sobre as músicas são acompanhados de curiosidades sobre as gravações, os bastidores ou a vida dos artistas.
",
            };
        }

        public static Product ChicoXavier()
        {
            return new Product
            {
                Id = "Chico-Xavier",
                Sold = true,
                Title = "As Vidas de Chico Xavier",
                Price = 10,
                RemoteImages = new List<string>() { "cU2Q6y1" },
                RemoteThumbnail = "iDRZcb1",
                Description = @"
ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Chico Xavier viveu seus 92 anos no limite. Com um pé na terra e outro no além, fechou os olhos e pôs no papel poemas, crônicas, mensagens. Em 2002, o médium que foi eleito um dos brasileiros mais importantes do século XX encerrou sua missão. Virou mito. Este livro traz sua história escrita pelo jornalista Marcel Souto Maior.
",
            };
        }

        public static Product DomainDrivenDesign()
        {
            return new Product
            {
                Id = "Domain-Driven-Design",
                Sold = true,
                Title = "Domain-Driven Design - Atacando as Complexidades no Coração do Software",
                Price = 20,
                RemoteImages = new List<string>() { "v7Sa5cA" },
                RemoteThumbnail = "jAPX826",
                Description = @"
ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Este livro visa oferecer aos leitores uma abordagem sistemática com relação ao domain-driven design, ou DDD, apresentando um conjunto de práticas de design, técnicas baseadas em experiências e princípios que devem facilitar o desenvolvimento de projetos de software que enfrentam domínios complexos. Reunindo práticas de design e implementação, o livro procura incorporar exemplos baseados em projetos que ilustram a aplicação do design dirigido por domínios no desenvolvimento de softwares na vida real.
",
            };
        }

        public static Product XpVinicius()
        {
            return new Product
            {
                Id = "Extreme-Programming-Vinicius",
                Title = "Extreme Programming",
                Price = 15,
                RemoteImages = new List<string>() { "V3CZDQ4" },
                RemoteThumbnail = "GIzktEq",
                Description = @"
ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Extreme Programming (XP) é um processo de desenvolvimento que possibilita a criação de software de alta qualidade, de maneira ágil, econômica e flexível. Vem sendo adotado com enorme sucesso na Europa, nos Estados Unidos e, mais recentemente, no Brasil.
O XP concentra os esforços da equipe de desenvolvimento em atividades que geram resultados rapidamente na forma de software intensamente testado e alinhado às necessidades de seus usuários. Além disso, simplifica e organiza o trabalho combinando técnicas comprovandamente eficazes e eliminando atividades redundantes. Por fim, reduz o risco dos projetos desenvolvendo software de forma interativa e reavaliando permanentemente as prioridades dos usuários.
Este livro apresenta o XP de forma didática e prática, com base na experiência do autor que o utilizou em projetos reais. As explicações combinam teoria, exemplos, ilustrações e metáforas que facilitam, a compreensão dos conceitos e fornecem um caminho seguro para que o leitor incorpore o XP ao seu dia-a-dia.
",
            };
        }

        public static Product CodigoLimpo()
        {
            return new Product
            {
                Id = "Codigo-Limpo",
                Sold = true,
                Title = "Código Limpo",
                Price = 15,
                RemoteImages = new List<string>() { "A7mj1kq" },
                RemoteThumbnail = "lOwjmsU",
                Description = @"
ESTADO:
Bem conservado.

PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Mesmo um código ruim pode funcionar. Mas se ele não for limpo, pode acabar com uma empresa de desenvolvimento. Perdem-se a cada ano horas incontáveis e recursos importantes devido a um código mal escrito. O especialista em software, Robert C. Martin, apresenta um paradigma com 'Código limpo - Habilidades Práticas do Agile Software.' O leitor poderá aprender a ler códigos e descobrir o que está correto e errado neles. 'Código limpo' está divido em três partes. Na primeira há diversos capítulos que descrevem os princípios, padrões e práticas para criar um código limpo. A segunda parte consiste em diversos casos de estudo de complexidade cada vez maior. Cada um é um exercício para limpar um código - transformar o código base que possui alguns problemas em melhores e mais eficientes. A terceira parte é a compensação - um único capítulo com uma lista de heurísticas e 'odores' reunidos durante a criação dos estudos de caso.
",
            };
        }

        public static Product UseCabecaOo()
        {
            return new Product
            {
                Id = "Use-Cabeca-Oo",
                Sold = true,
                Title = "Use a Cabeça! Análise & Projeto Orientado ao Objeto",
                Price = 15,
                RemoteImages = new List<string>() { "ywr2UCk" },
                RemoteThumbnail = "NYindwz",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Aqui você aprenderá a:

* Usar princípios da OO, como encapsulamento e delegação, para criar aplicações flexíveis.
* Aplicar o Princípio do Aberto-Fechado (OCP) e o Princípio da Responsabilidade Única (SRP) para promover a reutilização do seu código.
* Aprender como os princípios da OO, os padrões de projeto e as diferentes abordagens de desenvolvimento se ajustam ao ciclo de vida de um projeto AePOO.
* Usar UML, casos de uso e diagramas para garantir que todos os participantes estejam se comunicando com clareza para ajudar você a entregar o software correto e que atenda às necessidades de todos.
* Ao explorar o funcionamento do seu cérebro,
* Use a Cabeça A&POO diminui o tempo de aprendizado e de retenção de informações complexas. Você terá se divertido,aprendido e escreverá um grande software de forma consistente quando terminar de ler este livro!
",
            };
        }

        public static Product AndarBebado()
        {
            return new Product
            {
                Id = "Andar-Bebado",
                Sold = true,
                Title = "O Andar do Bêbado - Como o Acaso Determina Nossas Vidas",
                Price = 10,
                RemoteImages = new List<string>() { "tVNnRMz" },
                RemoteThumbnail = "uMOaGPC",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Não estamos preparados para lidar com o aleatório – e, por isso, não percebemos o quanto o acaso interfere em nossas vidas. Citando exemplos e pesquisas presentes em todos os âmbitos da vida, do mercado financeiro aos esportes, de Hollywood à medicina, Mlodinow apresenta de forma divertida e curiosa as ferramentas necessárias para identificar os indícios do acaso. Como resultado, nos ajuda a fazer escolhas mais acertadas e a conviver melhor com fatores que não podemos controlar. Prepare-se para colocar em xeque algumas certezas sobre o funcionamento do mundo e para perceber que muitas coisas são tão previsíveis quanto o próximo passo de um bêbado depois de uma noitada...
",
            };
        }

        public static Product DesenvolvimentoOrientadoOo()
        {
            return new Product
            {
                Id = "Desenvolvimento-Orientado-Oo",
                Sold = true,
                Title = "Desenvolvimento orientado por objectos - Domain-Driven Design, Testes Unitários e Refactoring",
                Price = 10,
                RemoteImages = new List<string>() { "SbJgYGq" },
                RemoteThumbnail = "SbJgYGq",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Desenvolvimento orientado por objectos - Domain-Driven Design, Testes Unitários e Refactoring
Autores: João Hugo Miranda, José António Almeida

INTRODUÇÃO

1.1 Objectivos e temática
   1.1.1 Objectivos 
   1.1.2 Algumas considerações
1.2 Audiência
1.3 Motivação
   1.3.1 O Desenho Planeado
   1.3.2 O Desenho Emergente
   1.3.3 Um Programador Completo
1.4 Organização

PARTE I

2 O OBJECTO
2.1 A História e a Filosofia dos Objectos
   2.1.1 Simula
   2.1.2 Smalltalk
   2.1.3 C++
   2.1.4 Java
   2.1.5 .Net 
2.2 O que são Objectos?
   2.2.1 Pensar em Objectos
2.3 Conceitos fundamentais
   2.3.1 Objecto
   2.3.2 Responsabilidade
   2.3.3 Mensagem 
   2.3.4 Interface
   2.3.5 Encapsulamento
   2.3.6 Polimorfismo
2.4 Pontos-chave

3 DOMAIN-DRIVEN DESIGN
3.1 Compreender o domínio do problema
   3.1.1 Comunicação eficiente
   3.1.2 A importância da Comunicação
3.2 Linguagem Ubíqua
   3.2.1 Uma linguagem omnipresente
   3.2.2 Uma língua comum em todo o Projecto
   3.2.3 Linguagem Ubíqua e Documentação
3.3 Elementos do domínio da solução
   3.3.1 Entidades (Entity)
   3.3.2 Objectos-Valor (Value Objects)
   3.3.3 Serviços (Services)
   3.3.4 Associações
   3.3.5 Módulos
3.4 Pontos-chave

PARTE II

4 DESENVOLVIMENTO TEST-DRIVEN 
 4.1 Testes Unitários
    4.1.1 Granularidade dos testes
    4.1.2 Quando implementar os testes?
    4.1.3 Reforço positivo
4.2 O que é Desenvolvimento Test-Driven?
   4.2.1 Um teste simples
   4.2.2 Mais um teste
   4.2.3 Alterações ao processo de desenvolvimento
4.3 Pontos-chave

5 DESENVOLVIMENTO TEST-DRIVEN AVANÇADO
5.1 Mock Objects
   5.1.1 Pesquisa de livros através de um web service
5.2 Injecção de dependências
   5.2.1 Injecção de dependências através do construtor
   5.2.2 Injecção de dependências através de uma propriedade
   5.2.3 Injecção de dependências através de injecção de interfaces
5.3 Mock Objects estáticos
   5.3.1 Persistência de livros
5.4 Quando utilizar Mock Objects?
5.5 Pontos-chave

6 DESENVOLVIMENTO DE INTERFACES DE UTILIZAÇÃO
6.1 Interfaces de Utilização
6.2 Model View Controller
6.3 Implementação de clientes Web 
   6.3.1 Page Controller
6.4 Implementação de clientes ricos
   6.4.1 Model View Presenter
6.5 Pontos-chave

7 INTRODUÇÃO AO REFACTORING
7.1 O que é o Refactoring?
   7.1.1 Refactorings mais comuns 
   7.1.2 As origens
   7.1.3 Pré-requisitos
   7.1.4 Refactoring Automático
7.2 Refactoring no Processo de Desenvolvimento 
   7.2.1 Refactoring e Desenho
   7.2.2 Refactoring e Performance
   7.2.3 Refactoring e Aplicações Legadas 
   7.2.4 Refactoring e Paradigmas não Orientados-a-Objectos
7.3 Pontos-chave

8 REFACTORING APLICADO
8.1 A aplicação Catálogo de Livros
8.2 Corrigindo Código Doente
   8.2.1 Métodos demasiado grandes
   8.2.2 Comentários
   8.2.3 Eliminando Métodos Longos e Comentários
   8.2.4 Código duplicado 
   8.2.5 Classes demasiado grandes
   8.2.6 Eliminando Código Duplicado e Classes grandes
   8.2.7 Alterações divergentes
   8.2.8 Eliminando alterações divergentes
   8.2.9 Longas listas de parâmetros
   8.2.10 Blocos de dados
   8.2.11 Eliminando longas listas de parâmetros e blocos de dados
   8.2.12 “Inveja” 
   8.2.13 Eliminando as “Invejas”
   8.2.14 Classe de Dados
   8.2.15 Eliminando Classes de Dados
   8.2.16 Obsessão por Primitivas
   8.2.17 Eliminando a obsessão por Primitivas
   8.2.18 Alterações Transversais 
   8.2.19 Eliminando alterações transversais
   8.2.20 Switches
   8.2.21 Eliminando Switches
   8.2.22 Generalização especulativa
8.3 Pontos-chave

9 CONCLUSÕES E PASSOS FUTUROS
9.1 O que aprendemos
   9.1.1 Os Objectos
   9.1.2 Domain-Driven Design
   9.1.3 Desenvolvimento Test-Driven
   9.1.4 Refactoring
9.2 Próximos passos
   9.2.1 Beber das fontes originais
   9.2.2 Padrões de Desenho e Refactoring
9.3 Palavras finais

REFERÊNCIAS

ÍNDICE REMISSIVO
",
            };
        }

        public static Product Startup()
        {
            return new Product
            {
                Id = "Guia-Startup",
                Sold = true,
                Title = "Guia da Startup",
                Price = 10,
                RemoteImages = new List<string>() { "PD4zSZS" },
                RemoteThumbnail = "bJHLTt2",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Guia da Startup: Como startups e empresas estabelecidas podem criar produtos web rentáveis
Joaquim Torres

Aprenda as melhores técnicas para criar o seu produto web e faça ele render dinheiro o mais rápido possível com o Guia da Startup. Da mesma maneira que diversas empresas de sucesso fizeram, como a Caelum e a Locaweb, invista em suas ideias.
",
            };
        }

        public static Product AnaliseFundamentalista()
        {
            return new Product
            {
                Id = "Analise",
                Title = "Análise Fundamentalista",
                Price = 10,
                RemoteImages = new List<string>() { "B6NlJEr" },
                RemoteThumbnail = "Ifb7k9E",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

ANALISE FUNDAMENTALISTA
Autor: KOBORI, JOSE

Este livro procura ensinar como obter confiança para investir em ações e tornar-se sócio neste mercado com segurança e rentabilidade, por meio de um aprendizado sobre as ferramentas utilizadas nele. Para tanto, o autor apresenta os métodos básicos utilizados pela análise fundamentalista.
",
            };
        }

        public static Product AvaliandoEmpresas()
        {
            return new Product
            {
                Id = "Analise",
                Title = "Avaliando Empresas, Investindo em Ações",
                Price = 10,
                RemoteImages = new List<string>() { "PTbWuRT" },
                RemoteThumbnail = "f1xM7Qr",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

AVALIANDO EMPRESAS, INVESTINDO EM AÇOES
Autor: RUSSO, FELIPE AUGUSTO
Autor: DEBASTIANI, CARLOS ALBERTO

'Avaliando Empresas, Investindo em Ações' é uma obra destinada a investidores que desejam conhecer os métodos de análise que integram a linha de trabalho da escola fundamentalista. Traz ao leitor o conhecimento dos elementos necessários a uma análise da saúde financeira das empresas, envolvendo indicadores de balanço e de mercado, análise de liquidez e dos riscos pertinentes a fatores setoriais e conjunturas econômicas nacional e internacional. Os autores exercitam os conceitos teóricos abordados, desde os fundamentos básicos da economia até a formulação de estratégias para investimentos de longo prazo.
",
            };
        }

        public static Product Toyota()
        {
            return new Product
            {
                Id = "Toyota",
                Title = "Toyota - a Fórmula da Inovação",
                Price = 10,
                RemoteImages = new List<string>() { "l76FNtn" },
                RemoteThumbnail = "GvZ87Kj",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Toyota - A Fórmula da Inovação
Autor: Matthew May

A Toyota é hoje uma das três maiores empresas automobilísticas dos Estados Unidos, de acordo com o New York Times fato que era inimaginável há uma década. Neste livro, Matthew May e Kevin Roberts revelam como a filosofia da inovação baseada na equipe e em práticas criativas de negócios têm feito da Toyota uma empresa vencedora. A fórmula desse sucesso é baseada em princípios e práticas bem definidos, e guia a empresa pelo caminho da criatividade - com mais de um milhão de idéias vindas de funcionários implementadas a cada ano.

Apresentando a fórmula de sucesso de uma empresa que deu a volta por cima e voltou a ser líder, este livro é uma fonte de motivação para executivos e empresários que desejam revitalizar sua empresa.
",
            };
        }

        public static Product GoogleFaria()
        {
            return new Product
            {
                Id = "Google-Faria",
                Sold = true,
                Title = "O que a Google Faria?",
                Price = 10,
                RemoteImages = new List<string>() { "U3ywpiD" },
                RemoteThumbnail = "U3ywpiD",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

O que a Google Faria ?
Jarvis, Jeff

O sucesso da Google é singular. É a primeira empresa pós-mídia. É uma rede e uma plataforma. Neste livro, Jeff Jarvis mostra como pensar de maneiras novas, enfrentar novos desafios, resolver problemas com novas soluções, ver novas oportunidades e entender com outra perspectiva a estrutura da economia e da sociedade, ou seja, ver o mundo como a Google o faz. 
Ao longo da obra, o autor interpreta as regras ditadas pela Google com as quais devemos viver e fazer negócios em qualquer setor da sociedade, ilustra como essas leis podem ser aplicadas a diferentes empresas e analisa como o pensamento Google está afetando nossas vidas e o futuro.
",
            };
        }

        public static Product DarkSide()
        {
            return new Product
            {
                Id = "Dark-Side",
                Title = "The Dark Side of the Moon - os Bastidores da Obra-prima",
                Price = 10,
                RemoteImages = new List<string>() { "68V882j" },
                RemoteThumbnail = "z5qKIeE",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

The Dark Side of the Moon - Os Bastidores da Obra-prima do Pink Floyd
Harris, John

Um disco histórico que permanece no gosto das mais diferentes gerações e continua a ser ouvido nos lugares mais distantes do mundo.
As curiosidades, os bastidores e todo o processo de produção de The Dark Side of the Moon (1973) são revelados nessa obra, que inclui imagens inéditas e entrevistas exclusivas com os integrantes da banda. 
A superação da saída de Syd Barrett; o ambiente no estúdio; a integração das canções para formar um todo homogêneo; os truques tecnológicos para criar sons até então inimagináveis; a sensibilidade para resumir os sentimentos da juventude; tudo isso e a incrível universalidade dos temas abordados constituem a matéria desse livro - que fornece ao leitor a chave do mistério de Dark Side of the Moon.
",
            };
        }

        public static Product BeatlesCancoes()
        {
            return new Product
            {
                Id = "Beatles-Cancoes",
                Sold = true,
                Title = "The Beatles: a História por Trás de Todas as Canções ",
                Price = 10,
                RemoteImages = new List<string>() { "2nzmJib" },
                RemoteThumbnail = "XKFhHnN",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

The Beatles: a História por Trás de Todas as Canções 
Steve Turner

São 208 músicas gravadas pelos artistas mais influentes do século XX. São 208 histórias explicando a mágica de cada uma delas. O que o jornalista musical, biógrafo e poeta inglês Steve Turner faz em 'The Beatles - A História Por Trás de Todas as Canções' não é explicar os significados ou bastidores técnicos das composições da banda. Sua proposta é mostrar como elas nasceram e como todas têm histórias para contar, como se apropriam das pequenas frases soltas no dia-a-dia e dos eventos de canto de página nos jornais. Em cerca de 380 páginas e mais de 100 ilustrações coloridas, a edição não é só um compêndio das histórias das canções mais importantes do século passado, mas das histórias dos anos 1960.
",
            };
        }

        public static Product BemVindoBolsa()
        {
            return new Product
            {
                Id = "Bolsa",
                Title = "Bem-vindo À Bolsa de Valores",
                Price = 10,
                RemoteImages = new List<string>() { "WObtMoP" },
                RemoteThumbnail = "XE47vXC",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Bem-vindo À Bolsa de Valores
Piazza, Marcelo C.

Você já pensou em investir em ações, mas desistiu só de imaginar a agitação e o universo, aparentemente incompreensível, de gráficos e números da Bolsa de Valores? Achou que era preciso ter muito dinheiro para começar? Então, saiba que investir em ações é um processo simples, independente, e que qualquer pessoa pode participar desse mercado. Este livro, exclusivo para iniciantes, vai lhe ajudar a compreender o mecanismo dos investimentos, de forma fácil e rápida, para que você consiga comprar e vender ações através da internet.
",
            };
        }

        public static Product TeachCPlusPlus()
        {
            return new Product
            {
                Id = "CPlusPlus",
                Title = "Teach Yourself C++ in 21 Days",
                Price = 10,
                RemoteImages = new List<string>() { "lt7jAmh" },
                RemoteThumbnail = "hf1WJH4",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Sams Teach Yourself C++ In 21 Days
Jesse Liberty, 2002

1 Getting Started with C
2 The Components of a C Program
3 Storing Information: Variables and Constants
4 Statements, Expressions, and Operators
5 Functions: The Basics
6 Controlling Your Program’s Order of Execution
7 Fundamentals of Reading and Writing Information
8 Using Numeric Arrays
9 Understanding Pointers
10 Working with Characters and Strings
11 Implementing Structures, Unions, and TypeDefs
12 Understanding Variable Scope
13 Advanced Program Control
14 Working with the Screen, Printer, and Keyboard
15 Pointers: Beyond the Basics
16 Using Disk Files
17 Manipulating Strings
18 Getting More from Functions
19 Exploring the C Function Library
20 Working with Memory
21 Advanced Compiler Use
",
            };
        }

        public static Product Tdd()
        {
            return new Product
            {
                Id = "TDD",
                Sold = true,
                Title = "Desenvolvimento de Software Orientado a Objetos, Guiado por Teste",
                Price = 15,
                RemoteImages = new List<string>() { "BQXCkIM" },
                RemoteThumbnail = "dS5VVxn",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

Desenvolvimento de Software: Orientado a Objetos, Guiado por Testes
Steve Freeman e Nat Pryce

O livro aponta os desafios que as equipes de desenvolvimento enfrentam em relação a TDD – desde integrá-lo em seus processos a testar os seus recursos mais difíceis. A abordagem inclui:

- A implementação efetiva de TDD: começando e mantendo o pique durante o projeto;
- A criação de um código mais claro, expressivo e mais sustentável;
- O uso de testes para focalizar intensamente a manutenção de qualidade;
- A compreensão de como TDD, Objetos Simulados e Projetos Orientados a Objetos se unem no contexto do desenvolvimento de um projeto real de desenvolvimento de software;
- Uso de Objetos Simulados para guiar Projetos Orientados a Objetos;
- Como superar dificuldades de TDD: administração de dados de teste complexos e teste da persistência e simultaneidade.
",
            };
        }

        public static Product JeitoWarren()
        {
            return new Product
            {
                Id = "Warren-Buffet",
                Sold = true,
                Title = "O Jeito de Warren Buffett de Investir",
                Price = 10,
                RemoteImages = new List<string>() { "sYLA8Gt" },
                RemoteThumbnail = "SXyLrDL",
                Description = @"
PAGAMENTO:
À vista em dinheiro.

RETIRADA:
Buscar no Guará I em horário não comercial ou combinar retirada na Asa Norte ao lado do Conjunto Nacional.

O Jeito de Warren Buffett de Investir - Os Segredos do Maior Investidor do Mundo
Hagstrom, Robert G.

O livro contém o pensamento e a filosofia de um investidor que consistentemente ganhou dinheiro utilizando ferramentas disponíveis a qualquer pessoa, independentemente de sua situação financeira. Na obra, serão apresentados os 12 princípios atemporais que orientam a filosofia de investimentos de Buffett em todas as circunstâncias e em todos os mercados, sendo válidos para instruir qualquer investidor
",
            };
        }
    }
}