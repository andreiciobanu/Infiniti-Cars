namespace InfinitiCars.Events
{
   /// <summary>
   /// Message sent when a new customer marks a model as preffered
   /// </summary>
   public class CustomerHasModelPreffered
    {
       public string CustomerName { get; set; }

       public string Make { get; set; }

       public string Model { get; set; }

       public string Description { get; set; }
    }
}
