﻿using System.ComponentModel.DataAnnotations;

namespace DotNetBankingAppApi.Models;

public class User
{
    [Key]
    public string UserName { get; set; } = "";

    [Required, MinLength(9), DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; } = "";

    [Required, MinLength(8), RegularExpression("^[^\\s\\,]+$")]
    public string Password { get; set; } = "";
}
