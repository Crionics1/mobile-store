using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MobileStore.Repository;
using MobileStore.Repository.Interfaces;
using MobileStore.Repository.Repositories;
using System;

namespace MobileStore.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<MobileDbContext> builder = new DbContextOptionsBuilder<MobileDbContext>();
            builder.UseSqlServer("Data Source=.;DataBase = MobileStore;Integrated Security=True");
            MobileDbContext context = new MobileDbContext(builder.Options);


            Console.ReadKey();
        }
    }
}
