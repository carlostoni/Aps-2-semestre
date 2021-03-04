using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Criptografia
{
    class Program
    {

        static void Main(string[] args)
        {

            string opcao = "";

            while (opcao != "0")

            {

                Console.Clear();
                Console.WriteLine("Programa de Criptografia baseado na ci-fra de Cesar");
                Console.WriteLine("\nA senha deve conter apenas números ");

                Console.WriteLine("\nOpções:");
                Console.WriteLine("\n1 - Para Criptografar");
                Console.WriteLine("\n2 - Para Descriptografar");
                Console.WriteLine("\n3 - Para abrir um arquivo para Des-cripgrafar");
                Console.WriteLine("\n4 - Para sair");
                Console.Write("\nDigite o número da opção desejada:");

                opcao = Console.ReadLine();
                ShowMenu(opcao);

            }
        }




        public static void ShowMenu(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    Criptografar();
                    break;
                case "2":
                    Descriptografar();
                    break;
                case "3":
                    Abrir_arquivo();
                    break;
                case "4":
                    Environment.Exit(3);
                    break;
                default:
                    Console.WriteLine("Opção invalida");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
            Console.WriteLine();
        }

        public static void Criptografar()
        {
            string palavra1 = "";
            string palavra2 = "";
            int senha;
            int caractere1 = 0;
            int numero = 0;

            Console.Clear();
            Console.WriteLine("Digite o texto para Criptografar");
            palavra1 = Console.ReadLine();
            palavra1 = palavra1.ToUpper();
            Console.WriteLine("\nDigite a senha");
            senha = Convert.ToInt32(Console.ReadLine());
            caractere1 = palavra1.Length;
            for (int z = 0; z < caractere1; z++)
            {

                numero = Convert.ToInt32(palavra1[z]) + senha % 26;
                palavra2 += Convert.ToChar(numero);
            }
            Console.Clear();
            Console.WriteLine("O Texto Criptografado:\n{0}", palavra2);
            Console.WriteLine("\nDeseja salvar o arquivo S(SIM) OU N(NÃO)");
            var menu = Console.ReadLine();
            menu = menu.ToUpper();

            if (menu == "S")
            {
                Console.Clear();
                Directory.CreateDirectory("c:/Arquivo");
                StreamWriter txt = new StreamWriter("C:\\Arquivo\\criptografia.txt");
                txt.WriteLine(palavra2);
                txt.Close();
                palavra2 = null;
                Console.WriteLine("Arquivo salvo");
                Console.ReadKey();
            }
            else if (menu == "N")
                palavra2 = null;
            Console.Clear();


        }

        public static void Descriptografar()

        {
            string palavra1 = "";
            string palavra2 = "";
            int senha;
            int caractere1 = 0;
            int numero = 0;


            Console.Clear();
            Console.WriteLine("Digite o texto para Descriptografar");
            palavra1 = Console.ReadLine();
            Console.WriteLine("\nDigite a senha");
            senha = Convert.ToInt32(Console.ReadLine());
            caractere1 = palavra1.Length;
            for (int z = 0; z < caractere1; z++)
            {
                numero = Convert.ToInt32(palavra1[z]) - senha % 26;
                palavra2 += Convert.ToChar(numero);
            }
            Console.Clear();
            Console.WriteLine("O texto Descriptografado :\n{0}", palavra2);
            palavra2 = null;
            Console.ReadKey();


        }
        public static void Abrir_arquivo()
        {
            string palavra1 = "";
            string palavra2 = "";
            int senha;
            int caractere1 = 0;
            int numero = 0;

            Console.Clear();
            foreach (string line in File.ReadLines(@"C:\\Arquivo\\criptografia.txt"))
                palavra1 = Convert.ToString(line);
            Console.WriteLine("O Texto Criptografado:\n{0}", palavra1);
            Console.WriteLine("\nDigite a senha");
            senha = Convert.ToInt32(Console.ReadLine());
            caractere1 = palavra1.Length;
            for (int z = 0; z < caractere1; z++)
            {
                numero = Convert.ToInt32(palavra1[z]) - senha % 26;
                palavra2 += Convert.ToChar(numero);
            }
            Console.Clear();
            Console.WriteLine("O texto Descriptografado :\n{0}", palavra2);
            palavra2 = null;
            Console.ReadKey();
        }
    }

}
