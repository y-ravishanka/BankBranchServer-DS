using Microsoft.Data;
using Microsoft.Data.SqlClient;
using BankBranchServer1.Data;

namespace BankBranchServer1.Model
{
    internal class Database
    {
        private readonly SqlConnection con = new(@"Data Source=DESKTOP-1G3ODQ5;Initial Catalog=bankbranch;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        private int i = 0, j = 0;
        private string? que = null;
        private Calculations cal = new();

        internal bool testCon()
        {
            bool test = false;
            que = "select 1";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }

        #region Login Section
        internal bool CheckUser(string nic)
        {
            bool t = false;
            int tmp = 0;
            que = "select count(id) from login_details where nic = '" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        tmp = dr.GetInt32(0);
                    }

                }
                dr.Close();
                if(tmp == 0)
                { t = false; }
                else
                { t = true; }
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        internal ClientLogin GetLoginDetails(string nic)
        {
            ClientLogin log = new();
            que = "select id,nic,password,posision,active from login_details where nic = '" + nic + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log.id = dr.GetInt32(0);
                        log.nic = dr.GetString(1);
                        log.password = dr.GetString(2);
                        log.posision = dr.GetString(3);
                        log.active = dr.GetString(4);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return log;
        }
        #endregion

        #region FullStatus Section
        internal FullStatus GetFullStatus_ofDate(string date)
        {
            FullStatus status = new();
            que = "select date,deposits,damount,withdraws,wamount,balance,newaccounts from fullstatus where date = '" + date + "'";
            SqlCommand cmd = new(que,con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        status.date = dr.GetString(0);
                        status.deposits = dr.GetInt32(1);
                        status.damount = dr.GetFloat(2);
                        status.withdraws = dr.GetInt32(3);
                        status.wamount = dr.GetFloat(4);
                        status.balance = dr.GetFloat(5);
                        status.newaccounts = dr.GetInt32(6);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return status;
        }

        internal List<FullStatus> GetFullStatus()
        {
            List<FullStatus> list = new();
            FullStatus status;
            que = "select date,deposits,damount,withdraws,wamount,balance,newaccounts from fullstatus";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        status = new FullStatus
                        {
                            date = dr.GetString(0),
                            deposits = dr.GetInt32(1),
                            damount = dr.GetFloat(2),
                            withdraws = dr.GetInt32(3),
                            wamount = dr.GetFloat(4),
                            balance = dr.GetFloat(5),
                            newaccounts = dr.GetInt32(6)
                        };
                        list.Add(status);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }
        #endregion

        #region UserStatus Section
        internal UserStatus GetUserStatus_a(string date, string nic)
        {
            UserStatus status = new();
            que = "select date,nic,deposits,damount,withdraws,wamount,balance,newaccounts from userstatus where (date = '" + date + "') and (nic = '" + nic + "')";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        status.date = dr.GetString(0);
                        status.nic = dr.GetString(1);
                        status.deposits = dr.GetInt32(2);
                        status.damount = dr.GetFloat(3);
                        status.withdraws = dr.GetInt32(4);
                        status.wamount = dr.GetFloat(5);
                        status.balance = dr.GetFloat(6);
                        status.newaccounts = dr.GetInt32(7);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return status;
        }

        internal List<UserStatus> GetUserStatus(int id, string value)
        {
            List<UserStatus> list = new();
            UserStatus status;
            if(id == 0)
            {
                que = "select date,nic,deposits,damount,withdraws,wamount,balance,newaccounts from userstatus where date = '" + value + "'";
            }
            else if(id == 1)
            {
                que = "select date,nic,deposits,damount,withdraws,wamount,balance,newaccounts from userstatus where nic = '" + value + "'";
            }
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        status = new UserStatus
                        {
                            date = dr.GetString(0),
                            nic = dr.GetString(1),
                            deposits = dr.GetInt32(2),
                            damount = dr.GetFloat(3),
                            withdraws = dr.GetInt32(4),
                            wamount = dr.GetFloat(5),
                            balance = dr.GetFloat(6),
                            newaccounts = dr.GetInt32(7)
                        };
                        list.Add(status);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }
        #endregion

        #region Account Section
        internal int GetLastAccountNum()
        {
            int t = 0;
            que = "select top 1 number from account order by number desc";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        t = dr.GetInt32(0);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            string s1 = t.ToString();
            string s2 = GetBranchID().ToString();
            string s3 = s1.Replace(s2, "");
            t = Convert.ToInt32(s3);
            return t;
        }

        internal void CreateAcoount(Account ac)
        {
            que = "insert into account(number,nic,balance,branchid,createby) values(" + ac.number + "," + ac.nic + "," + ac.balance + "," + ac.branchid + "," + ac.createby + ")";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
        }

        internal int UpdateAccount(Account ac)
        {
            int tmp = 0;
            que = "update account set balanace = " + ac.balance + "where nic = '" + ac.nic + "' and number = " + ac.number;
            SqlCommand cmd = new(que,con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return tmp;
        }

        internal Account GetAccount(int id)
        {
            Account act = new();
            que = "select number,nic,balance,active,branchid,createby from account where number = " + id;
            SqlCommand cmd = new(que,con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        act.number = dr.GetInt32(0);
                        act.nic = dr.GetString(1);
                        act.balance = dr.GetFloat(2);
                        act.active = dr.GetString(3);
                        act.branchid = dr.GetInt32(4);
                        act.createby = dr.GetInt32(5);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return act;
        }

        internal List<Account> GetAccounts_byAll(AccountNevData nev)
        {
            List<Account> list = new();
            Account act;
            switch(nev.nev)
            {
                case 0:
                    que = "select number,nic,balance,active,branchid,createby from account";
                    break;
                case 1:
                    que = "select number,nic,balance,active,branchid,createby from account where number = '" + nev.nic + "'";
                    break;
                case 2:
                    que = "select number,nic,balance,active,branchid,createby from account where active = '" + nev.active + "'";
                    break;
                case 3:
                    que = "select number,nic,balance,active,branchid,createby from account where branchid = " + nev.branch;
                    break;
                case 4:
                    que = "select number,nic,balance,active,branchid,createby from account where branchid = " + nev.createby;
                    break;
            }
            
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        act = new Account
                        {
                            number = dr.GetInt32(0),
                            nic = dr.GetString(1),
                            balance = dr.GetFloat(2),
                            active = dr.GetString(3),
                            branchid = dr.GetInt32(4),
                            createby = dr.GetInt32(5)
                        };
                        list.Add(act);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }
        #endregion

        #region ActivityLog Section
        internal void SetActivityLogin(int nic)
        {
            //que = "exec insert_logintime @id = (select id from login_details where nic = '" + nic + "')";
            que = "exec insert_logintime @id =" + nic;
            SqlCommand cmd = new(que,con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
        }

        internal void SetActivityLogout(int nic)
        {
            //que = "exec insert_logouttime @id = (select id from login_details where nic = '" + nic + "')";
            que = "exec insert_logouttime @id =" + nic;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
        }

        internal List<ActivityLog> GetActivityLog(int nev, int id)
        {
            List<ActivityLog> list = new();
            ActivityLog log;
            if(nev == 0)
            {
                que = "select id,logintime,logouttime from activitylog";
            }
            else if(nev == 1)
            {
                que = "select id,logintime,logouttime from activitylog where id = " + id;
            }
            SqlCommand cmd = new(que,con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        log = new ActivityLog
                        {
                            #region comment - unnesessary code
                            /*
                            log.id = dr["id"].ToString();
                            log.login = dr["logintime"].ToString();
                            log.logout = dr["logouttime"].ToString();
                            */
                            #endregion
                            id = dr.GetInt32(0),
                            login = dr.GetSqlDateTime(1).ToString(),
                            logout = dr.GetSqlDateTime(2).ToString()
                        };
                        list.Add(log);
                    }
                }
                dr.Close();
            }
            catch(Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        internal int getLogCount()
        {
            int count = 0;
            que = "select count(id) from activitylog";
            SqlCommand cmd = new(que,con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        count = dr.GetInt32(0);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                count = 0;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return count;
        }
        #endregion

        #region Customer Section
        internal List<Customer> GetCustomers_all(int id, string? value)
        {
            List<Customer> list = new();
            Customer cus;
            switch (id)
            {
                case 0:
                    que = "select nic,fname,lname,dob,saddress,city,distric,province,zip,citizenship,currency,phone1,phone2,email,branchid from customer";
                    break;
                case 1:
                    que = "select nic,fname,lname,dob,saddress,city,distric,province,zip,citizenship,currency,phone1,phone2,email,branchid from customer where city = '" + value + "'";
                    break;
                case 2:
                    que = "select nic,fname,lname,dob,saddress,city,distric,province,zip,citizenship,currency,phone1,phone2,email,branchid from customer where distric = '" + value + "'";
                    break;
                case 3:
                    que = "select nic,fname,lname,dob,saddress,city,distric,province,zip,citizenship,currency,phone1,phone2,email,branchid from customer where province = '" + value + "'";
                    break;
                case 4:
                    que = "select nic,fname,lname,dob,saddress,city,distric,province,zip,citizenship,currency,phone1,phone2,email,branchid from customer where zip = '" + value + "'";
                    break;
                case 5:
                    que = "select nic,fname,lname,dob,saddress,city,distric,province,zip,citizenship,currency,phone1,phone2,email,branchid from customer where citizenship = '" + value + "'";
                    break;
                case 6:
                    que = "select nic,fname,lname,dob,saddress,city,distric,province,zip,citizenship,currency,phone1,phone2,email,branchid from customer where currency = '" + value + "'";
                    break;
                case 7:
                    que = "select nic,fname,lname,dob,saddress,city,distric,province,zip,citizenship,currency,phone1,phone2,email,branchid from customer where branchid = '" + value + "'";
                    break;
            }
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        cus = new Customer
                        {
                            id = dr.GetInt32(0),
                            nic = dr.GetString(1),
                            fname = dr.GetString(2),
                            lname = dr.GetString(3),
                            dob = dr.GetString(4),
                            saddress = dr.GetString(5),
                            city = dr.GetString(6),
                            distric = dr.GetString(7),
                            province = dr.GetString(8),
                            zip = dr.GetString(9),
                            citizenship = dr.GetString(10),
                            currency = dr.GetString(11),
                            phone1 = dr.GetString(12),
                            phone2 = dr.GetString(13),
                            email = dr.GetString(14),
                            branchid = dr.GetInt32(15)
                        };
                        list.Add(cus);
                    }
                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        internal Customer GetCustomer(int id, string value)
        {
            Customer cus = new();
            if(id == 0)
            {
                que = "select nic,fname,lname,dob,saddress,city,distric,province,zip,citizenship,currency,phone1,phone2,email,branchid from customer where nic = '" + value + "'";
            }
            else if(id == 1)
            {
                que = "select nic,fname,lname,dob,saddress,city,distric,province,zip,citizenship,currency,phone1,phone2,email,branchid from customer where id = '" + value + "'";
            }
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        cus = new Customer
                        {
                            id = dr.GetInt32(0),
                            nic = dr.GetString(1),
                            fname = dr.GetString(2),
                            lname = dr.GetString(3),
                            dob = dr.GetString(4),
                            saddress = dr.GetString(5),
                            city = dr.GetString(6),
                            distric = dr.GetString(7),
                            province = dr.GetString(8),
                            zip = dr.GetString(9),
                            citizenship = dr.GetString(10),
                            currency = dr.GetString(11),
                            phone1 = dr.GetString(12),
                            phone2 = dr.GetString(13),
                            email = dr.GetString(14),
                            branchid = dr.GetInt32(15)
                        };
                    }
                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return cus;
        }
        #endregion

        #region Transaction Section
        internal List<Transaction> GetTransactions_all(int id, string? value)
        {
            List<Transaction> list = new();
            Transaction t;
            switch (id)
            {
                case 0:
                    que = "select id,date,type,account,amount,depositor from transactions";
                    break;
                case 1:
                    que = "select id,date,type,account,amount,depositor from transactions where date = '" + value + "'";
                    break;
                case 2:
                    que = "select id,date,type,account,amount,depositor from transactions where type = '" + value + "'";
                    break;
                case 3:
                    que = "select id,date,type,account,amount,depositor from transactions where account = '" + value + "'";
                    break;
                case 4:
                    que = "select id,date,type,account,amount,depositor from transactions where depositor = '" + value + "'";
                    break;
            }
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        t = new Transaction
                        {
                            id = dr.GetString(0),
                            date = dr.GetString(1),
                            type = dr.GetString(2),
                            account = dr.GetInt32(3),
                            amount = dr.GetFloat(4),
                            depositor = dr.GetString(5)
                        };
                        list.Add(t);
                    }
                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        internal Transaction GetTransaction(string id)
        {
            Transaction t = new();
            que = "select id,date,type,account,amount,depositor from transactions where id = '" + id + "'";
            SqlCommand cmd = new(que,con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        t = new Transaction
                        {
                            id = dr.GetString(0),
                            date = dr.GetString(1),
                            type = dr.GetString(2),
                            account = dr.GetInt32(3),
                            amount = dr.GetFloat(4),
                            depositor = dr.GetString(5)
                        };
                    }
                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }
        #endregion

        #region System_Data Section
        internal int GetBranchID()
        {
            int id = 0;
            que = "select id from branchdata";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        id = dr.GetInt32(0);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return id;
        }
        #endregion
    }
}
