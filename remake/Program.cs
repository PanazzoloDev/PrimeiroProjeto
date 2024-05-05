using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gestor
{
    static class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu {Listar=1, Adicionar, Remover, Entrada, Saida, Sair}
        enum MenuProd {Fisico =1, Ebook, Curso, Sair}
        static void Main(string[]args)
        {
            Carregar();
            bool EscolheuSair = false;
            while (EscolheuSair == false)
            {
                Console.WriteLine("Gestor de estoque");
                Console.WriteLine ("[1] Listar\n[2] Adicionar\n[3] Remover\n[4] Adicionar entrada\n[5] Adicionar saida\n[6] Sair");
                int OpcInt = int.Parse(Console.ReadLine());
                Menu OpcMenu = (Menu)OpcInt;

                if (OpcInt > 0 && OpcInt< 7)
                {
                     switch (OpcMenu)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Adicionar();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            AdicionarEntrada();
                            break;
                        case Menu.Saida:
                        AdicionarSaida();
                            break;
                        case Menu.Sair:
                            EscolheuSair = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção Invalida");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            static void Listagem()
            {
                Console.WriteLine("Listagem de produtos");
                int i = 0;
                foreach (IEstoque produto in produtos)
                {
                    Console.WriteLine("ID: "+i);
                    produto.Exibir();
                    i++;
                }
                Console.ReadLine();
                Console.Clear();
            }
            static void Adicionar()
            {
                Console.Clear();
                bool EscolheuSair = false;
                while (EscolheuSair == false)
                {
                    Console.WriteLine("Menu de Registro");
                    Console.WriteLine("[1] Adicionar Produto Fisico\n[2] Adicionar Ebook\n[3] Adicionar Curso\n[4] Sair");
                    int OpcInt = int.Parse(Console.ReadLine());
                    MenuProd Opcmenu = (MenuProd)OpcInt;
                    
                    if (OpcInt >0 && OpcInt < 5)
                    {
                        switch (Opcmenu)
                        {
                            case MenuProd.Fisico:
                                CadastrarPFisico();
                                break;
                            case MenuProd.Ebook:
                                CadastrarPEbook();
                                break;
                            case MenuProd.Curso:
                                CadastrarPCurso();
                                break;
                            case MenuProd.Sair:
                                EscolheuSair= true;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opção Invalida");
                        EscolheuSair = true;
                    }     
                }

                static void CadastrarPFisico()
                {
                    Console.Clear();
                    Console.WriteLine ("Cadastrando Produto Fisico");
                    Console.WriteLine("Digite o nome do Produto");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite o preço do produto");
                    decimal preco = decimal.Parse(Console.ReadLine());
                    Console.WriteLine ("Digite o valor do frete");
                    decimal frete = decimal.Parse(Console.ReadLine());
                    ProdutoFisico PF = new ProdutoFisico(nome, preco, frete);
                    produtos.Add(PF);
                    Salvar();
                    Console.Clear();
                }
                static void CadastrarPEbook()
                {
                    Console.Clear();
                    Console.WriteLine ("Cadastrando Produto em Ebook");
                    Console.WriteLine("Digite o nome do Produto");
                    string nome = Console.ReadLine();
                    decimal preco = decimal.Parse(Console.ReadLine());
                    string autor = Console.ReadLine();
                    ProdutoEbook PE = new ProdutoEbook(nome,preco,autor);
                    produtos.Add(PE);
                    Salvar();
                    Console.Clear();
                }
                static void CadastrarPCurso()
                {
                    Console.Clear();
                    Console.WriteLine ("Cadastrando um novo Curso");
                    Console.WriteLine("Digite o nome do Curso");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite o valor do Curso");
                    decimal preco = decimal.Parse(Console.ReadLine());
                    Console.WriteLine ("digite o nome do autor");
                    string autor = Console.ReadLine();
                    ProdutoCurso PC = new ProdutoCurso(nome, preco, autor);
                    produtos.Add(PC);
                    Salvar();
                    Console.Clear();
                }
            }
            static void Salvar()
            {
                string json = JsonConvert.SerializeObject(produtos, Formatting.Indented);
                File.WriteAllText("produtos.json", json);
            }
            static void Remover()
            {
                Console.Clear();
                Console.WriteLine("Procure o ID do produto que deseja remover e pressione enter");
                Listagem();
                Console.WriteLine("Dgite o ID do produto que deseja remover");
                int ID = int.Parse(Console.ReadLine());
                if (ID >= 0 && ID <produtos.Count)
                {
                    produtos.RemoveAt(ID);
                    Salvar();
                }
            }
            static void AdicionarEntrada()
            {
                Listagem();
                Console.WriteLine("Dgite o ID do produto que deseja Adionar");
                int ID = int.Parse(Console.ReadLine());
                if (ID >= 0 && ID <produtos.Count)
                {
                    produtos[ID].AdicionarEntrada();
                    Salvar();
                }
            }
            static void AdicionarSaida()
            {
                Listagem();
                Console.WriteLine("Dgite o ID do produto que saiu");
                int ID = int.Parse(Console.ReadLine());
                if (ID >= 0 && ID <produtos.Count)
                {
                    produtos[ID].AdicionarSaida();
                    Salvar();
                }
            }
        }
            static void Carregar()
            {
                if (File.Exists("produtos.json"))
                {
                    string json = File.ReadAllText("produtos.json");
                    produtos = JsonConvert.DeserializeObject<List<IEstoque>>(json, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        Converters = { new IEstoqueConverter() } 
                    });
                }
                else
                {
                    produtos = new List<IEstoque>();
                }
            }
    }
}