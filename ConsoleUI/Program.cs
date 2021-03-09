using Business.Conrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using System;
using Business.Abstract;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //DtoTest();
            //carManagerAddTest(carManager);
            //carManagerDeleteTest(carManager);
            //carManagerUpdateTest(carManager);
            /*Brand ve Color için Business sınıfları yazılacak*/
            //customerManagerTest();
            //rentalManagerTest();
            //RentalManagerTest();
            //foreach (var rent in rental.GetAll().Data)
            //{
            //    Console.WriteLine(rent.RentDate);
            //}
            //Console.WriteLine(rental.GetRentsById(2).Data.ReturnDate);

        }

        private static void RentalManagerTest()
        {
            RentalManager rental = new RentalManager(new EfRentalDal());
            var add = rental.Add(new Rental
            {
                RentalId = 9,
                CustomerId = 3,
                CarId = 75,
                RentDate = DateTime.Now
            });
            Console.WriteLine(add.Message);
            var result = rental.GetRentDetailsDto(75);
            foreach (var rent in result.Data)
            {
                Console.WriteLine(rent.RentalId + " " +
                rent.CarBrandName + " " +
                rent.RentDate + " " + rent.ReturnDate);
            }
        }

        private static void rentalManagerTest()
        {
            RentalManager rentals = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentals.Add(new Rental
            {
                CarId = 11,
                RentalId = 6,
                CustomerId = 3,
                RentDate = new DateTime(2021, 01, 01),
                ReturnDate = new DateTime(2021, 12, 30)
            }).Message);
            foreach (var rental in rentals.GetAll().Data)
            {
                Console.WriteLine(rental.RentalId + " " + rental.RentDate + " " + rental.ReturnDate);
            }
        }

        private static void customerManagerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //Console.WriteLine(customerManager.Delete(new Customer { CustomerId = 5, UserId = 2, CompanyName = "Selmaaaa" }).Message);
            foreach (var result in customerManager.GetAll().Data)
            {
                Console.WriteLine(result.CompanyName);
            }
            Console.WriteLine(customerManager.GetCustomersById(1).Data.CompanyName);
        }

        private static void carManagerAddTest(CarManager carManager)
        {
            var result = carManager.Add(new Car { CarId = 81, BrandId = 1, ColorId = 1, DailyPrice = 1200 });
            Console.WriteLine(result.Message);
        }

        private static void carManagerDeleteTest(CarManager carManager)
        {
            var result = carManager.Delete(new Car { CarId = 81/*, BrandId = 1, ColorId = 1, DailyPrice = 1200 */});
            Console.WriteLine(result.Message);
        }

        private static void carManagerUpdateTest(CarManager carManager)
        {
            var result = carManager.Update(new Car { CarId = 14, BrandId = 1, ColorId = 1, DailyPrice = 1200 });
            Console.WriteLine(result.Message);
        }

        private static void DtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetailsDto();
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", car.CarId, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }
    }
}
