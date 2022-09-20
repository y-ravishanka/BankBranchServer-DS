namespace BankBranchServer1.Data
{
    public class Customer
    {
		public int id { get; set; }
		public string nic { get; set; }
		public string fname { get; set; }
		public string lname { get; set; }
		public string dob { get; set; }
		public string saddress { get; set; }
		public string city { get; set; }
		public string distric { get; set; }
		public string province { get; set; }
		public string zip { get; set; }
		public string citizenship { get; set; }
		public string currency { get; set; }
		public string phone1 { get; set; }
		public string phone2 { get; set; }
		public string email { get; set; }
		public int branchid { get; set; }
	}
}
