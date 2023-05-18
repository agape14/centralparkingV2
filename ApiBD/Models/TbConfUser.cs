using System;
using System.Collections.Generic;

namespace ApiBD.Models;

public partial class TbConfUser
{
    public ulong Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public DateTime? EmailVerifiedAt { get; set; }

    public string TwoFactorSecret { get; set; }

    public string TwoFactorRecoveryCodes { get; set; }

    public DateTime? TwoFactorConfirmedAt { get; set; }

    public string RememberToken { get; set; }

    public ulong? CurrentTeamId { get; set; }

    public string ProfilePhotoPath { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? Active { get; set; }

    public string Apaterno { get; set; }

    public string Amaterno { get; set; }

    public string Dni { get; set; }

    public int? RolId { get; set; }

    public virtual TbConfRole Rol { get; set; }
}
