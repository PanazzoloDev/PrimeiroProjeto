[System.Serializable]

public class ProdutoEbook : Produto, IEstoque
{
    private string autor;
    private int venda;
    public int Venda
    {
        get{return venda;}
        set {venda = value;}
    }
    public string Autor
    {
        get{return autor;}
        set {autor = value;}
    }
    public ProdutoEbook (string nome, decimal preco, string autor)
    {
       this.Nome = nome;
       this.Preco = preco;
       this.Autor = autor;
    }

    public void Exibir()
    {
        Console.WriteLine($"Nome do curso; {Nome}");
        Console.WriteLine($"Preço do curso; {Preco}");
        Console.WriteLine($"Autor do Ebook; {Autor}");
        Console.WriteLine($"Quantidade de Vendas; {Venda}");
    }
    public void AdicionarEntrada()
    {
        Console.WriteLine("Não é possível registrar entrada em produtos digitais !");
        Console.ReadLine();
    }
    public void AdicionarSaida()
    {
        Console.WriteLine($"Adicionar venda no Ebook: {Nome}");
        Console.WriteLine($"Digite a quantidade Vendida");
        int Entrada = int.Parse(Console.ReadLine());
        Venda += Entrada;
        Console.WriteLine("Entrada Registrada");
        Console.ReadLine();
    }
}