using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o tamanho da sua fila: ");
            int t = int.Parse(Console.ReadLine());
            Fila fila = new Fila(t);
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
                        fila.enfileirar(a);
                        break;

                    case 2:
                        fila.desenfileirar();
                        break;

                    case 3:
                        fila.display();
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
        private int[] fila;
        private int inicio;
        private int fim;
        private int tamanho;
        private int total;
        public Fila(int tamanho)
        {
            fila = new int[tamanho];
            inicio = 0;
            fim = 0;
            total = 0;
            this.tamanho = tamanho;
        }
        public void enfileirar(int elem)
        {//fazer o execption de fila cheia
            if (isFull())
            {
                int[] aux = new int[2 * tamanho];
                for (int i = 0; i < total; i++)
                {
                    aux[i] = fila[inicio];
                    inicio = (inicio + 1) % tamanho;
                    aux[fim] = elem;
                    fila = aux;
                    inicio = 0;
                    fim = i;
                    tamanho = 2 * tamanho;
                    total++;
                }
            }
            else
            {
                fila[fim] = elem;
                total++;
            }
        }
        public int desenfileirar()
        {//fazer a execption de fila vazia
            int elem = fila[inicio];
            inicio = (inicio + 1) % tamanho;
            total--;
            return elem;
        }
        public bool isEmpty()
        {
            return (total == 0);
        }
        public bool isFull()
        {
            return (total == tamanho - 1);
        }
        public int size()
        {
            return total;
        }
        public void display()
        {
            int[] novo = fila;
            int cont = total;
            while (--cont != -1)
            {
                Console.Write($"{novo[inicio]} ");
                inicio = inicio + 1;
            }
        }
    }
}
