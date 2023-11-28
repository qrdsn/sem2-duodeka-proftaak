namespace DuodekaModels.Items
{
    public class InsertItemModel
    {
        public int CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public ItemTypes ItemType { get; set; }
        public DateTime Created { get; }
        public DateTime Modified { get; set; }
        public bool Availability { get; set; }
        public string ExtensionType { get; set; }
        public int Size { get; set; }
        public string FileHashName { get; set; }


        public bool ValidateItemOrSometehing()
        {
            throw new NotImplementedException();
        }
    }
}