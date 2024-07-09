using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DenemeAPI.Model
{
    public class ModelOneAndModelTwo
    {
        public int ModelOneId { get; set; }
        public ModelOne? ModelOne { get; set; }
        public int ModelTwoId { get; set; }
        public ModelTwo? ModelTwo { get; set; }
    }

    public class ModelConfig : IEntityTypeConfiguration<ModelOneAndModelTwo>
    {
        public void Configure(EntityTypeBuilder<ModelOneAndModelTwo> builder)
        {
            builder.HasOne(x=> x.ModelOne)
        }
    }
}
