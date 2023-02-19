namespace libreriaApp.DAL.Core
{
    public abstract class Location : AuditEntity
    {
        public string? city { get; set; }
        public char? state { get; set; }
    }
}
