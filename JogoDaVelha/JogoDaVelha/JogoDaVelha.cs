using System;

namespace JogoDaVelha
{
    class JogoDaVelha
    {
        private bool terminaOJogo;
        private char[] posicoes;
        private char vez;
        private int quantidadePreenchida;

        public JogoDaVelha()
        {
            terminaOJogo = false;
            posicoes = new[] {
                '1','2','3',
                '4','5','6',
                '7','8','9'};
            vez = 'X';
            quantidadePreenchida = 0;
        }

        public void Iniciar()
        {
            while(!terminaOJogo)
            {
                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerificaFimDeJogo();
                MudarVez();
            }
        }

        private void MudarVez()
        {
            vez = vez == 'X' ? 'O' : 'X';
        }

        private void VerificaFimDeJogo()
        {
            if(quantidadePreenchida < 5)
            {
                return;
            }

            if(VitoriaNaHorizontal() || VitoriaNaVertical() || VitoriaNaDiagonal())
            {
                terminaOJogo = true;
                Console.WriteLine($"Fim de jogo! Vitória de {vez}\n");
                return;
            }

            if(quantidadePreenchida is 9)
            {
                terminaOJogo = true;
                Console.WriteLine("Fim de jogo! Empate\n");
                return;
            }
        }

        private bool VitoriaNaHorizontal()
        {
            bool linha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool linha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool linha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return linha1 || linha2 || linha3;
        }
        private bool VitoriaNaVertical()
        {
            bool linha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool linha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool linha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return linha1 || linha2 || linha3;
        }
        private bool VitoriaNaDiagonal()
        {
            bool linha1 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            bool linha2 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];

            return linha1 || linha2;
        }

        private void LerEscolhaDoUsuario()
        {
            Console.WriteLine($"{VerificaJogadorAtual()}, escolha um número de 1 a 9, que esteja disponível na tabela.\nAo escolher, ele será substituído por {vez}.");

            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é invalido, por favor digite um numero entre 1 e 9 que esteja disponivel na tabela.");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            posicoes[indice] = vez;
            quantidadePreenchida++;
        }

        private bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            if (posicoes[indice] == 'O' || posicoes[indice] == 'X')
            {
                return false;
            }

            return true;
        }

        private void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        private string VerificaJogadorAtual()
        {
            if (vez == 'X')
            {
                return "Jogador 1";
            }
            else
            {
                return "Jogador 2";
            }
        }

        private string ObterTabela()
        {
            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n";
        }
    }
}
