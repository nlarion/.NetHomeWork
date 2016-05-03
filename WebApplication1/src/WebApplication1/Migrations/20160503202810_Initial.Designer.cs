using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ToDoApp.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ToDoAppContext))]
    [Migration("20160503202810_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToDoApp.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.HasAnnotation("Relational:TableName", "Categories");
                });

            modelBuilder.Entity("ToDoApp.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<bool>("Done");

                    b.HasKey("ItemId");

                    b.HasAnnotation("Relational:TableName", "Items");
                });

            modelBuilder.Entity("ToDoApp.Models.Item", b =>
                {
                    b.HasOne("ToDoApp.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
        }
    }
}
