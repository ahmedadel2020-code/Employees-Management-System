using System;
using EmployeesBusinessLib;
using EmployeesEntity;
using Menue;
using System.Collections.Generic;
namespace EmployeeProject
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            // creat the menue to allow the user to choose from it
            
            MenueEntity Add = new MenueEntity()
            {
                CodeMenue = 1,
                NameMenue = "Add"
            };


            MenueEntity edit = new MenueEntity()
            {
                CodeMenue = 2,
                NameMenue = "Edit"
            };

            MenueEntity Remove = new MenueEntity()
            {
                CodeMenue = 3,
                NameMenue = "Remove"
            };          

            MenueEntity DetailsForAll = new MenueEntity()
            {
                CodeMenue = 4,
                NameMenue = "DetailsForAll"
            };

            MenueEntity DetailsForOne = new MenueEntity()
            {
                CodeMenue = 5,
                NameMenue = "DetailsForOne"
            };

           
            // add each item in menue to the list

            List<MenueEntity> _MenueList = new List<MenueEntity>();
            _MenueList.Add(Add);           
            _MenueList.Add(edit);
            _MenueList.Add(Remove);
            _MenueList.Add(DetailsForAll);
            _MenueList.Add(DetailsForOne);
           

            Console.WriteLine("Menue");
            Console.WriteLine("*****************");
            // Display menue

            foreach (MenueEntity DisplayMenue in _MenueList)
            {
                Console.WriteLine(DisplayMenue.CodeMenue + "-" + DisplayMenue.NameMenue);
            }

            Console.WriteLine("***************************************");

            // ask the user to choose from the menue
            Console.WriteLine("Please choose any number from menue ");
            int d = int.Parse((Console.ReadLine()));
            
            // search for what user enter in this menue and display it
            foreach (MenueEntity DisplayOneItem in _MenueList)
            {
                // if user enter 1 it will direct him to Add screen    
                if (d == DisplayOneItem.CodeMenue && DisplayOneItem.CodeMenue.Equals(1))
                {

                    Console.WriteLine("You are in" + " " + DisplayOneItem.NameMenue + " " + "Screen:-");
                    Console.WriteLine("-------------------------------------");
                    string createAnotherUser = "N";

                    // prompt the user to enter the data about his FullTime employees
                    do
                    {
                        EmployeeFullTimeBus EFT = new EmployeeFullTimeBus();

                        Console.WriteLine("Enter Employee FullTime Name");
                        EFT.Name = Console.ReadLine();
                        EmployeeFullTimeBus.ExName(EFT); // if user Enter number in his name it will throw an exception

                        Console.WriteLine("Enter Employee FullTime ID");
                        EFT.ID = int.Parse(Console.ReadLine());

                        Console.WriteLine("Add Birthday FullTime as following formate - month/day/year");
                        EFT.Birthday = DateTime.Parse(Console.ReadLine());
                        EmployeeFullTimeBus.ExBirthday(EFT); // if user age was < 10 it will throw an exception

                        Console.WriteLine("Add FullTime Salary");
                        EFT.Salary = int.Parse(Console.ReadLine());
                        EmployeeFullTimeBus.ExSalary(EFT); // if user Enter minus sign in his salary it will throw an exception

                        EmployeeFullTimeBus.AddEmployeesFull(EFT); // Add all data of fullTime Employees to the list

                        Console.WriteLine("Do you want to create another FullTime Employee[Y/N]?"); // ask the user again if he want to enter another FullTime Employee
                        createAnotherUser = Console.ReadLine().ToUpper();
                    } while (createAnotherUser == "Y");

                    // ask the user if he want to put PartTime Employees data
                    Console.WriteLine("Do you want to creat PartTime Employee[Y/N]?");
                    string CreatPart = Console.ReadLine().ToUpper();

                    if (CreatPart == "Y")
                    {
                        do
                        {
                            EmployeePartTimeBus EPT = new EmployeePartTimeBus();

                            Console.WriteLine("Enter Employee PartTime Name");
                            EPT.Name = Console.ReadLine();
                            EmployeePartTimeBus.ExName(EPT); // if user Enter number in his name it will throw an exception

                            Console.WriteLine("Enter Employee PartTime ID");
                            EPT.ID = int.Parse(Console.ReadLine());

                            Console.WriteLine("Add PartTime Employee Birthday as following formate - month/day/year");
                            EPT.Birthday = DateTime.Parse(Console.ReadLine());
                            EmployeePartTimeBus.ExBirthday(EPT); // if user age was < 10 it will throw an exception

                            Console.WriteLine("Add PartTime Salary");
                            EPT.Salary = int.Parse(Console.ReadLine());
                            EmployeePartTimeBus.ExSalary(EPT); // if user Enter minus sign in his salary it will throw an exception

                            EmployeePartTimeBus.AddEmployeePart(EPT); // Add all data of PartTime Employees to the list

                            Console.WriteLine("Do you want to create another PartTime Employee[Y/N]?"); // ask the user again if he want to enter another FullTime Employee
                            createAnotherUser = Console.ReadLine().ToUpper();
                        } while (createAnotherUser == "Y");

                        Console.WriteLine("FullTime Employees you added are");                       
                        EmployeeFullTimeBus.DisplayAllEmployeesFull(); // Display all FullTime Employees in the list

                        Console.WriteLine("PartTime Employees you added are");   
                        EmployeePartTimeBus.DisplayAllEmployeesPart(); // Display all PartTime Employees in the list
                    }

                    else if (CreatPart == "N")
                    {
                        Console.WriteLine("FullTime Employees you added are");
                        EmployeeFullTimeBus.DisplayAllEmployeesFull();
                    }

                    
                }
            }


            // finish Add

            // start Edit
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Do u want to go back to minue [Y/N]?"); // ask the user if he want to go back to the menue
            string backMenue = Console.ReadLine().ToUpper(); 
            if (backMenue == "y".ToUpper())
            {
                foreach (MenueEntity Back in _MenueList) // Display menue
                {
                    Console.WriteLine(Back.CodeMenue + "-" + Back.NameMenue);
                }

                Console.WriteLine("***************************************");
                Console.WriteLine("Please choose the next item from menue");  // ask the user to choose next item in the menue
                int UserInputForMenue = int.Parse((Console.ReadLine()));

                foreach (MenueEntity B in _MenueList) // search for what user enter in this menue and display it
                {
                    // if user enter 2 it will direct him to Edit screen
                    if (UserInputForMenue == B.CodeMenue && B.CodeMenue.Equals(2)) 
                    {
                        EmployeeFullTimeBus EditEmpF = new EmployeeFullTimeBus();
                        EmployeePartTimeBus EditEmpP = new EmployeePartTimeBus();
                        Console.WriteLine("You are in" + " " + B.NameMenue + " " + "Screen:-");
                        Console.WriteLine("-------------------------------------");

                        string ChooseToEdit = "N";
                       
                        Console.WriteLine("Do you watn to edit FullTime Employees[Y/N]?"); 
                        string ChooseF = Console.ReadLine().ToUpper();
                        if (ChooseF == "Y") // check if user want to edit fullTime employee
                        {
                            do
                            {
                                // prompt the user to enter ID that he want to edit
                                Console.WriteLine("Enter the ID to edit FullTime Employee");
                                EditEmpF.ID = int.Parse(Console.ReadLine());

                                Console.WriteLine("Do you Want to choose another one[Y/N]?");
                                ChooseToEdit = Console.ReadLine().ToUpper();

                                EmployeeFullTimeBus.DeleteFullTimeEmployee(EditEmpF); // Delete the old id that he want to change 

                            } while (ChooseToEdit == "Y");

                            do
                            {
                                // ask user about the new change in Employees that he want to make
                                EmployeeFullTimeBus AddEmpF = new EmployeeFullTimeBus();
                                Console.WriteLine("Enter the new correct ID of FullTime Employee");
                                AddEmpF.ID = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the new correct Name of FullTime Employee");
                                AddEmpF.Name = Console.ReadLine();
                                EmployeeFullTimeBus.ExName(AddEmpF); // vlaidation for name

                                Console.WriteLine("Enter the new correct Birthday FullTime as following formate - month/day/year");
                                AddEmpF.Birthday = DateTime.Parse(Console.ReadLine());
                                EmployeeFullTimeBus.ExBirthday(AddEmpF); // validation for age

                                Console.WriteLine("Enter the new correct FullTime Salary");
                                AddEmpF.Salary = int.Parse(Console.ReadLine());
                                EmployeeFullTimeBus.ExSalary(AddEmpF); // validation for salary

                                EmployeeFullTimeBus.AddEmployeesFull(AddEmpF); // add this new change to the list

                                Console.WriteLine("Do you Want to choose another one[Y/N]?");
                                ChooseToEdit = Console.ReadLine().ToUpper();


                            } while (ChooseToEdit == "Y");

                            Console.WriteLine("FullTime Employees after Edit");
                            EmployeeFullTimeBus.DisplayAllEmployeesFull(); // print FullTime Employees
                        }

                        Console.WriteLine("Do you watn to Edit PartTime Employee[Y/N]?");
                        string ChooseP = Console.ReadLine().ToUpper();

                        if (ChooseP == "Y")
                        {
                            do
                            {
                                // prompt the user to enter ID that he want to edit
                                Console.WriteLine("Enter the ID to Edit PartTime Employee");
                                EditEmpP.ID = int.Parse(Console.ReadLine());

                                Console.WriteLine("Do you Want to choose another one[Y/N]?");
                                ChooseToEdit = Console.ReadLine().ToUpper();

                                EmployeePartTimeBus.DeletePartTimeEmployee(EditEmpP);

                            } while (ChooseToEdit == "Y");

                            do
                            {
                                // ask user about the new change in Employees that he want to make
                                EmployeePartTimeBus AddEmpP = new EmployeePartTimeBus();
                                Console.WriteLine("Enter the new correct ID of PartTime Employee");
                                AddEmpP.ID = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the new correct Name of PartTime Employee");
                                AddEmpP.Name = Console.ReadLine();
                                EmployeePartTimeBus.ExName(AddEmpP);

                                Console.WriteLine("Enter the new correct Birthday PartTime as following formate - month/day/year");
                                AddEmpP.Birthday = DateTime.Parse(Console.ReadLine());
                                EmployeePartTimeBus.ExBirthday(AddEmpP);

                                Console.WriteLine("Enter the new correct PartTime Salary");
                                AddEmpP.Salary = int.Parse(Console.ReadLine());
                                EmployeePartTimeBus.ExSalary(AddEmpP);

                                EmployeePartTimeBus.AddEmployeePart(AddEmpP);

                                Console.WriteLine("Do you Want to choose another one[Y/N]?");
                                ChooseToEdit = Console.ReadLine().ToUpper();


                            } while (ChooseToEdit == "Y");

                            Console.WriteLine("PartTime Employees after Edit");
                            EmployeePartTimeBus.DisplayAllEmployeesPart(); // print PartTime Employees
                            

                        }
                    }
                }

            }

            // if user did't want to go backe to menue we will exit the program
            else if(backMenue == "n".ToUpper())
            {
                System.Environment.Exit(0);
            }

            // finish Edit

            //start Remove

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Do u want to go back to minue [Y/N]?");
            string backMenue1 = Console.ReadLine().ToUpper();
            if (backMenue1 == "y".ToUpper())
            {
                // Display menue
                foreach (MenueEntity Back in _MenueList)
                {
                    Console.WriteLine(Back.CodeMenue + "-" + Back.NameMenue);
                }

                Console.WriteLine("***************************************");
                Console.WriteLine("Please choose the next item from menue");
                int UserInputForMenue = int.Parse((Console.ReadLine()));

                foreach (MenueEntity B in _MenueList)
                {
                    // check that the user in Remove menue
                    if (UserInputForMenue == B.CodeMenue && B.CodeMenue.Equals(3))
                    {
                        EmployeeFullTimeBus DeleteEmpF = new EmployeeFullTimeBus();
                        EmployeePartTimeBus DeleteEmpP = new EmployeePartTimeBus();
                        Console.WriteLine("You are in" + " " + B.NameMenue + " " + "Screen:-");
                        Console.WriteLine("-------------------------------------");

                        string ChooseToDelete = "N";

                        Console.WriteLine("Do you watn to delete FullTime Employees[Y/N]?");
                        string ChooseF = Console.ReadLine().ToUpper();
                        if (ChooseF == "Y")
                        {
                            do
                            {
                                // Take the id of FullTime Employee 

                                Console.WriteLine("Enter the ID to Remove FullTime Employee");
                                DeleteEmpF.ID = int.Parse(Console.ReadLine());

                                Console.WriteLine("Do you Want to choose another one[Y/N]?");
                                ChooseToDelete = Console.ReadLine().ToUpper();

                                EmployeeFullTimeBus.DeleteFullTimeEmployee(DeleteEmpF); // Delete FullTime ID

                            } while (ChooseToDelete == "Y");

                            Console.WriteLine("Remaining FullTime Employees after deleting");
                            EmployeeFullTimeBus.DisplayAllEmployeesFull(); 
                        }

                        Console.WriteLine("Do you watn to delete PartTime Employee[Y/N]?");
                        string ChooseP = Console.ReadLine().ToUpper();

                        if (ChooseP == "Y")
                        {
                            do
                            {
                                // Take Id of PartTime Employee
                                Console.WriteLine("Enter the ID to Remove PartTime Employee");
                                DeleteEmpP.ID = int.Parse(Console.ReadLine());

                                Console.WriteLine("Do you Want to choose another one[Y/N]?");
                                ChooseToDelete = Console.ReadLine().ToUpper();

                                EmployeePartTimeBus.DeletePartTimeEmployee(DeleteEmpP); // Delete PartTime ID

                            } while (ChooseToDelete == "Y");

                            Console.WriteLine("Remaining PartTime Employees after deleting");
                            EmployeePartTimeBus.DisplayAllEmployeesPart();
                           
                        }
                    }
                }

            }

            else if (backMenue1 == "n".ToUpper())
            {
                System.Environment.Exit(0);
            }

            //finish Remove

            // start DisplayAll

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Do u want to go back to minue [Y/N]?");
            string backMenue2 = Console.ReadLine().ToUpper();
            if (backMenue2 == "y".ToUpper())
            {
                foreach (MenueEntity Back in _MenueList)
                {
                    Console.WriteLine(Back.CodeMenue + "-" + Back.NameMenue);
                }

                Console.WriteLine("***************************************");
                Console.WriteLine("Please choose the next item from menue ");
                int UserInputForMenue = int.Parse((Console.ReadLine()));

                foreach (MenueEntity B in _MenueList)
                {
                    // check that the user is in DetailsForALl Employees
                    if (UserInputForMenue == B.CodeMenue && B.CodeMenue.Equals(4))
                    {

                        Console.WriteLine("You are in" + " " + B.NameMenue + " " + "Screen:-");
                        Console.WriteLine("-------------------------------------");
                        // Display All Employees
                        Console.WriteLine("All Employees are");
                        EmployeeFullTimeBus.DisplayAllEmployeesFull();
                        EmployeePartTimeBus.DisplayAllEmployeesPart();
                    }
                }
              
            }

            
            else if (backMenue2 == "n".ToUpper())
            {
                System.Environment.Exit(0);
            }

            // finish DisplayAll

            // start DisplayOneEmployee by ID
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Do u want to go back to minue [Y/N]?");
            string backMenue3 = Console.ReadLine().ToUpper();
            if (backMenue3 == "y".ToUpper())
            {
                foreach (MenueEntity Back in _MenueList)
                {
                    Console.WriteLine(Back.CodeMenue + "-" + Back.NameMenue);
                }

                Console.WriteLine("***************************************");
                Console.WriteLine("Please choose the next item from menue ");
                int UserInputForMenue = int.Parse((Console.ReadLine()));

                foreach (MenueEntity B in _MenueList)
                {
                    if (UserInputForMenue == B.CodeMenue && B.CodeMenue.Equals(5))
                    {
                        EmployeeFullTimeBus DIDF = new EmployeeFullTimeBus();
                        EmployeePartTimeBus DIDP = new EmployeePartTimeBus();
                        
                        Console.WriteLine("You are in" + " " + B.NameMenue + " " + "Screen:-");
                        Console.WriteLine("-------------------------------------");
                        String ChooseId = "N";

                        do
                        {
                            
                            Console.WriteLine("Enter the ID to Display FullTime Employee");
                            DIDF.ID = int.Parse(Console.ReadLine());
                            EmployeeFullTimeBus.DisplayByIdFull(DIDF); // Display only one FullTime Employee

                            Console.WriteLine("Do you Want to choose another one[Y/N]?");
                            ChooseId = Console.ReadLine().ToUpper();
                                                       
                        } while (ChooseId == "Y");
                        

                        do
                        {
                            Console.WriteLine("Enter the ID to Display PartTime Employee");
                            DIDP.ID = int.Parse(Console.ReadLine());
                            EmployeePartTimeBus.DisplayByIdPart(DIDP); // Display only one PartTime Employee

                            Console.WriteLine("Do you Want to choose another one[Y/N]?");
                            ChooseId = Console.ReadLine().ToUpper();

                          
                        } while (ChooseId == "Y");
                        
                    }
                }            
            }
            else if (backMenue3 == "n".ToUpper())
            {
                System.Environment.Exit(0);
            }

            // finish Display by ID
        }   
    }
}
