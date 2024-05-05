[System.Serializable]
public class ProdutoFisico : Produto, IEstoque
{
    private decimal frete;
    private int estoque;

    public int Estoque
    {
        get{return estoque;}
        set {estoque = value;}
    }
    public decimal Frete
    {
        get {return frete;}
        set {frete=value;}
    }
    public ProdutoFisico (string nome, decimal preco, decimal frete)
    {
        this.Nome = nome;
        this.Preco = preco;
        this.Frete = frete;
    }

    public override void Exibir()
    {
        Console.WriteLine($"Nome do Prodouto: {Nome}");
        Console.WriteLine($"Preço do Produto; {Preco}");
        Console.WriteLine($"Valor do Frete; {Frete}");
        Console.WriteLine ($"Quantidade em Estoque {Estoque}");

    }

    public void AdicionarEntrada()
    {
        Console.WriteLine($"Adionar entrada no estoque do produto{Nome}");
        Console.WriteLine($"Digite a quantidade que você quer dar entrada");
        int Entrada = int.Parse(Console.ReadLine());
        Estoque += Entrada;
        Console.WriteLine("Entrada Registrada");
        Console.ReadLine();
    }
    public void AdicionarSaida()
    {
        Console.WriteLine($"Adionar saida no estoque do produto{Nome}");
        Console.WriteLine($"Digite a quantidade que saiu do estoque");
        int Entrada = int.Parse(Console.ReadLine());
        Estoque -= Entrada;
        Console.WriteLine("Saida Registrada");
        Console.ReadLine();
    }
}