using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            //Classes produtos
            Refrigerante refri = new Refrigerante();
            Lacta barra = new Lacta();

            //Estoque de produtos
            int refrigerante = 5;
            int lacta = 5;
            //Valor de Produtos
            refri.preco = 6;
            barra.preco = 3.5;
            //entrada do pagamento
            double pagamento = 0;
            //variaveis uteis
            double diferenca, valorfaltante, quantidadevendasrefri = 0, quantidadevendaslacta = 0, superusuario, quantidadevendastotal = 0;
            char repeticao = 's';

            //condição para repetir o processo
            while (repeticao == 's')
            {
                //impressão da maquina
                Console.WriteLine("---VendingMachine LabLuby---");
                Console.WriteLine(" ___________________________");
                Console.WriteLine("|Refrigerante - Código (1)  |");
                Console.WriteLine("|Quantidade: {0}              |", refrigerante);
                Console.WriteLine("|Valor {0} R$                 |", refri.preco);
                Console.WriteLine("|___________________________|");
                Console.WriteLine("|Barra Lacta - Código (2)   |");
                Console.WriteLine("|Quantidade: {0}              |", lacta);
                Console.WriteLine("|Valor {0} R$               |", barra.preco);
                Console.WriteLine("|___________________________|");
                Console.WriteLine(" ***************************");
                Console.WriteLine(" ___________________________");
                Console.WriteLine("Caso seja o dono da máquina ");
                Console.WriteLine("e queira acessar o SUsuário:");
                Console.WriteLine("Digite: 0                   ");
                Console.WriteLine("|___________________________|");

                //Solicitando a escolha do usuário
                Console.WriteLine("O que você deseja?: ");
                int produtodesejado = int.Parse(Console.ReadLine());

                //Verificando se a escolha existe dentro da máquina
                while (produtodesejado < 0 || produtodesejado > 2)
                {
                    Console.WriteLine("Produto Indisponível, tente outro:");
                    produtodesejado = int.Parse(Console.ReadLine());
                }

                //Confirmando a escolha do usuário
                switch (produtodesejado)
                {
                    case 1://caso escolha refrigerante
                        Console.WriteLine("Você selecionou Refrigerante Pepsi (300ml)!");
                        refrigerante--;//subtrai a quantidade de refris
                        if (refrigerante <= 0)//caso já não haja mais no estoque
                        {
                            Console.WriteLine("Mas, não há mais unidades disponíveis. Lamentamos o transtorno.");
                            break;
                        }

                        //solicitando o pagamento
                        Console.WriteLine("Insira o valor correspondente de R$ {0} ", refri.preco);
                        pagamento = double.Parse(Console.ReadLine());

                        //Condicional para caso o pagamento esteja faltando
                        while (pagamento < refri.preco)
                        {
                            diferenca = refri.preco - pagamento;
                            Console.WriteLine("Por favor, insira mais R$ {0} para a liberação do produto", diferenca.ToString("F2"));
                            Console.WriteLine("Insira o valor faltante: ");
                            valorfaltante = double.Parse(Console.ReadLine());
                            pagamento += valorfaltante;
                        }
                        //Código para caso você precise receber troco
                        if (pagamento > refri.preco)
                        {
                            diferenca = pagamento - refri.preco;
                            Console.WriteLine("Você inseriu mais do que o valor do produto!");
                            Console.WriteLine("Seu troco é de: R$ " + diferenca.ToString("F2"));
                        }
                        Console.WriteLine("Refrigerante disponível para retirada!");
                        quantidadevendasrefri++;
                        break;

                    case 2://caso escolha barrinha
                        Console.WriteLine("Você selecionou Barrinha Lacta!");
                        lacta--;//subtrai a quantidade de barrinhas
                        if (lacta <= 0)//caso já não haja mais no estoque
                        {
                            Console.WriteLine("Mas, não há mais unidades disponíveis. Lamentamos o transtorno.");
                            break;
                        }

                        //solicitando o pagamento
                        Console.WriteLine("Insira o valor correspondente de R$ {0} ", barra.preco);
                        pagamento = double.Parse(Console.ReadLine());

                        //Condicional para caso o pagamento esteja faltando
                        while (pagamento < barra.preco)
                        {
                            diferenca = barra.preco - pagamento;
                            Console.WriteLine("Por favor, insira mais R$ {0} para a liberação do produto", diferenca.ToString("F2"));
                            Console.WriteLine("Insira o valor faltante: ");
                            valorfaltante = double.Parse(Console.ReadLine());
                            pagamento += valorfaltante;
                        }
                        //Código para caso você precise receber troco
                        if (pagamento > barra.preco)
                        {
                            diferenca = pagamento - barra.preco;
                            Console.WriteLine("Você inseriu mais do que o valor do produto!");
                            Console.WriteLine("Seu troco é de: R$ " + diferenca.ToString("F2"));
                        }
                        Console.WriteLine("Brrinha Lacta disponível para retirada!");
                        quantidadevendaslacta++;
                        break;

                    case 0://caso você seja o dono e queira acessar o SuperUsuário
                        Console.WriteLine("Insira a senha de SuperUsuário: ");
                        int senha = int.Parse(Console.ReadLine());
                        //Solicitanto senha para confirmar que é um superusuário
                        while (senha != 12345)
                        {
                            Console.WriteLine("Senha Incorreta! Tente novamente:");
                            senha = int.Parse(Console.ReadLine());
                        }
                        //Opções de SuperUsuário
                        Console.WriteLine("Gostaria de: (1) Acessar o Estoque ou (2) Verificar o nº de vendas?");
                        superusuario = double.Parse(Console.ReadLine());
                        switch (superusuario)
                        {
                            case 1:
                                Console.WriteLine("O estoque de refrigerante é de {0} e de Barrinha Lacta é de {1}.", refrigerante, lacta);
                                break;
                            case 2:
                                quantidadevendastotal = quantidadevendaslacta + quantidadevendasrefri;
                                Console.WriteLine("O número de vendas, até o momento é de: " + quantidadevendastotal);
                                Console.WriteLine("E o valor somado é de: R$ {0} dos Refrigerantes e de R$ {1} de barrinhas. Dando um total de: R$ {2}", quantidadevendasrefri * refri.preco, quantidadevendaslacta * barra.preco, ((quantidadevendasrefri * refri.preco) + (quantidadevendaslacta * barra.preco)));
                                break;
                        }
                        break;
                }
                //Caso queira realizar outra operação
                Console.WriteLine("Deseja comprar algum outro produto ou realizar alguma outra operação? (s/n)");
                repeticao = char.Parse(Console.ReadLine());
                while (repeticao != 's' && repeticao != 'n')
                {
                    Console.WriteLine("Opção inválida, tente novamente: ");
                    repeticao = char.Parse(Console.ReadLine());
                }
                Console.WriteLine("\n");

            }
        }
    }
}

