using Microsoft.EntityFrameworkCore;
using FunTogether.Models;

namespace FunTogether.Data
{
    public class FunTogetherContext : DbContext
    {
        public FunTogetherContext(DbContextOptions<FunTogetherContext> options) : base(options)
        {
        }

    }
}
