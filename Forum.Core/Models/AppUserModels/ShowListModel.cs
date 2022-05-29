namespace Forum.Core.Models.AppUserModels
{
    public class ShowListModel<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int CurrentAppUserId { get; set; }
    }
}
