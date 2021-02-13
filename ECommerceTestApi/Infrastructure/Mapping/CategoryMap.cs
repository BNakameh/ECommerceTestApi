using ECommerceTestApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreakApiService.Core.Context.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceTestApi.Infrastructure.Mapping
{
    public class CategoryMap : TrackableMap<CategoryDto>
    {
        public override void Configure(EntityTypeBuilder<CategoryDto> builder)
        {

        }
    }
}
