using Bussiness.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Model.Data;

public class ArtBookingDbContext : DbContext
{
    public ArtBookingDbContext(DbContextOptions<ArtBookingDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<ArtOrganization> ArtOrganizations{ get; set; }
    public DbSet<ArtEvent> ArtEvents { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<ScheduleItem> ScheduleItems { get; set; }
    public DbSet<PriceList> PriceLists { get; set; }
    public DbSet<PriceEntry> PriceEntries { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasKey(u => u.UserId);
        modelBuilder.Entity<ArtOrganization>().HasKey(o => o.ArtOrganizationId);
        modelBuilder.Entity<ArtEvent>().HasKey(ae => ae.Id);
        modelBuilder.Entity<Venue>().HasKey(v => v.Id);
        modelBuilder.Entity<ScheduleItem>().HasKey(si => si.Id);
        modelBuilder.Entity<PriceList>().HasKey(pl => pl.Id);
        modelBuilder.Entity<PriceEntry>().HasKey(pe => pe.Id);
        modelBuilder.Entity<Area>().HasKey(a => a.Id);
        modelBuilder.Entity<Seat>().HasKey(s => s.Id);
        modelBuilder.Entity<Ticket>().HasKey(t => t.Id);

        modelBuilder.Entity<User>()
            .HasOne(u => u.ArtOrganization)
            .WithMany(ao => ao.Users)
            .HasForeignKey(u => u.ArtOrganizationId);

        modelBuilder.Entity<ArtEvent>()
            .HasOne(ae => ae.ArtOrganization)
            .WithMany(ao => ao.ArtEvents)
            .HasForeignKey(ae => ae.ArtOrganizationId);

        modelBuilder.Entity<Venue>()
            .HasMany(v => v.Areas)
            .WithOne(a => a.Venue)
            .HasForeignKey(a => a.VenueId);

        modelBuilder.Entity<ScheduleItem>()
            .HasOne(si => si.ArtEvent)
            .WithMany(ae => ae.ScheduleItems)
            .HasForeignKey(si => si.ArtEventId);

        modelBuilder.Entity<PriceEntry>()
            .HasOne(pe => pe.PriceList)
            .WithMany(pl => pl.PriceEntries)
            .HasForeignKey(pe => pe.PriceListId);

        modelBuilder.Entity<Area>()
            .HasMany(a => a.Seats)
            .WithOne(s => s.Area)
            .HasForeignKey(s => s.AreaId);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.ScheduleItem)
            .WithMany()
            .HasForeignKey(t => t.ScheduleItemId);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Seat)
            .WithMany()
            .HasForeignKey(t => t.SeatId);
    }
}