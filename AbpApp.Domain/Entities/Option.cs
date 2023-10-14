namespace AbpApp.Domain.Entities
{
    public class Option
    {
        public int Id { get; set; }
        public Key Key { get; set; }
        public string Value { get; set; }
        public decimal Weight { get; set; }
    }
}
