namespace ContactApi.Models;

public class ContactCard
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public ContactCard()
    {
        this.Id = string.Empty;
        this.Name = string.Empty;
        this.Address = string.Empty;
    }

    public ContactCard(string id, string name, string address)
    {
        this.Id = id;
        this.Name = name;
        this.Address = address;
    }
}