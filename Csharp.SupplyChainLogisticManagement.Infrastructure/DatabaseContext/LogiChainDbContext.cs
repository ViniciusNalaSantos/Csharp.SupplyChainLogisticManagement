using Csharp.SupplyChainLogisticManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;

public class LogiChainDbContext : DbContext
{
    public LogiChainDbContext(DbContextOptions<LogiChainDbContext> options)
    : base(options) 
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrdersItems> OrdersItems { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<ProductsStock> ProductsStock { get; set; }
    public DbSet<Warehouses> Warehouses { get; set; }
    public DbSet<Shipments> Shipments { get; set; }
    public DbSet<Deliveries> Deliveries { get; set; }
    public DbSet<Transporters> Transporters { get; set; }
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Suppliers> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ModelOrders(modelBuilder);
        ModelOrdersItems(modelBuilder);
        ModelProducts(modelBuilder);
        ModelProductsStock(modelBuilder);
        ModelWarehouses(modelBuilder);
        ModelShipments(modelBuilder);
        ModelDeliveries(modelBuilder);
        ModelTransporters(modelBuilder);
        ModelCustomers(modelBuilder);
        ModelSuppliers(modelBuilder);
    }

    private void ModelOrders(ModelBuilder modelBuilder)
    {
        var entityModelBuilder = modelBuilder.Entity<Orders>();

        entityModelBuilder
            .ToTable("ORDERS")
            .HasKey(l => l.Id);

        entityModelBuilder
            .Property(l => l.Id)
            .HasColumnName("ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.EmissionDate)
            .HasColumnName("EMISSION_DATE")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.CustomersId)
            .HasColumnName("CUSTOMERS_ID")
            .IsRequired(false);

        entityModelBuilder
            .Property(l => l.SuppliersId)
            .HasColumnName("SUPPLIERS_ID")
            .IsRequired(false);

        entityModelBuilder
            .Property(l => l.Price)
            .HasColumnName("PRICE")
            .IsRequired()
            .HasPrecision(19,6);

        entityModelBuilder
            .HasOne(l => l.Customers)
            .WithMany(l => l.Orders)
            .HasForeignKey(l => l.CustomersId);

        entityModelBuilder
            .HasOne(l => l.Suppliers)
            .WithMany(l => l.Orders)
            .HasForeignKey(l => l.SuppliersId);
    }
    private void ModelOrdersItems(ModelBuilder modelBuilder)
    {
        var entityModelBuilder = modelBuilder.Entity<OrdersItems>();

        entityModelBuilder
            .ToTable("ORDERS_ITEMS")
            .HasKey(l => new { l.OrdersId, l.ProductsId });

        entityModelBuilder
            .Property(l => l.OrdersId)
            .HasColumnName("ORDERS_ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.ProductsId)
            .HasColumnName("PRODUCTS_ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.Quantity)
            .HasColumnName("QUANTITY")
            .IsRequired()
            .HasPrecision(10, 2);

        entityModelBuilder
            .HasOne(l => l.Orders)
            .WithMany(l => l.OrdersItems)
            .HasForeignKey(l => l.OrdersId);

        entityModelBuilder
            .HasOne(l => l.Products)
            .WithMany(l => l.OrdersItems)
            .HasForeignKey(l => l.ProductsId);
    }
    private void ModelProducts(ModelBuilder modelBuilder)
    {
        var entityModelBuilder = modelBuilder.Entity<Products>();

        entityModelBuilder
            .ToTable("PRODUCTS")
            .HasKey(l => l.Id);

        entityModelBuilder
            .Property(l => l.Id)
            .HasColumnName("ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.Description)
            .HasColumnName("DESCRIPTION")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.Price)
            .HasColumnName("PRICE")
            .IsRequired()
            .HasPrecision(19, 6);
    } 
    private void ModelProductsStock(ModelBuilder modelBuilder)
    {
        var entityModelBuilder = modelBuilder.Entity<ProductsStock>();

        entityModelBuilder
            .ToTable("PRODUCTS_STOCK")
            .HasKey(l => l.Id);

        entityModelBuilder
            .Property(l => l.Id)
            .HasColumnName("ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.ProductsId)
            .HasColumnName("PRODUCTS_ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.WarehousesId)
            .HasColumnName("WAREHOUSES_ID")
            .IsRequired();

        entityModelBuilder
            .HasOne(l => l.Products)
            .WithMany(l => l.ProductsStocks)
            .HasForeignKey(l => l.ProductsId);

        entityModelBuilder
            .HasOne(l => l.Warehouses)
            .WithMany(l => l.ProductsStock)
            .HasForeignKey(l => l.WarehousesId);
    }
    private void ModelWarehouses(ModelBuilder modelBuilder)
    {
        var entityModelBuilder = modelBuilder.Entity<Warehouses>();

        entityModelBuilder
            .ToTable("WAREHOUSES")
            .HasKey(l => l.Id);

        entityModelBuilder
            .Property(l => l.Id)
            .HasColumnName("ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.Name)
            .HasColumnName("NAME")
            .IsRequired();
    }
    private void ModelShipments(ModelBuilder modelBuilder)
    {
        var entityModelBuilder = modelBuilder.Entity<Shipments>();

        entityModelBuilder
            .ToTable("SHIPMENTS")
            .HasKey(l => l.Id);

        entityModelBuilder
            .Property(l => l.Id)
            .HasColumnName("ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.OrdersId)
            .HasColumnName("ORDERS_ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.ShipmentDate)
            .HasColumnName("SHIPMENT_DATE")
            .IsRequired();

        entityModelBuilder
            .HasOne(l => l.Orders)
            .WithMany(l => l.Shipments)
            .HasForeignKey(l => l.OrdersId);
    }
    private void ModelDeliveries(ModelBuilder modelBuilder)
    {
        var entityModelBuilder = modelBuilder.Entity<Deliveries>();

        entityModelBuilder
            .ToTable("DELIVERIES")
            .HasKey(l => l.Id);

        entityModelBuilder
            .Property(l => l.Id)
            .HasColumnName("ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.TransportersId)
            .HasColumnName("TRANSPORTERS_ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.DeliveryDate)
            .HasColumnName("DELIVERY_DATE")
            .IsRequired();

        entityModelBuilder
            .HasOne(l => l.Orders)
            .WithMany(l => l.Deliveries)
            .HasForeignKey(l => l.OrdersId);

        entityModelBuilder
            .HasOne(l => l.Transporters)
            .WithMany(l => l.Deliveries)
            .HasForeignKey(l => l.TransportersId);
    }
    private void ModelTransporters(ModelBuilder modelBuilder)
    {
        var entityModelBuilder = modelBuilder.Entity<Transporters>();

        entityModelBuilder
            .ToTable("TRANSPORTERS")
            .HasKey(l => l.Id);

        entityModelBuilder
            .Property(l => l.Id)
            .HasColumnName("ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.Name)
            .HasColumnName("NAME")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.Email)
            .HasColumnName("EMAIL")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.Phone)
            .HasColumnName("PHONE")
            .IsRequired();
    }
    private void ModelCustomers(ModelBuilder modelBuilder)
    {
        var entityModelBuilder = modelBuilder.Entity<Customers>();

        entityModelBuilder
            .ToTable("CUSTOMERS")
            .HasKey(l => l.Id);

        entityModelBuilder
            .Property(l => l.Id)
            .HasColumnName("ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.Name)
            .HasColumnName("NAME")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.Email)
            .HasColumnName("EMAIL")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.Address)
            .HasColumnName("ADDRESS")
            .IsRequired();
    }
    private void ModelSuppliers(ModelBuilder modelBuilder)
    {
        var entityModelBuilder = modelBuilder.Entity<Suppliers>();

        entityModelBuilder
            .ToTable("SUPPLIERS")
            .HasKey(l => l.Id);

        entityModelBuilder
            .Property(l => l.Id)
            .HasColumnName("ID")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.Name)
            .HasColumnName("NAME")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.Email)
            .HasColumnName("EMAIL")
            .IsRequired();

        entityModelBuilder
            .Property(l => l.Phone)
            .HasColumnName("PHONE")
            .IsRequired();
    }
}
