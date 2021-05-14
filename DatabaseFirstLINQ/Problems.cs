using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstLINQ.Models;

namespace DatabaseFirstLINQ
{
    class Problems
    {
        private ECommerceContext _context;

        public Problems()
        {
            _context = new ECommerceContext();
        }
        public void RunLINQQueries()
        {
            //ProblemOne();
            //ProblemTwo();
            //ProblemThree();
            //ProblemFour();
            //ProblemFive();
            //ProblemSix();
            //ProblemSeven();
            //ProblemEight();
            //ProblemNine();
            //ProblemTen();
            //ProblemEleven();
            //ProblemTwelve();
            //ProblemThirteen();
            //ProblemFourteen();
            //ProblemFifteen();
            //ProblemSixteen();
            //ProblemSeventeen();
            //ProblemEighteen();
            //ProblemNineteen();
            //ProblemTwenty();
            //BonusTwo();
        }

        // <><><><><><><><> R Actions (Read) <><><><><><><><><>
        private void ProblemOne()
        {
            // Write a LINQ query that returns the number of users in the Users table.
            // HINT: .ToList().Count
            var userCount = _context.Users.ToList().Count;

            {
                Console.WriteLine(userCount);

            }

            
        }

        private void ProblemTwo()
        {
            // Write a LINQ query that retrieves the users from the User tables then print each user's email to the console.
            var users = _context.Users;

            foreach (User user in users)
            {
                Console.WriteLine(user.Email);
            }

        }

        private void ProblemThree()
        {
            // Write a LINQ query that gets each product where the products price is greater than $150.
            // Then print the name and price of each product from the above query to the console.
            var product = _context.Products;


            var productsGreaterThanOneFity = product.Where(p => p.Price > 150);
            foreach (var name in productsGreaterThanOneFity)
            {
                Console.WriteLine($"{name.Price} {name.Name}");
            } 
           
        }

        private void ProblemFour()
        {
            // Write a LINQ query that gets each product that contains an "s" in the products name.
            // Then print the name of each product from the above query to the console.
            var product = _context.Products;
            var containsS = product.Where(p => p.Name.Contains("s"));
            foreach(var products in containsS)
            { 
            Console.WriteLine(products.Name);
            }
          
        }

        private void ProblemFive()
        {
            // Write a LINQ query that gets all of the users who registered BEFORE 2016
            // Then print each user's email and registration date to the console.
            var rDate = _context.Users;
            DateTime date = new DateTime(2016, 1, 1);  //year,month,day
            var beforeSixteen = rDate.Where(d => d.RegistrationDate < date);

            foreach(var dates in beforeSixteen)
            {
                Console.WriteLine($"{dates.Email} {dates.RegistrationDate}");
            }

        }

        private void ProblemSix()
        {
            // Write a LINQ query that gets all of the users who registered AFTER 2016 and BEFORE 2018
            // Then print each user's email and registration date to the console.
            var rDate = _context.Users;
            DateTime dateAfter = new DateTime(2016, 12, 31);
            DateTime dateBefore = new DateTime(2018, 1, 1);
            var beforeSixteen = rDate.Where(d => d.RegistrationDate > dateAfter && d.RegistrationDate < dateBefore);
            
            foreach(var dates in beforeSixteen)
            {
                Console.WriteLine($"{dates.Email} {dates.RegistrationDate}");
            }
            
        }

        // <><><><><><><><> R Actions (Read) with Foreign Keys <><><><><><><><><>

        private void ProblemSeven()
        {
            // Write a LINQ query that retreives all of the users who are assigned to the role of Customer.
            // Then print the users email and role name to the console.
            var customerUsers = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Customer");
            foreach (UserRole userRole in customerUsers)
            {
                Console.WriteLine($"Email: {userRole.User.Email} Role: {userRole.Role.RoleName}");
            }
        }

        private void ProblemEight()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "afton@gmail.com".
            // Then print the product's name, price, and quantity to the console.
            var user = _context.ShoppingCarts.Where(id => id.User.Email == "afton@gmail.com").Include(id => id.Product).ToList();

            foreach (ShoppingCart products in user)
            {
                Console.WriteLine($" Product Name: {products.Product.Name} Price: {products.Product.Price} Quantity: {products.Quantity}");
            }
        }

        private void ProblemNine()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "janett@gmail.com" and returns the sum of all of the products prices.
            // HINT: End of query will be: .Select(sc => sc.Product.Price).Sum();
            // Then print the total of the shopping cart to the console.
            var user = _context.ShoppingCarts.Where(id => id.User.Email == "janett@gmail.com").Include(id => id.Product).Select(sc => sc.Product.Price).Sum();
            
