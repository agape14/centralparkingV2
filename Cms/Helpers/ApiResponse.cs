namespace Cms.Helpers
{
    public class ApiResponse<T>
    {
        public T Result { get; set; }
        public int Id { get; set; }
        public object Exception { get; set; }
        public int Status { get; set; }
        // Agrega otras propiedades si es necesario
    }
}
