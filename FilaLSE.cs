using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila();
            No no = new No();
            int sair = 0;
            while (sair == 0)
            {
                imprimeOpcoes();
                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.Write("\nDigite um número para inserir na fila: ");
                        int a = int.Parse(Console.ReadLine());
                        fila.inserir(a);
                        no.SetElemento(a);
                        break;

                    case 2:
                        fila.Remover();
                        break;

                    case 3:
                        fila.ImprimirFila();
                        break;

                    case 4:
                        sair = 1;
                        break;
                }
            }
        }
        static public void imprimeOpcoes()
        {
            Console.WriteLine("\nEscolha uma opção:\n");
            Console.WriteLine("1 - Inserir na fila");
            Console.WriteLine("2 - Tirar da fila");
            Console.WriteLine("3 - Imprimir fila");
            Console.WriteLine("4 - Sair\n");
        }
    }
    class Fila
    {
        private No incioFila;
        private No fimFila;
        private int tamanho;

        public Fila()
        {
            tamanho = 0;
            incioFila = null;
            fimFila = null;
        }

        public bool filaVazia()
        {
            return tamanho == 0;
        }

        public void inserir(int e)
        {
            No novo = new No();
            if (filaVazia())
            { //Se a fila estiver vazia
                novo.SetElemento(e); // o novo no recebera o valor do elemento
                novo.SetProximo(null); // o proximo do no apontara para nulo
                incioFila = novo; //o inicio da fila ira apontar para o novo assim como o final sera o inicio pois é o primeiro elemento da fila
                fimFila = incioFila;
                tamanho++;//incrementamos o tamanho
            }
            else
            {//Se a fila não estiver vazia
                novo.SetElemento(e);//o novo no recebera o valor do elemento
                novo.SetProximo(null);//o proximo apontara para nulo
                fimFila.SetProximo(novo); //adicionamos mais um no no final da fila, aqui temos o no atual e modificamos seu proximo que apontava para null e agora aponta para esse novo no.
                fimFila = novo;// agora mudamos a posição do final da fila, pois ele estava sendo o no anterior
                tamanho++;//incrementamos o tamanho da fila
            }
        }
        public void Remover()
        {
            No novo = incioFila;
            if (filaVazia())
            {
                Console.WriteLine("Fila vazia!!!");
            }
            else
            {
                novo = novo.GetProximo();//o novo vai ser o proximo do iniciodafila
                incioFila = novo;// e o inicio da fila vai ser o novo nó
                tamanho--;//decrementa o tamanho
            }
        }
        public int tamanhoFila()
        {
            return tamanho;
        }

        public void ImprimirFila()
        {
            No novo = incioFila;
            if (tamanhoFila() == 0)
            {
                Console.WriteLine("Fila Vazia!");
            }
            else
            {
                for (int i = 0; i < tamanho; i++)
                {
                    Console.Write($"{novo.GetElemento()} ");
                    novo = novo.GetProximo();
                }
            }
        }
    }
    class No
    {
        private int Elemento;
        private No proximo;

        public void SetElemento(int Elemento)
        {
            this.Elemento = Elemento;
        }
        public int GetElemento()
        {
            return Elemento;
        }
        public void SetProximo(No proximo)
        {
            this.proximo = proximo;
        }

        public No GetProximo()
        {
            return proximo;
        }
    }
}
