using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using paymentAPI.Models;

namespace paymentAPI.Data;

public partial class PaymentdetailContext : DbContext
{
    public PaymentdetailContext()
    {
    }

    public PaymentdetailContext(DbContextOptions<PaymentdetailContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paymentdetail> Paymentdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=paymentdetail;user=root;password=Nehabha@2929", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Paymentdetail>(entity =>
        {
            entity.HasKey(e => e.PaymentDetailId).HasName("PRIMARY");

            entity.ToTable("paymentdetails");

            entity.Property(e => e.PaymentDetailId).HasColumnName("PaymentDetailID");
            entity.Property(e => e.CardNumber).HasMaxLength(16);
            entity.Property(e => e.CardOwnerName).HasMaxLength(100);
            entity.Property(e => e.ExpirationDate).HasMaxLength(5);
            entity.Property(e => e.SecurityCode).HasMaxLength(3);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
