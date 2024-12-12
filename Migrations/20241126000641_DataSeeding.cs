﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerInvoicesApp.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address1", "Address2", "City", "ContactEmail", "ContactFirstName", "ContactLastName", "IsDeleted", "Name", "Phone", "ProvinceOrState", "ZipOrPostalCode" },
                values: new object[,]
                {
                    { 1, "27371 Valderas", null, "Mission Viejo", "kgonz@bja.com", "Keeton", "Gonzalo", false, "Blanchard & Johnson Associates", "214-555-3647", "CA", "92691" },
                    { 2, "3255 Ramos Cir", null, "Sacramento", "manton@gmail.com", "Mauro", "Anton", false, "California Chamber Of Commerce", "916-555-6670", "CA", "95827" },
                    { 3, "PO Box 85826", null, "San Diego", null, "Jane", "Smith", false, "Golden Eagle Insurance Co", "917-544-7090", "CA", "92186" },
                    { 4, "1952 H Street", "P.O. Box 1952", "Fresno", null, "Chad", "Jones", false, "Fresno Photoengraving Company", "559-555-3005", "CA", "93718" },
                    { 5, "Ohio Valley Litho Division", null, "Cincinnate", null, "Paul", "Morgan", false, "Nielson", "519-824-3477", "OH", "45264" },
                    { 6, "PO Box 40513", null, "Jacksonville", "gerald.kristoff@outlook.com", "Gerald", "Kristoff", false, "Naylor Publications Inc", "800-555-6041", "FL", "32231" },
                    { 7, "60 Madison Ave", null, "New York", "tneftaly@venture.com", "Thalia", "Neftaly", false, "Venture Communications", "212-533-4800", "NY", "10010" },
                    { 8, "Attn:  Supt. Window Services", "PO Box 7005", "Madison", null, "Alberto", "Francesco", false, "US Postal Service", "800-555-1205", "WI", "53707" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTerms",
                columns: new[] { "PaymentTermsId", "Description", "DueDays" },
                values: new object[,]
                {
                    { 1, "Net due 10 days", 10 },
                    { 2, "Net due 20 days", 20 },
                    { 3, "Net due 30 days", 30 },
                    { 4, "Net due 60 days", 60 },
                    { 5, "Net due 90 days", 90 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "CustomerId", "InvoiceDate", "PaymentDate", "PaymentTermsId", "PaymentTotal" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 2, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 3, 2, new DateTime(2022, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 4, 2, new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0.0 },
                    { 5, 3, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 6, 3, new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0.0 },
                    { 7, 4, new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 8, 4, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0.0 },
                    { 9, 5, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 10, 6, new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 11, 7, new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0.0 },
                    { 12, 8, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceLineItems",
                columns: new[] { "InvoiceLineItemId", "Amount", "Description", "InvoiceId" },
                values: new object[,]
                {
                    { 1, 1089.99, "Part 123", 1 },
                    { 2, 173499.5, "Service XYZ", 1 },
                    { 3, 4654499.5, "Part 110", 2 },
                    { 4, 78799.5, "Part A", 2 },
                    { 5, 679.5, "Part AA", 3 },
                    { 6, 786.89999999999998, "Part Z", 3 },
                    { 7, 998.5, "Trip 1", 4 },
                    { 8, 1011.5, "Service XYZ", 4 },
                    { 9, 565735.5, "Rental DEF", 5 },
                    { 10, 5753.5, "Rental ZZZ", 5 },
                    { 11, 58453.900000000001, "Service ABC", 6 },
                    { 12, 111232.5, "Service ABC", 6 },
                    { 13, 109.5, "Rental ABC", 7 },
                    { 14, 57846.5, "Rental ABC", 8 },
                    { 15, 132.5, "Trip 2", 9 },
                    { 16, 6877.8999999999996, "Service XYZ", 9 },
                    { 17, 8999.5, "Trip 3", 10 },
                    { 18, 1033.5, "Blah blah", 10 },
                    { 19, 56455.5, "Ho hum", 11 },
                    { 20, 1454589.5, "Fiddle dee", 11 },
                    { 21, 583453.5, "Service ABC", 12 },
                    { 22, 567.5, "Fiddle dum", 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "InvoiceLineItems",
                keyColumn: "InvoiceLineItemId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "PaymentTerms",
                keyColumn: "PaymentTermsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PaymentTerms",
                keyColumn: "PaymentTermsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentTerms",
                keyColumn: "PaymentTermsId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PaymentTerms",
                keyColumn: "PaymentTermsId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PaymentTerms",
                keyColumn: "PaymentTermsId",
                keyValue: 5);
        }
    }
}
