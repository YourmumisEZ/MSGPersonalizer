using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MessagePersonalizer
{
	[Activity (Label = "Write Message")]			
	public class MessageActivity : Activity
	{
		List<PhoneElement> selectedContacts;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Message);
			selectedContacts = Global.SelectedContacts;
			EditText editText = FindViewById<EditText>(Resource.Id.editText1);
			TextView messagesTextView = FindViewById<TextView>(Resource.Id.textView2);
			editText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				
				int count= e.Text.Count();
				decimal nrOfMessages=count/160;
				decimal decimalPointValue=nrOfMessages - Math.Floor(nrOfMessages) ;
				if(decimalPointValue==0)
				{
					messagesTextView.Text=string.Format("Messages: {0}",nrOfMessages);
				}
				else 
				{
					messagesTextView.Text=string.Format("Messages: {0}",nrOfMessages+2);
				}
				editText.SetSelection (editText.Text.Count ());
			};
			Button placeholderBtn = FindViewById<Button> (Resource.Id.placeholderBtn);
			placeholderBtn.Click += (object sender, EventArgs e) =>
			{
				string currentText=editText.Text;
				editText.Text=string.Format("{0}{1}",currentText,"%@%");
				int count= editText.Text.Count();
				decimal nrOfMessages=count/160;
				decimal decimalPointValue=nrOfMessages - Math.Floor(nrOfMessages) ;
				if(decimalPointValue==0)
				{
					messagesTextView.Text=string.Format("Messages: {0}",nrOfMessages);
				}
				else 
				{
					messagesTextView.Text=string.Format("Messages: {0}",nrOfMessages+2);
				}
			};
			editText.SetSelection (editText.Text.Count ());
		}
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
//			if (item.ItemId == 2131099654) 
//			{
//				Intent intent= new Intent(this,typeof(MessageActivity));
//				StartActivityForResult(intent, 0);
//			}
			return base.OnOptionsItemSelected(item);
		}
		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menuMessage, menu);
			return base.OnPrepareOptionsMenu(menu);
		}
	}
}

