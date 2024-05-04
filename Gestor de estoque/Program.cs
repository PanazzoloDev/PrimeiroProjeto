using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Gestor
{
    static class Program
    {
        static List<Product> produtos = new List<Product>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        enum ECadastro { CEbook = 1, CProdutoFisico, CCurso, Csair }

        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.WriteLine("Sistema de estoque");
                Console.WriteLine("[1] Listar\n[2] Adicionar\n[3] Remover\n[4] Registrar entrada\n[5] Registar saida\n[6] Sair");
                int Opint = int.Parse(Console.ReadLine());

                if (Opint > 0 && Opint < 7)
                {
                    Menu escolha = (Menu)Opint;

                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            break;
                        case Menu.Entrada:
                            break;
                        case Menu.Saida:
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida\nFechando o programa...");
                    escolheuSair = true;
                }
                Console.Clear();
            }
        }

        static void Listagem()
        {
            Console.WriteLine("Lista de produtos");
            foreach (Product produto in produtos)
            {
                ExibirProduto(produto);
            }
            Console.ReadLine();
        }

        static void Cadastro()
        {
            Console.Clear();
            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.WriteLine("Cadastro de produto");
                Console.WriteLine("[1] Cadastrar Ebook\n[2] Cadastrar Produto físico\n[3] Cadastrar Curso\n[4] Sair");
                int Opint = int.Parse(Console.ReadLine());

                if (Opint > 0 && Opint < 5)
                {
                    ECadastro OPecadastro = (ECadastro)Opint;

                    switch (OPecadastro)
                    {
                        case ECadastro.CCurso:
                            CadastrarPCurso();
                            break;
                        case ECadastro.CEbook:
                            CadastrarPEbook();
                            break;
                        case ECadastro.CProdutoFisico:
                            CadastrarPfisico();
                            break;
                        case ECadastro.Csair:
                            escolheuSair = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
                Console.Clear();
            }
        }

        static void CadastrarPfisico()
        {
            Console.Clear();
            Console.WriteLine("Cadastrando produto físico");
            Console.WriteLine("Digite o nome do produto:");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço do produto:");
            decimal preco = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Frete:");
            decimal frete = decimal.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf.ToProduct());
            Salvar();
            Console.WriteLine($"Cadastro do produto {nome} concluído!");
        }

        static void CadastrarPEbook()
        {
            Console.Clear();
            Console.WriteLine("Cadastrando Ebook");
            Console.WriteLine("Digite o nome do ebook:");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço do produto:");
            decimal preco = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Autor:");
            string autor = Console.ReadLine();
            ProdutoEbook pe = new ProdutoEbook(nome, preco, autor);
            produtos.Add(pe.ToProduct());
            Salvar();
            Console.WriteLine($"Cadastro do produto {nome} concluído!");
        }

        static void CadastrarPCurso()
        {
            Console.Clear();
            Console.WriteLine("Cadastrando Curso");
            Console.WriteLine("Digite o nome do curso:");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço do produto:");
            decimal preco = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Autor:");
            string autor = Console.ReadLine();
            Curso pc = new Curso(nome, preco, autor);
            produtos.Add(pc.ToProduct());
            Salvar();
            Console.WriteLine($"Cadastro do produto {nome} concluído!");
        }

        static void ExibirProduto(Product produto)
        {
            Console.WriteLine($"Nome: {produto.Name}");
            Console.WriteLine($"Preço: {produto.Price}");
            if (produto.Author != null)
            {
                Console.WriteLine($"Autor: {produto.Author}");
            }
            if (produto.Freight != null)
            {
                Console.WriteLine($"Frete: {produto.Freight}");
            }
            Console.WriteLine("====================================================================");
        }

        static void Salvar()
        {
            string json = JsonSerializer.Serialize(produtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("produtos.json", json);
        }

        static void Carregar()
        {
            if (File.Exists("produtos.json"))
            {
                string json = File.ReadAllText("produtos.json");
                produtos = JsonSerializer.Deserialize<List<Product>>(json);
            }
            else
            {
                produtos = new List<Product>();
            }
        } 
    }
}
