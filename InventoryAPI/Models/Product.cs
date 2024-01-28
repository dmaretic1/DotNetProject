using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models;

public class Product {
    public int Id {get;set;}
    public string Name {get;set;}
    public string Description {get;set;}
    public bool Available {get;set;}
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price {get;set;}
    public string PricePretty {get => Price + "€";}
    public double Volume {get;set;}
    public string VolumePretty {get => Volume + "cm^3";}
}