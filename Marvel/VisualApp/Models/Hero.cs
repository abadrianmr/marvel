namespace VisualApp.Models
{
    public class Hero
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public PowerStats PowerStats { get; set; }
        public Biography Biography { get; set; }
        public Appearance Appearance { get; set; }
        public Work Work { get; set; }
        public Connections Connections { get; set; }
        public Image Image { get; set; }
    }
}
