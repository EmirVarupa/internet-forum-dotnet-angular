﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models;

public class PostTag
{
    public int TagId { get; set; }

    public Tag Tag { get; set; }

    public int PostId { get; set; }

    public Post Post { get; set; }
}