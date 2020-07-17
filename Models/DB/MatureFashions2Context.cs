using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MatureFashionsAppV2.Models.DB
{
    public partial class MatureFashions2Context : DbContext
    {
        public MatureFashions2Context()
        {
        }

        public MatureFashions2Context(DbContextOptions<MatureFashions2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Franchises> Franchises { get; set; }
        public virtual DbSet<Franchisors> Franchisors { get; set; }
        public virtual DbSet<Homes> Homes { get; set; }
        public virtual DbSet<Hometypes> Hometypes { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Orderlines> Orderlines { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Partners> Partners { get; set; }
        public virtual DbSet<Postcodes> Postcodes { get; set; }
        public virtual DbSet<Saleitems> Saleitems { get; set; }
        public virtual DbSet<Shows> Shows { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Franchises>(entity =>
            {
                entity.HasKey(e => e.FranchiseNo)
                    .HasName("PK__franchis__6D39F373C2D2CA3D");

                entity.ToTable("franchises");

                entity.Property(e => e.FranchiseNo)
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseAddress)
                    .IsRequired()
                    .HasColumnName("franchise_address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseFax)
                    .HasColumnName("franchise_fax")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseName)
                    .IsRequired()
                    .HasColumnName("franchise_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisePostcode)
                    .IsRequired()
                    .HasColumnName("franchise_postcode")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseStartdate)
                    .HasColumnName("franchise_startdate")
                    .HasColumnType("date");

                entity.Property(e => e.FranchiseTel)
                    .IsRequired()
                    .HasColumnName("franchise_tel")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisorNo)
                    .IsRequired()
                    .HasColumnName("franchisor_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.FranchisorNoNavigation)
                    .WithMany(p => p.Franchises)
                    .HasForeignKey(d => d.FranchisorNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__franchise__franc__398D8EEE");
            });

            modelBuilder.Entity<Franchisors>(entity =>
            {
                entity.HasKey(e => e.FranchisorNo)
                    .HasName("PK__franchis__3A3BACB7A9AE0C96");

                entity.ToTable("franchisors");

                entity.Property(e => e.FranchisorNo)
                    .HasColumnName("franchisor_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisorAddress)
                    .IsRequired()
                    .HasColumnName("franchisor_address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisorFax)
                    .IsRequired()
                    .HasColumnName("franchisor_fax")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisorName)
                    .IsRequired()
                    .HasColumnName("franchisor_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisorPostcode)
                    .IsRequired()
                    .HasColumnName("franchisor_postcode")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FranchisorTel)
                    .IsRequired()
                    .HasColumnName("franchisor_tel")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Homes>(entity =>
            {
                entity.HasKey(e => e.HomeNo)
                    .HasName("PK__homes__8ECADEFCB4E1A071");

                entity.ToTable("homes");

                entity.Property(e => e.HomeNo)
                    .HasColumnName("home_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.HomeAddress)
                    .IsRequired()
                    .HasColumnName("home_address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomeName)
                    .IsRequired()
                    .HasColumnName("home_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.HomePostcode)
                    .IsRequired()
                    .HasColumnName("home_postcode")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.HomeTel)
                    .IsRequired()
                    .HasColumnName("home_tel")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.HometypeCode)
                    .IsRequired()
                    .HasColumnName("hometype_code")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.HometypeCodeNavigation)
                    .WithMany(p => p.Homes)
                    .HasForeignKey(d => d.HometypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__homes__hometype___3A81B327");
            });

            modelBuilder.Entity<Hometypes>(entity =>
            {
                entity.HasKey(e => e.HometypeCode)
                    .HasName("PK__hometype__4FE16C0A42F7F559");

                entity.ToTable("hometypes");

                entity.Property(e => e.HometypeCode)
                    .HasColumnName("hometype_code")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.HometypeDescription)
                    .IsRequired()
                    .HasColumnName("hometype_description")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasKey(e => e.InvoiceNo)
                    .HasName("PK__invoices__F58CA1E3C160EFC7");

                entity.ToTable("invoices");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoice_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseNo)
                    .IsRequired()
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasColumnType("date");

                entity.Property(e => e.InvoiceDateDue)
                    .HasColumnName("invoice_date_due")
                    .HasColumnType("date");

                entity.Property(e => e.InvoiceNet)
                    .HasColumnName("invoice_net")
                    .HasColumnType("decimal(9, 2)");

                entity.Property(e => e.OrderNo)
                    .IsRequired()
                    .HasColumnName("order_no")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.FranchiseNoNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.FranchiseNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__invoices__franch__3B75D760");

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.OrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__invoices__order___3C69FB99");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemNo)
                    .HasName("PK__items__5202274EF94E5F73");

                entity.ToTable("items");

                entity.Property(e => e.ItemNo)
                    .HasColumnName("item_no")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.ItemColour)
                    .HasColumnName("item_colour")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasColumnName("item_description")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemGender)
                    .HasColumnName("item_gender")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ItemRetailPrice)
                    .HasColumnName("item_retail_price")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.ItemSize)
                    .HasColumnName("item_size")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ItemWholesalePrice)
                    .HasColumnName("item_wholesale_price")
                    .HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<Orderlines>(entity =>
            {
                entity.HasKey(e => new { e.OrderNo, e.ItemNo })
                    .HasName("PK__orderlin__B37CA3CDF11FDD24");

                entity.ToTable("orderlines");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNo)
                    .HasColumnName("item_no")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.OrderQuantity).HasColumnName("order_quantity");

                entity.HasOne(d => d.ItemNoNavigation)
                    .WithMany(p => p.Orderlines)
                    .HasForeignKey(d => d.ItemNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderline__item___3D5E1FD2");

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.Orderlines)
                    .HasForeignKey(d => d.OrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderline__order__3E52440B");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderNo)
                    .HasName("PK__orders__465C81B964E8F526");

                entity.ToTable("orders");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseNo)
                    .IsRequired()
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.FranchiseNoNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FranchiseNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__franchis__3F466844");
            });

            modelBuilder.Entity<Partners>(entity =>
            {
                entity.HasKey(e => new { e.FranchiseNo, e.PartnerName })
                    .HasName("PK__partners__0FB114D3F3D94548");

                entity.ToTable("partners");

                entity.Property(e => e.FranchiseNo)
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PartnerName)
                    .HasColumnName("partner_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.FranchiseNoNavigation)
                    .WithMany(p => p.Partners)
                    .HasForeignKey(d => d.FranchiseNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__partners__franch__403A8C7D");
            });

            modelBuilder.Entity<Postcodes>(entity =>
            {
                entity.HasKey(e => e.PostcodeArea)
                    .HasName("PK__postcode__891BAE98FDA2C45B");

                entity.ToTable("postcodes");

                entity.Property(e => e.PostcodeArea)
                    .HasColumnName("postcode_area")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseNo)
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PostcodeName)
                    .IsRequired()
                    .HasColumnName("postcode_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.FranchiseNoNavigation)
                    .WithMany(p => p.Postcodes)
                    .HasForeignKey(d => d.FranchiseNo)
                    .HasConstraintName("FK__postcodes__franc__412EB0B6");
            });

            modelBuilder.Entity<Saleitems>(entity =>
            {
                entity.HasKey(e => new { e.FranchiseNo, e.HomeNo, e.ShowDate, e.ItemNo })
                    .HasName("PK__saleitem__11533B7519A94CDC");

                entity.ToTable("saleitems");

                entity.Property(e => e.FranchiseNo)
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.HomeNo).HasColumnName("home_no");

                entity.Property(e => e.ShowDate)
                    .HasColumnName("show_date")
                    .HasColumnType("date");

                entity.Property(e => e.ItemNo)
                    .HasColumnName("item_no")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.SaleQuantity).HasColumnName("sale_quantity");

                entity.HasOne(d => d.ItemNoNavigation)
                    .WithMany(p => p.Saleitems)
                    .HasForeignKey(d => d.ItemNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__saleitems__item___4316F928");

                entity.HasOne(d => d.Shows)
                    .WithMany(p => p.Saleitems)
                    .HasForeignKey(d => new { d.FranchiseNo, d.HomeNo, d.ShowDate })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__saleitems__4222D4EF");
            });

            modelBuilder.Entity<Shows>(entity =>
            {
                entity.HasKey(e => new { e.FranchiseNo, e.HomeNo, e.ShowDate })
                    .HasName("PK__shows__65A61B57F5F5585E");

                entity.ToTable("shows");

                entity.Property(e => e.FranchiseNo)
                    .HasColumnName("franchise_no")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.HomeNo).HasColumnName("home_no");

                entity.Property(e => e.ShowDate)
                    .HasColumnName("show_date")
                    .HasColumnType("date");

                entity.Property(e => e.ShowTime)
                    .IsRequired()
                    .HasColumnName("show_time")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ShowTotalSale)
                    .HasColumnName("show_total_sale")
                    .HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.FranchiseNoNavigation)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.FranchiseNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shows__franchise__440B1D61");

                entity.HasOne(d => d.HomeNoNavigation)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.HomeNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shows__home_no__44FF419A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
