﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SockItToeMe.Entities
{
    public class MaterialEntity : ISockEntity, IValueEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}