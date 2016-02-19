using System;

namespace MessagePersonalizer
{
	public class PhoneElement
	{	
		public string Id {
			get;
			set;
		}
		public string ContactName {
			get;
			set;
		}
		public string ContactNumber {
			get;
			set;
		}
		public bool Checked {
			get;
			set;
		}
		public PhoneElement (string id,string contactName,string contactNumber)
		{
			Id = id;
			ContactName = contactName;
			ContactNumber = contactNumber;
			Checked = false;
		}
	}
}

