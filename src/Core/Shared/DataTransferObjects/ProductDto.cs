﻿using Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Shared.DataTransferObjects
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public string ImgUrl { get; set; }
        public string ManufacturerName { get; set; }
        public ICollection<AttributeValue> AttributeValues { get; set; }

    }
}
