using System;

namespace Gestor
{
    public abstract class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public long Quantidade { get; set; }
        public DateTime? DataRegistro { get; set; }
        public abstract Product ToProduct();
    }
}
