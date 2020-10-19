using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.DataAccess.Concrete
{
   public class Context:DbContext
    {
        public Context()
        {
            this.Database.CommandTimeout = 99999;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillLine> BillLines { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<SalesProcess> SalesProcesses { get; set; }
        public DbSet<Admin> Admins { get; set; }


    }
}