            Console.WriteLine(user);
        }

        private void ProblemTen()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of users who have the role of "Employee".
            // Then print the user's email as well as the product's name, price, and quantity to the console.

            var cartUser = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Employee").ToList();

            foreach(UserRole customer in cartUser)
            {
                var cartProducts = _context.ShoppingCarts.Include(sc => sc.User).Include(sc => sc.Product).Where(sc => sc.UserId == customer.UserId).ToList();
                Console.WriteLine($"{cartProducts[0].User.Email} {cartProducts[0].Product.Name} {cartProducts[0].Product.Price} {cartProducts[0].Quantity}");
            }

         }

        // <><><><><><><><> CUD (Create, Update, Delete) Actions <><><><><><><><><>

        // <><> C Actions (Create) <><>

        private void ProblemEleven()
        {
            // Create a new User object and add that user to the Users table using LINQ.
            User newUser = new User()
            {
                Email = "david@gmail.com",
                Password = "DavidsPass123"
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        private void ProblemTwelve()
        {
            // Create a new Product object and add that product to the Products table using LINQ.
            Product newProduct = new Product()
            {
                Name = "Soccer Ball",
                Description = "Bouncy",
                Price = 13
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        private void ProblemThirteen()
        {
            // Add the role of "Customer" to the user we just created in the UserRoles junction table using LINQ.
            var roleId = _context.Roles.Where(r => r.RoleName == "Customer").Select(r => r.Id).SingleOrDefault();
            var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
            UserRole newUserRole = new UserRole()
            {
                UserId = userId,
                RoleId = roleId
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        private void ProblemFourteen()
        {
            // Add the product you create to the user we created in the ShoppingCart junction table using LINQ.
            var productId = _context.Products.Where(p => p.Name == "Soccer Ball").Select(p => p.Id).SingleOrDefault();
            var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
            ShoppingCart newUserProduct = new ShoppingCart()
            {
                UserId = userId,
                ProductId = productId
            };
            _context.ShoppingCarts.Add(newUserProduct);
            _context.SaveChanges();
        }

        // <><> U Actions (Update) <><>

        private void ProblemFifteen()
        {
            // Update the email of the user we created to "mike@gmail.com"
            var user = _context.Users.Where(u => u.Email == "david@gmail.com").SingleOrDefault();
            user.Email = "mike@gmail.com";
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        private void ProblemSixteen()
        {
            // Update the price of the product you created to something different using LINQ.
            var price = _context.Products.Where(p => p.Name == "Soccer Ball").SingleOrDefault();
            price.Price = 15;


            _context.Products.Update(price);
            _context.SaveChanges();
        }

        private void ProblemSeventeen()
        {
            // Change the role of the user we created to "Employee"
            // HINT: You need to delete the existing role relationship and then create a new UserRole object and add it to the UserRoles table
            // See problem eighteen as an example of removing a role relationship
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == "mike@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            UserRole newUserRole = new UserRole()
            {
                UserId = _context.Users.Where(u => u.Email == "mike@gmail.com").Select(u => u.Id).SingleOrDefault(),
                RoleId = _context.Roles.Where(r => r.RoleName == "Employee").Select(r => r.Id).SingleOrDefault()
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        // <><> D Actions (Delete) <><>

        private void ProblemEighteen()
        {
            // Delete the role relationship from the user who has the email "oda@gmail.com" using LINQ.
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == "oda@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();
        }
        private void ProblemNineteen()
        {
            // Delete all of the product relationships to the user with the email "oda@gmail.com" in the ShoppingCart table using LINQ.
            // HINT: Loop
            var shoppingCartProducts = _context.ShoppingCarts.Where(sc => sc.User.Email == "oda@gmail.com");
            foreach (ShoppingCart userProductRelationship in shoppingCartProducts)
            {
                _context.ShoppingCarts.Remove(userProductRelationship);
            }
            _context.SaveChanges();
        }

        private void ProblemTwenty()
        {
            // Delete the user with the email "oda@gmail.com" from the Users table using LINQ.
            var userD = _context.Users.Where(ur => ur.Email == "oda@gmail.com");
            foreach (User userRelationship in userD)
            {
                _context.Users.Remove(userRelationship);
            }
            _context.SaveChanges();
        
    }

        // <><><><><><><><> BONUS PROBLEMS <><><><><><><><><>

        private void BonusOne()
        {
            // Prompt the user to enter in an email and password through the console.
            // Take the email and password and check if the there is a person that matches that combination.
            // Print "Signed In!" to the console if they exists and the values match otherwise print "Invalid Email or Password.".
        }

        private void BonusTwo()
        {
            // Write a query that finds the total of every users shopping cart products using LINQ.
            // Display the total of each users shopping cart as well as the total of the toals to the console.

            var shoppingCart = _context.ShoppingCarts
               .Include(sc => sc.Product)
               .Select(sc => new { sc.UserId, sc.Product, sc.Quantity, })
               .GroupBy(sc => sc.UserId)
               .Select(sc => new {
                   UserK = sc.Key,
                   Count = sc.Count(),
                   Subtotal = sc.Sum(st => st.Quantity * st.Product.Price),
               }
               ).ToList();

         
            decimal AllCartsTotal = 0;
            foreach (var item in shoppingCart)
            {
                Console.WriteLine($"User ID: {item.UserK} has {item.Count} in total of ${item.Subtotal}");
                AllCartsTotal += (decimal)item.Subtotal;
            }
            Console.WriteLine($"Total cart Value is ${AllCartsTotal}");

        }

        // BIG ONE
        private void BonusThree()
        {
            // 1. Create functionality for a user to sign in via the console
            // 2. If the user succesfully signs in
            // a. Give them a menu where they perform the following actions within the console
            // View the products in their shopping cart
            // View all products in the Products table
            // Add a product to the shopping cart (incrementing quantity if that product is already in their shopping cart)
            // Remove a product from their shopping cart
            // 3. If the user does not succesfully sing in
            // a. Display "Invalid Email or Password"
            // b. Re-prompt the user for credentials

        }

    }
}
