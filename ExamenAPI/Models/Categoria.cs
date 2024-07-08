namespace ExamenAPI.Models
{
    public class Categoria
    {
        public int idCategoria { get; set; }
        public string nombreCategoria { get; set; }
        public string descripcion { get; set; }

        public List<Producto> Productos { get; set; }
    }
}
