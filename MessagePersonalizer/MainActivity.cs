using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Provider;
using Android.Views;
using Android.Content;
using System.Linq;

namespace MessagePersonalizer
{
	[Activity (Label = "Choose Contacts", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		List<PhoneElement> contactList;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Main);
			var uri = ContactsContract.CommonDataKinds.Phone.ContentUri;
			string[] projection = { ContactsContract.Contacts.InterfaceConsts.Id,ContactsContract.Contacts.InterfaceConsts.DisplayName, ContactsContract.CommonDataKinds.Phone.Number};
			var cursor = ManagedQuery (uri, projection, null, null, null);
			contactList=new List<PhoneElement> (); 
			if (cursor.MoveToFirst ()) {
				do {
					PhoneElement item= new PhoneElement(cursor.GetString (cursor.GetColumnIndex (projection [0])),
														cursor.GetString (cursor.GetColumnIndex (projection [1])),
														cursor.GetString (cursor.GetColumnIndex (projection [2])));
					contactList.Add(item);
				}  while (cursor.MoveToNext());
			}

			ListView listView = FindViewById<ListView>(Resource.Id.PhoneNumbersListView);
			listView.Adapter = new PhoneListAdapter (this, contactList);
			listView.ItemClick += OnListItemClick;

		}
		protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{

			var currentlistView = sender as ListView;
			IParcelable state =  currentlistView.OnSaveInstanceState ();
			PhoneElement elem = contactList[e.Position];
			SetSelected (elem);
			ListView listView = FindViewById<ListView>(Resource.Id.PhoneNumbersListView);
			listView.Adapter = new PhoneListAdapter(this, contactList);
			listView.OnRestoreInstanceState(state);
		}
		private void SetSelected(PhoneElement elem)
		{
			if (elem.Checked==false)
				elem.Checked=true;
			else 
			{
				elem.Checked=false;
			}
		}
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			if (item.ItemId == 2131099654) 
			{
				Global.SelectedContacts = contactList.Where(x => x.Checked == true).ToList();
				Intent intent= new Intent(this,typeof(MessageActivity));
				StartActivityForResult(intent, 0);
			}
			return base.OnOptionsItemSelected(item);
		}
		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu, menu);
			return base.OnPrepareOptionsMenu(menu);
		}

	}
}


