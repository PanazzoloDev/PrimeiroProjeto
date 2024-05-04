namespace Gestor
{
    public class ProdutoEbook : Produto
    {
        public string Author { get; set; }

        public ProdutoEbook(string nome, decimal preco, string autor)
        {
            Nome = nome;
            Preco = preco;
            Author = autor;
        }

        public override Product ToProduct()
        {
            return new Product
            {
                Name = this.Nome,
                Price = this.Preco,
                Author = this.Author
            };
        }
    }
}
