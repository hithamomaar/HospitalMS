using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "GenericName", "IsDeleted", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, "Paracetamol", false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 2, "Amoxicillin/Clavulanate", false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Augmentin" },
                    { 3, "Acetylsalicylic Acid", false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aspirin" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Description", "Image", "IsDeleted", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, "Diagnosis and treatment of heart diseases", "cardiology.png", false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cardiology" },
                    { 2, "Brain, spinal cord, and nervous system care", "neurology.png", false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neurology" },
                    { 3, "Bones, joints, and musculoskeletal treatment", "orthopedics.png", false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orthopedics" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "FullName", "Gender", "IsDeleted", "LastModified", "NationalId", "ProfileImage" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Ahmed Samir", 0, false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "29801010100001", "doctor1.jpg" },
                    { 2, new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Sara Nabil", 1, false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "29202020200002", "doctor2.jpg" },
                    { 3, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hassan Omar", 0, false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "30103030300003", "patient1.jpg" },
                    { 4, new DateTime(2002, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mona Adel", 1, false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "30204040400004", "patient2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "HireDate", "HourRate", "LicenseNumber", "SpecialtyId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700m, "LIC-1001", 1 },
                    { 2, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 800m, "LIC-1002", 2 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "BloodType" },
                values: new object[,]
                {
                    { 3, 0 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "DoctorSchedules",
                columns: new[] { "Id", "DoctorId", "EndTime", "IsBooked", "IsDeleted", "LastModified", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 3, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2026, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2026, 3, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 21, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CancellationReason", "IsDeleted", "LastModified", "PatientId", "ScheduleId", "Status" },
                values: new object[] { 1, "", false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
