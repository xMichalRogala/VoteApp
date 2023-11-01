namespace VoteApp.Backend.Commons.Entities
{
    public interface IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
