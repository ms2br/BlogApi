namespace DenemeAPI.Model
{
    public class ModelTwo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IQueryable<ModelOneAndModelTwo> modelOneAndModelTwos { get; set; }
    }
}
