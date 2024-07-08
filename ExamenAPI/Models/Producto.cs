using System.Text.Json.Serialization;

namespace ExamenAPI.Models
{
    public class Producto
    {
        public int idProducto { get; set; }
        public int idCategoria { get; set; }
        public string nombreProducto { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public string imagen { get; set; }
        [JsonIgnore]
        public Categoria Categoria { get; set; }
    }
}
