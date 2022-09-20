namespace BankBranchServer1.Data
{
    public class Account
    {
        public int number { get; set; }
        public string? nic { get; set; }
        public float balance { get; set; }
	    public string? active { get; set; }
	    public int branchid { get; set; }
        public int createby { get; set; }
    }
}
