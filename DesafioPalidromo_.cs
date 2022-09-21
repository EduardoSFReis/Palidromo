using System;

namespace Desafio
{

    //      Autor: Eduardo S. F. Reis
    //      E-mail: edufrancoreis@hotmail.com
    //      Produção:  30/08/2022
    //      Ultima atualização: 30/08/2022
    //
    //      Objetivo:    1) Gerar número palidromo de 9 digitos,
    //                   2) Verificar se o número é primo
    //                   3) Verificar posição do número na cadeia do PI
    //


    class Program
    {
        private static System.Timers.Timer aTimer;
        static DateTime dataProcessamento = DateTime.Now;
        public static string fileContents = string.Empty;
        public static int Posicaonumero = 0;


        static void Main(string[] args)
        {

            //carregar biblioteca de PI
            fileContents = System.IO.File.ReadAllText(@"D:\PI\pi-billion.txt");


            //Gerar número Palidromo
            Console.WriteLine("Inicio Processamento..... " + dataProcessamento);

           
            int intcount = 1;
            string n;
            bool palindromo;
            int i;
            int x;
            int numPesquisado = 0;
            int numPosicao = 999999999;
            int posicao = 0;

            char[] vetor1 = new char[4];
            char[] vetor2 = new char[4];
           
            vetor1[0] = '0';
            vetor1[1] = '0';
            vetor1[2] = '0';
            vetor1[3] = '0';
            vetor2[0] = '0';
            vetor2[1] = '0';
            vetor2[2] = '0';
            vetor2[3] = '0';

            for (int d = 0; d <= 9; d++)
            {

                for (int k = 1; k <= 9999; k++)
                {
                    
                    n = k.ToString("0000");
                    x = 0;
                   
                    foreach (char c in n.ToCharArray())
                    {
                        vetor1[x] = c;
                        vetor2[3 - x] = c;

                        x++;
                    }
                   
                    palindromo = true;
                    i = 0;
                    while (i < 4 && palindromo != false)
                    {
                        if (vetor1[i] == vetor2[3 - i])
                        {
                            palindromo = true;
                        }
                        else
                        {
                            palindromo = false;
                        }
                        i++;
                    }

                    if (vetor1[0] != '0')
                    {

                        if (palindromo)
                        {
                            string strPalidromo = $"{vetor1[0]}{vetor1[1]}{vetor1[2]}{vetor1[3]}{d}{vetor2[0]}{vetor2[1]}{vetor2[2]}{vetor2[3]}";
                            int intPalidromo = Convert.ToInt32(strPalidromo);
                                                        
                            //verifica se o número é primo
                            var response = VerificarPrimo(intPalidromo);

                            if (response == true)
                            {

                                 posicao = ProcessarPI(intPalidromo);

                                if (posicao != -2)
                                {
                                    if (numPosicao >= posicao)
                                    {
                                        numPesquisado = intPalidromo;
                                        numPosicao = posicao;
                                    }
                                }
                                Console.WriteLine(intcount + "   Palindromo Primo:" + intPalidromo + "   Posição: "+ posicao + "  Primeiro número: " + numPosicao + " 1º Posição:  " + numPosicao);
                                intcount = intcount + 1;
                             
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Número: " + numPesquisado + "1º Posição: " + numPosicao);
            Console.WriteLine("Fim Processamento..... " + dataProcessamento);
        }

        public static int ProcessarPI(int pesquisanumero)
        {
            try
            {
                //Carregar arquivo texto de Pi
                //Arquivo texto com 1 bilão de númeo do PI
                // https://stuff.mit.edu/afs/sipb/contrib/pi/
                // One billion (10^9) digits of pi (actually 1,000,000,001 digits if you count the initial "3")
                // Retorna a posição na cadeia de caracteres, se não encontrar retorna -1
                //


               // string fileContents = string.Empty;
               // var Posicaonumero = 0;
               // fileContents = System.IO.File.ReadAllText(@"D:\PI\pi-billion.txt");

                string numeroString = pesquisanumero.ToString();
                Posicaonumero = fileContents.IndexOf(numeroString);

                return (Posicaonumero - 1);

            }
            catch (Exception ex)
            {
                throw ex;
            }
}

        public static Boolean VerificarPrimo(int n)

            {
            // Verificar se  número é primo
            // Retorna (true) caso o número seja primo

            int divisores = 0;
                Boolean isPrimo = true;
                for (int i = 1; i <= n; i++)
                {
                    if (n % i == 0)
                    {
                    divisores++;
                    }
                    if (divisores > 2) 
                    {
                        break;
                    }
                }
                if (divisores == 2)
                     isPrimo = true;
                else
                     isPrimo = false;

                return isPrimo;
        }
      
    }
}