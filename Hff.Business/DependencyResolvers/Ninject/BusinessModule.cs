using Hff.Business.Abstract;
using Hff.Business.Managers;
using Hff.DataAccess.Abstract;
using Hff.DataAccess.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Business.DependencyResolvers.Ninject
{
   public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            //DataAccess
            Bind<IProductDal>().To<ProductDal>().InSingletonScope();
            Bind<ICategoryDal>().To<CategoryDal>().InSingletonScope();
            Bind<IEmployeeDal>().To<EmployeeDal>().InSingletonScope();
            Bind<IExpenseDal>().To<ExpenseDal>().InSingletonScope();
            Bind<ISaleProcessDal>().To<SaleProcessDal>().InSingletonScope();
            Bind<IDepartmentDal>().To<DepartmentDal>().InSingletonScope();
            Bind<IAdminDal>().To<AdminDal>().InSingletonScope();
            Bind<IBillDal>().To<BillDal>().InSingletonScope();
            Bind<IBillLineDal>().To<BillLineDal>().InSingletonScope();
            Bind<ICustomerDal>().To<CustomerDal>().InSingletonScope();


            //Businesss
            Bind<IProductService>().To<ProductManager>();
            Bind<ICategoryService>().To<CategoryManager>();
            Bind<IEmployeeService>().To<EmployeeManager>();
            Bind<IExpenseService>().To<ExpenseManager>();
            Bind<ISaleProcessService>().To<SaleProcessManager>();
            Bind<IDepartmentService>().To<DepartmentManager>();
            Bind<IAdminService>().To<AdminManager>();
            Bind<IBillService>().To<BillManager>();
            Bind<IBillLineService>().To<BillLineManager>();
            Bind<ICustomerService>().To<CustomerManager>();
            //Context
            Bind<DbContext>().To<Context>();
        }
    }
}
