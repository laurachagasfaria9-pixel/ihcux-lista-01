using System;
//Heurísticas de Nielsen aplicadas:
// 1. Visibilidade do status: exibimos Passo X de 3 para mostrar em qual etapa o usuário está.
// 2. Controle e liberdade: usuário pode digitar "voltar" para corrigir ou "cancelar" para abortar.
// 3. Ajuda e erros: mensagens detalhadas quando o código do produto ou a quantidade são inválidos.

class Program
{
    static void Main()
    {
        // Lista de 10 produtos
        string[] produtos = { "Coxinha", "Pastel", "Hambúrguer", "Pizza", "Refrigerante",
                              "Suco", "Salgado", "Pão de queijo", "Café", "Bolo" };

        int passo = 1;
        int codigo = 0;
        int quantidade = 0;

        while (true)
        {
            Console.Clear();

            // passo 1 Escolha do produto 
            if (passo == 1)
            {
                Console.WriteLine("[1/3] Escolha do Produto");

                for (int i = 0; i < produtos.Length; i++)
                    Console.WriteLine((i + 1) + " - " + produtos[i]);

                Console.WriteLine("\nDigite 'cancelar' para sair.");
                Console.Write("Código do produto: ");
                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado.");
                    return;
                }

                if (!int.TryParse(entrada, out codigo))
                {
                    Erro("Digite apenas números.");
                    continue;
                }

                if (codigo < 1 || codigo > produtos.Length)
                {
                    Erro("Código " + codigo + " não encontrado. Use valores de 1 a " + produtos.Length + ".");
                    continue;
                }

                passo = 2;
            }

            //passo2 Quantidade
            else if (passo == 2)
            {
                Console.WriteLine("[2/3] Quantidade");
                Console.WriteLine("Produto: " + produtos[codigo - 1]);
                Console.WriteLine("Digite a quantidade:");
                Console.WriteLine("Comandos: voltar | cancelar");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado.");
                    return;
                }

                if (entrada == "voltar")
                {
                    passo = 1;
                    continue;
                }

                if (!int.TryParse(entrada, out quantidade) || quantidade <= 0)
                {
                    Erro("Digite uma quantidade válida maior que zero.");
                    continue;
                }

                passo = 3;
            }

            // passo3 Confirmaçao
            else if (passo == 3)
            {
                Console.WriteLine("[3/3] Confirmação\n");
                Console.WriteLine("Resumo do Pedido:");
                Console.WriteLine("Produto: " + produtos[codigo - 1]);
                Console.WriteLine("Quantidade: " + quantidade);
                Console.WriteLine("\nConfirmar? (s/n)");
                Console.WriteLine("Comandos: voltar | cancelar");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado.");
                    return;
                }

                if (entrada == "voltar")
                {
                    passo = 2;
                    continue;
                }

                if (entrada == "s")
                {
                    Console.Clear();
                    Console.WriteLine("=== PEDIDO FINALIZADO ===\n");
                    Console.WriteLine("Produto escolhido: " + produtos[codigo - 1]);
                    Console.WriteLine("Quantidade total: " + quantidade);
                    Console.WriteLine("\nObrigado pelo pedido!");
                    break;
                }
                else if (entrada == "n")
                {
                    passo = 1;
                }
                else
                {
                    Erro("Digite 's' para sim ou 'n' para não.");
                }
            }
        }

        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    static void Erro(string mensagem)
    {
        Console.WriteLine("\nErro: " + mensagem);
        Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
        Console.ReadKey();
    }
}