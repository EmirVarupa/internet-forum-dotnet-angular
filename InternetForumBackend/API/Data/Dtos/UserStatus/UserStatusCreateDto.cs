﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace API.Data.Dtos.UserStatus;

public class UserStatusCreateDto
{
    public string StatusName { get; set; }
}