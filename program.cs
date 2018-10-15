using System;
using System.Collections;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://msdn.microsoft.com/pt-br/library/cc564861.aspx
            Console.WriteLine("Trabalhando com Arrays");
            Console.WriteLine("SortedList");
            SortedList();
            Console.WriteLine("QUEUE");
            QUEUE();
            Console.WriteLine("STACK");
            STACK();
            Console.WriteLine("ArrayList");
            ArrayList();
            //https://www.devmedia.com.br/csharp-trabalhando-com-arrays/38596
            Console.WriteLine("ExemploDevMedia");
            ExemploDevMedia();
            //http://www.linhadecodigo.com.br/artigo/1295/serie-aprenda-csharp-arrays-em-csharp.aspx
            Console.WriteLine("ArrayUnidimensionalVetor");
            ArrayUnidimensionalVetor();
            ArrayBidimensionalMatriz();
            PercorrendoArrayForeach();
            //http://www.macoratti.net/10/05/c_arrays.htm
            MacorattiArrays();
        }

        /// <summary>
        /// Este é sem duvida um dos mais poderosos “contrutores” de arrays, por assim dizer, possibilita a concatenação de strings e obedece a cadeia conhecida como FIFO 
        /// (First Intput, First OutPut – primeiros que entra, primeiro que sai) nada muito diferente do que já conhecemos hoje, porém com algumas vantagens.
        /// </summary>
        static void QUEUE()
        {
            //1)Não foi necessário indicar o tamanho da variável, ou seja, ela se dimensiona de acordo com sua necessiadade
            //2)Não foi necessário um contador para indicar até quando nosso while deveria estar imprimindo o conteúdo de nossa array de strings, 
            //porque isso é totalmente controlado pelos processos herdados do QUEUE desde a classe Collections. 

            //Método mais utilizado o Enqueue que permite a concatenação nas posições subseqüentes de nossa array, 
            //abaixo está o Dequeue que possibilita a retirada de valores de nossa array obedecendo a ordem FIFO.
            Queue qInteiros = new Queue();
            qInteiros.Enqueue("Ganhador 1");
            qInteiros.Enqueue("Ganhador 2");
            qInteiros.Enqueue("Ganhador 3");
            qInteiros.Enqueue("Ganhador 4");
            qInteiros.Enqueue("Ganhador 5");
            while (qInteiros.Count != 0)
                Console.WriteLine(qInteiros.Dequeue().ToString());
            //DEQUEUE, remove literalmente os dados de nossa array, não permitindo uma nova impressão do conteúdo de nosso array, 
            //para que você possa extrair os dados de um QUEUE, você poderá utilizar o método PEEK(), que extrai o conteúdo de nosso array sem removê-lo literalmente 
            //de nossa variável.

            //pode fazer uma consulta a seu array e descobrir que determinada string está contida e nosso array, utilizando apenas o método CONTAINS, por exemplo:
            qInteiros.Contains("Ganhador 5"); //Devolverá TRUE
            qInteiros.Contains("CSHARP"); //Devolverá FALSE
            qInteiros.Contains("ganhador 5"); //Devolverá FALSE–ele É “sensitive case”
        }

        /// <summary>
        /// Sorted List
        /// O “Sorted List”, conforme o próprio nome diz, serve para trabalharmos com listas ordenadas dentro de nosso array, mas nos permite mais que isso, 
        /// permite também que você possa acessar ao conteúdo através de um Label e não mais através de um Índice, o que pode em alguns momentos de nossa codificação ser muito, 
        /// muito interessante.Para este Objeto herdado de nosa Classe System.Collections, existem dois métodos importantes que vamos estudar agora, 
        /// e que são a chave para o bom uso do Tipo SortedList de nossa classe Collections.        
        /// KEY e Value - Que conforme os próprios nomes me ingles indicam, são as chaves que nos servirão para buscas dentro de nosso array e os valores dentro de nosso array.
        /// </summary>
        static void SortedList()
        {
            SortedList Paises = new SortedList();

            //Preenchendo nossa lista, voce adicina a chave de busca e o valor que você 
            //deseja estar armazenando em nossa Array
            Paises.Add("Brasil", 0);
            Paises.Add("Espanha", 1);
            Paises.Add("Alemanha", 2);
            Paises.Add("Mexico", 3);
            Paises.Add("Italia", 4);
            //Este código remove a Alemanha de nossa lista e o ForEach imprimirá apenas 
            //os outros paises, redimensionando sem necessidade de código, nossa array.
            Paises.Remove("Italia");
            foreach (DictionaryEntry locais in Paises)
                //Observe que a lista foi impressa, agora não com o FIFO ou LIFO e sim de forma ordenada através da propriedade KEY de nossa Lista
                Console.WriteLine(locais.Key.ToString() + "=" + locais.Value.ToString());
            //Resultado do Código acima -> É impresso o Key Espanha porque ela é quem contem o índice numero 2(dois) 
            //já com a lista ordenada. [0]=Alemanha, [1]=Brasil, [2]=Espanha.
            Console.WriteLine(Paises.GetKey(2).ToString());
        }

        /// <summary>
        /// O STACK possui os mesmos métodos do QUEUE porém ele ao invés de utilizar o ENQUEUE, utiliza o Push! 
        /// E ao invés de utilizar o DEQUEUE, utiliza o POP. E ao invés de utilizar-se do método FIFO – como no QUEUE – utiliza-se do método de enfileiração LIFO 
        /// (Last Input First OutPut – Ultimo que entra, primeiro que sai) .
        /// </summary>
        static void STACK()
        {
            Stack scArray = new Stack();
            scArray.Push("Ganhador 1");
            scArray.Push("Ganhador 2");
            scArray.Push("Ganhador 3");
            scArray.Push("Ganhador 4");
            scArray.Push("Ganhador 5");
            while (scArray.Count != 0)
                //Resultado do uso do STACK, observe que foi aplicado o LIFO como ordem de impressão e captura dos dados (Last Input, First OutPut)
                Console.WriteLine(scArray.Pop().ToString());
        }

        /// <summary>
        /// Uma das características do ArrayList é a possibilidade de redimensionar-se de acordo com a necessidade, sem que tenhamos que indicar previamente seu tamanho, 
        /// a possibilidade de trabalharmos com o Valor de nosso Array e com o Índice de nosso Array também é muito interessante e economiza sem duvida muito trabalho 
        /// no momento em que desejamos, por exemplo, remover um valor de nosso array.
        /// </summary>
        static void ArrayList()
        {
            ArrayList Extenso = new ArrayList();
            Extenso.Add("UM");
            Extenso.Add("DOIS");
            Extenso.Add("TRES");
            Extenso.Add("QUATRO");
            Extenso.Add("CINCO");
            Extenso.Add("SEIS");
            for (int contador = 0; contador != Extenso.Count; contador++)
                Console.WriteLine(Extenso[contador].ToString());
            Extenso.Remove("CINCO");//Removemos o Índice que contem o valoro “CINCO”
            Extenso.RemoveAt(2); //Removemos o Índice 2, independente de seu valor
            for (int contador = 0; contador != Extenso.Count; contador++)
                Console.WriteLine(Extenso[contador].ToString());
        }

        /// <summary>
        /// Arrays são coleções de dados extremamente importantes em qualquer linguagem de programação. Sua grande vantagem está no fato de serem estruturas indexadas, 
        /// ou seja, os itens dos arrays podem ser acessados através de índices, o que garante grande velocidade para essas operações.
        /// </summary>
        static void ExemploDevMedia()
        {
            //Declaração de arrays
            //tipo[] nomeDoArray = new tipo[tamanho_do_array];
            int[] array = new int[10];

            //Inserção de dados no array
            int[] array1 = new int[5] { 1, 3, 7, 12, 8 };// declaração explícita
            int[] array2 = { 1, 3, 2, 7, 6 }; //implícita 
            int[] array3 = new int[50];
            for (int i = 0; i < 50; i++)//através de seu índice
            {
                array3[i] = i + 1;
            }

            //Acesso aos dados do array
            Console.WriteLine(array[10]);//acessarmos o índice específico

            //Iterações sobre os arrays
            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine(array[j]);
            }

            int k = 0;
            while (k < 10)
            {
                Console.WriteLine(array[k]);
                k++;
            }

            foreach (int l in array)
            {
                Console.WriteLine(l);
            }

            //Exemplo Pratico
            string[] pilotos = new string[4] { "Ayrton Senna", "Michael Schumacher", "Lewis Hamilton", "Alain Prost" };
            Console.WriteLine(pilotos[3]);
            Console.WriteLine();
            pilotos[3] = "Rubens Barrichello";
            foreach (string piloto in pilotos)
            {
                Console.WriteLine(piloto);
            }
        }
        /// <summary>
        /// Array Unidimensional – Vetor
        ///  um vetor é um array de uma única dimensão.
        /// </summary>
        static void ArrayUnidimensionalVetor()
        {
            //A sintaxy da declaração é simples colocamos o tipo que queremos que o nosso array(vetor) se torne e a frente abrimos e fechamos colchetes([]) e 
            //damos um nome(neste caso ‘carros’).
            string[] carros; //Array somente declarado, não inicializado e nem criado efetivamente

            carros = new string[3]; // vetor com 3 elementos, aqui estamos criando-o efetivamente
            //as posições de um vetor é acessada através de um Índice que sempre começa com zero, veja:
            carros[0] = "Palio";
            carros[1] = "Corsa";
            carros[2] = "Gol";

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(carros[i].ToString());
            }

        }

        /// <summary>
        /// Array Bidimensional Matriz
        /// array de duas dimensões
        /// </summary>
        static void ArrayBidimensionalMatriz()
        {
            int[,] array = new int[2, 2];

            array[0, 0] = 1;
            array[0, 1] = 2;
            array[1, 0] = 3;
            array[1, 1] = 4;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine(array[i, j].ToString());
                }
            }
        }

        static void PercorrendoArrayForeach()
        {
            int[] array = new int[2];

            array[0] = 1;
            array[1] = 2;

            foreach (int valor in array)
            {
                Console.WriteLine(valor.ToString());
            }
        }

        /// <summary>
        ///  Um Array é um conjunto de elementos de um mesmo tipo de dados onde cada elemento do conjunto é acessado pela posição no array que é dada através de um índice
        ///  (uma sequência de números inteiros).  Um array de uma dimensão é também conhecido como vetor,e , um array de mais de uma dimensão e conhecido como uma matriz.
        ///  Um array é uma estrutura de dados que contém uma série de dados ordenados, chamados "elementos". Os elementos são referenciados por número ordinal (índice), 
        ///  primeiro elemento é 1, segundo 2, etc. Os elementos podem ser de qualquer tipo, string, caractere, numérico, data, etc.
        /// </summary>
        static void MacorattiArrays()
        {
            //Declarando Arrays em C#
            //Na linguagem C#  os arrays possuem o índice com base zero, ou seja, o primeiro elemento do array possui o índice zero (0).
            //Um array de uma dimensão é declarado informando o tipo de dados do array seguido do nome do array, lembrando que devemos colocar colchetes([]) 
            //depois do tipo do array e não após o seu nome:
            //int[] tabela; ==> correto     int tabela[];  ==> incorreto
            //Na linguagem C# o tamanho do arrray não é parte do seu tipo, isso permite declarar uma array e em seguida atribuir qualquer array de objetos int a ele, sem considerar o seu tamanho:

            int[] numeros;         //declara numeros como um array de inteiros de qualquer tamanho
            numeros = new int[10]; // numeros agora é um array de 10 elementos
            numeros = new int[20]; // numeros agora é um array de 20 elementos

            //Além de arrays de uma dimensão a linguagem C# suporta os seguintes tipos de arrays:
            
            // - Arrays com mais de uma dimensão:
            string[,] nomes;
            int[,] array = new int[2, 2];

            // - Array - of - arrays(jagged):
            byte[][] resultados;
            int[][] numArray = new int[][] { new int[] { 1, 3, 5 }, new int[] { 2, 4, 6, 8, 10 } };

            //Criando e inicializando um Array
            string[] nomes2;         //array nomes de qualquer tamanho, mas isso não cria o array para fazer isso devemos declarar:
            nomes2 = new string[5];  //array de strings de 5 elementos 

            //finalmente para incializar o array fazemos assim:
            nomes2[0] = "José";
            nomes2[1] = "Carlos";
            nomes2[2] = "Macoratti";
            nomes2[3] = "Miriam";
            nomes2[4] = "Estela";
            
            //Para um array de mais de uma dimensão a sintaxe usada pode ser:
            string[,] nomes3 = new string[5, 4];   //declara um array bidimensional com 5 linhas e 4 colunas

            //1 - Uma Dimensão
            //definindo o tamanho e o operador new
            int[] numeros2 = new int[5] { 1, 2, 3, 4, 5 };
            string[] nomes4 = new string[3] { "Mac", "Jessica", "MiMi" };
            //omitindo o tamanho do array
            int[] numeros3 = new int[] { 1, 2, 3, 4, 5 };
            string[] nomes5 = new string[] {"Mac", "Jessica", "MiMi"};
            //Omitindo o operador new
            int[] numeros4 = { 1, 2, 3, 4, 5};
            string[] nomes6 = { "Mac", "Jessica", "MiMi" };

            //2- Mais de uma Dimensão
            //definindo o tamanho e o operador new
            int[,] numeros5 = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            string[,] nomes7 = new string[2, 2] { { "Mac", "Jan" }, { "Mimi", "Jeff" } };
            // omitindo o tamanho do array
            int[,] numeros6 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            string[,] nomes8 = new string[,] { { "Mac", "Jan" }, { "Mimi", "Jeff" } };
            //Omitindo o operador new
            int[,] numeros7 = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            string[,] nomes9 = { { "Mac", "Jan" }, { "Mimi", "Jeff" } };

            //3- Arrays de Arrays (jagged arrays)
            //definindo o tamanho e o operador new
            int[][] numeros8 = new int[2][] { new int[] { 2, 3, 4 }, new int[] { 5, 6, 7, 8, 9 } };
            //omitindo o tamanho do array
            int[][] numeros9 = new int[][] { new int[] { 2, 3, 4 }, new int[] { 5, 6, 7, 8, 9 } };
            int[][] numeros10 = { new int[] { 2, 3, 4 }, new int[] { 5, 6, 7, 8, 9 } };

            //Acessando e percorrendo Arrays
            //array de uma dimensao
            int[] numeros11 = { 10, 9, 8, 7, 6 };
            Console.WriteLine("Primeiro elemento: " + numeros11[0]);
            Console.WriteLine("Segundo elemento: " + numeros11[1]);
            Console.WriteLine("Terceiro elemento: " + numeros11[2]);
            Console.WriteLine("Quarto elemento: " + numeros11[3]);
            Console.WriteLine("Quinto elemento: " + numeros11[4]);

            //Para um array de mais de uma dimensão somente temos que definir os demais índices do array. No exemplo a seguir eu declaro um array bidimensional 
            //chamado numeros2 e a seguir crio e inicio o array com 5 elementos:
            int[,] numeros12 = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 }, { 9, 10 } };
            Console.WriteLine("numeros2[0,0] = " + numeros12[0, 0]);
            Console.WriteLine("numeros2[0,1] = " + numeros12[0, 1]);
            Console.WriteLine("numeros2[1,0] = " + numeros12[1, 0]);
            Console.WriteLine("numeros2[1,1] = " + numeros12[1, 1]);
            Console.WriteLine("numeros2[2,0] = " + numeros12[2, 0]);
            Console.WriteLine("numeros2[2,1] = " + numeros12[2, 1]);
            Console.WriteLine("numeros2[3,0] = " + numeros12[3, 0]);
            Console.WriteLine("numeros2[3,1] = " + numeros12[3, 1]);
            Console.WriteLine("numeros2[4,0] = " + numeros12[4, 0]);
            Console.WriteLine("numeros2[4,1] = " + numeros12[4, 1]);

            //Para atribuir valores a uma posição do array eu também uso os índices.Assim temos:
            int[,] matriz3x3 = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

            //Outro exemplo de array bidimensional:
            string[,] livros = {
                                {"Macbeth", "Shakespear", "ID12341"},
                                {"1984", "George Owell", "ID234234"},
                                {"ASP - Internet ", "Macoratti", "ID3422134"}
                               };

            //A classe Array fornece propriedades e métodos para criar, manipular, procurar e ordenar arrays. Abaixo temos os mais importantes:
            string[] Cores = { "vermelho", "verde", "amarelo", "laranja", "azul" };
            // 1 - Propriedades
            Console.WriteLine("IsFixedSize - Retorna um valor indicando se um array possui um tamanho fixo ou não.");
            if (Cores.IsFixedSize)
            {
                Console.WriteLine("O array e fixo");
                Console.WriteLine(" tamanho => (Cores.Lenght) = " + Cores.Length);
                Console.WriteLine(" intervalo => (Cores.Rank) = " + Cores.Rank);
            }
            Console.WriteLine("IsReadOnly - Retorna um a valor indicando se um array é somente - leitura ou não.");
            Console.WriteLine("IsSynchronized - Retorna um a valor que indica se o acesso a um array é thread - safe ou não.");
            Console.WriteLine("Length - Retorna o número total de itens em todas as dimensões de um array");
            int qtd = Cores.Length;
            Console.WriteLine("Rank - Retorna o número de dimensões de um array");
            Console.WriteLine("SyncRoot - Retorna um objeto que pode ser usado para sincronizar o acesso a um array.");
            //2 - Métodos
            Console.WriteLine("BinarySearch - Procura em um array unidimensional ordenado por um valor usando o algoritmo de busca binário.");
            object oCor = "verde";
            int retorno = Array.BinarySearch(Cores, oCor);
            if (retorno >= 0)
                Console.WriteLine("Indice do Item " + retorno.ToString());
            else
                Console.WriteLine("Item nÆo localizado");
            Console.WriteLine("Clear - Remove todos os itens de um array e define um intervalo de itens no array com valor zero.");
            Console.WriteLine("Clone - Cria uma cópia do Array.");
            Console.WriteLine("Copy - Copia uma seção de um array para outro array e realiza a conversão de tipos e boxing requeridas.");
            Console.WriteLine("CopyTo - Copia todos os elementos do array unidimensional atual para o array unidimensional especificado iniciando no índice de destino especificado do array.");
            Console.WriteLine("CreateInstance - Inicializa uma nova instância da classe Array.");
            Console.WriteLine("GetEnumerator - Retorna um IEnumerator para o Array.");
            Console.WriteLine("GetLength - Retorna o número de itens de um Array.");
            Console.WriteLine("GetLowerBound - Retorna o primeiro item de um Array.");
            Console.WriteLine("GetUpperBound - Retorna o último item de um Array.");
            for (int j = Cores.GetLowerBound(0); j <= Cores.GetUpperBound(0); j++)
            {
                Console.WriteLine("Cores[0] = " + j + " " + Cores[j]);
            }
            Console.WriteLine("GetValue - Retorna o valor do item especificado no  Array.");
            Console.WriteLine("IndexOf - Retorna o índice da primeira ocorrência de um valor em um array de uma dimensão ou em uma porção do Array.");
            int ind = Array.IndexOf(Cores, "verde");
            Console.WriteLine("O índice do item 'verde' e " + ind);
            Console.WriteLine("LastIndexOf - Retorna o índice da última ocorrência de um valor em um array unidimensional ou em uma  porção do Array.");
            Console.WriteLine("Reverse - Reverte a ordem de um item em um array de uma dimensão ou parte do array.");
            Array.Reverse(Cores);
            Console.WriteLine("SetValue - Define o item especificado em um array atual para o valor definido.");
            Console.WriteLine("Sort - Ordena os itens de um array.");
            Array.Sort(Cores);
        }

    }
}
