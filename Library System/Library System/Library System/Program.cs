using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Library_System
{
   class Design
   {
      public static void Line()
      {
         char[] lines = new char[120];
         lines[0] = '*';
         for (int i = 0; i < lines.Length - 1; ++i)
         {
            if (lines[i] == '*')
               lines[i + 1] = '*';
         }
         foreach (int number in lines)
         {
            Console.Write(lines[number]);
            Console.Beep(100, 10);
         }
      }
      public static void Lines()
      {
         Console.WriteLine();
         Console.WriteLine();
         Console.ForegroundColor = ConsoleColor.Black;
         Line();
         Line();
         clear();
      }
      public static void Lines2red()
      {
         Console.WriteLine();
         Console.WriteLine();
         Console.ForegroundColor = ConsoleColor.Red;
         Line();
         Line();
         clear();
      }
      public static void Lines2()
      {
         Console.WriteLine();
         Console.WriteLine();
         Console.ForegroundColor = ConsoleColor.Black;
         Line();
         Line();
         //  clear();
      }
      public static void Welcome1()
      {
         Console.SetCursorPosition(0, 10);
         Console.ForegroundColor = ConsoleColor.Red;
         Line();
         Console.ForegroundColor = ConsoleColor.White;
         Line();

         Console.SetCursorPosition(47, 14);
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.WriteLine("Welcome to Library System.");

         Console.SetCursorPosition(0, 17);
         Console.ForegroundColor = ConsoleColor.White;
         Line();
         Console.ForegroundColor = ConsoleColor.Red;
         Line();
      }
      public static void clear()
      {
         Console.Beep(1000, 2000);
         Console.Clear();
      }
      public static void Welcome2()
      {
         Console.BackgroundColor = ConsoleColor.Yellow;
         Console.Clear();
         Console.ForegroundColor = ConsoleColor.Black;
         Line();
         Line();
         Console.ForegroundColor = ConsoleColor.Black;
         Console.SetCursorPosition(47, 3);
         Console.WriteLine("Welcome To Library System");
         Console.SetCursorPosition(0, 5);
         Line();
         Line();
      }
      public static void exit()
      {
         Console.BackgroundColor = ConsoleColor.Black;
         Console.Clear();
         Console.SetCursorPosition(0, 10);
         Console.ForegroundColor = ConsoleColor.Red;
         Line();
         Console.ForegroundColor = ConsoleColor.White;
         Line();

         Console.SetCursorPosition(42, 14);
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.WriteLine("End the Library System.");

         Console.SetCursorPosition(0, 17);
         Console.ForegroundColor = ConsoleColor.White;
         Line();
         Console.ForegroundColor = ConsoleColor.Red;
         Line();
      }
   }
   class Windows
   {
      //variables
      public static int number, id, Not = 1;
      public static string Fname, Mname, Lname, colloge, university, dept, TempID;

      //method of calss Windows

      //1) Welcome To Library System
      public static void page1()
      {
         Design.Welcome1();
         Design.clear();
      }

      /*2)Question Card
       * yes goto verification from that
       * no goto Registering a Student 
       */
      public static void page2()
      {
         Console.BackgroundColor = ConsoleColor.Red;
         Console.Clear();
         Console.SetCursorPosition(0, 3);
         Console.ForegroundColor = ConsoleColor.Black;
         Design.Line();
         Design.Line();
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.SetCursorPosition(40, 7);
         Console.WriteLine("Do You Have an universal card?");
         Console.SetCursorPosition(40, 9);
         Console.Write("1- Yes.");
         Console.WriteLine("\t\t    2- No.");
         Console.SetCursorPosition(40, 11);
         Console.Write("Enter the number: ");
      l1:
         try
         {
            number = int.Parse(Console.ReadLine());
         }
         catch
         {
            Console.Write("Enter the number: ((1 or 2)): ");
            goto l1;
         }
         switch (number)
         {
            case 1:
               Design.Lines();
               verification();
               break;
            case 2:
               Design.Lines();
               Pagestudent();
               break;
            default:
               Console.Write("Enter Just number: ((1 or 2)): ");
               goto l1;
         }
      }

      /*3)verification from the Student
         he is found?
         yes goto booklist
         no Question Card
      */
      public static void verification()
      {
         Design.Welcome2();
         Console.ForegroundColor = ConsoleColor.DarkRed;
         Console.SetCursorPosition(45, 12);
         Console.Write("Enter your ID: ");
         Console.ForegroundColor = ConsoleColor.DarkGreen;
      l3:
         try
         {
            id = int.Parse(Console.ReadLine());
         }
         catch
         {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Enter your ID ((Number)): ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            goto l3;
         }
         Console.ForegroundColor = ConsoleColor.Black;
         Console.Write("\nPlease Wait ...");

         //Collection With the database of student
         {
            try
            {
               SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\السباعي\Desktop\Library System\Library System\Library System\Students.mdf;Integrated Security=True");
               con.Open();
               Console.WriteLine("\n\n\t\t\t\t\t\tDatabase Connected");
               SqlCommand search = new SqlCommand("Select Id from Students", con);
               SqlDataReader value = search.ExecuteReader();
               while (value.Read())
               {
                  TempID = value.GetValue(0).ToString();
                  if (TempID == Convert.ToString(id))
                  {
                     Not = 0;
                     Console.WriteLine("\t\t\t\t\t       ^_^ We find you ^_^");
                  }
               }
               if (Not == 1)
                  Console.WriteLine("\t\t\t\t\t<'_'> You are Not in our system <'_'>");
               con.Close();
            }
            catch (Exception x)
            {
               Console.WriteLine(x.Message);
            }
            Design.Lines();
            if (Not == 1)
               page2();
            else
               LibrarySystem.book();
         }
      }

      //4)Registering a Student
      public static void Pagestudent()
      {
         Design.Welcome2();
         Console.SetCursorPosition(0, 7);
         Console.ForegroundColor = ConsoleColor.DarkBlue;
         Console.WriteLine("Enter your ID: ");
         Console.ForegroundColor = ConsoleColor.Red;
      l2:
         try
         {
            id = int.Parse(Console.ReadLine());
         }
         catch
         {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Enter your ID ((Number)): ");
            Console.ForegroundColor = ConsoleColor.Red;
            goto l2;
         }
         Console.ForegroundColor = ConsoleColor.DarkBlue;
         Console.WriteLine("Enter your First name: ");
         Console.ForegroundColor = ConsoleColor.Red;
         Fname = Console.ReadLine();
         Console.ForegroundColor = ConsoleColor.DarkBlue;
         Console.WriteLine("Enter your Middel name: ");
         Console.ForegroundColor = ConsoleColor.Red;
         Mname = Console.ReadLine();
         Console.ForegroundColor = ConsoleColor.DarkBlue;
         Console.WriteLine("Enter your Last name: ");
         Console.ForegroundColor = ConsoleColor.Red;
         Lname = Console.ReadLine();
         Console.ForegroundColor = ConsoleColor.DarkBlue;
         Console.WriteLine("Enter your Colloge's name: ");
         Console.ForegroundColor = ConsoleColor.Red;
         colloge = Console.ReadLine();
         Console.ForegroundColor = ConsoleColor.DarkBlue;
         Console.WriteLine("Enter your University's name:");
         Console.ForegroundColor = ConsoleColor.Red;
         university = Console.ReadLine();
         Console.ForegroundColor = ConsoleColor.DarkBlue;
         Console.WriteLine("Enter your Department's name:");
         Console.ForegroundColor = ConsoleColor.Red;
         dept = Console.ReadLine();
         Console.ForegroundColor = ConsoleColor.Black;
         Console.Write("\nPlease Wait ...");
         //Collection With the database of student
         {
            try
            {
               SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\السباعي\Desktop\Library System\Library System\Library System\Students.mdf;Integrated Security=True");
               con.Open();
               Console.WriteLine("\n\n\t\t\t\t\t\tDatabase Connected");
               SqlCommand insert = new SqlCommand("Insert into Students values ('" + id + "','" + Fname + "','" + Mname + "','" + Lname + "','" + colloge + "','" + university + "','" + dept + "')", con);
               insert.ExecuteNonQuery();
               Console.WriteLine("\t\t\t\t\t  ^_^ The Information Inserted ^_^");
               con.Close();
            }
            catch (Exception x)
            {
               Console.WriteLine(x.Message);
            }
         }
         Design.Lines();
         LibrarySystem.book();
      }
      
      //read to file
      public static void file()
      {
        foreach (var value in LibrarySystem.array)
         {
            File.AppendAllText("Library System.txt", "\n"+value);
         }
         File.AppendAllText("Library System.txt", "***********************************************************************************************************************");
      }
   }
   class LibrarySystem
   {
      public static int dept, Dept, bookId, number, days, hour, i = 0, money = 0,Not =1;
      public static DateTime thatday, today = DateTime.Now;
      public static TimeSpan st;
      public static string quere;
      public static string [] array =new string[11];

      public static void book()
      {
         //Collection With the database of book
         {
            try
            {
               SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\السباعي\Desktop\Library System\Library System\Library System\Books.mdf;Integrated Security=True");
               Design.Welcome2();
               Console.WriteLine();
               Console.WriteLine("\n\t\t\t\t\t   Database Connected");
               Console.WriteLine("Choose number from 1 to 3: ");
               Console.WriteLine("1) Information System. ");
               Console.WriteLine("2) Information Technology. ");
               Console.WriteLine("3) Computer Science. ");
               Console.Write("Please enter your choice:");
            l5:
               try
               {
                  number = int.Parse(Console.ReadLine());
               }
               catch
               {
                  Console.Write("Enter the number: ((1 or 2 or 3 )): ");
                  goto l5;
               }
               dept = number;
               switch (number)
               {
                  case 1:
                     Department(1);
                     break;
                  case 2:
                     Department(2);
                     break;
                  case 3:
                     Department(3);
                     break;
                  default:
                     Console.Write("Enter Just number: ((1 or 2 or 3 )): ");
                     goto l5;
               }
            l7:
               Console.Write("\nEnter the number of book: ");
            l6:
               try
               { 
                  bookId = int.Parse(Console.ReadLine());
                  con.Open();
                  SqlCommand search = new SqlCommand("Select number from books", con);
                  SqlDataReader value = search.ExecuteReader();
                  while (value.Read())
                  {
                     if (value.GetValue(0).ToString() == Convert.ToString(bookId) )
                     {
                           Not = 0;
                           Console.WriteLine("\t\t\t\t\t       ^_^ We find the book ^_^");
                           break;
                      }
                  }
                  con.Close();
                  if (Not == 1)
                  {
                     Console.WriteLine("\t\t\t\t\t<'_'> The book is Not in our Libraray <'_'>");
                     goto l7;
                  }
                  
                }
               catch (Exception x)
               {
                  Console.WriteLine(x.Message);
                  Console.Write("\nEnter THE NUMBER OF BOOK: ");
                  goto l6;
               }
               Design.Lines2();
               Design.clear();
               List();
               
            }
            catch (Exception x)
            {
               Console.WriteLine(x.Message);
            }
         }
      }
      public static void Department(int dept)
      {
         //Collection With the database of book

         {
            try
            {
               SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\السباعي\Desktop\Library System\Library System\Library System\Books.mdf;Integrated Security=True");
               con.Open();
               Design.Line();
               Console.WriteLine();
               Console.WriteLine("\n\t\t\t\t\t   Database Connected");
               if (dept == 1)
               {
                  Console.WriteLine("\t\t\t\t ^_^ The Information System's 1books ^_^");
                  quere = "select * from books where [IS] != 0 ";
               }
               if (dept == 2)
               {
                  Console.WriteLine("\t\t\t\t ^_^ The Information Technology's  books ^_^");
                  quere = "select * from books where IT != 0 ";
               }
               if (dept == 3)
               {
                  Console.WriteLine("\t\t\t\t ^_^ The Computer Science's  books ^_^");
                  quere = "select * from books where CS != 0 ";
               }
               SqlCommand department = new SqlCommand(quere, con);
               department.ExecuteNonQuery();
               SqlDataReader Dr = department.ExecuteReader();

               while (Dr.Read())
               {
                  Console.WriteLine(Dr.GetValue(0).ToString() + ") " + Dr.GetValue(1).ToString());
               }
               con.Close();
               con.Open();
               SqlCommand insert = new SqlCommand("Insert into books (tokenFrom) values ('" +dept + "')", con);
               insert.ExecuteNonQuery();
               con.Close();
            }
            catch (Exception x)
            {
               Console.WriteLine(x.Message);
            }
         }
      }
      public static void bookInformation()
      {
         //Collection With the database of book
         {
            try
            {
               SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\السباعي\Desktop\Library System\Library System\Library System\Books.mdf;Integrated Security=True");
               con.Open();
               SqlCommand readB = new SqlCommand("select * from books where number= '" + bookId + "'", con);
               SqlDataReader drB = readB.ExecuteReader();
               drB.Read();
               array[6] = "The book's name is: " + drB.GetValue(1).ToString();
               array[7] = "The book's author is: " + drB.GetValue(2).ToString();
               array[8] = "The book's edition is: " + drB.GetValue(3).ToString();
               Console.WriteLine("The book's name is: " + drB.GetValue(1).ToString());
               Console.WriteLine("The book's author is: " + drB.GetValue(2).ToString());
               Console.WriteLine("The book's edition is: " + drB.GetValue(3).ToString());
               switch (drB.GetValue(9).ToString())
               {
                  case "1":
                     array[9] = "The book from information system department .";
                     Console.WriteLine("The book from information system department .");
                     break;
                  case "2":
                     array[9] = "The book from information technology department .";
                     Console.WriteLine("The book from information technology department .");
                     break;
                  case "3":
                     array[9] = "The book from computer science department .";
                     Console.WriteLine("The book from computer science department .");
                     break;
               }
               con.Close();
            }
            catch (Exception x)
            {
               Console.WriteLine(x.Message);
            }
         }
      }
      public static void studentInformation()
      {
         //Collection With the database of student
         {
            try
            {
               SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\السباعي\Desktop\Library System\Library System\Library System\Students.mdf;Integrated Security=True");
               con.Open();
               SqlCommand readS = new SqlCommand("select * from students where id= '" + Windows.id + "'", con);
               SqlDataReader drS = readS.ExecuteReader();
               drS.Read();
               array[0] = "Your ID is: " + drS.GetValue(0).ToString();
               array[1] = "Your name is: " + drS.GetValue(1).ToString() + " " + drS.GetValue(2).ToString() + " " + drS.GetValue(3).ToString();
               array[2] = "Your Colloge's name is: " + drS.GetValue(4).ToString();
               array[3] = "Your University's name is: " + drS.GetValue(5).ToString();
               array[4] = "Your Department's name is: " + drS.GetValue(6).ToString();
               Console.WriteLine("Your ID is: " + drS.GetValue(0).ToString());
               Console.WriteLine("Your name is: " + drS.GetValue(1).ToString() + " " + drS.GetValue(2).ToString() + " " + drS.GetValue(3).ToString());
               Console.WriteLine("Your Colloge's name is: " + drS.GetValue(4).ToString());
               Console.WriteLine("Your University's name is: " + drS.GetValue(5).ToString());
               Console.WriteLine("Your Department's name is: " + drS.GetValue(6).ToString());
               con.Close();
            }
            catch (Exception x)
            {
               Console.WriteLine(x.Message);
            }
         }
      }
      public static void List()
      {
         Console.BackgroundColor = ConsoleColor.Black;
         Console.Clear();
         Console.ForegroundColor = ConsoleColor.Red;
         Design.Line();
         Design.Line();
         Console.SetCursorPosition(47, 3);
         Console.WriteLine("Welcome To Library System");
         Console.SetCursorPosition(0, 5);
         Design.Line();
         Design.Line();
         Console.SetCursorPosition(45, 10);
         Console.ForegroundColor = ConsoleColor.DarkRed;
         Console.WriteLine("Enter Number from  1 to 4: ");
         Console.ForegroundColor = ConsoleColor.DarkBlue;
         Console.SetCursorPosition(45, 11);
         Console.WriteLine("1- Read the Book.");
         Console.ForegroundColor = ConsoleColor.DarkMagenta;
         Console.SetCursorPosition(45, 12);
         Console.WriteLine("2- Borrow the book.");
         Console.ForegroundColor = ConsoleColor.DarkYellow;
         Console.SetCursorPosition(45, 13);
         Console.WriteLine("3- Return the book.");
         Console.ForegroundColor = ConsoleColor.DarkGreen;
         Console.SetCursorPosition(45, 14);
         Console.WriteLine("4- Exit from the System.");
         Console.ForegroundColor = ConsoleColor.Gray;
         Console.SetCursorPosition(45, 17);
         Console.Write("Enter the number:");
      l4:
         try
         {
            number = int.Parse(Console.ReadLine());
         }
         catch
         {
            Console.Write("Enter the number: ((1 or 2 or 3 or 4)): ");
            goto l4;
         }

         switch (number)
         {
            case 1:
               Design.Lines2red();
               Read();
               break;
            case 2:
               Design.Lines2red();
               Borrow();
               break;
            case 3:
               Design.Lines2red();
               Return();
               break;
            case 4:
               Design.Lines2red();
               Design.exit();
               break;
            default:
               Console.Write("Enter Just number: ((1 or 2 or 3 or 4)): ");
               goto l4;
         }
      }
      public static void Read()
      {
         Design.Welcome2();
         Console.Write("How many hour you want to read this book:");
      l7:
         try
         {
            hour = int.Parse(Console.ReadLine());
            if (hour > 12)
            {
               Console.Write("Enter number of hours less than 12 hours: ");
               goto l7;
            }
         }
         catch
         {
            Console.Write("Enter the ((number)) of hours: ");
            goto l7;
         }


         Console.WriteLine(); Console.WriteLine();
         Design.Line();
         Console.WriteLine();
         studentInformation();
         array[5] = "The book's situation is: Read for " + hour + " hours. ";
         Console.WriteLine("The book's situation is: Read for {0} hours. ", hour);
         bookInformation();
         Design.Lines2();
         Design.clear();
         Design.exit();
      }
      public static void Borrow()
      {
         //Collection With the database of book
         {
            try
            {
               SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\السباعي\Desktop\Library System\Library System\Library System\Books.mdf;Integrated Security=True");
               con.Open();
               Design.Welcome2();
               SqlCommand readborrow = new SqlCommand("select * from books where number='" + bookId + "'", con);
               SqlDataReader read = readborrow.ExecuteReader();
               read.Read();
               if (read.GetValue(4).ToString() != "0")
                  {
                     array[5] = "Sorry <-_-> You can't borrow this book!";
                     Console.WriteLine("Sorry <-_-> You can't borrow this book!");
                     con.Close();
                     Design.Lines2();
                     Design.clear();
                     book();
                  }
               else
                  {
                     Console.WriteLine("\nNote: ");
                     Console.WriteLine("You can borrow the book for 3 days");
                     Console.Write("How many days you want to borrow the book:");
                     l8:
                     try
                        {

                           days = int.Parse(Console.ReadLine());
                           if (days != 1 && days != 2 && days != 3)
                              {
                                 Console.Write("Enter number of days <<1 or 2 or 3>>: ");
                                 goto l8;
                              }

                        }
                     catch
                        {
                           Console.Write("Enter the ((number)) of days: ");
                           goto l8;
                        }
                     con.Close();
                     con.Open();
                     SqlCommand readDays = new SqlCommand("update books set borrow= '" + days + "'where number= '" + bookId + "'", con);
                     readDays.ExecuteNonQuery();               
                     SqlCommand readDept = new SqlCommand("update books set tokenFrom= '" + dept + "'where number= '" + bookId + "'", con);
                     readDept.ExecuteNonQuery();
                     SqlCommand readID = new SqlCommand("update books set studentID= '" + Windows.id + "'where number= '" + bookId + "'", con);
                     readID.ExecuteNonQuery();
                     Console.WriteLine();
                     Design.Line();
                     Console.WriteLine();
                     studentInformation();
                     thatday = today.AddDays(days);
                     if (days == 1)
                      {
                         array[5] = "The book's situation is: Borrow for " + days + " day from " + today.ToString("d/M/yyyy") + " to " + thatday.ToString("d/M/yyyy") + ". ";
                         Console.WriteLine("The book's situation is: Borrow for {0} day from {1} to {2}. ", days, today.ToString("d/M/yyyy"), thatday.ToString("d/M/yyyy"));
                      }
                   else
                     {
                        array[5] = "The book's situation is: Borrow for " + days + " days from " + today.ToString("d/M/yyyy") + " to " + thatday.ToString("d/M/yyyy") + ". ";
                        Console.WriteLine("The book's situation is: Borrow for {0} days from {1} to {2}. ", days, today.ToString("d/M/yyyy"), thatday.ToString("d/M/yyyy"));
                     }
                   SqlCommand setDate = new SqlCommand("update books set Returning= '" + thatday.ToShortDateString() + "'where number= '" + bookId + "'", con);
                   setDate.ExecuteNonQuery();
                   bookInformation();
                   Console.WriteLine();
                   Design.Line();
                   Console.WriteLine("\nNote: ");
                   Console.WriteLine("If you return the book after more than three days you'll pay 3$ for each day.");
                   Design.Lines2();
                   Design.clear();
                   Design.exit();
                   con.Close();
               }
            }
            catch (Exception x)
            {
               Console.WriteLine(x.Message);
            }
        }      
      }
      public static void Return()
      {
         //Collection With the database of book
         {
            try
            {
               SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\السباعي\Desktop\Library System\Library System\Library System\Books.mdf;Integrated Security=True");
               con.Open();
               Design.Welcome2();
               Console.WriteLine();
               SqlCommand readB = new SqlCommand("select * from books where number= '" + bookId + "'", con);
               SqlDataReader drB = readB.ExecuteReader();
               drB.Read();
               if ( drB.GetValue(10).ToString() != Convert.ToString( Windows.id))
                  {
                     array[5] = "You didn't borrow this book Before!";
                     Console.WriteLine("You didn't borrow this book Before!");
                     Design.Lines2();
                     Design.clear();
                     book();
                  }
               else
                  {
                     studentInformation();
                     thatday = Convert.ToDateTime(drB.GetValue(5));
                     Dept = Convert.ToInt32(drB.GetValue(9));
                     st = thatday - today;
                     days = st.Days - 1;
                     if (dept == Dept)
                     {
                        if (days > 3)
                        {
                           array[5] = "The book's situation is: Return after " + days + " days of the metaphor from " + today.ToShortDateString() + " to " + Convert.ToDateTime(drB.GetValue(5)).ToShortDateString() + ". ";
                           Console.WriteLine("The book's situation is: Return after {0} days of the metaphor from {1} to {2}. ", drB.GetValue(4).ToString(), today.ToShortDateString(), Convert.ToDateTime(drB.GetValue(5)).ToShortDateString());
                           for (int i = days - 3; i > 0; i--)
                              money += 3;
                           array[10] = "The money that you must to pay is " + money + "$.";
                           Console.WriteLine("The money that you must to pay is {0}$.", money);
                        }
                        else
                        {
                           array[5] = "Thanks for returning our book ^_^";
                           Console.WriteLine("Thanks for returning our book ^_^");
                        }
                        bookInformation();
                        con.Close();
                        con.Open();
                        SqlCommand NullDays = new SqlCommand("update books set borrow = DEFAULT where number= '" + bookId + "'", con);
                        NullDays.ExecuteNonQuery();
                        SqlCommand NullDate = new SqlCommand("update books set Returning = DEFAULT where number= '" + bookId + "'", con);
                        NullDate.ExecuteNonQuery();
                        SqlCommand NullDepartment = new SqlCommand("update books set tokenFrom = DEFAULT where number= '" + bookId + "'", con);
                        NullDepartment.ExecuteNonQuery();
                        SqlCommand NullStudentID = new SqlCommand("update books set studentID = DEFAULT where number= '" + bookId + "'", con);
                        NullStudentID.ExecuteNonQuery();
                        Design.Lines2();
                        Design.clear();
                        Design.exit();
                     }
                     else
                     {
                        array[5] = "<'_'> You Don't borrow this book from this depatment. <'_'>";
                        Console.WriteLine("<'_'> You Don't borrow this book from this depatment. <'_'>");
                     }
                  }
               con.Close();
            }
            catch (Exception x)
            {
               Console.WriteLine(x.Message);
            }
         }
      }
   }
   class Program
   {
      static void Main()
      {
         Console.Title = "Library System.";
         Windows.page1();
         Windows.page2();
         Windows.file();
         Console.ReadKey();
      }
   }
}