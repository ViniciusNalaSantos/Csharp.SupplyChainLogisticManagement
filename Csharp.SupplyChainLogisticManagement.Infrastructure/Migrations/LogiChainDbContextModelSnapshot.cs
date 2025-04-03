﻿// <auto-generated />
using System;
using Csharp.SupplyChainLogisticManagement.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Migrations
{
    [DbContext(typeof(LogiChainDbContext))]
    partial class LogiChainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ADDRESS");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("CUSTOMERS", (string)null);
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Deliveries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DELIVERY_DATE");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("TransportersId")
                        .HasColumnType("int")
                        .HasColumnName("TRANSPORTERS_ID");

                    b.HasKey("Id");

                    b.HasIndex("OrdersId");

                    b.HasIndex("TransportersId");

                    b.ToTable("DELIVERIES", (string)null);
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomersId")
                        .HasColumnType("int")
                        .HasColumnName("CUSTOMERS_ID");

                    b.Property<DateTime>("EmissionDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EMISSION_DATE");

                    b.Property<int>("OrdersItemsId")
                        .HasColumnType("int")
                        .HasColumnName("ORDERS_ITEMS_ID");

                    b.Property<decimal>("Price")
                        .HasPrecision(19, 6)
                        .HasColumnType("decimal(19,6)")
                        .HasColumnName("PRICE");

                    b.Property<int?>("SuppliersId")
                        .HasColumnType("int")
                        .HasColumnName("SUPPLIERS_ID");

                    b.HasKey("Id");

                    b.HasIndex("CustomersId");

                    b.HasIndex("SuppliersId");

                    b.ToTable("ORDERS", (string)null);
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.OrdersItems", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("int")
                        .HasColumnName("ORDERS_ID");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int")
                        .HasColumnName("PRODUCTS_ID");

                    b.Property<decimal>("Quantity")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("QUANTITY");

                    b.HasKey("OrdersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("ORDERS_ITEMS", (string)null);
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<decimal>("Price")
                        .HasPrecision(19, 6)
                        .HasColumnType("decimal(19,6)")
                        .HasColumnName("PRICE");

                    b.HasKey("Id");

                    b.ToTable("PRODUCTS", (string)null);
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.ProductsStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductsId")
                        .HasColumnType("int")
                        .HasColumnName("PRODUCTS_ID");

                    b.Property<int>("WarehousesId")
                        .HasColumnType("int")
                        .HasColumnName("WAREHOUSES_ID");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId");

                    b.HasIndex("WarehousesId");

                    b.ToTable("PRODUCTS_STOCK", (string)null);
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Shipments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrdersId")
                        .HasColumnType("int")
                        .HasColumnName("ORDERS_ID");

                    b.Property<DateTime>("ShipmentDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("SHIPMENT_DATE");

                    b.HasKey("Id");

                    b.HasIndex("OrdersId");

                    b.ToTable("SHIPMENTS", (string)null);
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Suppliers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PHONE");

                    b.HasKey("Id");

                    b.ToTable("SUPPLIERS", (string)null);
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Transporters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PHONE");

                    b.HasKey("Id");

                    b.ToTable("TRANSPORTERS", (string)null);
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Warehouses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("WAREHOUSES", (string)null);
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Deliveries", b =>
                {
                    b.HasOne("Csharp.SupplyChainLogisticManagement.Domain.Entities.Orders", "Orders")
                        .WithMany("Deliveries")
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Csharp.SupplyChainLogisticManagement.Domain.Entities.Transporters", "Transporters")
                        .WithMany("Deliveries")
                        .HasForeignKey("TransportersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Transporters");
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Orders", b =>
                {
                    b.HasOne("Csharp.SupplyChainLogisticManagement.Domain.Entities.Customers", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("CustomersId");

                    b.HasOne("Csharp.SupplyChainLogisticManagement.Domain.Entities.Suppliers", "Suppliers")
                        .WithMany("Orders")
                        .HasForeignKey("SuppliersId");

                    b.Navigation("Customers");

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.OrdersItems", b =>
                {
                    b.HasOne("Csharp.SupplyChainLogisticManagement.Domain.Entities.Orders", "Orders")
                        .WithMany("OrdersItems")
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Csharp.SupplyChainLogisticManagement.Domain.Entities.Products", "Products")
                        .WithMany("OrdersItems")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.ProductsStock", b =>
                {
                    b.HasOne("Csharp.SupplyChainLogisticManagement.Domain.Entities.Products", "Products")
                        .WithMany("ProductsStocks")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Csharp.SupplyChainLogisticManagement.Domain.Entities.Warehouses", "Warehouses")
                        .WithMany("ProductsStock")
                        .HasForeignKey("WarehousesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("Warehouses");
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Shipments", b =>
                {
                    b.HasOne("Csharp.SupplyChainLogisticManagement.Domain.Entities.Orders", "Orders")
                        .WithMany("Shipments")
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Customers", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Orders", b =>
                {
                    b.Navigation("Deliveries");

                    b.Navigation("OrdersItems");

                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Products", b =>
                {
                    b.Navigation("OrdersItems");

                    b.Navigation("ProductsStocks");
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Suppliers", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Transporters", b =>
                {
                    b.Navigation("Deliveries");
                });

            modelBuilder.Entity("Csharp.SupplyChainLogisticManagement.Domain.Entities.Warehouses", b =>
                {
                    b.Navigation("ProductsStock");
                });
#pragma warning restore 612, 618
        }
    }
}
