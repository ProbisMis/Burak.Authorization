using Burak.Authorization.Models.BaseModel;

namespace Burak.Authorization.Data.EntityModels
{
    public class Setting : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int StoreId { get; set; }
    }
}
