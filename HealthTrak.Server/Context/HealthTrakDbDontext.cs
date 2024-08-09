using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealthTrak.Server.Context;

public class HealthTrakDbDontext : IdentityDbContext<IdentityUser>
{
    public HealthTrakDbDontext(DbContextOptions<HealthTrakDbDontext> options) : base(options)
        { }
}
