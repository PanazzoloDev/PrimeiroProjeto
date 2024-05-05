using System.Diagnostics.Contracts;

[System.Serializable]
public abstract class Produto
{
    private string nome;
    private decimal preco;
    private int  quantidade;

    public string Nome
    {
        get {return nome;}
        set {nome = value;}
    }

    public decimal Preco
    {
        get {return preco;}
        set {preco= value;}
    }

    public int Quantidade
    {
        get {return quantidade;}
        set {quantidade = value;}
    }

    public virtual void Exibir()
    {
        throw new NotImplementedException();
    }
    public virtual void AdicionarEntrada()
    {
        throw new NotImplementedException();
    }
    public virtual void AdicionarSaida()
    {
        throw new NotImplementedException();
    }
}