﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FT.Travelako.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCoupon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TimeExpried",
                table: "Coupons",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeExpried",
                table: "Coupons",
                type: "time",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
