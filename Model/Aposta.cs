namespace ConsciousbetApp.Model
{
    public class Aposta
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Resultado { get; set; }
        public int UsuarioId { get; set; }
    }
}
