using Microsoft.EntityFrameworkCore;
using youtube_notes_api.Entities;

namespace youtube_notes_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
    }


}
