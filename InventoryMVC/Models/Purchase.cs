using System.Text.Json.Serialization;

namespace InventoryMVC.Models;

public class Purchase {
    public int Id {get;set;}
    public string BuyerName {get;set;}
    public int ProductId {get;set;}
    [JsonIgnore]
    public Product? Product {get;set;}
}