﻿using MultiShop.Data.Interfaces;

namespace MultiShop.Data
{
    public class Slider : BaseEntity, IOrdered
    {
        public int Id { get; set; }
        public required string Header { get; set; }
        public required string Content { get; set; }
        public required string Image { get; set; }
        public bool IsSlider { get; set; }
        public int? Order { get; set; }
    }

}