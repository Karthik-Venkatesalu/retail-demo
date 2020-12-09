using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Product
{
    public static class Mapper
    {
        public static Domain.Entities.Product MapToDomain(this Dto.Model.Product product)
        {
            return new Domain.Entities.Product()
            {
                 Description = product.Description,
                 ID = product.ID,
                 Name = product.Name,
                 Price = product.Price,
                 Quantity = product.Quantity
            };
        }

        public static Dto.Model.Product MapToDto(this Domain.Entities.Product product)
        {
            return new Dto.Model.Product()
            {
                Quantity = product.Quantity,
                Price = product.Price,
                Name = product.Name,
                ID = product.ID,
                Description = product.Description
            };
        }
    }
}
