namespace AbpApp.Domain.Entities
{
    public class Experiment
    {
        public Guid Id { get; set; }
        public string DeviceToken { get; set; }
        public Option Option { get; set; }
    }
}
