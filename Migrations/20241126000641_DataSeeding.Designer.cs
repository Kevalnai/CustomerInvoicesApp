﻿// <auto-generated />
using System;
using CustomerInvoicesApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerInvoicesApp.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241126000641_DataSeeding")]
    partial class DataSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerInvoicesApp.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvinceOrState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipOrPostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address1 = "27371 Valderas",
                            City = "Mission Viejo",
                            ContactEmail = "kgonz@bja.com",
                            ContactFirstName = "Keeton",
                            ContactLastName = "Gonzalo",
                            IsDeleted = false,
                            Name = "Blanchard & Johnson Associates",
                            Phone = "214-555-3647",
                            ProvinceOrState = "CA",
                            ZipOrPostalCode = "92691"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address1 = "3255 Ramos Cir",
                            City = "Sacramento",
                            ContactEmail = "manton@gmail.com",
                            ContactFirstName = "Mauro",
                            ContactLastName = "Anton",
                            IsDeleted = false,
                            Name = "California Chamber Of Commerce",
                            Phone = "916-555-6670",
                            ProvinceOrState = "CA",
                            ZipOrPostalCode = "95827"
                        },
                        new
                        {
                            CustomerId = 3,
                            Address1 = "PO Box 85826",
                            City = "San Diego",
                            ContactFirstName = "Jane",
                            ContactLastName = "Smith",
                            IsDeleted = false,
                            Name = "Golden Eagle Insurance Co",
                            Phone = "917-544-7090",
                            ProvinceOrState = "CA",
                            ZipOrPostalCode = "92186"
                        },
                        new
                        {
                            CustomerId = 4,
                            Address1 = "1952 H Street",
                            Address2 = "P.O. Box 1952",
                            City = "Fresno",
                            ContactFirstName = "Chad",
                            ContactLastName = "Jones",
                            IsDeleted = false,
                            Name = "Fresno Photoengraving Company",
                            Phone = "559-555-3005",
                            ProvinceOrState = "CA",
                            ZipOrPostalCode = "93718"
                        },
                        new
                        {
                            CustomerId = 5,
                            Address1 = "Ohio Valley Litho Division",
                            City = "Cincinnate",
                            ContactFirstName = "Paul",
                            ContactLastName = "Morgan",
                            IsDeleted = false,
                            Name = "Nielson",
                            Phone = "519-824-3477",
                            ProvinceOrState = "OH",
                            ZipOrPostalCode = "45264"
                        },
                        new
                        {
                            CustomerId = 6,
                            Address1 = "PO Box 40513",
                            City = "Jacksonville",
                            ContactEmail = "gerald.kristoff@outlook.com",
                            ContactFirstName = "Gerald",
                            ContactLastName = "Kristoff",
                            IsDeleted = false,
                            Name = "Naylor Publications Inc",
                            Phone = "800-555-6041",
                            ProvinceOrState = "FL",
                            ZipOrPostalCode = "32231"
                        },
                        new
                        {
                            CustomerId = 7,
                            Address1 = "60 Madison Ave",
                            City = "New York",
                            ContactEmail = "tneftaly@venture.com",
                            ContactFirstName = "Thalia",
                            ContactLastName = "Neftaly",
                            IsDeleted = false,
                            Name = "Venture Communications",
                            Phone = "212-533-4800",
                            ProvinceOrState = "NY",
                            ZipOrPostalCode = "10010"
                        },
                        new
                        {
                            CustomerId = 8,
                            Address1 = "Attn:  Supt. Window Services",
                            Address2 = "PO Box 7005",
                            City = "Madison",
                            ContactFirstName = "Alberto",
                            ContactLastName = "Francesco",
                            IsDeleted = false,
                            Name = "US Postal Service",
                            Phone = "800-555-1205",
                            ProvinceOrState = "WI",
                            ZipOrPostalCode = "53707"
                        });
                });

            modelBuilder.Entity("CustomerInvoicesApp.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentTermsId")
                        .HasColumnType("int");

                    b.Property<double?>("PaymentTotal")
                        .HasColumnType("float");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentTermsId");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            InvoiceId = 1,
                            CustomerId = 1,
                            InvoiceDate = new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0
                        },
                        new
                        {
                            InvoiceId = 2,
                            CustomerId = 1,
                            InvoiceDate = new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0
                        },
                        new
                        {
                            InvoiceId = 3,
                            CustomerId = 2,
                            InvoiceDate = new DateTime(2022, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0
                        },
                        new
                        {
                            InvoiceId = 4,
                            CustomerId = 2,
                            InvoiceDate = new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 4,
                            PaymentTotal = 0.0
                        },
                        new
                        {
                            InvoiceId = 5,
                            CustomerId = 3,
                            InvoiceDate = new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0
                        },
                        new
                        {
                            InvoiceId = 6,
                            CustomerId = 3,
                            InvoiceDate = new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 4,
                            PaymentTotal = 0.0
                        },
                        new
                        {
                            InvoiceId = 7,
                            CustomerId = 4,
                            InvoiceDate = new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0
                        },
                        new
                        {
                            InvoiceId = 8,
                            CustomerId = 4,
                            InvoiceDate = new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 5,
                            PaymentTotal = 0.0
                        },
                        new
                        {
                            InvoiceId = 9,
                            CustomerId = 5,
                            InvoiceDate = new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0
                        },
                        new
                        {
                            InvoiceId = 10,
                            CustomerId = 6,
                            InvoiceDate = new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0
                        },
                        new
                        {
                            InvoiceId = 11,
                            CustomerId = 7,
                            InvoiceDate = new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 2,
                            PaymentTotal = 0.0
                        },
                        new
                        {
                            InvoiceId = 12,
                            CustomerId = 8,
                            InvoiceDate = new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTermsId = 3,
                            PaymentTotal = 0.0
                        });
                });

            modelBuilder.Entity("CustomerInvoicesApp.Models.InvoiceLineItem", b =>
                {
                    b.Property<int>("InvoiceLineItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceLineItemId"));

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.HasKey("InvoiceLineItemId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceLineItems");

                    b.HasData(
                        new
                        {
                            InvoiceLineItemId = 1,
                            Amount = 1089.99,
                            Description = "Part 123",
                            InvoiceId = 1
                        },
                        new
                        {
                            InvoiceLineItemId = 2,
                            Amount = 173499.5,
                            Description = "Service XYZ",
                            InvoiceId = 1
                        },
                        new
                        {
                            InvoiceLineItemId = 3,
                            Amount = 4654499.5,
                            Description = "Part 110",
                            InvoiceId = 2
                        },
                        new
                        {
                            InvoiceLineItemId = 4,
                            Amount = 78799.5,
                            Description = "Part A",
                            InvoiceId = 2
                        },
                        new
                        {
                            InvoiceLineItemId = 5,
                            Amount = 679.5,
                            Description = "Part AA",
                            InvoiceId = 3
                        },
                        new
                        {
                            InvoiceLineItemId = 6,
                            Amount = 786.89999999999998,
                            Description = "Part Z",
                            InvoiceId = 3
                        },
                        new
                        {
                            InvoiceLineItemId = 7,
                            Amount = 998.5,
                            Description = "Trip 1",
                            InvoiceId = 4
                        },
                        new
                        {
                            InvoiceLineItemId = 8,
                            Amount = 1011.5,
                            Description = "Service XYZ",
                            InvoiceId = 4
                        },
                        new
                        {
                            InvoiceLineItemId = 9,
                            Amount = 565735.5,
                            Description = "Rental DEF",
                            InvoiceId = 5
                        },
                        new
                        {
                            InvoiceLineItemId = 10,
                            Amount = 5753.5,
                            Description = "Rental ZZZ",
                            InvoiceId = 5
                        },
                        new
                        {
                            InvoiceLineItemId = 11,
                            Amount = 58453.900000000001,
                            Description = "Service ABC",
                            InvoiceId = 6
                        },
                        new
                        {
                            InvoiceLineItemId = 12,
                            Amount = 111232.5,
                            Description = "Service ABC",
                            InvoiceId = 6
                        },
                        new
                        {
                            InvoiceLineItemId = 13,
                            Amount = 109.5,
                            Description = "Rental ABC",
                            InvoiceId = 7
                        },
                        new
                        {
                            InvoiceLineItemId = 14,
                            Amount = 57846.5,
                            Description = "Rental ABC",
                            InvoiceId = 8
                        },
                        new
                        {
                            InvoiceLineItemId = 15,
                            Amount = 132.5,
                            Description = "Trip 2",
                            InvoiceId = 9
                        },
                        new
                        {
                            InvoiceLineItemId = 16,
                            Amount = 6877.8999999999996,
                            Description = "Service XYZ",
                            InvoiceId = 9
                        },
                        new
                        {
                            InvoiceLineItemId = 17,
                            Amount = 8999.5,
                            Description = "Trip 3",
                            InvoiceId = 10
                        },
                        new
                        {
                            InvoiceLineItemId = 18,
                            Amount = 1033.5,
                            Description = "Blah blah",
                            InvoiceId = 10
                        },
                        new
                        {
                            InvoiceLineItemId = 19,
                            Amount = 56455.5,
                            Description = "Ho hum",
                            InvoiceId = 11
                        },
                        new
                        {
                            InvoiceLineItemId = 20,
                            Amount = 1454589.5,
                            Description = "Fiddle dee",
                            InvoiceId = 11
                        },
                        new
                        {
                            InvoiceLineItemId = 21,
                            Amount = 583453.5,
                            Description = "Service ABC",
                            InvoiceId = 12
                        },
                        new
                        {
                            InvoiceLineItemId = 22,
                            Amount = 567.5,
                            Description = "Fiddle dum",
                            InvoiceId = 12
                        });
                });

            modelBuilder.Entity("CustomerInvoicesApp.Models.PaymentTerms", b =>
                {
                    b.Property<int>("PaymentTermsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentTermsId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DueDays")
                        .HasColumnType("int");

                    b.HasKey("PaymentTermsId");

                    b.ToTable("PaymentTerms");

                    b.HasData(
                        new
                        {
                            PaymentTermsId = 1,
                            Description = "Net due 10 days",
                            DueDays = 10
                        },
                        new
                        {
                            PaymentTermsId = 2,
                            Description = "Net due 20 days",
                            DueDays = 20
                        },
                        new
                        {
                            PaymentTermsId = 3,
                            Description = "Net due 30 days",
                            DueDays = 30
                        },
                        new
                        {
                            PaymentTermsId = 4,
                            Description = "Net due 60 days",
                            DueDays = 60
                        },
                        new
                        {
                            PaymentTermsId = 5,
                            Description = "Net due 90 days",
                            DueDays = 90
                        });
                });

            modelBuilder.Entity("CustomerInvoicesApp.Models.Invoice", b =>
                {
                    b.HasOne("CustomerInvoicesApp.Models.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerInvoicesApp.Models.PaymentTerms", "PaymentTerms")
                        .WithMany()
                        .HasForeignKey("PaymentTermsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("PaymentTerms");
                });

            modelBuilder.Entity("CustomerInvoicesApp.Models.InvoiceLineItem", b =>
                {
                    b.HasOne("CustomerInvoicesApp.Models.Invoice", "Invoice")
                        .WithMany("InvoiceLineItems")
                        .HasForeignKey("InvoiceId");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("CustomerInvoicesApp.Models.Customer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("CustomerInvoicesApp.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceLineItems");
                });
#pragma warning restore 612, 618
        }
    }
}
