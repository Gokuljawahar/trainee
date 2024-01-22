namespace trainee.Models;
using Microsoft.EntityFrameworkCore;

  public class TraineeContext : DbContext
   {
       public TraineeContext(DbContextOptions<TraineeContext> options)
           : base(options)
       {
       }

       public DbSet<TraineeModel> trainee { get; set; } = null!;
}

