// See https://aka.ms/new-console-template for more information
using HousingSociety.Data;
using HousingSociety.Domain;

Console.WriteLine("Hello, World!");


HousingSocietyDbContext dbContext = new HousingSocietyDbContext();


List<Flat> flats = dbContext.Flats.ToList();
int rowsAffected = 0;
char toContinue = 'y';
int tableChoice = 0;
int choice = 0;



do
{
    Console.WriteLine("Enter 1 => Flat 2 =>Maintenance 3=>Transaction");

    tableChoice = int.Parse(Console.ReadLine());
    if (tableChoice == 1)
    {
        Console.WriteLine("Select 1-->Add New Flat 2-->Reading the Flat Details 3--> Update the flat details 4-->Delete the flat details");
     choice= int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter the Flat Details: ");
                Flat flat = new Flat();
                Console.WriteLine("Flat Name");
                flat.FlatName = Console.ReadLine();
                Console.WriteLine("Flat Owner");
                flat.FlatOwner = Console.ReadLine();
                Console.WriteLine("Wing");
                flat.Wing = Console.ReadLine();
                Console.WriteLine("Aadhar Number");
                flat.AAdhar = long.Parse(Console.ReadLine());
                Console.WriteLine("Email");
                flat.Email = Console.ReadLine();
                Console.WriteLine("Phone Number");
                flat.Contact = long.Parse(Console.ReadLine());

                //Adding the new Data to the DBSET
                dbContext.Flats.Add(flat); // Creating a Insert SQL query 

                //Save the changes to DB permently
                rowsAffected = dbContext.SaveChanges(); // Execute the created INsert query
                if (rowsAffected > 0)
                    Console.WriteLine("Flat Details Added");

                break;
            case 2:
                flats = dbContext.Flats.ToList();
                foreach (Flat item in flats)
                {
                    Console.WriteLine(item.FlatName + "    " + item.Contact);
                }
                break;
            case 3:
                Console.WriteLine("Enter the Flat Name For Changing the Contact");
                string flatName = Console.ReadLine();
                Flat _flat = dbContext.Flats.ToList().Find(t => t.FlatName == flatName);
                Console.WriteLine("New Contact :");
                _flat.Contact = long.Parse(Console.ReadLine());
                rowsAffected = dbContext.SaveChanges();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Flat " + flatName + " has changed the contact as " + _flat.Contact);
                }

                break;
            case 4:
                Console.WriteLine("Enter the Flat Name For Deleting");
                flatName = Console.ReadLine();
                _flat = dbContext.Flats.ToList().Find(t => t.FlatName == flatName);
                //    dbContext.Flats.Remove(_flat); // Hard Delete of data
                _flat.IsActive = false; // Doing a soft delete of data.
                rowsAffected = dbContext.SaveChanges();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Flat " + _flat.FlatName + " is deleted");
                }
                break;
            default:
                Console.WriteLine("Find the list of flats in The given Wing ");
                Console.WriteLine("Enter the Wing");
                string wing = Console.ReadLine();
                Console.WriteLine("The Flats in Wing " + wing + " are :");
                List<Flat> f = dbContext.Flats.Where(ff => ff.Wing == wing).ToList();
                foreach (var item in f)
                {
                    Console.WriteLine(item.FlatName + "     " + item.FlatOwner + "   " + item.Wing);
                }

                Console.WriteLine("Display No.Of Flats Active in each wing : ");
                var query = from temp in dbContext.Flats
                            where temp.Wing != "D"
                            group temp by temp.Wing into grp

                            select new { Wing = grp.Key, Count = grp.Count() };

                foreach (var item in query)
                {
                    Console.WriteLine(item.Wing + "   " + item.Count);
                }
                break;
        }
    }

        else if (tableChoice == 2)
{
        Console.WriteLine("Select 1-->Add New Maintenance 2-->Reading the Maintenance Details ");
choice= int.Parse(Console.ReadLine());
        switch(choice)
        {
            case 1:
                Console.WriteLine("Enter the Maintenance Type");
                Maintenance maintenance = new Maintenance();
                maintenance.MaintenanceType = Console.ReadLine();
                dbContext.Maintenances.Add(maintenance);
                rowsAffected = dbContext.SaveChanges();
                if (rowsAffected>0)
                {
                    Console.WriteLine("New Maintenance Added");
                }
                break;
            case 2:
                List<Maintenance> maintenances = dbContext.Maintenances.ToList();

                Console.WriteLine("Maintenance ID\t Maintenances Type");
                foreach (var item in maintenances)
                {
                    Console.WriteLine(item.MaintenanceId+"\t"+item.MaintenanceType);
                }
                break;

        }

    }

    else if (tableChoice == 3)
    {
        Console.WriteLine("Select 1-->Add New Transaction 2-->Reading the Transaction Details 3--> Update the Transaction details ");
        choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter the Maintenance Type");
                string mType = Console.ReadLine();
                Transaction transaction = new Transaction();
                Console.WriteLine("Enter the Flat Name For Transaction");
                string fName = Console.ReadLine();
                transaction.Flat = dbContext.Flats.FirstOrDefault(f => f.FlatName == fName);
                //    Console.WriteLine("Enter the Maintenance Type");

                Console.WriteLine("Transaction Date");
                transaction.TransactionDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Transaction Amount");
                transaction.TransactionAmount = int.Parse(Console.ReadLine());
              transaction. Maintenance  = dbContext.Maintenances.FirstOrDefault(r => r.MaintenanceType == mType);
              //  transaction. Maintenance.MaintenanceId= m.MaintenanceId;
                  dbContext.Transactions.Add(transaction);
                rowsAffected = dbContext.SaveChanges();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("New Transaction Added");
                }
                break;
            case 2:
                List<Transaction> transactions =  dbContext.Transactions.ToList();

                Console.WriteLine("Transaction ID\t Maintenances Type\t Transaction Date \t Transaction Amount\t Flat Name");
                foreach (var item in transactions)
                {
                   
                    Console.WriteLine(item.TransactionId + "\t" + item.Maintenance.MaintenanceType + "\t" + item.TransactionDate + "\t" + item.TransactionAmount + "\t" + item.Flat.FlatName);
                }
                break;

        }

    }

    Console.WriteLine("Do you want to continue (y/n)? ");
    toContinue = char.Parse(Console.ReadLine());

} while (toContinue == 'y' || toContinue == 'Y');
       
    
    
