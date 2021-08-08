namespace BasketService.Api.Model
{
    public class Stock : BaseEntityModel
    {
        public int ProductId { get; set; }

        public int Amount { get; set; }
    }
}
