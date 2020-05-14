namespace Burak.Authorization.Models.BaseModel
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
