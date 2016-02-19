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
	public class PhoneListAdapter: BaseAdapter<PhoneElement> {
		List<PhoneElement> items;
		Activity context;
		public PhoneListAdapter(Activity context, List<PhoneElement> items)
			: base()
		{
			this.context = context;
			this.items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override PhoneElement this[int position]
		{
			get { return items[position]; }
		}
		public override int Count
		{
			get { return items.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];

			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.RowView, null);
			view.FindViewById<TextView>(Resource.Id.Text1).Text = item.ContactName;
			view.FindViewById<TextView>(Resource.Id.Text2).Text = item.ContactNumber;
			view.FindViewById<CheckBox>(Resource.Id.checkBox1).Checked = item.Checked;
			return view;
		}
	}
}