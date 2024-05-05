[System.Serializable]
public class ProdutoCurso : Produto, IEstoque
{
    private string autor;
    private int vagas;
    public int Vagas
    {
        get{return vagas;}
        set{vagas = value;}
    }

    public string Autor
    {
        get{return autor;}
        set{autor = value;}
    }
    public ProdutoCurso (string nome, decimal preco, string autor)
    {
        this.Nome = nome;
        this.Preco = preco;
        this.Autor = autor;
    }
    public void Exibir()
    {
        Console.WriteLine($"Nome do curso: {Nome}");
        Console.WriteLine($"Preço do curso; {Preco}");
        Console.WriteLine($"Autor do Curso; {Autor}");
        Console.WriteLine ($"Quantidade de Vagas; {Vagas}");
    }
    public void AdicionarEntrada()
    {
        Console.WriteLine($"Adionar vagas no curso: {Nome}");
        Console.WriteLine($"Digite a quantidade de vagas");
        int Entrada = int.Parse(Console.ReadLine());
        Vagas += Entrada;
        Console.WriteLine("Entrada Registrada");
        Console.ReadLine();
    }
     public void AdicionarSaida()
    {
        Console.WriteLine($"Remover quantidade de vagas no curso: {Nome}");
        Console.WriteLine($"Digite a quantidade de vagas que foram obitidas por alunos");
        int Entrada = int.Parse(Console.ReadLine());
        Vagas -= Entrada;
        Console.WriteLine("Saida Registrada");
        Console.ReadLine();
    }
}