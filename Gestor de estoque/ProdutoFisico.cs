namespace Gestor
{
    public class ProdutoFisico : Produto
    {
        public decimal Frete { get; set; }

        public ProdutoFisico(string nome, decimal preco, decimal frete)
        {
            Nome = nome;
            Preco = preco;
            Frete = frete;
        }

        public override Product ToProduct()
        {
            return new Product
            {
                Name = this.Nome,
                Price = this.Preco,
                Freight = this.Frete
            };
        }
    }
}
