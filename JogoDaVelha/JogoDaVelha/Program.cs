using System;

namespace JogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {
            Console.WriteLine("Ola jogadores\n");
            Opcoes();
            int opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    JogoDaVelha jogoDaVelha = new JogoDaVelha();
                    jogoDaVelha.Iniciar();
                    break;
                case 2:
                    RegrasDoJogo();
                    break;
                case 3:
                    Sobre();
                    break;
                case 4:
                    Console.WriteLine("Saindo...");
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Você digitou um valor inválido, tente novamente.");
                    break;
            }
        }

        private static void Opcoes()
        {
            Console.WriteLine("1 - Jogar.");
            Console.WriteLine("2 - Regras do jogo.");
            Console.WriteLine("3 - História do jogo.");
            Console.WriteLine("4 - Sair.");
            Console.WriteLine("\nDigite uma opção.");
        }

        private static void RegrasDoJogo()
        {
            Console.Clear();

            Console.WriteLine("\n REGRAS DO JOGO.\n");
            Console.WriteLine("* O jogador 1, sempre será o X e sempre iniciará o jogo.");
            Console.WriteLine("* O jogador 2, sempre será o O e sempre será o segundo a jogar.");
            Console.WriteLine("* O jogo pode ter 3 resultados: vitória do jogador 1, vitória do jogador 2 ou empate.");
            Console.WriteLine("* Ganha o jogador que primeiro formar uma reta na diagonal, vertical ou horizontal no tabuleiro.\n");
            Console.WriteLine("<- Para voltar digite 9.");

            Voltar();
        }

        private static void Sobre()
        {
            Console.Clear();

            Console.WriteLine("Por que o jogo da velha tem esse nome?\n" +
                "No século 19, era comum as senhoras se reunirem para jogar noughts and crosses (zeros e cruzes)\n" +
                "enquanto bordavam e conversavam. Foi assim que o passatempo virou “jogo das velhas” e depois simplificado\n" +
                "para “jogo da velha”. Mas também pode chamar de cerquilha, jogo do galo ou tic-tac-toe.\n");
            Console.WriteLine("<- Para voltar digite 9.");

            Voltar();
        }

        private static void Voltar()
        {
            bool continua = true;
            int desejaVoltar = Convert.ToInt32(Console.ReadLine());

            while (continua)
            {
                if (desejaVoltar == 9)
                {
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.WriteLine("Opção inválida. Digite 9 para voltar.");
                    desejaVoltar = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
    }
}
