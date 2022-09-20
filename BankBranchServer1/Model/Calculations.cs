namespace BankBranchServer1.Model
{
    public class Calculations
    {
        internal string GetDate()
        {
            return DateTime.Now.ToString("yyyy/MM/dd");
        }

        internal string GetDateCanInt()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }

        internal bool CheckNIC(string nic)
        {
            bool t = false;
            if(nic == null)
            { t=false; }
            else if((nic.Length != 10) || (nic.Length != 12) )
            { t=false; }
            else
            {
                if(nic.Length == 12)
                {
                    try
                    {
                        int n = Convert.ToInt32(nic);
                        t = true;
                    }
                    catch (Exception e)
                    { t= false; }
                }
                else if(nic.Length == 10)
                {
                    char[] ca = nic.ToCharArray();
                    if((ca[nic.Length - 1] == 'v') || (ca[nic.Length - 1] == 'V'))
                    {
                        char[] caa = new char[9];
                        for(int i=0; i < (ca.Length-1); i++)
                        {
                            caa[i] = ca[i];
                        }
                        string s1 = caa.ToString();
                        try
                        {
                            int n1 = Convert.ToInt32(s1);
                            t = true;
                        }
                        catch (Exception e)
                        { t = false; }
                    }
                    else
                    { t = false; }
                }
            }
            GC.Collect();
            return t;
        }

        internal string MakeTransID(int id, string oid)
        {
            string sid = id.ToString();
            string header = sid + GetDateCanInt();
            string onum = oid.Replace(header, "");
            return onum;
        }

    }
}
