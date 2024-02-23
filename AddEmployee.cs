using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace AddressBook_W_ADO
{
    public class AddEmployee
    {
        public string Connection = "Data Source=DESKTOP-G942POH; Initial Catalog=AddressBook; Integrated Security=True";
        SqlConnection conect = null;
        public void AddDetails()
        {
            try
            {
                string FirstName = "";
                string MiddleName = "";
                string LastName = "";
                string Email = "";
                string city = "";
                string zip = "";
                string state = "";
                string mob = "";
                bool invalid = true;
                int i = 1;
                while (i <= 8)
                {
                    switch (i)
                    {
                        case 1:
                            while (invalid)
                            {

                                Console.WriteLine("Enter a FirstName");
                                FirstName = Console.ReadLine();
                                invalid = !Regex.IsMatch(FirstName, "^[A-Z][a-z]{2,}$");
                                if (invalid)
                                {
                                    Console.WriteLine("Enter a First character Capital");
                                }
                            }
                            i++;
                            invalid = true;
                            break;
                        case 2:
                            while (invalid)
                            {
                                Console.WriteLine("Enter a MiddleName");
                                MiddleName = Console.ReadLine();
                                invalid = !Regex.IsMatch(MiddleName, "^[A-Z][a-z]{2,}$");
                                if (invalid)
                                {
                                    Console.WriteLine("Enter a First Letter capital");
                                }
                            }
                            i++;
                            invalid = true;
                            break;
                        case 3:
                            while (invalid)
                            {
                                Console.WriteLine("Enter a LastName");
                                LastName = Console.ReadLine();
                                invalid = !Regex.IsMatch(LastName, "^[A-Z][a-z]{2,}$");
                                if (invalid)
                                {
                                    Console.WriteLine("Enter a First Letter Capital");
                                }
                            }
                            i++;
                            invalid = true;
                            break;
                        case 4:
                            while (invalid)
                            {
                                Console.WriteLine("Enter a Email");
                                Email = Console.ReadLine();
                                invalid = !Regex.IsMatch(Email, "^[A-Za-z0-9]{1,}[@][A-Za-z0-9.]{2,}[a-z]{2,3}$");
                                if (invalid)
                                {
                                    Console.WriteLine("Enter a Email in Email Format only");
                                }
                            }
                            i++;
                            invalid = true;
                            break;
                        case 5:
                            while (invalid)
                            {
                                Console.WriteLine("Enter a city");
                                city = Console.ReadLine();
                                invalid = !Regex.IsMatch(city, "^[A-Z][a-z]{2,}$");
                                if (invalid)
                                {
                                    Console.WriteLine("Enter a FIrst letter is Capital letter");
                                }
                            }
                            i++;
                            invalid = true;
                            break;

                        case 6:
                            while (invalid)
                            {
                                Console.WriteLine("Enter a zip");
                                zip = Console.ReadLine();
                                invalid = !Regex.IsMatch(zip, "^[1-9][0-9]{5,}$");
                                if (invalid)
                                {
                                    Console.WriteLine("Please Enter a First letter Capital");
                                }
                            }
                            i++;
                            invalid = true;
                            break;

                        case 7:
                            while (invalid)
                            {
                                Console.WriteLine("Enter a state");
                                state = Console.ReadLine();
                                invalid = !Regex.IsMatch(state, "^[A-Z][a-z]{2,}$");
                                if (invalid)
                                {
                                    Console.WriteLine("Start no 0 not allowed and please Enter a 6 digits only");
                                }
                            }
                            i++;
                            invalid = true; break;

                        case 8:
                            while (invalid)
                            {
                                Console.WriteLine("Enter a contact");
                                mob = (Console.ReadLine());
                                invalid = !Regex.IsMatch(mob, "^[6-9][0-9]{9}$");
                                if (invalid)
                                {
                                    Console.WriteLine("please enter a Start digit belong 6 to 9 and total digits only 10'a allowed");
                                }
                            }
                            i++;
                            break;
                    }
                }
                using (conect = new SqlConnection(Connection))
                {
                    conect.Open();
                    string query = $"insert into EmployeeDetail values('{FirstName}','{MiddleName}','{LastName}','{Email}','{city}','{zip}','{state}',{mob})";
                    SqlCommand cmd = new SqlCommand(query, conect);

                    int p = cmd.ExecuteNonQuery();

                    if (p > 0)
                    {
                        Console.WriteLine("Employee inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to insert employee.");
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ShowDetail()
        {
            using (conect = new SqlConnection(Connection))
            {
                string query = $"select * from EmployeeDetail";
                SqlCommand cmd = new SqlCommand(query, conect);
                conect.Open();
                SqlDataReader obj = cmd.ExecuteReader();

                while (obj.Read())
                {
                    Console.WriteLine($"FirstName : {obj["FName"]} MiddleName:{obj["MName"]} LastName:{obj["LName"]} city:{obj["city"]} state:{obj["state"]} Email:{obj["Email"]} zip:{obj["zip"]} contact:{obj["contact"]}");
                }
            }
        }
        public string Update(string input1, string input2)
        {
            if (input1 == "")
            {
                return input2;
            }
            return input1;
        }
        public void EditContact()
        {
            using (conect = new SqlConnection(Connection))
            {
                try
                {
                    Console.WriteLine("Enter your Contact details: ");
                    string contact = Console.ReadLine();
                    string query1 = $"SELECT * FROM EmployeeDetail WHERE contact  = '{contact}' ";

                    SqlCommand cmd = new SqlCommand(query1, conect);
                    conect.Open();

                    SqlDataReader obj = cmd.ExecuteReader();
                    obj.Read();
                    Console.WriteLine($"oldFirstName : {obj["FName"]}");
                    Console.WriteLine($"Old_MiddleName :{obj["MName"]}");
                    Console.WriteLine($"Old_LastName :{obj["LName"]}");
                    Console.WriteLine($"old_city : {obj["city"]}");
                    Console.WriteLine($"old_state : {obj["state"]}");
                    Console.WriteLine($"old_Email : {obj["Email"]}");
                    Console.WriteLine($"old_zip : {obj["zip"]}");
                    Console.WriteLine($"old_contact : {obj["contact"]}");
                    Console.WriteLine("Leave blank if no changes");

                    Console.WriteLine("Enter new FirstName : ");
                    string FirstName = Update(Console.ReadLine(), Convert.ToString(obj["FName"]));
                    Console.WriteLine("Enter a MiddleName");
                    string MiddleName = Update(Console.ReadLine(), Convert.ToString(obj["MName"]));
                    Console.WriteLine("Enter a Last Name");
                    string LastName = Update(Console.ReadLine(), Convert.ToString(obj["LName"]));
                    Console.WriteLine("Enter a CIty");
                    string city = Update(Console.ReadLine(), Convert.ToString(obj["city"]));
                    Console.WriteLine("Enter a state");
                    string state = Update(Console.ReadLine(), Convert.ToString(obj["state"]));
                    Console.WriteLine("Enter a Email");
                    string Email = Update(Console.ReadLine(), Convert.ToString(obj["Email"]));
                    Console.WriteLine("Enter a zip");
                    string zip = Update(Console.ReadLine(), Convert.ToString(obj["zip"]));
                    Console.WriteLine("Enter a contact");
                    string newcontact = Update(Console.ReadLine(), Convert.ToString(obj["Contact"]));

                    conect.Close();
                    Console.WriteLine("Entering");
                    string query2 = $"UPDATE EmployeeDetail SET FName = '{FirstName}', MName='{MiddleName}',LName='{LastName}',City = '{city}' , State = '{state}', Email = '{Email}', Zip_code = '{zip}', Contact = '{newcontact}' where Contact = '{contact}' ";
                    Console.WriteLine("Exit");

                    conect.Open();
                    SqlCommand cmd1 = new SqlCommand(query2, conect);
                    int a = cmd1.ExecuteNonQuery();

                    if (a > 0)
                    {

                        Console.WriteLine("Details Updated Succesfully");
                    }
                    else
                    {
                        Console.WriteLine("Details Updation Failed!!");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Delete()
        {
            try
            {
                using (conect = new SqlConnection(Connection))
                {

                    Console.WriteLine("Enter a Contact To delete");
                    string contact1 = Console.ReadLine();
                    conect.Open();
                    string query = $"Delete from EmployeeDetail where contact='{contact1}'";
                    SqlCommand cmd = new SqlCommand(query, conect);
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Console.WriteLine("Record Deleted Succesfully");
                    }
                    else
                    {
                        Console.WriteLine("Error Deleting the Record");

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void FindDetailCityWise()
        {
            {
                try
                {
                    conect = new SqlConnection(Connection);

                    Console.WriteLine("Enter Your city");
                    string input = Console.ReadLine();
                    string query1 = $"SELECT * FROM EmployeeDetail WHERE city='{input}'";
                    conect.Open();
                    SqlCommand cmd = new SqlCommand(query1, conect);
                    SqlDataReader obj = cmd.ExecuteReader();
                    while (obj.Read())
                    {
                        Console.WriteLine($"FirstName : {obj["FName"]} MName:{obj["MName"]} LastName:{obj["LName"]} city:{obj["city"]} state:{obj["state"]} Email:{obj["Email"]} zip:{obj["zip"]} contact:{obj["contact"]}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public void FindDetailStateWies()
        {
            {
                try
                {
                    conect = new SqlConnection(Connection);
                    Console.WriteLine("Enter Your code");
                    string input = Console.ReadLine();
                    string query1 = $"SELECT * FROM EmployeeDetail WHERE City='{input}'";
                    conect.Open();
                    SqlCommand cmd = new SqlCommand(query1, conect);
                    SqlDataReader obj = cmd.ExecuteReader();
                    while (obj.Read())
                    {
                        Console.WriteLine($"FirstName : {obj["FirstName"]} MiddleName:{obj["MiddleName"]} LastName:{obj["LastName"]} city:{obj["city"]} state:{obj["state"]} Email:{obj["EMail"]} zip:{obj["zip"]} contact:{obj["contact"]}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}








