using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace Domain.Models.DTOs
{
    public class ProductFilter : ICustomQueryable
    {
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string Name { get; set; }
        [QueryOperator(Operator = WhereOperator.GreaterThanOrEqualTo, HasName = "Price")]
        public decimal PriceMin { get; set; }
        [QueryOperator(Operator = WhereOperator.LessThanOrEqualTo, HasName = "Price")]
        public decimal PriceMax { get; set; }
    }

    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
